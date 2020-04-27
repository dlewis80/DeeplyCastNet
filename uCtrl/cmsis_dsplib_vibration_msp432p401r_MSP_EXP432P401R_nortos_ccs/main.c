/* DriverLib Includes */
#include <ti/devices/msp432p4xx/driverlib/driverlib.h>

/* Standard Includes */
#include <stdint.h>
#include <stdbool.h>

#include "arm_math.h"

#include "arm_const_structs.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
/*
 /|\
 *                MSP432P401      10k  10k      MSP432P401
 *                   slave         |    |         master
 *             -----------------   |    |   -----------------
 *            |     P1.6/UCB0SDA|<-|----+->|P1.6/UCB0SDA     |
 *            |                 |  |       |                 |
 *            |                 |  |       |                 |
 *            |     P1.7/UCB0SCL|<-+------>|P1.7/UCB0SCL     |
 *            |                 |          |                 |

 /* Timer_A Continuous Mode Configuration Parameter */
const Timer_A_UpModeConfig upModeConfig = {
TIMER_A_CLOCKSOURCE_SMCLK,            // ACLK Clock Source
        TIMER_A_CLOCKSOURCE_DIVIDER_1,       // ACLK/1 = 24Mhz
        240,                                 // 100 kHz sampling
        TIMER_A_TAIE_INTERRUPT_DISABLE,      // Disable Timer ISR
        TIMER_A_CCIE_CCR0_INTERRUPT_DISABLE, // Disable CCR0
        TIMER_A_DO_CLEAR                     // Clear Counter
        };

/* Timer_A Compare Configuration Parameter */
const Timer_A_CompareModeConfig compareConfig = {
TIMER_A_CAPTURECOMPARE_REGISTER_1,          // Use CCR1
        TIMER_A_CAPTURECOMPARE_INTERRUPT_DISABLE,   // Disable CCR interrupt
        TIMER_A_OUTPUTMODE_SET_RESET,               // Toggle output but
        240                                      // 100Khz sampling
        };

//![Simple UART Config]
/* UART Configuration Parameter. These are the configuration parameters to
 * make the eUSCI A UART module to operate with a 2400 baud rate. These
 * values were calculated using the online calculator that TI provides
 * at:
 *http://software-dl.ti.com/msp430/msp430_public_sw/mcu/msp430/MSP430BaudRateConverter/index.html
 */

const eUSCI_UART_ConfigV1 uartConfig = {
EUSCI_A_UART_CLOCKSOURCE_SMCLK,          // SMCLK Clock Source
        625,                                     // BRDIV = 625
        0,                                       // UCxBRF = 0
        0,                                       // UCxBRS = 0
        EUSCI_A_UART_NO_PARITY,                  // No Parity
        EUSCI_A_UART_LSB_FIRST,                  // LSB First
        EUSCI_A_UART_ONE_STOP_BIT,               // One stop bit
        EUSCI_A_UART_MODE,                       // UART mode
        EUSCI_A_UART_OVERSAMPLING_BAUDRATE_GENERATION, // Oversampling last parameter in calculator
        EUSCI_A_UART_8_BIT_LEN                  // 8 bit data length
        };

/* Statics */

static uint_fast16_t ADCresultsBuffer[UINT8_MAX * 2];
static volatile uint8_t resPos;
static volatile uint8_t serialPos;
static int16_t fftOutput[UINT8_MAX * 2];
uint16_t counter;
uint16_t bit_counter;
uint16_t test;
uint32_t smclk;
uint32_t time;
uint32_t indexh;
uint32_t indexl;
uint32_t resulth;
uint32_t resultl;
uint32_t byte_counter;
uint32_t repeat_counter;
uint32_t message_length;
char receive_data;

static volatile bool transmit;
int bin_size = 64;
int digital_gain = 80;
int ENERGYBIN_SIZE = 2;
const int SAMPLING_RATE = 100000;
static char serial_data[UINT8_MAX];
static char message[UINT8_MAX];
char first_digit;
char second_digit;

uint32_t targetFrequency1;
uint32_t targetFrequency2;

/* -----------------------------------------------------------------
 * Global variables for FFT Bin Example
 * ------------------------------------------------------------------- */
uint32_t ifftFlag = 0;
uint32_t doBitReverse = 1;

int main(void)
{
    /* Halting WDT  */
    MAP_WDT_A_holdTimer();

    resPos = 0;
    serialPos = 0;
    bit_counter = 0;
    receive_data = 0;
    transmit = false;
    MAP_Interrupt_disableMaster();

    /* Set the core voltage level to VCORE1 */
    MAP_PCM_setCoreVoltageLevel(PCM_VCORE1);

    /* Set 2 flash wait states for Flash bank 0 and 1*/
    MAP_FlashCtl_setWaitState(FLASH_BANK0, 2);
    MAP_FlashCtl_setWaitState(FLASH_BANK1, 2);

    /* Initializes Clock System */
    MAP_CS_setDCOCenteredFrequency(CS_DCO_FREQUENCY_48);
    MAP_CS_initClockSignal(CS_MCLK, CS_DCOCLK_SELECT, CS_CLOCK_DIVIDER_1);
    MAP_CS_initClockSignal(CS_HSMCLK, CS_DCOCLK_SELECT, CS_CLOCK_DIVIDER_1);
    MAP_CS_initClockSignal(CS_SMCLK, CS_DCOCLK_SELECT, CS_CLOCK_DIVIDER_2);
    MAP_CS_initClockSignal(CS_ACLK, CS_REFOCLK_SELECT, CS_CLOCK_DIVIDER_1);

    /* Setting reference voltage to 2.5  and enabling reference */
    MAP_REF_A_setReferenceVoltage(REF_A_VREF1_2V);
    MAP_REF_A_enableReferenceVoltage();

    /* Enabling the FPU for floating point operation */
    MAP_FPU_enableModule();
    MAP_FPU_enableLazyStacking();

    /* Initializing ADC (MCLK/1/1) */
    MAP_ADC14_enableModule();
    MAP_ADC14_initModule(ADC_CLOCKSOURCE_MCLK, ADC_PREDIVIDER_1, ADC_DIVIDER_1,
                         0);

    /* Configuring GPIOs (5.5 A0) */
    MAP_GPIO_setAsPeripheralModuleFunctionInputPin(GPIO_PORT_P5, GPIO_PIN5,
    GPIO_TERTIARY_MODULE_FUNCTION);

    /* Configuring P5.4 as output (transmit) */
        MAP_GPIO_setAsOutputPin(GPIO_PORT_P5, GPIO_PIN4);

    /* Selecting P1.2 and P1.3 in UART mode */
    MAP_GPIO_setAsPeripheralModuleFunctionInputPin(
            GPIO_PORT_P1,
            GPIO_PIN2 | GPIO_PIN3,
            GPIO_PRIMARY_MODULE_FUNCTION);

    /* Configuring ADC Memory */
    MAP_ADC14_configureSingleSampleMode(ADC_MEM0, true);
    MAP_ADC14_configureConversionMemory(ADC_MEM0, ADC_VREFPOS_AVCC_VREFNEG_VSS,
    ADC_INPUT_A0,
                                        false);

    /* Configuring Timer_A in continuous mode and sourced from ACLK */
    MAP_Timer_A_configureUpMode(TIMER_A0_BASE, &upModeConfig);

    /* Configuring Timer_A0 in CCR1 to trigger at 16000 (0.5s) */
    MAP_Timer_A_initCompare(TIMER_A0_BASE, &compareConfig);

    /* Configuring the sample trigger to be sourced from Timer_A0  and setting it
     * to automatic iteration after it is triggered*/
    MAP_ADC14_setSampleHoldTrigger(ADC_TRIGGER_SOURCE1, false);

    /* Enabling the interrupt when a conversion on channel 1 is complete and
     * enabling conversions */
    MAP_ADC14_enableInterrupt(ADC_INT0);
    MAP_ADC14_enableConversion();

    /* Configuring UART Module */
    MAP_UART_initModule(EUSCI_A0_BASE, &uartConfig);

    /* Enable UART module */
    MAP_UART_enableModule(EUSCI_A0_BASE);

    targetFrequency1 = 10000;
    targetFrequency2 = 20000;
    indexl = floor(512 * (targetFrequency1) / SAMPLING_RATE);
    indexh = floor(512 * (targetFrequency2) / SAMPLING_RATE);

    /* Enabling Interrupts */
    MAP_Interrupt_enableInterrupt(INT_ADC14);
    MAP_UART_enableInterrupt(EUSCI_A0_BASE, EUSCI_A_UART_RECEIVE_INTERRUPT);
    MAP_Interrupt_enableInterrupt(INT_EUSCIA0);
    MAP_Interrupt_setPriority(INT_EUSCIA0, (0 << 5)); // Serial communication with pc has highest priority
    MAP_Interrupt_setPriority(INT_ADC14, (1 << 5)); // ADC has second highest priority

    MAP_Interrupt_enableMaster();

    /* Starting the Timer */
    MAP_Timer_A_startCounter(TIMER_A0_BASE, TIMER_A_UP_MODE);
    //MAP_DMA_enableChannel(7);
    smclk = CS_getSMCLK();
    smclk = CS_getACLK();
    smclk = CS_getACLK();
    // main loop;
    while (1)
    {
        test = test + 1;
    }
}

/* This interrupt is fired whenever a conversion is completed and placed in
 * ADC_MEM0 */
void ADC14_IRQHandler(void)
{
    if (!transmit)
    {
        uint64_t status;

        status = MAP_ADC14_getEnabledInterruptStatus();
        MAP_ADC14_clearInterruptFlag(status);

        if (status & ADC_INT0)
        {
            if (resPos == bin_size)
            {
                counter = Timer_A_getCounterValue(TIMER_A0_BASE);

                resPos = 0;
                arm_cfft_q15(&arm_cfft_sR_q15_len512,
                             (q15_t *) ADCresultsBuffer, ifftFlag,
                             doBitReverse);
                arm_cmplx_mag_q15((q15_t *) ADCresultsBuffer,
                                  (q15_t *) fftOutput, UINT8_MAX);

                smclk = Timer_A_getCounterValue(TIMER_A0_BASE);
                int n = 0;
                resultl = 0;
                resulth = 0;
                for (n = 0; n < 2 * ENERGYBIN_SIZE; n++)
                {
                    resultl = resultl + fftOutput[indexl - ENERGYBIN_SIZE + n];
                    resulth = resulth + fftOutput[indexh - ENERGYBIN_SIZE + n];
                }

                if ((resulth > 50) & (resulth > resultl))
                {
                    receive_data = (receive_data | (1 << bit_counter));

                    bit_counter = bit_counter + 1;
                }

                if ((resultl > 50) & (resultl > resulth))
                {
                    bit_counter = bit_counter + 1;
                }

                if (bit_counter == 8)
                {
                    bit_counter = 0;
                    MAP_UART_transmitData(EUSCI_A0_BASE, receive_data);
                    receive_data = 0;
                }
                time = smclk - counter;
                memset(ADCresultsBuffer, 0, sizeof(ADCresultsBuffer));
            }

            ADCresultsBuffer[resPos++] = MAP_ADC14_getResult(ADC_MEM0)
                    * digital_gain;
        }
    }
    else
    {
        if (byte_counter < message_length)
        {
            if (repeat_counter >= bin_size)
            {
                bit_counter++;
                repeat_counter = 0;
                if (bit_counter >= 8)
                {
                    bit_counter = 0;
                    byte_counter++;
                }
            }
            int lbit = message[byte_counter] & (1 << bit_counter);

            if (lbit > 0)
            {
                GPIO_setOutputHighOnPin(GPIO_PORT_P5, GPIO_PIN4);
            }
            else
            {
                GPIO_setOutputLowOnPin(GPIO_PORT_P5, GPIO_PIN4);
            }

        }
        else
        {
            byte_counter = 0;
            bit_counter = 0;
            repeat_counter = 0;
            transmit = false;
        }
    }

}

/* EUSCI A0 UART ISR - Echoes data back to PC host */
void EUSCIA0_IRQHandler(void)
{
    uint32_t status = MAP_UART_getEnabledInterruptStatus(EUSCI_A0_BASE);

    if (status & EUSCI_A_UART_RECEIVE_INTERRUPT_FLAG)
    {
        //MAP_UART_receiveData(EUSCI_A0_BASE);

        serial_data[serialPos] = MAP_UART_receiveData(EUSCI_A0_BASE);

        serialPos += 1;

        if (serial_data[serialPos - 1] == 10)
        {

            //serial_data[serialPos] = '\0';

            /*char str1[15];
             strcpy(str1, "akhil");
             uint8_t res = 4;
             res = strncmp(serial_data,str1,3);

             res  = res +res;*/
            first_digit = serial_data[0];
            second_digit = serial_data[1];
            switch (first_digit)
            {
            case '1':
            {
                int i = 0;
                memset(message, 0, sizeof(message));
                for (i = 2; i < serialPos - 1; i++)
                {
                    message[i - 2] = serial_data[i];
                }
                switch (second_digit)
                {
                case '2':
                {
                    targetFrequency1 = atoi(message);
                    indexl = floor(512 * (targetFrequency1) / SAMPLING_RATE);

                    break;
                }
                case '3':
                {
                    targetFrequency2 = atoi(message);
                    indexh = floor(512 * (targetFrequency2) / SAMPLING_RATE);
                    break;

                }
                case '4':
                {
                    bin_size = atoi(message);
                    break;
                }
                case '5':
                {
                    ENERGYBIN_SIZE = atoi(message);
                    break;
                }
                case '6':
                {
                    digital_gain = atoi(message);
                    break;
                }

                default:
                    break;
                }
                break;
            }
            case '0':
            {

                transmit = true;
                uint8_t n = 0;
                memset(message, 0, sizeof(message));
                for (n = 2; n < serialPos - 1; n++)
                {
                    message[n - 2] = serial_data[n];

                }
                memset(ADCresultsBuffer, 0, sizeof(ADCresultsBuffer));
                resPos = 0;
                break;
            }
            default:
                break;
            }

            MAP_UART_transmitData(EUSCI_A0_BASE, '0');
            message_length = serialPos - 3;
            bit_counter = 0;
            byte_counter = 0;
            repeat_counter = 0;

            serialPos = 0;

        }
        //

    }

}


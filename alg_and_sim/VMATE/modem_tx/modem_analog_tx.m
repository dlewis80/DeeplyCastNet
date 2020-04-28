function [out0,out1] = modem_analog_tx(in0,in1)

% This function models the path from the microcontroller through the
% transducer. Due to time constraints, the model is not complete.
% Currently, only gain is accounted for. Noise is added at a system level
% in the propagation model, which should be modified

% Inputs:
% in0: vector of data sent to DAC by microcontroller containing '0' data
% in1: vector of data sent to DAC by microcontroller containing '1' data

% Outputs:
% out0: Pressure in uPa emitted by the transducer containing '0' data
% out1: Pressure in uPa emitted by the transducer containing '1' data

%% DAC model
% Needs shaping and noise
dac_out0 = in0./(2^12).*3.3;
dac_out1 = in1./(2^12).*3.3;

%% Class D model
% Needs shaping and noise
classD_out0 = dac_out0.*(30./3.3);
classD_out1 = dac_out1.*(30./3.3);

%% Transducer model
% Assume constant TVR 143dB V/uPa in narrow frequency band
out0 = classD_out0*10^(143/20);
out1 = classD_out1*10^(143/20);

end
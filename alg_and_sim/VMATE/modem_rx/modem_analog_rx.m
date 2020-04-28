function out = modem_analog_rx(in,fs)

% This function models the path from the transducer to the microcontroller.
% Due to time constraints, this model is not complete. Currently, this
% model accounts for theoretical gain and some shaping effects, but no
% noise or shaping effects.

%% Transducer Model
% Assume constant OCVS -190dB V/uPa in narrow frequency band
trans_out = in*10^(-190/20); 

%% Lowpass Filter Model
% Digital approximation to a 4th order 30kHz analog butterworth filter
[b,a] = butter(4,30000./(fs./2));
LPF_out = filter(b,a,trans_out);

%% Low-Noise Op-Amp Model
% Needs noise and shaping
amp_out = LPF_out .* 500;
assignin('base','pre_clip_rx',amp_out)

%% ADC
% Needs noise and shaping
% Clip to 3.3V
ADC_in = amp_out;
clip_mask = ADC_in>3.3;
ADC_in(clip_mask) = 3.3;
if sum(clip_mask)>0
    disp('Clipping present for next test case')
end

% ADC
out = round(ADC_in./3.3*2^14);

end
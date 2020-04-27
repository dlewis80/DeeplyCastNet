function [out0,out1] = modem_analog_tx(in0,in1)

% TBD. Currently just translates 12 bit data back to analog

%% DAC model
out0 = in0./(2^12);
out1 = in1./(2^12);

%% Class D model

%% Transformer model

%% Transducer model

end
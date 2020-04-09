function out = modem_analog_tx(in)

% TBD. Currently just translates 12 bit data back to analog

%% DAC model
out = in./(2^12);

%% Class D model

%% Transformer model

%% Transducer model

end
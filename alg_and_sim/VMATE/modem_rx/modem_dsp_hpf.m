function out = modem_dsp_hpf(in,path)

% This function implements a filter using the coefficients stored in "Num"
% and "Den" in the given .mat file

% Inputs:
% in = input data vector
% path = filename of .mat file contain filter coefficients "Num", the x
% coefficients, and "Den", the y coefficients

% Outputs:
% out = filtered data

load(path)
%out = filter(Num,Den,in);
out = in;

end
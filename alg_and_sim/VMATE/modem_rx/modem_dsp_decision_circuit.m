function out = modem_dsp_decision_circuit(in_a, thresh_a, in_b, thresh_b)

% This function implements an asynchronous FSK demodulator decision circuit
% based on inputs from two bandpass filters and input threshholds. The
% outputs are no detection ("NaN"), "a" detected ("0"), and "b" detected
% ("1")

% Inputs:
% in_a: vector containing magnitude values of bandpass a
% thresh_a: threshhold to indicate a valid detection of a
% in_b: vector containing magnitude values of bandpass b
% thresh_b: threshhold to indicate a valid detection of b

% Outputs:
% out: vector containing detector outputs "NaN", "0", and "1"

a = in_a./thresh_a;
b = in_b./thresh_b;
out = [];
for i = 1:length(a)
    if a(i)<1 && b(i)<1
        out = [out,NaN];
    elseif a(i) >= b(i)
        out = [out,0];
    elseif b(i) > a(i)
        out = [out, 1];
    end
end

end
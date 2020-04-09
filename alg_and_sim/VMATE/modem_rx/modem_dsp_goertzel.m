function out = modem_dsp_goertzel(in,fs,ft,N)
% This function implements the goertzel algorithm for frequency detection.
% For each block of N samples, a single magnitude coefficient is generated
% relative to the input power of the signal. This must be fed into a
% decision function for full asynchronous fsk demodulation.

% Inputs:
% in = input data vector
% fs = sampling frequency
% ft = target frequency
% N = block size

% Outputs:
% out = vector of the output magnitude for each block

in_padded = [in, zeros(1,N-mod(length(in),N))];
out = [];

m = ft*N/fs;
coeff = 2*cos(2*pi*m/N);

for j = [1:N:length(in_padded)]
    block = in_padded([j:j+N-1]);
    mean_block = mean(abs(block));
    Q0 = 0;
    Q1 = 0;
    Q2 = 0;
    for i = 1:N
        Q0 = coeff * Q1 - Q2 + block(i);
        Q2 = Q1;
        Q1 = Q0;
    end
    out = [out, sqrt(Q1^2 + Q2^2 - Q1*Q2*coeff)];
end
end
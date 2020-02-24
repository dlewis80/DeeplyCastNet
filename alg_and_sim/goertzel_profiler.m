function [freq_vec, mag_vec] = goertzel_profiler(fs,ft,N)

% This function outputs a Goertzel filter profile for the given input 
% parameters

% Inputs:
% fs = sampling frequency
% ft = target frequency
% N = block size for algorithm

% Outputs:
% freq_vec = vector of frequencies used to generate profile
% mag_vec = magnitude of filter output relative to freq_vec

m = ft*N/fs;
coeff = 2*cos(2*pi*m/N);

Q0 = 0;
Q1 = 0;
Q2 = 0;
f = 0:10:2*ft;
for j = 1:length(f)
    sample = sin(2*pi*f(j)*((1:N)/fs));
    for i = 1:N
        Q0 = coeff * Q1 - Q2 + sample(i);
        Q2 = Q1;
        Q1 = Q0;
    end
    mag(j) = sqrt(Q1^2 + Q2^2 - Q1*Q2*coeff);
end

freq_vec = f;
mag_vec = mag;

end
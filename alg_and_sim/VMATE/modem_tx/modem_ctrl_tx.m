function [msg_out,out] = modem_ctrl_tx(in,filename)

% This function acts as the transmit firmware for the modem. It takes an
% input string, adds a timestamp to the front of it, and converts it to 12
% bit data to send to a DAC

% Inputs:
% in: input string containing '1's and '0's
% filename: filename containing parameters for modem_ctrl_tx

% Outputs:
% msg_out: string representation of message for error checking purposes
% out: vector of data to send to DAC (stored as a double, fits in 12 bits)

% Import transmitter parameters
fp = fopen(filename,'r');
fs = str2double(strtok(fgets(fp),' '));
ft_a = str2double(strtok(fgets(fp),' '));
N_a = str2double(strtok(fgets(fp),' '));
ft_b = str2double(strtok(fgets(fp),' '));
N_b = str2double(strtok(fgets(fp),' '));
ts_bits = str2double(strtok(fgets(fp),' '));
fclose(fp);

% Generate message. Note that messages are sent as triplets (each bit
% appears 3 times in a row) scaled to 3.3V, 12 bit messages
tic
msg_out = [dec2bin(round(mod(toc*100,2^ts_bits)),ts_bits),in]; % timestamp
out = [];
for i = 1:length(msg_out)
    start_ndx = (((i-1)*3*N_a)+1);
    t = [start_ndx:start_ndx+3*N_a-1]./fs;
    if msg_out(i) == '0'
        out = [out, round(sin(2*pi*ft_a.*t).*3.3.*(2^12))];
    elseif msg_out(i) == '1'
        out = [out, round(sin(2*pi*ft_b.*t).*3.3.*(2^12))];
    end
end

end
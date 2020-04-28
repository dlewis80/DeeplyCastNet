function [msg_out,out0,out1] = modem_ctrl_tx(in,filename)

% This function acts as the transmit firmware for the modem. It takes an
% input string, adds a timestamp to the front of it, and converts it to 12
% bit data to send to a DAC.

% Inputs:
% in: input string containing '1's and '0's
% filename: filename containing parameters for modem_ctrl_tx

% Outputs:
% msg_out: string representation of message for error checking purposes
% out0: vector of data to send to DAC containing '0' data
% out1: vector of data to send to DAC containing '1' data

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
% appears 3 times in a row) at 12 bit precision for the DAC
tic
msg_out = [dec2bin(round(mod(toc*100,2^ts_bits)),ts_bits),in]; % timestamp
out1 = [];
out0 = [];
for i = 1:length(msg_out)
    start_ndx = (((i-1)*3*N_a)+1);
    t = [start_ndx:start_ndx+3*N_a-1]./fs;
    if msg_out(i) == '0'
        out0 = [out0, round(sin(2*pi*ft_a.*t).*(2^11))+2^11];
        out1 = [out1, round(sin(2*pi*0.*t).*(2^11))+2^11];
    elseif msg_out(i) == '1'
        out0 = [out0, round(sin(2*pi*0.*t).*(2^11))+2^11];
        out1 = [out1, round(sin(2*pi*ft_b.*t).*(2^11))+2^11];
    end
end

end
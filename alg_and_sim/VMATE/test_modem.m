% This script runs the modem transmitter directly into the modem receiver
% to verify compatability

clear
clc

addpath('modem_rx')
addpath('modem_tx')

in = num2str('11001010');

filename = 'default_modem_tx.txt';
[tx_out0,tx_out1,msg_out] = MASTER_modem_tx(in,filename);

prop_out = stokes_attenuation(tx_out0,tx_out1,100000,[100,500,1000],[27000,22000]);
[r,c,d] = size(prop_out);

filename = 'default_modem_rx.txt';
out = [];
    for j = 1:c
        out = MASTER_modem_rx(squeeze(prop_out(1,j,:))',filename);
        status = strcmp(msg_out,out{1}(15:end));
        if status
            fprintf("Receiver %i success\n",j)
        else
            fprintf("Receiver %i failed\n",j)
            disp(out);
        end
    end

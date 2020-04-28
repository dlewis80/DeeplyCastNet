% This script runs the modem transmitter directly into the modem receiver
% to verify compatability

clear
clc

addpath('modem_rx')
addpath('modem_tx')

in = num2str(round(rand(1,145)));
in(isspace(in)) = [];

filename = 'default_modem_tx.txt';
[tx_out0,tx_out1,msg_out] = MASTER_modem_tx(in,filename);

prop_out = stokes_attenuation(tx_out0,tx_out1,100000,[300,400,700,950],[27000,22000],inf);
[r,c,d] = size(prop_out);

filename = 'default_modem_rx.txt';
out = [];
    for j = 1:c
        out = MASTER_modem_rx(squeeze(prop_out(1,j,:))',filename);
        status = strcmp(msg_out,out{1}(15:end));
        if status
            fprintf("Receiver %i success\n\n",j)
        else
            fprintf("Receiver %i failed\n",j)
            fprintf("Received '%s'\n",out{1}([15:end]));
            fprintf("Accurate '%s'\n\n",msg_out);
        end
    end

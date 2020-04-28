% This script runs VMATE. It is fed by several text files listed in
% VMATE_default.txt
clear
clc
addpath('modem')
addpath('modem_tx')
addpath('modem_rx')
addpath('propagation')
addpath('propagation\stokes')

% What should be in text files
modem_filename = 'default_modem.txt';
stokes_filename = 'default_propagation.txt';

% Generate random input of proper size
in = num2str(round(rand(1,145)));
in(isspace(in)) = [];

[tx_out0,tx_out1,msg_out] = MASTER_modem_tx(in,modem_filename);

prop_out = stokes_attenuation(tx_out0,tx_out1,100000,[300,400,700,950],[27000,22000],inf);
[r,c,d] = size(prop_out);

out = [];
    for j = 1:c
        out = MASTER_modem_rx(squeeze(prop_out(1,j,:))',modem_filename);
        status = strcmp(msg_out,out{1}(15:end));
        if status
            fprintf("Receiver %i success\n\n",j)
        else
            fprintf("Receiver %i failed\n",j)
            fprintf("Received '%s'\n",out{1}([15:end]));
            fprintf("Accurate '%s'\n\n",msg_out);
        end
    end

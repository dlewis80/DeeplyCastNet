% This script runs VMATE. It is fed by VMATE_settings.txt, which is
% initially made by 'make_VMATE_settings.m'. To run this for the first
% time, it is important to also run 'modem/make_default_parameters_modem.m'
% and 'propagation/make_default_parameters_propagation.m'
clear
clc

% Give visibility into subdirectories
addpath('modem')
addpath('modem/modem_tx')
addpath('modem/modem_rx')
addpath('propagation')
addpath('propagation')

% What should be in text files
modem_filename = 'default_modem.txt';
stokes_filename = 'default_propagation.txt';
msg_len = 145;

% Generate random input of proper size
in = num2str(round(rand(1,msg_len)));
in(isspace(in)) = [];

% Run VMATE
[tx_out0,tx_out1,msg_out] = MASTER_modem_tx(in,modem_filename);

prop_out = stokes_attenuation(tx_out0,tx_out1,stokes_filename);
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

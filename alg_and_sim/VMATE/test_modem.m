% This script runs the modem transmitter directly into the modem receiver
% to verify compatability

clear
clc

addpath('modem_rx')
addpath('modem_tx')

in = '00110101';
filename = 'default_modem_tx.txt';
[tx_out,msg_out] = MASTER_modem_tx(in,filename);
filename = 'default_modem_rx.txt';
out = MASTER_modem_rx(tx_out,filename);

status = strcmp(msg_out,out{1}(15:end))
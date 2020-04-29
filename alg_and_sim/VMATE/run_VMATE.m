%% VMATE Master Script

% This is fed by two text files, 'default_modem.txt' and
% 'default_propagation.txt' which are not under source control and may be
% freely edited. These files will be made automatically if they don't exist

% This script is partially hard coded. To expand VMATE into a modular
% simulator (i.e. be able change propagation model/modem on the fly),
% follow the suggestions commented below

% I would also recommend editing modem_rx to handle input matrices.
% Currently the workspace only supports one receiver modem's output.
% Supporting matrix input and output would eliminate the need for the for
% loop and provide more debugging information

%% Setup
clear
clc

% Give visibility into subdirectories
addpath('modem')
addpath('modem/modem_tx')
addpath('modem/modem_rx')
addpath('propagation')

% Input Parameters
% These should be read in through text files, for now hardcoded because 
% they won't change for the purpose of our project
modem_filename = 'default_modem.txt';
stokes_filename = 'default_propagation.txt';
msg_len = 145;

% Generate random input of proper size
in = num2str(round(rand(1,msg_len)));
in(isspace(in)) = [];

% Check if input files exist. If not, make them.
if ~isfile('default_modem.txt')
    make_default_parameters_modem
end
if ~isfile('default_propagation.txt')
    make_default_parameters_propagation
end

%% Run VMATE
% This needs to be rewritten to accomodate multiple models. Probably need
% to switch/case the function calls, maybe in other scripts, based 
% on an input text file

% Transmit modem
[tx_out0,tx_out1,msg_out] = MASTER_modem_tx(in,modem_filename);

% Propagation model
prop_out = stokes_attenuation(tx_out0,tx_out1,stokes_filename);

% Receive Modems
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

% Clean workspace
vars = {'ans','c','d','r','fp','i','j','status','vars','modem_filename','stokes_filename','msg_len'};
clear(vars{:});
 
%% VMATE README

% This file contains a description of VMATE, the Virtual Modem Acoustic
% Test Environment. The goal of VMATE is to simulate the effectiveness of
% an acoustic modem under varying propagation and noise conditions. It is
% particularly useful for fast parameter tuning and algorithm exploration

% VMATE was written by Daniel Lewis in the Spring 2020 semester

%% Usage instructions

% Simply run the script 'run_VMATE'. Default parameter files will be
% created and results for each receiver will appear in the command line

% To change parameters, edit the two text files that appear in the VMATE
% directory. Please note that fs must be set independently in both of them.

% Further development on VMATE will make the system more modular, allowing 
% more propagation models and modem designs. Please see 'run_VMATE' for 
% more details on how to increase modularity.

%% Description of System

% In its current state, VMATE will generate a random binary message and 
% send the data to a MATLAB version of the acoustic modem transmitter. The
% transmitter attaches a timestamp to the front of the message and encodes
% it using frequency shift keying ('modem/modem_tx/modem_ctrl_tx.m'). The
% data then passes through the analog transceiver model, where the
% waveforms corresponding to '1's and '0's are kept seperate.
% ('modem/modem_tx/modem_analog_tx.m'). These waveforms are outputted as
% pressure in microPascals (uPa).

% The propagation model uses Stoke's Law of sound attenuation to estimate 
% transmission loss as a function of distance and frequency 
% ('propagation/stokes_attenuation.m'). Each distance inputted to the
% function is considered a seperate receiver from the perspective of VMATE.
% Additionally, at each receiver, noise is added at a specified level of
% SNR. Note that this means that noise also "attenuates" with distance
% instead of being consistent across the full range.

% The modem receiver model takes in a pressure and converts it to a digital
% voltage in the receiver analog model
% ('modem/modem_rx/modem_analog_rx.m'). This data is then decoded using an
% asynchronous FSK demodulation algorithm. Asynchronous FSK demodulation 
% involves a bandpass filter and level detector 
% ('modem/modem_rx/modem_dsp_goertzel.m') that feeds a decision circuit 
% ('modem/modem_rx/modem_dsp_decision_circuit.m'), which decides what bit 
% was received. The receiver control logic then assembles the outputs of 
% the decision circuit, adding a receive timestamp to the message and
% implementing an error correction triplet
% ('modem/modem_rx/modem_ctrl_rx.m').

% VMATE takes the output of the modem receiver model and compares it to the
% original message. In the command line, VMATE will indicate which messages
% clipped the Analog-to-Digital Converter, which messages were successful,
% and which messages failed. For failed messages, VMATE will show what the
% receiver thought the message was versus what the message actually was to
% help the user understand both where the issues lie and the severity of
% the issue. Additionally, VMATE will leave key pieces of information in
% the base workspace. They are generated in the following order:

% in: input message, binary
% msg_out: transmitted message, binary
% tx_out0: transmitted pressure waveform, only accounting for '0' bits
% tx_out1: transmitted pressure waveform, only accounting for '1' bits
% gain_mat: matrix of attenuation factors due to propagation
% prop_out: received pressure waveforms (matrix of all receivers)
% pre_clip_rx: received analog waveform (last receiver only)
% analog_rx: received analog waveform, converted to digital
% hpf_out: output of digital highpass filter. It is currently commented out
% goertzel_out_a: perceived magnitude of '0' bit
% goertzel_out_b: perceived magnitude of '1' bit
% decision: output of decision circuit - picks whether bit is '0' or '1'
% out: received binary message with receive timestamp added

function [out0,out1,msg_out] = MASTER_modem_tx(in,filename)

% This function models the entire transmit path of the modem from the
% message from the host PC to the pressure generated by the transducer.
% Note that there are two physical outputs; this does not model the actual
% behavior of the modem, this is simply to accomodate the needs of the
% propagation model

% Inputs:
% in: vector containing pressure data from propagation model
% filename: filename of text file containing modem rx parameters

% Outputs:
% out0: transmitted message containing analog '0' information
% out1: transmitted message containing analog '1' information
% msg_out: digital representation of message, used for error checking

[msg_out,dig_out0,dig_out1] = modem_ctrl_tx(in,filename);
[out0,out1] = modem_analog_tx(dig_out0,dig_out1);

end
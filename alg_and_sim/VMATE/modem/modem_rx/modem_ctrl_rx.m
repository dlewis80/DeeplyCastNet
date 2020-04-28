function out = modem_ctrl_rx(in,ts_bits)

% This function implements the receiver logic for the modem. The receive
% logic controls how bits are assembled into messages. Because the
% simulator is not real time, timestamps are not indicative of actual send
% and receive times

% Inputs:
% in: vector containing decision circuit outputs
% ts_bits: number of bits in timestamp

% Outputs:
% out: cell array containing received messages

tic
dv = 0;
in = [in, NaN(1,3)]; %Add a NaN triplet to end to esnure timestamp added
out = [];

while length(in)>=3
    % not currently assembling message
    if ~dv
        if ~isnan(in(1)) % detected valid sample
            dv = 1;
            msg = dec2bin(round(mod(toc*100,2^ts_bits)),ts_bits); %rx timestamp
        else % didn't detect valid sample
            in(1) = [];
        end
        
        % currently assembling message
    elseif dv
        triplet = in([1:3]);
        if length(find(triplet==1))>1
            msg = [msg,'1'];
        elseif length(find(triplet==0))>1
            msg = [msg,'0'];
        else
            dv = 0;
            out = [out,{msg}];
        end
        in([1:3]) = [];
    end
end
if isempty(out)
    out = {'no detection'};
end
end
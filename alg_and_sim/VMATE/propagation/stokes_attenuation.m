function out = stokes_attenuation(in0,in1,prop_filename)

% This is a very simple model of sound attenuation in a fluid. It is not an
% ocean acoustics model. Ideally this will be replaced later on, but for
% now it will acheive the objective of how noise affects performance for
% different levels of attenuation

% Constants
eta = 1.72; % dynamic viscosity coefficient of water near freezing
rho = 997; % density water
V = 1500; % speed of sound in water (average)

% Input parameters
fp = fopen(prop_filename);
fs = str2double(strtok(fgets(fp),' '));
distances = eval(strtok(fgets(fp),' '));
freqs = eval(strtok(fgets(fp),' '));
fclose(fp)

% Adjust for delay
delay = round(distances/V*fs); 
num_samples = max(delay)+length(in0);
delayed_data0 = zeros(1,length(distances),num_samples);
delayed_data1 = zeros(1,length(distances),num_samples);
for i = 1:length(delay)
    delayed_data0(1,i,[delay(i)+1:delay(i)+length(in0)]) = in0;
    delayed_data1(1,i,[delay(i)+1:delay(i)+length(in1)]) = in1;
end
delayed_data = [delayed_data0;delayed_data1];

% Adjust for transmission loss
omegas = (2.*pi.*freqs); % frequencies to transmit
alphas = 2.*eta.*(omegas.^2)./3./rho./(V.^3); % stokes attenuation
gain_mat = zeros(length(omegas),length(distances));
out = zeros(length(omegas),length(distances),num_samples);
for i = 1:length(alphas)
    for j = 1:length(distances)
        gain_mat(i,j) = exp(-alphas(i).*distances(j));
        for k = 1:num_samples
            out(i,j,k) = delayed_data(i,j,k).*gain_mat(i,j);
        end
    end
end
assignin('base','gain_mat',gain_mat)
out = sum(out);

%noise_level = rms(out)*(10^(-snr/20));
%out = out+(noise_level.*rand(1,1,length(out)));

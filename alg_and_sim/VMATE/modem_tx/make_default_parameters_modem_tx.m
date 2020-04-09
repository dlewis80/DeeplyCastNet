% This script generates a default text file for modem_ctrl_tx

fp = fopen('default_modem_tx.txt','w');

fprintf(fp,"100000 (fs)\n");
fprintf(fp,"27000 (ft_a)\n");
fprintf(fp,"166 (N_a)\n");
fprintf(fp,"25000 (ft_b)\n");
fprintf(fp,"166 (N_b)\n");
fprintf(fp,"14 (ts_bits)");

fclose(fp);
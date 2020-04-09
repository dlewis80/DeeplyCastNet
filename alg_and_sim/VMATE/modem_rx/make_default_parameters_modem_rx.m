fp = fopen('default_modem_rx.txt','w');

fprintf(fp,"100000 (fs)\n");
fprintf(fp,"hpf_4_order.mat (hpf_path)\n");
fprintf(fp,"27000 (ft_a)\n");
fprintf(fp,"166 (N_a)\n");
fprintf(fp,"25000 (ft_b)\n");
fprintf(fp,"166 (N_b)\n");
fprintf(fp,"40 (thresh_a)\n");
fprintf(fp,"60 (thresh_a)\n");
fprintf(fp,"14 (ts_bits)");

fclose(fp);
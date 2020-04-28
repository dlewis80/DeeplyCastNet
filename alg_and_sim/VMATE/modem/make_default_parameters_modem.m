fp = fopen('default_modem.txt','w');

fprintf(fp,"100000 (fs)\n");
fprintf(fp,"hpf_4_order.mat (hpf_path)\n");
fprintf(fp,"27000 (ft_a)\n");
fprintf(fp,"22000 (ft_b)\n");
fprintf(fp,"64 (N)\n");
fprintf(fp,"100 (thresh_a)\n");
fprintf(fp,"100 (thresh_a)\n");
fprintf(fp,"14 (ts_bits)");

fclose(fp);
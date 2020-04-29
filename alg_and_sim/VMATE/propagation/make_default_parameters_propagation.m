fp = fopen('default_propagation.txt','w');

fprintf(fp,"100000 (fs)\n");
fprintf(fp,"[300,400,700,950] (distances)\n");
fprintf(fp,"[27000,22000] (frequencies)\n");
fprintf(fp,"Inf (snr)");

fclose(fp);
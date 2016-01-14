<?

$fp = fopen("Cron/testFile.txt", "r");
$stareDane = fread($fp, filesize("Cron/testFile.txt"));
fclose($fp);

$noweDane  = date('l jS F Y h:i:s A')."\n";
$noweDane .= $stareDane;

$fp = fopen("Cron/testFile.txt", "w");
fputs($fp, $noweDane);
fclose($fp);
?>
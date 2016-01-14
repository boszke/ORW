<html>
<head>
	<title>Strona Cron</title>
</head>
<body>
	<p>Oto strona Cron</p>
	<?php
	$wp = fopen("Cron/testFile.txt", "r");
	
	while (!feof($wp)) {
	$wyswietl = fgets($wp,999);
	echo $wyswietl."<br />";
	}
	?>
	
	<script>
	var image = document.getElementById("obraz");
	var img_array=["images/1.jpg","images/2.jpg","images/3.jpg"];
	var index=0;
	function slide()
	{

		document["obraz"].src = img_array[index];
		index++;
		if(index>=img_array.length)
		{
		index=0;
		}
	}
	setInterval("slide()",2000);
	</script>
	
	<img id="obraz" src="images/1.jpg" width="400" height="400" name="image" />
</body>
</html>
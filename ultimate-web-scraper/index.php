<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2" />
	<title>Web Scraping</title>
</head>
<body>
<table>
<thead>
	<tr>
		<th></th>
		<th>Stacja</th>
		<th>Lokalizacja</th>
		<th>Pb95</th>
		<th>Pb98</th>
		<th>ON</th>
		<th>LPG</th>
		<th>Data aktualizacji</th>
		<th></th>
	</tr>
</thead>
<tbody>
<?php

  require_once "support/http.php";
  require_once "support/web_browser.php";
  require_once "support/simple_html_dom.php";
 
  // Simple HTML DOM tends to leak RAM like
  // a sieve.  Declare what you will need here.
  // Objects are reusable.
  $html = new simple_html_dom();

  $url = "http://korki.trojmiasto.pl/paliwa/?&city=3";
  $web = new WebBrowser();
  $result = $web->Process($url);

  if (!$result["success"])  echo "Error retrieving URL.  " . $result["error"] . "\n";

  else if ($result["response"]["code"] != 200)  echo "Error retrieving URL.  Server returned:  " . $result["response"]["code"] . " " . $result["response"]["meaning"] . "\n";

  else
  {
	echo $url;
    $html->load($result["body"]);
	//przeszukiwanie td (wiersze tabeli)
    $rows = $html->find("td");
	
	$counter=0;
	
    foreach ($rows as $row)
    {
		if ($counter%9==0)
		{
			echo "<tr>";
		}
		else if ($counter%9==9)
		{
			echo "</tr>";
		}
		 echo "<td>".strip_tags($row)."</td>";
	  
	  //dodanie do licznika w celu rysowania <br />
	  $counter++;
    }
	/*
	$html1 = new simple_html_dom();
	$html1->load($result["body"]);
	$rows1 = $html1->find('div[class=text-container]');
	
	foreach ($rows1 as $row)
    {
		 echo "<br />".strip_tags($row);
    }
	*/
  }
?>
</tbody>
</table>
</body>
</html>
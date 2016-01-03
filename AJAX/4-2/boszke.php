
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="pl" lang="pl">
  <head>
    <title>Ajax. Kurs od podstaw. Część pierwsza: Wprowadzenie. Przykład #4.2</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    
    <style type="text/css">
    .tresc {
        width: 300px;
		/* ramka 3d */
        border-style: outset;
        padding: 10px;
        background: #e8fff1;        
        margin: 10px;
		
    }
    .minitresc {
        display: none;
        padding: 5px;
    }
    a {
        width: 20px;
        font-family: "Courier New", monospace;
        text-decoration: none;
    }
    </style>
    
<script type="text/javascript">

function expandCollapse(Id)
{
    var n = Id.parentNode.childNodes[2];
    if (n.style.display == 'block') {
        n.style.display = 'none';        
        Id.innerHTML = '+';
    } else {
        n.style.display = 'block';                
        n.innerHTML = 'Michał Boszke';
        Id.innerHTML = '-';        
    }
}

</script>    
    
    
  </head>
<body>

<?php
	for ($i=0; $i<=10; $i++)
	{
		echo '<div class="tresc">';
		echo '<a href="#" onclick="expandCollapse(this);">';
		echo '+';
		echo '</a>';
		echo '<span>';
		echo 'Pojemnik na treść nr ';
		echo $i;
		echo '</span><div></div></div>';
	}
?>

</body>
</html>
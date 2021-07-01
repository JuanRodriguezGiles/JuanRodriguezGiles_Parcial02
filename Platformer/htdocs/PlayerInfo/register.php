<!DOCTYPE html>
<html>
<head>
	<meta charset="utf-8">
	<title>Player Info</title>
</head>
<body>

<?php 
	$con = mysqli_connect("localhost","root","root","playerinfo");

	if(mysqli_connect_errno())
	{
		echo "1: Connection Failed";
		exit();
	}

	$playername = $_POST["playername"];
	$score = $_POST["score"];
	$deathcount = $_POST["deathcount"];

	$namecheckquery = "SELECT playername FROM player WHERE playername ='" . $playername ."';";

	$namecheck = mysqli_query($con,$namecheckquery) or die ("2: Name check query failed");

	if(mysqli_num_rows($namecheck) > 0)
	{
		echo"3: Name already exists";
		exit();
	}
	
	$insertuserquery = "INSERT INTO player (playername,score,deathcount) VALUES ('".$playername."',
	'".$score."','".$deathcount."');";
	mysqli_query($con,$insertuserquery) or die("4: Insert player query failed");

	echo("1");
 ?>

</body>
</html>
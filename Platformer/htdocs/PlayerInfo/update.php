<?php
	$con = mysqli_connect("localhost","root","root", "playerinfo"); //

//
//	check that connection happened

	if (mysqli_connect_errno())
	{ 
		echo "1: Connection failed"; //error code #1 = connection failed
		exit();
	}

	$playername = $_POST["playername"];
	$score = $_POST["score"];
	$deathcount = $_POST["deathcount"];

//check if name exists
$namecheckquery = "SELECT playername FROM player WHERE playername='" . $playername . "';";

$namecheck = mysqli_query($con,$namecheckquery) or die ("2: Name check query failed"); //error code #2 - name check query failed

if(mysqli_num_rows($namecheck) != 1)
{
	echo "3: Nombre no existente"; //error code #3 name exist cannot register
	exit();
}

//add user to the table
	$updatequery = "UPDATE player SET score = '".$score."',deathcount = '".$deathcount."'  WHERE playername = '".$playername."';";
	mysqli_query($con, $updatequery) or die("4: Insert player query failed"); //error code # - inser query failed

	echo ("0");
 ?>
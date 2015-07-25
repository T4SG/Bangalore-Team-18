<?php
#phpinfo();
ini_set('display_errors',1);
ini_set('display_startup_errors',1);
error_reporting(-1);
$conn=mysqli_connect("localhost","root","code4good","Pratham");
if($conn){
echo 'connected successfully';
}
$s1='SELECT *  FROM sponcor';
$retrieval=mysqli_query($conn,$s1);
if(mysqli_num_rows($retrieval)>0)
while($r1=mysqli_fetch_assoc($retrieval))
echo "no is:{$r1['SerialNumber']} <br>";
?>

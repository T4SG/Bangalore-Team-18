<?php
#phpinfo();
ini_set('display_errors',1);
ini_set('display_startup_errors',1);
error_reporting(-1);
$conn=mysqli_connect("localhost","root","code4good","Pratham");
#$flag=1;
if($s1='SELECT uname FROM Verify where uname="admin"')
include("register.html");
#echo $s1;
$retrieval=mysqli_query($conn,$s1);
#echo $retrieval;
if (mysqli_num_rows($retrieval)>0)
{
while($r1=mysqli_fetch_assoc($retrieval))
{
echo "ok";
#if ($_GET['user']==$r1)
#{
#if ($flag==1)
#{
#$s2='SELECT category FROM Verify';
#$ret=mysqli_query($conn,$s2);
#if ($ret=="centerhead")
 # include("centerhead.php");
#else if ($ret=="mentor")
 #  include("mentor.php");
#else if ($ret=="student")
 #  echo "student page";
#else
 #  echo "no such page"; 
#}}
#else
 # {
  #  echo "wrong username and password";
   # include("login.php");
# }}
}}
?>

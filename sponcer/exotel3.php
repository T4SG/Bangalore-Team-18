<?php

$conn = new mysqli("localhost","root","code4good","Pratham");
if ($conn->connect_error) {
die("Connection failed: " . $conn->connect_error);
}
$check = "SELECT SerialNumber FROM sponcor;";
if ($result=mysqli_query($conn,$check))
{
$sn1 = mysqli_num_rows($result);
$sn=$sn1++;
$sql = "INSERT INTO sponcor(SerialNumber, PI_SponcorName, Name, Sponcorship, StampSponcorName, Amount, Year) VALUES ('".$sn."','$_POST[pl_spcname]', '$_POST[name]', '$_POST[spc]', '$_POST[sponsership]', '$_POST[amount]','$_POST[year]');";
}
if ($conn->query($sql)==TRUE) {
echo "New record created";
}
else {
echo "Error: " . $sql . "<br>" . $conn->error;
}
$conn->close();
?>


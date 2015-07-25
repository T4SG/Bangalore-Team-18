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
$sql = "INSERT INTO sponcor(SerialNumber, PI_SponcorName, Name, Sponcorship, StampSponcorName, Amount, Year) VALUES ('".$sn."','PI_SP0142', 'Cisco', 1, 'cs', 200000,2015);";
}
if ($conn->query($sql)==TRUE) {
echo "New record created";
}
else {
echo "Error: " . $sql . "<br>" . $conn->error;
}
$conn->close();
?>


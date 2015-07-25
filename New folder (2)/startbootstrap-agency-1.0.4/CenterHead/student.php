<?php

$conn = new mysqli("localhost","root","code4good","Pratham");
if ($conn->connect_error) {
die("Connection failed: " . $conn->connect_error);
}
#$check = "SELECT SID FROM Student;";
#if ($result=mysqli_query($conn,$check))
#{
#$sn1 = mysqli_num_rows($result);
#$sn=$sn1++;
$sql = "INSERT INTO Student(SID, FName, LName, EDate, DOB, Age, MaritalStatus, Gender, Religion, Address, City, State, PhNo, TotalFee, Paid, Balance, DropOut, Email, StartDate, Course) VALUES ('$_POST[SID]','$_POST[fname]', '$_POST[lname]', '', '$_POST[DOB]', '$_POST[Age]', '$_POST[mstatus]','$_POST[gender]','$_POST[religion]','$_POST[addr]','$_POST[city]','$_POST[state]','$_POST[pnno]','$_POST[total]','$_POST[paid]','$_POST[balance]','$_POST[dropout]','$_POST[email]', '','$_POST[course]');";
#}
if ($conn->query($sql)==TRUE) {
echo "New record created";
}
else {
echo "Error: " . $sql . "<br>" . $conn->error;
}
$conn->close();
?>


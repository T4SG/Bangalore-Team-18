<html>
    <head>
        <meta charset="UTF-8">
        <title>Sponsors</title>
    </head>
    <body>

        <?php
        $con=  mysqli_connect("localhost", "root", "code4good", "Pratham");

        if(!$con)
       {
           die('not connected');
       }
            $con=  mysqli_query($con, "select * from Student");

       ?>
        <div>
            <td>Sponsors Database</td>
        <table border="2" style= "background-color: #84ed86; color: #761a9b; margin: 0 auto;" >
	
	<tr>  
            <th> SID</th>
                    <th>Fname</th>
                    <th>Lname</th>
                     <th>EDate</th>
                    <th>DOB</th>
                    <th>Age</th>
                    <th>MaritalStatus</th>
                    <th>gender</th>
                    <th>religion</th>
                    <th>address</th>
                     <th>city</th>
                     <th>state</th>
                     <th>pbno</th>
                      <th>totalfee</th>
                      <th>paid</th>
                      <th>balance</th>
                      <th>dropout</th>
                      <th>email</th>
                      <th>startdate</th>
                      <th>course</th>
                    

            </tr>

        <?php

             while($row=  mysqli_fetch_array($con))

             {
                 ?>
            <tr>
                <td><?php echo $row['SID']; ?></td>
                <td><?php echo $row['FName']; ?></td>
                <td><?php echo $row['Lname']; ?></td>
                <td><?php echo $row['EDate'] ;?></td>
                <td><?php echo $row['DOB'] ;?></td>
                <td><?php echo $row['Age'] ;?></td>
                <td><?php echo $row['MaritalStatus'] ;?></td>
 <td><?php echo $row['Gender']; ?></td>
 <td><?php echo $row['Religion']; ?></td>
 <td><?php echo $row['Address']; ?></td>
 <td><?php echo $row['City']; ?></td>
 <td><?php echo $row['State']; ?></td>
 <td><?php echo $row['PhNo']; ?></td>
 <td><?php echo $row['TotalFee']; ?></td>
 <td><?php echo $row['Paid']; ?></td>
 <td><?php echo $row['Balance']; ?></td>
 <td><?php echo $row['DropOut']; ?></td>
 <td><?php echo $row['Email']; ?></td>
 <td><?php echo $row['StartDate']; ?></td>
 <td><?php echo $row['Course']; ?></td>


                
            </tr>
<?php } ?>



             </table>
            </div>
    </body>
</html>

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
            $con=  mysqli_query($con, "select * from sponcor");

       ?>
        <div>
            <td>Sponsors Database</td>
        <table border="2" style= "background-color: #84ed86; color: #761a9b; margin: 0 auto;" >
	
	<tr>  
            <th> Serial Number </th>
                    <th>PI_Sponsor Name</th>
                    <th>Name</th>
                     <th>Sponsorship</th>
                    <th>Stamp Sponsor name</th>
                    <th>Amount</th>
                    <th>Year</th>
                    

            </tr>

        <?php

             while($row=  mysqli_fetch_array($con))

             {
                 ?>
            <tr>
                <td><?php echo $row['SerialNumber']; ?></td>
                <td><?php echo $row['PI_SponcorName']; ?></td>
                <td><?php echo $row['Name']; ?></td>
                <td><?php echo $row['Sponcorship'] ;?></td>
                <td><?php echo $row['StampSponcorName'] ;?></td>
                <td><?php echo $row['Amount'] ;?></td>
                <td><?php echo $row['Year'] ;?></td>
                
            </tr>
        <?php
             }
             ?>
             </table>
            </div>
    </body>
</html>

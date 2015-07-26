<html>
    <head>
        <meta charset="UTF-8">
        <title>Sponsors</title>
		<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
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
		
		
		<table class="table">
    <thead>
      <tr>
        <th> Serial Number </th>
        <th>PI_Sponsor Name</th>
        <th>Name</th>
        <th>Sponsorship</th>
        <th>Stamp Sponsor name</th>
        <th>Amount</th>
        <th>Year</th>
      </tr>
    </thead>
    <tbody>
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
    </tbody>
  </table>
            </div>
    </body>
</html>

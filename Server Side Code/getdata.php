<?php
 header("Access-Control-Allow-Credentials: true");
 header('Access-Control-Allow-Origin: *');
 header('Access-Control-Allow-Methods: POST, GET, OPTIONS');
 header('Access-Control-Allow-Headers: Accept, X-Access-Token, X-Application-Name, X-Request-Sent-Time');
 $servername = "localhost"; 
 $server_username = "id8964988_kdavidmitchell"; 
 $server_password = "leetness1"; 
 $dbName = "id8964988_module_db";
  
  //make connection
  $conn = new mysqli($servername, $server_username, $server_password, $dbName);
  if(!conn){
    die("Connection failed: " . mysqli_connect_error());
  }
 
    $query = "SELECT * FROM `tablename` ORDER by `score` DESC LIMIT 10";
    $result = mysqli_query($conn, $query);
  
  if(mysqli_num_rows($result) > 0){
    //show data for each row
    while($row = mysqli_fetch_assoc($result)){
      echo " Name: ".$row['name']. " - Score: ".$row['score']."\n";
    }
  }
?>
<?php 
  header("Access-Control-Allow-Credentials: true");
  header('Access-Control-Allow-Origin: *');
  header('Access-Control-Allow-Methods: POST, GET, OPTIONS');
  header('Access-Control-Allow-Headers: Accept, X-Access-Token, X-Application-Name, X-Request-Sent-Time');
  $servername = "localhost"; 
  $server_username = "id8964988_kdavidmitchell"; 
  $server_password = "leetness1"; 
  $dbName = "id8964988_module_db";
  
    // Strings must be escaped to prevent SQL injection attack. 
    $name = $_POST["namePost"];
    $score = $_POST["scorePost"]; 
    $hash = $_POST["hashPost"];
  //make connection
  $conn = new mysqli($servername, $server_username, $server_password, $dbName);
  if(!conn){
    die("Connection failed: " . mysqli_connect_error());
  }
  
  $secretKey="insertsecretcodehere";
  $real_hash = md5($name . $score . $secretKey);
  
  if($real_hash == $hash){
    $sql = "INSERT INTO SuperBao_SP_Easy (name, score)
      VALUES ('".$name."','".$score."')";
      $result = mysqli_query($conn ,$sql);
  }
  
  //Check Connection
  if(!$conn){
    die("Connection Failed. ". mysqli_connect_error());
  }
?>
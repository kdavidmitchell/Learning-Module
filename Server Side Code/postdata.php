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
    $id = $_POST["idPost"];
    $correct = $_POST["correctPost"];
    $incorrect = $_POST["incorrectPost"]; 
    $hash = $_POST["hashPost"];
  //make connection
  $conn = new mysqli($servername, $server_username, $server_password, $dbName);
  if(!conn){
    die("Connection failed: " . mysqli_connect_error());
  }
  
  $secretKey="avocadotoast";
  $real_hash = md5($id . $correct . $incorrect . $secretKey);
  
  if($real_hash == $hash){
    $sql = "INSERT INTO pretest_stats
      VALUES ('".$id."','".$correct."','".$incorrect."')";
      $result = mysqli_query($conn ,$sql);
  }
  
  //Check Connection
  if(!$conn){
    die("Connection Failed. ". mysqli_connect_error());
  }
?>
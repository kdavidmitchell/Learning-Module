<?php 
  header("Access-Control-Allow-Credentials: true");
  header('Access-Control-Allow-Origin: *');
  header('Access-Control-Allow-Methods: POST, GET, OPTIONS');
  header('Access-Control-Allow-Headers: Accept, X-Access-Token, X-Application-Name, X-Request-Sent-Time');

    // Configuration
   $hostname = 'localhost';
   $username = 'id8964988_kdavidmitchell';
   $password = 'leetness1';
   $database = 'id8964988_module_db';

   // Strings must be escaped to prevent SQL injection attack. 
    $id = $_POST["idPost"] ?? '';
    $correct = $_POST["correctPost"] ?? ''; 
    $incorrect = $_POST["incorrectPost"] ?? '';
    $hash = $_POST["hashPost"] ?? '';

    //make connection
    $conn = new mysqli($hostname, $username, $password, $database);
    if(!$conn){
      die("Connection failed: " . mysqli_connect_error());
    }

    $secretKey = "avocadotoast"; // Change this value to match the value stored in the client javascript below
    $str = $id . $correct . $incorrect . $secretKey;
    $realHash = md5($str);

    if($realHash == $hash)
    {
      $sql = "INSERT INTO test (session_id, num_correct, num_incorrect)
      VALUES ('".$id."','".$correct."','".$incorrect."')";
      $result = mysqli_query($conn ,$sql);
    }

     //Check Connection
    if(!$conn){
      die("Connection Failed. ". mysqli_connect_error());
    }
?>
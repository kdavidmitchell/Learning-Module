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
    $correct = $_POST["correctPost"] ?? ''; 
    $incorrect = $_POST["incorrectPost"] ?? '';
    $hash = $_POST["hashPost"] ?? '';
    $time = $_POST["timePost"] ?? '';
    $q_id = array();
    $q_correct = array();
    $q_certainty = array();

    for ($i = 0; $i < 32; $i++)
    {
      $q_id[$i] = $_POST["q".$i."IDPost"] ?? '';
      $q_correct[$i] = $_POST["q".$i."CorrectPost"] ?? '';
      $q_certainty[$i] = $_POST["q".$i."CertaintyPost"] ?? '';
    }

    //make connection
    $conn = new mysqli($hostname, $username, $password, $database);
    if(!$conn){
      die("Connection failed: " . mysqli_connect_error());
    }

    $secretKey = "avocadotoast"; // Change this value to match the value stored in the client javascript below
    $str = $correct . $incorrect . $secretKey;
    $realHash = md5($str);

    if($realHash == $hash)
    {
      $sql = "INSERT INTO test_pretest (num_correct, num_incorrect, completion_time)
      VALUES ('".$correct."','".$incorrect."','".$time"')";
      $result = mysqli_query($conn ,$sql);
    }

     //Check Connection
    if(!$conn){
      die("Connection Failed. ". mysqli_connect_error());
    }
?>
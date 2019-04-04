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
    $hash = $_POST["hashPost"] ?? '';

    for ($i = 0; $i < 20; $i++)
    {
      $q_teacher[$i] = $_POST["q".$i."TeacherPost"] ?? '';
    }

    //make connection
    $conn = new mysqli($hostname, $username, $password, $database);
    if(!$conn){
      die("Connection failed: " . mysqli_connect_error());
    }

    $secretKey = "avocadotoast"; // Change this value to match the value stored in the client javascript below
    $str = $secretKey;
    $realHash = md5($str);
    $uid = mysqli_insert_id();

    if($realHash == $hash)
    {

      $sql = "INSERT INTO test_teacher (q1, q2, q3, q4, q5, q6, q7, q8, q9, q10, q11, q12, q13, q14, q15, q16) VALUES ('".$uid."',";

      for ($i = 0; $i < 16; $i++) 
      { 
        if ($i < 15)
        {
          $sql .= "'".$q_teacher[$i]."',";
        } else
        {
          $sql .= "'".$q_teacher[$i]."')";
        }
      }

      $result = mysqli_query($conn ,$sql);

      if ($result)
      {
        echo "True query";
      } else
      {
        echo "Query failed..." . mysqli_error($conn);
      }
    }

     //Check Connection
    if(!$conn){
      die("Connection Failed. ". mysqli_connect_error());
    }
?>
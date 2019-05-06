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
    $userid = $_POST["userID"] ?? '';
    $q_id = array();
    $q_correct = array();
    $q_certainty = array();

    for ($i = 0; $i < 34; $i++)
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

      $sql = "INSERT INTO s1_pretest (user_id, num_correct, num_incorrect, completion_time, q1_ID, q2_ID, q3_ID, q4_ID, q5_ID, q6_ID, q7_ID,
        q8_ID, q9_ID, q10_ID, q11_ID, q12_ID, q13_ID, q14_ID, q15_ID, q16_ID, q17_ID, q18_ID, q19_ID, q20_ID, q21_ID, q22_ID, q23_ID,
        q24_ID, q25_ID, q26_ID, q27_ID, q28_ID, q29_ID, q30_ID, q31_ID, q32_ID, q33_ID, q34_ID, q1_correct, q2_correct, q3_correct, q4_correct, q5_correct, q6_correct, q7_correct, q8_correct, q9_correct, q10_correct, q11_correct, q12_correct, q13_correct, q14_correct, q15_correct, q16_correct, q17_correct, q18_correct, q19_correct, q20_correct, q21_correct, q22_correct, q23_correct, q24_correct, q25_correct, q26_correct, q27_correct, q28_correct, q29_correct, q30_correct, q31_correct, q32_correct, q33_correct, q34_correct, q1_certainty, q2_certainty, q3_certainty, q4_certainty, q5_certainty, q6_certainty, q7_certainty, q8_certainty, q9_certainty, q10_certainty, q11_certainty, q12_certainty, q13_certainty, q14_certainty, q15_certainty, q16_certainty, q17_certainty, q18_certainty, q19_certainty, q20_certainty, q21_certainty, q22_certainty, q23_certainty, q24_certainty, q25_certainty, q26_certainty, q27_certainty, q28_certainty, q29_certainty, q30_certainty, q31_certainty, q32_certainty, q33_certainty, q34_certainty) VALUES ('".$userid."','".$correct."','".$incorrect."','".$time."',";

      for ($i = 0; $i < 34; $i++) 
      { 
        $sql .= "'".$q_id[$i]."',";
      }

      for ($i = 0; $i < 34; $i++) 
      { 
        $sql .= "'".$q_correct[$i]."',";
      }

      for ($i = 0; $i < 34; $i++) 
      {
        if ($i < 33)
        {
          $sql .= "'".$q_certainty[$i]."',";
        }
        else
        {
          $sql .= "'".$q_certainty[$i]."')";
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
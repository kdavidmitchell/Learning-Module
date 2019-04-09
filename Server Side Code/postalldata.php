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

    $hash = $_POST["hashPost"] ?? '';
    $precorrect = $_POST["preCorrectPost"] ?? ''; 
    $preincorrect = $_POST["preIncorrectPost"] ?? '';
    $pretime = $_POST["preTimePost"] ?? '';
    $preq_id = array();
    $preq_correct = array();
    $preq_certainty = array();

    for ($i = 0; $i < 32; $i++)
    {
      $preq_id[$i] = $_POST["q".$i."PreIDPost"] ?? '';
      $preq_correct[$i] = $_POST["q".$i."PreCorrectPost"] ?? '';
      $preq_certainty[$i] = $_POST["q".$i."PreCertaintyPost"] ?? '';
    }

    $postcorrect = $_POST["postCorrectPost"] ?? ''; 
    $postincorrect = $_POST["postIncorrectPost"] ?? '';
    $posttime = $_POST["postTimePost"] ?? '';
    $postq_id = array();
    $postq_correct = array();
    $postq_certainty = array();

    for ($i = 0; $i < 32; $i++)
    {
      $postq_id[$i] = $_POST["q".$i."PostIDPost"] ?? '';
      $postq_correct[$i] = $_POST["q".$i."PostCorrectPost"] ?? '';
      $postq_certainty[$i] = $_POST["q".$i."PostCertaintyPost"] ?? '';
    }

    for ($i = 0; $i < 20; $i++)
    {
      $q_survey[$i] = $_POST["q".$i."SurveyPost"] ?? '';
    }

    for ($i = 0; $i < 20; $i++)
    {
      $q_teacher[$i] = $_POST["q".$i."TeacherPost"] ?? '';
    }

    //make connection
    $conn = new mysqli($hostname, $username, $password, $database);
    if(!$conn)
    {
      die("Connection failed: " . mysqli_connect_error());
    }

    $secretKey = "avocadotoast"; // Change this value to match the value stored in the client javascript below
    $str = $secretKey;
    $realHash = md5($str);

    if($realHash == $hash)
    {
      $sql = "INSERT INTO test_pretest (num_correct, num_incorrect, completion_time, q1_ID, q2_ID, q3_ID, q4_ID, q5_ID, q6_ID, q7_ID,
        q8_ID, q9_ID, q10_ID, q11_ID, q12_ID, q13_ID, q14_ID, q15_ID, q16_ID, q17_ID, q18_ID, q19_ID, q20_ID, q21_ID, q22_ID, q23_ID,
        q24_ID, q25_ID, q26_ID, q27_ID, q28_ID, q29_ID, q30_ID, q31_ID, q32_ID, q1_correct, q2_correct, q3_correct, q4_correct, q5_correct, q6_correct, q7_correct, q8_correct, q9_correct, q10_correct, q11_correct, q12_correct, q13_correct, q14_correct, q15_correct, q16_correct, q17_correct, q18_correct, q19_correct, q20_correct, q21_correct, q22_correct, q23_correct, q24_correct, q25_correct, q26_correct, q27_correct, q28_correct, q29_correct, q30_correct, q31_correct, q32_correct, q1_certainty, q2_certainty, q3_certainty, q4_certainty, q5_certainty, q6_certainty, q7_certainty, q8_certainty, q9_certainty, q10_certainty, q11_certainty, q12_certainty, q13_certainty, q14_certainty, q15_certainty, q16_certainty, q17_certainty, q18_certainty, q19_certainty, q20_certainty, q21_certainty, q22_certainty, q23_certainty, q24_certainty, q25_certainty, q26_certainty, q27_certainty, q28_certainty, q29_certainty, q30_certainty, q31_certainty, q32_certainty) VALUES ('".$precorrect."','".$preincorrect."','".$pretime."',";

      for ($i = 0; $i < 32; $i++) 
      { 
        $sql .= "'".$preq_id[$i]."',";
      }

      for ($i = 0; $i < 32; $i++) 
      { 
        $sql .= "'".$preq_correct[$i]."',";
      }

      for ($i = 0; $i < 32; $i++) 
      {
        if ($i < 31)
        {
          $sql .= "'".$preq_certainty[$i]."',";
        }
        else
        {
          $sql .= "'".$preq_certainty[$i]."');";
        }
      }

      $sql .= "INSERT INTO test_posttest (num_correct, num_incorrect, completion_time, q1_ID, q2_ID, q3_ID, q4_ID, q5_ID, q6_ID, q7_ID,
        q8_ID, q9_ID, q10_ID, q11_ID, q12_ID, q13_ID, q14_ID, q15_ID, q16_ID, q17_ID, q18_ID, q19_ID, q20_ID, q21_ID, q22_ID, q23_ID,
        q24_ID, q25_ID, q26_ID, q27_ID, q28_ID, q29_ID, q30_ID, q31_ID, q32_ID, q1_correct, q2_correct, q3_correct, q4_correct, q5_correct, q6_correct, q7_correct, q8_correct, q9_correct, q10_correct, q11_correct, q12_correct, q13_correct, q14_correct, q15_correct, q16_correct, q17_correct, q18_correct, q19_correct, q20_correct, q21_correct, q22_correct, q23_correct, q24_correct, q25_correct, q26_correct, q27_correct, q28_correct, q29_correct, q30_correct, q31_correct, q32_correct, q1_certainty, q2_certainty, q3_certainty, q4_certainty, q5_certainty, q6_certainty, q7_certainty, q8_certainty, q9_certainty, q10_certainty, q11_certainty, q12_certainty, q13_certainty, q14_certainty, q15_certainty, q16_certainty, q17_certainty, q18_certainty, q19_certainty, q20_certainty, q21_certainty, q22_certainty, q23_certainty, q24_certainty, q25_certainty, q26_certainty, q27_certainty, q28_certainty, q29_certainty, q30_certainty, q31_certainty, q32_certainty) VALUES ('".$precorrect."','".$preincorrect."','".$pretime."',";

      for ($i = 0; $i < 32; $i++) 
      { 
        $sql .= "'".$postq_id[$i]."',";
      }

      for ($i = 0; $i < 32; $i++) 
      { 
        $sql .= "'".$postq_correct[$i]."',";
      }

      for ($i = 0; $i < 32; $i++) 
      {
        if ($i < 31)
        {
          $sql .= "'".$postq_certainty[$i]."',";
        }
        else
        {
          $sql .= "'".$postq_certainty[$i]."');";
        }
      }

      $sql = "INSERT INTO test_survey (q1, q2, q3, q4, q5, q6, q7, q8, q9, q10, q11, q12, q13, q14, q15, q16, q17, q18, q19, q20) VALUES (";

      for ($i = 0; $i < 20; $i++) 
      { 
        if ($i < 19)
        {
          $sql .= "'".$q_survey[$i]."',";
        } else
        {
          $sql .= "'".$q_survey[$i]."');";
        }
      }

      $sql .= "INSERT INTO test_teacher (q1, q2, q3, q4, q5, q6, q7, q8, q9, q10, q11, q12, q13, q14, q15, q16) VALUES (";

      for ($i = 0; $i < 16; $i++) 
      { 
        if ($i < 15)
        {
          $sql .= "'".$q_teacher[$i]."',";
        } else
        {
          $sql .= "'".$q_teacher[$i]."');";
        }
      }

      if (mysqli_multi_query($conn, $sql)) 
      {
        echo "New records created successfully";
      } else {
        echo "Error: " . $sql . "<br>" . mysqli_error($conn);
      }
    }

    //Check Connection
    if(!$conn)
    {
      die("Connection Failed. ". mysqli_connect_error());
    }
?>
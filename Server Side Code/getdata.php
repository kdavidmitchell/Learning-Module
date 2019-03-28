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

    //make connection
  $conn = new mysqli($hostname, $username, $password, $database);
  if(!$conn){
    die("Connection failed: " . mysqli_connect_error());
  }

  $query = "SELECT * FROM test ORDER by session_id";
  $result = mysqli_query($conn, $query);

  if(mysqli_num_rows($result) > 0){
    //show data for each row
    while($row = mysqli_fetch_assoc($result)){
      echo " ID: ".$row['session_id']. " - Correct: ".$row['num_correct']. " - Incorrect: ".$row['num_incorrect']."\n";
    }
  }
 
    // try {
    //     $dbh = new PDO('mysql:host='. $hostname .';dbname='. $database, $username, $password);
    //     $dbh->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    //     echo "Connected successfully";
    // } catch(PDOException $e) {
    //     echo '<h1>An error has occurred.</h1><pre>', $e->getMessage() ,'</pre>';
    // }
 
    // $sth = $dbh->query('SELECT * FROM pretest_stats ORDER BY session_id');
    // $sth->setFetchMode(PDO::FETCH_ASSOC);
 
    // $result = $sth->fetchAll();
 
    // if(count($result) > 0) {
    //     foreach($result as $r) {
    //         echo $r['session_id'], "\t", $r['num_correct'], "\t", $r['num_incorrect'], "\n";
    //     }
    // }
?>
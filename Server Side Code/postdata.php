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

   $secretKey = "avocadotoast"; // Change this value to match the value stored in the client javascript below 

   try {
       $dbh = new PDO('mysql:host='. $hostname .';dbname='. $database, $username, $password);
   } catch(PDOException $e) {
       echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage() ,'</pre>';
   }

   $id = $_GET['id'];
   $correct = $_GET['correct'];
   $incorrect = $_GET['incorrect'];

   $realHash = md5($_GET['id'] . $_GET['correct'] . $_GET['incorrect'] . $secretKey);
   $hash = $_GET['hash'];

   if($realHash == $hash) { 
     $sth = $dbh->prepare('INSERT INTO pretest_stats VALUES (:id, :correct, :incorrect)');
     try {
         $sth->execute(['id' => $id, 'correct' => $correct, 'incorrect' => $incorrect]);
     } catch(Exception $e) {
         echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage() ,'</pre>';
     }
   }
?>
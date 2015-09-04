<?php
// Include the helper gateway class
require_once('AfricasTalkingGateway.php');

// Specify your login credentials
$username   = "MyAfricasTalkingUsername";
$apikey     = "MyAfricasTalkingAPIKey";

// Create a new instance of our awesome gateway class
$gateway  = new AfricaStalkingGateway($username, $apikey);

// Any gateway errors will be captured by our custom Exception class below, 
// so wrap the call in a try-catch block
try 
{
  // Our gateway will return 100 messages at a time back to you, starting with
  // what you currently believe is the lastReceivedId. Specify 0 for the first
  // time you access the gateway, and the ID of the last message we sent you
  // on subsequent results
  $lastReceivedId = 0;
  
  // Here is a sample of how to fetch all messages using a while loop
  do {
    
    $results = $gateway->fetchMessages($lastReceivedId);
    foreach($results as $result) {
      
      echo " From: " .$result->from;
      echo " To: " .$result->to;
      echo " Message: ".$result->text;
      echo " Date Sent: " .$result->date;
      echo " LinkId: " .$result->linkId;
      echo " id: ".$result->id;
      echo "\n";
      $lastReceivedId = $result->id;
      
    }
  } while ( count($results) > 0 );
  
  // NOTE: Be sure to save lastReceivedId here for next time
  
}
catch ( AfricasTalkingGatewayException $e )
{
  echo "Encountered an error: ".$e->getMessage();
}
?>

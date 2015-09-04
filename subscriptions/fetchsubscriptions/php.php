<?php
// Include the helper gateway class
require_once('AfricasTalkingGateway.php');

// Specify your login credentials
$username   = "MyAfricasTalkingUsername";
$apikey     = "MyAfricasTalkingAPIKey";

// Specify your premium shortcode and keyword
$shortCode = "XXXXX";
$keyword   = "myPremiumKeyword";

// Create a new instance of our awesome gateway class
$gateway  = new AfricasTalkingGateway($username, $apikey);

// Any gateway errors will be captured by our custom Exception class below, 
// so wrap the call in a try-catch block
try 
{
  // Our gateway will return 100 subscription numbers at a time back to you, starting with
  // what you currently believe is the lastReceivedId. Specify 0 for the first
  // time you access the gateway, and the ID of the last message we sent you
  // on subsequent results
  $lastReceivedId = 0;
  
  // Here is a sample of how to fetch all messages using a while loop
  do {
    
    $results = $gateway->fetchPremiumSubscriptions($shortCode, $keyword, $lastReceivedId);
    foreach($results as $result) {
      
      echo " From: " .$result->phoneNumber;
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

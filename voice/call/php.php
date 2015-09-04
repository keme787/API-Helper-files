<?php
// Be sure to include our gateway class
require_once('AfricasTalkingGateway.php');

// Specify your login credentials
$username   = "MyAfricasTalking_Username";
$apikey     = "MyAfricasTalking_APIKey";

// Specify your Africa's Talking phone number in international format
$from = "+254711082XYZ";

// Specify the numbers that you want to call to in a comma-separated list
// Please ensure you include the country code (+254 for Kenya in this case)
$to   = "+254711XXXYYY,+254733YYYZZZ";

// Create a new instance of our awesome gateway class
$gateway = new AfricasTalkingGateway($username, $apikey);

// Any gateway errors will be captured by our custom Exception class below, 
// so wrap the call in a try-catch block
try 
{
  // Make the call
  $gateway->call($from, $to);
  echo "Calls have been initiated. Time for song and dance!\n";
  // Our API will now contact your callback URL once the recipient answers the call!
}
catch ( AfricasTalkingGatewayException $e )
{
  echo "Encountered an error while making the call: ".$e->getMessage();
}

?>

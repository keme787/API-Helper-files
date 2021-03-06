<?php

require_once('AfricasTalkingGateway.php');

$username   = "MyAfricasTalkingUsername";
$apikey     = "MyAfricasTalkingAPIKey";

$recipients = "+254711XXXYYY,+254722YYYZZZ";

// Specify your premium shortCode and keyword
$shortCode = "XXXXX";
$keyword   = "premiumKeyword";

// Set the bulkSMSMode flag to 0 so that the subscriber gets charged
$bulkSMSMode = 0;

// Create an array which would hold the following parameters:
// keyword: Your premium keyword,
// retryDurationInHours: The numbers of hours our API should retry to send the message 
// incase it doesn't go through. It is optional

$options = array(
            'keyword'              => $keyword,
            'retryDurationInHours' => "No of hours to retry"
           );
           
$message = "Get your daily message and thats how we roll.";


$gateway    = new AfricasTalkingGateway($username, $apikey);

try 
{ 

  $results = $gateway->sendMessage($recipients, $message, $shortCode, $bulkSMSMode, $options);
  foreach($results as $result) {
    echo " Number: " .$result->number;
    echo " Status: " .$result->status;
    echo " MessageId: " .$result->messageId . "\n";
  }
}
catch ( AfricasTalkingGatewayException $e )
{
  echo "Encountered an error while sending: ".$e->getMessage();
}
?>

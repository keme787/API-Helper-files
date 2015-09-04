<?php
require_once('AfricasTalkingGateway.php');

$username   = "MyAfricasTalkingUsername";
$apikey     = "MyAfricasTalkingAPIKey";

$recipients = "+254711XXXYYY,+254722YYYZZZ";


$shortCode = "XXXXX";
$keyword   = "premiumKeyword"; // $keyword = null;

$bulkSMSMode = 0;

// Create an array which would hold parameters keyword, retryDurationInHours and linkId
// linkId is received from the message sent by subscriber to your onDemand service
$linkId = "messageLinkId";

$options = array(
            'keyword'             => $keyword,
            'linkId'              => $linkId,
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

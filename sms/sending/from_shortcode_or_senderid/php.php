<?php
//Sending Messages using sender id/short code

require_once('AfricasTalkingGateway.php');

$username   = "MyAfricasTalkingUsername";
$apikey     = "MyAfricasTalkingAPIKey";

$recipients = "+254711XXXYYY,+254733YYYZZZ";

$message    = "I'm a lumberjack and its ok, I sleep all night and I work all day";

// Specify your AfricasTalking shortCode or sender id
$from = "shortCode or senderId";

$gateway    = new AfricasTalkingGateway($username, $apikey);

try 
{
   
   $results = $gateway->sendMessage($recipients, $message, $from);
			
  foreach($results as $result) {
    echo " Number: " .$result->number;
    echo " Status: " .$result->status;
    echo " MessageId: " .$result->messageId;
    echo " Cost: "   .$result->cost."\n";
  }
}
catch ( AfricasTalkingGatewayException $e )
{
  echo "Encountered an error while sending: ".$e->getMessage();
}
?>

<?php
require_once('AfricasTalkingGateway.php');

$username   = "MyAfricasTalkingUsername";
$apikey     = "MyAfricasTalkingAPIKey";

$recipients = "+254711XXXYYY,+254733YYYZZZ";

$message    = "I'm a lumberjack and its ok, I sleep all night and I work all day";

$from = null; //$from = "shortCode or senderId";

$bulkSMSMode = 1; // This should always be 1 for bulk messages

// enqueue flag is used to queue messages incase you are sending a high volume.
// The default value is 0.
$options = array("enqueue" => 1);

$gateway    = new AfricasTalkingGateway($username, $apikey);

try 
{
   
   $results = $gateway.sendMessage($recipients, $message, $from, $bulkSMSMode, $options);
			
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

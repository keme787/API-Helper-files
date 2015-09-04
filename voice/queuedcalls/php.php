<?php
// Be sure to include our gateway class
require_once('AfricasTalkingGateway.php');

// Specify your login credentials
$username   = "MyAfricasTalking_Username";
$apikey     = "MyAfricasTalking_APIKey";

// Specify your Africa's Talking phone number in international format
// Comma separate them if they are more than one
$phoneNumbers = "+254711082XYZ,+254205134XYZ";

// Specify the numbers that you want to call to in a comma-separated list
// Please ensure you include the country code (+254 for Kenya in this case)

// Create a new instance of our awesome gateway class
$gateway = new AfricasTalkingGateway($username, $apikey);

// Any gateway errors will be captured by our custom Exception class below, 
// so wrap the call in a try-catch block
try 
{
  $results = $gateway->getNumQueuedCalls($phoneNumbers);
  
  foreach($results as $result) {
   echo "Phone number: " . $result->phoneNumber . "; ";
   echo "Queue name: " . $result->queueName . "; ";
   echo "Number of queued calls: " . $result->numCalls . "&lt;br/&gt;";
  }
}
catch ( AfricasTalkingGatewayException $e )
{
  echo "Encountered an error while making the call: ".$e->getMessage();
}

?>

</pre>	
</fieldset>

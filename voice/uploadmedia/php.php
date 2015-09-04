<?php
// Be sure to include our gateway class
require_once('AfricasTalkingGateway.php');

// Specify your login credentials
$username   = "MyAfricasTalking_Username";
$apikey     = "MyAfricasTalking_APIKey";

// Specify your the url of file to be uploaded
$file_url = "http://onlineMediaUrl.com/file.wav";

// Create a new instance of our awesome gateway class
$gateway = new AfricasTalkingGateway($username, $apikey);

// Any gateway errors will be captured by our custom Exception class below, 
// so wrap the call in a try-catch block
try 
{
  $gateway->uploadMediaFile($file_url);
  echo "File upload initiated. Time for song and dance!\n";
  
}
catch ( AfricasTalkingGatewayException $e )
{
  echo "Encountered an error while uploading file: ".$e->getMessage();
}

?>

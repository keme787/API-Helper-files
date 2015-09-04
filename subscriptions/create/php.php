<?php

	require_once "AfricasTalkingGateway.php";
	
		//Specify your credentials
		$username = "myAfricasTalkingUsername";
		$apiKey   = "myAfricasTalkingAPIKey";
		
	// Specify the number that you want to subscribe
	// Please ensure you include the country code (+254 for Kenya in this case)
	$phoneNumber   = "+254711YYYZZZ";
	
	//Specify your Africa's Talking short code and keyword
	$shortCode = "ABCDE";
	$keyword   = "myKeyword";
		
		//Create an instance of our awesome gateway class and pass your credentials
		$gateway = new AfricasTalkingGateway($username, $apiKey);
		
		// Thats it, hit send and we'll take care of the rest. Any errors will
   // be captured in the Exception class as shown below
   
   try {
    $result = $gateway->createSubscription($phoneNumber, $shortCode, $keyword);
    
    //Only status Success signifies the subscription was successfully
    echo $result->status;
    echo $result->description;
   }
   catch(AfricasTalkingGatewayException $e){
   	echo $e->getMessage();
   }
?>

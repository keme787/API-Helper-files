using System;

class MainClass
{
	static public void Main () {
		
		// Specify your login credentials
		string username = "MyAfricasTalking_Username";
		string apiKey   = "MyAfricasTalking_APIKey";

  
  	// Create a new instance of our awesome gateway class
			AfricasTalkingGateway gateway = new AfricasTalkingGateway (username, apiKey);

			// Any gateway errors will be captured by our custom Exception class below,
			// so wrap the call in a try-catch block          
			try {

				dynamic response = gateway.getUserData ();
				Console.WriteLine (response["balance"]);

			} catch (AfricasTalkingGatewayException e) {

				Console.WriteLine ("Encountered an error: " + e.Message);		

		}
	}
}

using System;

class MainClass {
	static public void Main () {
		
		// Specify your login credentials
		string username = "MyAfricasTalking_Username";
		string apiKey   = "MyAfricasTalking_APIKey";
		
		// Create a new instance of our awesome gateway class
		AfricasTalkingGateway gateway  = new AfricasTalkingGateway(username, apiKey);
		
		// Our gateway will return 10 messages at a time back to you, starting with
		// what you currently believe is the lastReceivedId. Specify 0 for the first
		// time you access the gateway, and the ID of the last message we sent you
		// on subsequent results
		
		int lastReceivedId = 0;
		
		// Any gateway errors will be captured by our custom Exception class below,
		// so wrap the call in a try-catch block
		
		try {
            
			// Here is a sample of how to fetch all messages using a while loop     
			do {
	        	
				dynamic results = gateway.fetchMessages(lastReceivedId);

				foreach(dynamic result in results) {
					Console.WriteLine("From: " + result["from"]);
					Console.WriteLine("To: " + result["to"]);
					Console.WriteLine("Message: " + result["text"]);
					Console.WriteLine("Date: " + result["date"]);
					Console.WriteLine("linkId: " + result["linkId"]);
					lastReceivedId = (int)result["id"];
				}
			} while ( results.Count > 0 );
			
		} catch (AfricasTalkingGatewayException e) {

			Console.WriteLine ("Encountered an error: " + e.Message);		
		
		}// NOTE: Be sure to save lastReceivedId here for next time                                                                                            

		// DONE!!!
	}
}

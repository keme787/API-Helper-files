using System;

class MainClass
{
	static public void Main (){
	
		// Specify your login credentials
		string username = "MyAfricasTalking_Username";
		string apiKey   = "MyAfricasTalking_APIKey"; 
		
		// Specify your AfricasTalking phone number in international format.
		// Comma separate them for more than one number
		string phoneNumbers = "+254711082XXX,+254205134YYY";
		
		// Create a new instance of our awesome gateway class
		AfricasTalkingGateway gateway = new AfricasTalkingGateway (username, apiKey);

		// Wrap the call in a try-catch block 
		// Any gateway errors will be captured by our custom Exception class below
		try {

			dynamic results = gateway.getNumQueuedCalls(phoneNumbers);
			
			foreach(dynamic result in results) {
			 Console.Write("Phone number: " + result["phoneNumber"]);
			 Console.Write("Queue name: " + result["queueName"]);
			 Console.WriteLine("Number of queued calls: " + result["numCalls"]);
			}

		} catch (AfricasTalkingGatewayException e) {

			Console.WriteLine ("Encountered an error: " + e.Message);		

		}
	}
}

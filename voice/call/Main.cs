using System;

class MainClass
{
	
	static public void testCalling ()
	{
		// Specify your login credentials
		string username = "MyAfricasTalking_Username";
		string apiKey   = "MyAfricasTalking_APIKey"; 
		
		// Specify your Africa's Talking phone number in international format
		string from = "+254711082XYZ";
		
		// Specify the numbers that you want to call to in a comma-separated list
		// Please ensure you include the country code (+254 for Kenya in this case)
		string to   = "+254711XXXYYY,+254733YYYZZZ";

		// Create a new instance of our awesome gateway class
		AfricasTalkingGateway gateway = new AfricasTalkingGateway (username, apiKey);

		// Any gateway error will be captured by our custom Exception class below,
		// so wrap the call in a try-catch block          
		try {

			gateway.call(from, to);
			Console.WriteLine ("Calls have been initiated. Time for song and dance!");
			
			// Our API will now contact your callback URL once the recipient answers the call!   

		} catch (AfricasTalkingGatewayException e) {

			Console.WriteLine ("Encountered an error: " + e.Message);		

		}
	}
}

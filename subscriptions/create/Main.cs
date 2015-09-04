using System;

class MainClass
{
	static public void Main (){
		
		// Specify your login credentials
		string username = "MyAfricasTalkingUsername";
		string apiKey   = "MyAfricasTalkingAPIKey";
		
		// Specify the number that you want to subscribe
		// Please ensure you include the country code (+254 for Kenya in this case)
		string phoneNumber   = "+254711YYYZZZ";
		
		//Specify your Africa's Talking premium short code and keyword
		string shortCode = "myAfricasTalkingShortCode";
		string keyword   = "myAfricasTalkingKeyword"; 
		
		//Create an instance of our gateway class and pass your login credentials
		AfricasTalkingGateway gateway = new AfricasTalkingGateway(username, apiKey);
		
		// Any gateway error will be captured by our custom Exception class as shown below, 
		// so wrap the call in a try-catch block          
		try {
			
			dynamic result = gateway.createSubscription(phoneNumber, shortCode, keyword);
			Console.WriteLine("Status: " + result["status"]);
			Console.WriteLine("Description: " + result["description"]);
			
		} catch (AfricasTalkingGatewayException e) {

			Console.WriteLine ("Encountered an error: " + e.Message);		

		}
	}
}

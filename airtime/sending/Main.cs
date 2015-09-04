using System;

class MainClass
{
	static public void Main (){
		
	// Specify your login credentials
		string username = "MyAfricasTalking_Username";
		string apiKey   = "MyAfricasTalking_APIKey";
		
		// Specify an array list to hold numbers to receive airtime
		ArrayList AirtimeRecipientsList = new ArrayList();
		
		// Declare hashtable to hold the first number
		// Please ensure you include the country code for phone numbers (+254 for Kenya in this case)
		// Specify the country currency and the amount as shown below (KES for Kenya in this case)
		
		Hashtable rec1      = new Hashtable();
		rec1["phoneNumber"] = "+254722XXXYYY";
		rec1["amount"]      = "KES XXX";
		
		// Add recipient to list
		AirtimeRecipientsList.Add(rec1);
		
		// Declare hashtable to hold the another number
		Hashtable rec2     = new Hashtable();
		rec2["phoneNumber"] = "+254722XXXYYY";
		rec2["amount"]      = "KES XXX";
		
		// Add recipient to list
		AirtimeRecipientsList.Add(rec2);
		
  // Create a new instance of our awesome gateway class
		AfricasTalkingGateway gateway = new AfricasTalkingGateway (username, apiKey);
		
	 try {
				// That's it. Hit send and we will handle the rest
				
				dynamic response = gateway.sendAirtime(AirtimeRecipientsList);
				foreach (dynamic result in response) {
					Console.Write (result["status"] + ",");
					Console.Write (result["phoneNumber"] + ",");
					Console.Write (result["amount"] + ",");
					Console.Write (result["discount"] + ",");
					Console.WriteLine (result["errorMessage"]);
				}
			}
			catch(AfricasTalkingGatewayException ex) {
				Console.WriteLine (ex.Message);
			}
	}
}

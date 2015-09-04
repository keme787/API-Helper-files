import org.json.*;

public class SendAirime 
{

	public static void main(String[] args) 
	{
		
		//Specify your credentials
		String username = "myAfricasTalkingUsername";
		String apiKey   = "myAfricasTalkingAPIKey";
		
		//Specify the phone number/s and amount in the format shown
		//Specify the country currency and the amount as shown below (KES for Kenya in this case)
		// Please ensure you include the country code for phone numbers (+254 for Kenya in this case)
		
		//Declare an json array to hold the recipients and the amount to send
		JSONArray recipients = new JArray();
		
		//Add the first recipient and the amount as a json object to the json array
		recipients.put(new JSONObject().put("phoneNumber","+254700XXXYYY").put("amount","KES XX"));
		
		//Add the second recipient and the amount as a json object to the json array
		recipients.put(new JSONObject().put("phoneNumber","+254733YYYZZZ").put("amount","KES YY"));
		
		//Convert the recipient array into a string. The string produced will have the format:
		// [{"amount":"KES 100", "phoneNumber":+254700XXXYYY},{"amount":"KES 100", "phoneNumber":+254733YYYZZZ}]
		//A string with the shown format may be created directly and skip the above steps
		String recipientStringFormat = recipients.toString();
		
		//Create an instance of our awesome gateway class and pass your credentials
		AfricasTalkingGateway gateway = new AfricasTalkingGateway(username, apiKey);
		
		// Thats it, hit send and we'll take care of the rest. Any errors will
   // be captured in the Exception class as shown below
   
   try {
   	
   	//That's it. Hit send and we will handle the rest 
   	JSONArray results = gateway.sendAirtime(recipientStringFormat);
   	int length = results.length();
   	for(int i = 0; i < length; i++) {
   	 JSONObject result = results.getJSONObject(i);
   	 System.out.println(result.getString("status"));
   	 System.out.println(result.getString("amount"));
   	 System.out.println(result.getString("phoneNumber"));
   	 System.out.println(result.getString("discount"));
   	 System.out.println(result.getString("requestId"));
   	 
   	 //Error message is important when the status is not Success
   	 System.out.println(result.getString("errorMessage"));
   	}
   }
   catch(Exception e){
   	System.out.println(e.getMessage());
   }
	}
}

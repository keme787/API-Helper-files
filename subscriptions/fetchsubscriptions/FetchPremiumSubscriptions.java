// Make sure the downloaded jar file is in the classpath
import org.json.*;

public class FetchPremiumSubscriptions
{
    public static void main(String[] args_)
    {
	     // Specify your login credentials
	     String username = "MyAfricasTalkingUsername";
	     String apiKey   = "MyAfricasTalkingAPIKey";
	     
	     // Specify your premium shortcode and keyword
	     
	     String shortCode = "XXXXX";
	     String keyword   = "myPremiumKeyword";
	
	     // Create a new instance of our awesome gateway class
	     AfricasTalkingGateway gateway  = new AfricasTalkingGateway(username, apiKey);
	
	    // Our gateway will return 100 subscription numbers at a time back to you, starting with
	    // what you currently believe is the lastReceivedId. Specify 0 for the first
	    // time you access the gateway, and the ID of the last message we sent you
	    // on subsequent results
	    int lastReceivedId = 0;
	
	    // Here is a sample of how to fetch all messages using a while loop
	    try {
	       JSONArray results = null;
	       do {
		         results = gateway.fetchPremiumSubscriptions(shortCode, keyword, lastReceivedId);
		         for(i = 0; i < results.length(); i++) {
		            JSONObject result = results.getJSONObject(i);
		            System.out.println(result.getString("phoneNumber"));
		            lastReceivedId = result.getInt("id");
		         }
	       } while ( results.length() > 0 );
	   }
	   
	   catch (Exception e) {
	      System.out.println("Caught an Exception: " + e.getMessage());
   	}
	
	// NOTE: Be sure to save lastReceivedId here for next time
	
	// DONE!!!
    }
}

import org.json.*;
import java.util.HashMap;

public class TestSending
{
    public static void main(String[] args_)
    {
    	
	     String username = "MyUsername";
	     String apiKey   = "MyAPIKey";
	     
	     String recipients = "+254711XXXYYY,+254733YYYZZZ";
	     
	     String message = "Get your daily message and thats how we roll.";
	
	     // Specify your premium shortcode and keyword
	     String shortCode = "XXXXX";
	     String keyword = "premiumKeyword";
	     
	     // Set the bulkSMSMode flag to 0 so that the subscriber get charged
	     int bulkSMSMode = 0;
	     
	     // Create a hashmap which would hold the following parameters:
	     // keyword: Your premium keyword,
	     // retryDurationInHours: The numbers of hours our API should retry to send the message 
	     // incase it doesn't go through. It is optional
	     
	     HashMap<String, String> options = new HashMap<String, String>();
	     options.put("keyword", keyword);
	     options.put("retryDurationInHours", "No. of hours to retry sending message");
	     
	     AfricasTalkingGateway gateway  = new AfricasTalkingGateway(username, apiKey);
	     
	     try  {
	     	
	        JSONArray results = gateway.sendMessage(recipients, message, from, bulkSMSMode, options);
	        for( int i = 0; i < results.length(); ++i ) {
		          JSONObject result = results.getJSONObject(i);
		          System.out.print(result.getString("status") + ",");
		          System.out.print(result.getString("number") + ",");
		          System.out.print(result.getString("messageId") + ",");
	    }
   	}
   	
   	catch (Exception e) {
	    System.out.println("Encountered an error while sending " + e.getMessage());
	    }
	
   }
}

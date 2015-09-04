import org.json.*;
import java.util.HashMap;

public class PremiumOnDemand
{
    public static void main(String[] args_)
    {
    	
	     String username = "MyUsername";
	     String apiKey   = "MyAPIKey";
	     
	     String recipients = "+254711XXXYYY,+254733YYYZZZ";
	     
	     String message = "Get your daily message and thats how we roll.";
	
	     String shortCode = "XXXXX";
	     String keyword = "premiumKeyword"; // String keyword = null;
	     
	     int bulkSMSMode = 0;
	     
	     // Create a hashmap which would hold parameters keyword, retryDurationInHours and linkId
	     // linkId is received from the message sent by subscriber to your onDemand service
	     String linkId = "messageLinkId";
	     
	     HashMap<String, String> options = new HashMap<String, String>();
	     options.put("keyword", keyword);
	     options.put("linkId", linkId);
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

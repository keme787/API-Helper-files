import org.json.*;
import java.util.HashMap;

public class MessageQueueing
{
    public static void main(String[] args_)
    {
	     String username = "MyUsername";
	     String apiKey   = "MyAPIKey";
	
	     String recipients = "+254711XXXYYY,+254733YYYZZZ";
	
	     String message = "We are lumberjacks. We code all day and sleep all night";
	     
	     String from = null; //String from = "shortCode or senderId";
	     
	     int bulkSMSMode = 1; // This should always be 1 for bulk messages
	     
	     // enqueue flag is used to queue messages incase you are sending a high volume.
	     // The default value is 0.
	     HashMap<String, int> options = new HashMap<String, int>();
	     options.put("enqueue", 1);
	
	     AfricasTalkingGateway gateway  = new AfricasTalkingGateway(username, apiKey);
	     
	    try {
	        JSONArray results = gateway.sendMessage(recipients, message, from, bulkSMSMode, options);
			
	        for( int i = 0; i < results.length(); ++i ) {
		          JSONObject result = results.getJSONObject(i);
		          System.out.print(result.getString("status") + ",");
		          System.out.print(result.getString("number") + ",");
		          System.out.print(result.getString("messageId") + ",");
		          System.out.println(result.getString("cost"));
	    }
   	}
   	
   	catch (Exception e) {
	    System.out.println("Encountered an error while sending " + e.getMessage());
	    }
	
   }
}

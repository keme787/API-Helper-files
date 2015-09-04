import org.json.*;
import java.util.HashMap;

public class FromShortCodeOrSenderId
{
    public static void main(String[] args_)
    {
	     String username = "MyUsername";
	     String apiKey   = "MyAPIKey";
	
	     String recipients = "+254711XXXYYY,+254733YYYZZZ";
	
	     String message = "We are lumberjacks. We code all day and sleep all night";
	     
	     // Specify your AfricasTalking shortCode or sender id
	     String from = "shortCode or senderId";
	
	     AfricasTalkingGateway gateway  = new AfricasTalkingGateway(username, apiKey);
	     
	    try {
	        JSONArray results = gateway.sendMessage(recipients, message, from);
			
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

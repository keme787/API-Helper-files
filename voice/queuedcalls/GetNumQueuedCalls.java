// Make sure the downloaded jar file is in the classpath
import org.json.*;

public class GetNumQueuedCalls
{
    public static void main(String[] args_)
    {
	     // Specify your login credentials
	     String username = "MyAfricasTalking_Username";
	     String apiKey   = "MyAfricasTalking_APIKey";
	
	     // Specify your Africa's Talking phone number in international format
	     // Comma separate them for more than one number
	     String phoneNumbers = "+254711082XYZ,+254205134XYZ";
	
	     // Create a new instance of our awesome gateway class
	     AfricasTalkingGateway gateway  = new AfricasTalkingGateway(username, apiKey);
	
	     // Wrap the call in a try-catch block
	     // Any gateway errors will be captured by our custom Exception class below
     	try {
	         JSONArray queuedCalls = gateway.getNumQueuedCalls(phoneNumbers);
	         
	         int length = queuedCalls.length;
	         
	         for(int i = 0; i < length; i++) {
	         	JSONObject result = queuedCalls.getJSONObject(i);
	         	System.out.println("Phone number: " + result.getString("phoneNumber"));
	         	System.out.println("Queue name: " + result.getString("queueName"));
	         	System.out.println("Number of queued calls: " + result.getString("queuedCalls"));
	         }
	         
     	} 
     	
     	catch (Exception e) {
	         System.out.println("Encountered an error" + e.getMessage());
	    }
	
    }
}

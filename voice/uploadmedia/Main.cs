using System;

class MainClass
{
	static public void Main (){
		
		// Specify your login credentials
		string username = "MyAfricasTalking_Username";
		string apiKey   = "MyAfricasTalking_APIKey"; 
		
		// Specify your the url of file to be uploaded
		string url = "http://onlineMediaUrl.com/file.wav";
		
		// Create a new instance of our awesome gateway class
		AfricasTalkingGateway gateway = new AfricasTalkingGateway (username, apiKey);

		// Any gateway errors will be captured by our custom Exception class below,                                                                                                                       
        // so wrap the call in a try-catch block          
		try {

			gateway.uploadMediaFile(url);
			Console.WriteLine ("File upload initiated. Time for song and dance!");  

		} catch (AfricasTalkingGatewayException e) {

			Console.WriteLine ("Encountered an error: " + e.Message);		

		}
	}
}

Imports System.IO
Imports System.Collections
Imports System.Collections.Generic

Public Class Application
	Public Shared Sub Main()
		
			' Specify your login credentials
			
			Dim username As String = "myAfricasTalkingUsername"
			Dim apikey As String   = "myAPIKey"
			
			' Create a new instance of our awesome gateway class
			Dim gateway As New AfricasTalkingGateway(username, apikey)
			
			' Specify your AfricasTalking phone number in international format. eg +254711082XXX
			Dim from As String = "AfricasTalkingPhoneNumber"
			
			' Specify the numbers that you want to call to in a comma-separated list in international format
			Dim to As String = "+254711XXXYYY,+254733YYYZZZ"
			
			' Wrap the call in a try-catch block.
			' Any gateway error will be captured by our custom Exception class below
			
			Try
				gateway.call(from, to);
				System.Console.WriteLine ("Calls have been initiated. Time for song and dance!");
				
				' Our API will now contact your callback URL once the recipient answers the call!  
				
			catch ex As AfricasTalkingGatewayException
				System.Console.WriteLine(ex.Message())
			End Try 
	End Sub
End Class
}

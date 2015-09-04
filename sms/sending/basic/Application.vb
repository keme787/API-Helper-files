Imports System.IO
Imports System.Collections
Imports System.Collections.Generic

Public Class Application
	Public Shared Sub Main()
		
			' Specify your login credentials
			
			Dim username As String = "myAfricasTalkingUsername"
			Dim apikey As String   = "myAPIKey"
			
			' Specify the numbers that you want to send to in a comma-separated list
			' Please ensure you include the country code (+254 for Kenya in this case)
			Dim recipients As String = "+254711XXXYYY,+254733YYYZZZ"
			
			' And of course we want our recipients to know what we really do
			Dim message As String = "I'm a lumberjack and its ok, I sleep all night and I work all day"
			
			' Create a new instance of our awesome gateway class
			Dim gateway As New AfricasTalkingGateway(username, apikey)
			
			' Any gateway error will be captured by our custom Exception class below,
			' so wrap the call in a try-catch block
			
			
			Try
			 ' Hit send and we will handle the rest
				Dim response as object() = gateway.sendMessage(recipients, message)
				
				Dim result as object
				for each result in response
					System.Console.WriteLine("Status: " + result("status")) ' status is either "Success" or "error message"
					System.Console.WriteLine("MessageID: " + result("messageId"))
					System.Console.WriteLine("phoneNumber: " + result("number"))
					System.Console.WriteLine("Cost: " + result("cost"))
				next
		catch ex As AfricasTalkingGatewayException
			System.Console.WriteLine(ex.Message())
		End Try 
	End Sub
End Class

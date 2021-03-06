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
			
			' Our gateway will return 100 messages at a time back to you, starting with
			' what you currently believe is the lastReceivedId. Specify 0 for the first
			' time you access the gateway, and the ID of the last message we sent you
			' on subsequent results
			
			Dim lastReceivedId As Integer = 0;
			
			' Any gateway errors will be captured by our custom Exception class below,
			' so wrap the call in a try-catch block
			
			Try
			 
			 Dim messages As Object() = gateway.fetchMessages(lastReceivedId)
			 
			 While messages.Length > 0
			 	
			 	Dim result As Object
			 	for each result in messages
			 		System.Console.WriteLine("from: " + result("from"))
			 		System.Console.WriteLine("to: " + result("to"))
			 		System.Console.WriteLine("message: " + result("text"))
			 		System.Console.WriteLine("date: " + result("date"))
			 		System.Console.WriteLine("linkId: " + result("linkId"))
			 		lastReceivedId = result("id")
			 	next
			 	
			 	messages = gateway.fetchMessages(lastReceivedId)
			 	
			 End While
			 
		catch ex As AfricasTalkingGatewayException
			System.Console.WriteLine(ex.Message())
		End Try 
	End Sub
End Class

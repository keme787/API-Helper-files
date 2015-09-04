Imports System.IO
Imports System.Collections
Imports System.Collections.Generic

Public Class Application
	Public Shared Sub Main()
		
			' Specify your login credentials
			
			Dim username As String = "myAfricasTalkingUsername"
			Dim apikey As String   = "myAPIKey"
			
			' Specify your premium shortcode and keyword
			Dim shortCode As String = "XXXXX";
			Dim keyword As String = "myPremiumKeyword";
			
			' Create a new instance of our awesome gateway class
			Dim gateway As New AfricasTalkingGateway(username, apikey)
			
			' Our gateway will return 100 subscription numbers at a time back to you, starting with
			' what you currently believe is the lastReceivedId. Specify 0 for the first
			' time you access the gateway, and the ID of the last number we sent you
			' on subsequent results
			
			Dim lastReceivedId As Integer = 0;
			
			' Any gateway errors will be captured by our custom Exception class below,
			' so wrap the call in a try-catch block
			
			Try
			 
			 Dim subscriptions As Object() = gateway.fetchPremiumSubscriptions(shortCode, keyword, lastReceivedId)
			 
			 While subscriptions.Length > 0
			 	
			 	Dim result As Object
			 	for each result in subscriptions
			 		System.Console.WriteLine("Phone number: " + result("phoneNumber"))
			 		lastReceivedId = result("id")
			 	next
			 	
			 	subscriptions = gateway.fetchPremiumSubscriptions(shortCode, keyword, lastReceivedId)
			 	
			 End While
			 
		catch ex As AfricasTalkingGatewayException
			System.Console.WriteLine(ex.Message())
		End Try 
	End Sub
End Class

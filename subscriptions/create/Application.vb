Imports System.IO
Imports System.Collections
Imports System.Collections.Generic

Public Class Application
	Public Shared Sub Main()
		
			' Specify your login credentials
			
			Dim username As String = "myAfricasTalkingUsername"
			Dim apikey As String   = "myAPIKey"
			
			' Specify the number that you want to subscribe
			' Please ensure you include the country code (+254 for Kenya in this case)
			Dim phoneNumber As String  = "+254711YYYZZZ"
			
			' Specify your Africa's Talking premium short code and keyword
			Dim shortCode As String = "myAfricasTalkingShortCode"
			Dim keyword As String  = "myAfricasTalkingKeyword"
			
			' Create a new instance of our awesome gateway class
			Dim gateway As New AfricasTalkingGateway(username, apikey)
			
			' Wrap the function call in a Try block
			' Any Exception will be captured by our custom AfricasTalkingException class
			
			Try
				Object result = gateway.createSubscription(phoneNumber, shortCode, keyword)
				System.Console.WriteLine("Status: " + result("status"))
				System.Console.WriteLine("Description: " + result("description"))
				
			catch ex As AfricasTalkingGatewayException
				System.Console.WriteLine(ex.Message())
		
		End Try 
	End Sub
End Class

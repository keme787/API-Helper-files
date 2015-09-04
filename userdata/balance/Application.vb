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
			
			' Wrap the function call in a Try block
			' Any Exception will be captured by our custom AfricasTalkingException class
			
			Try
				Object userData = gateway.getUserData()
				Dim balance As String = userData("balance")
				System.Console.WriteLine("Balance: " + balance)
				
			catch ex As AfricasTalkingGatewayException
				System.Console.WriteLine(ex.Message())
		
		End Try 
	End Sub
End Class

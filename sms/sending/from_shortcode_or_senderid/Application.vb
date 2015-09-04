Imports System.IO
Imports System.Collections
Imports System.Collections.Generic

Public Class Application
	Public Shared Sub Main()
			
			Dim username As String = "myAfricasTalkingUsername"
			Dim apikey As String   = "myAPIKey"
			
			Dim recipients As String = "+254711XXXYYY,+254733YYYZZZ"
			
			Dim message As String = "I'm a lumberjack and its ok, I sleep all night and I work all day"
			
			' Specify your AfricasTalking shortCode or sender id
			Dim sender As String = "shortCode or senderId";
			
			Dim gateway As New AfricasTalkingGateway(username, apikey)
			
			Try
			 ' Hit send and we will handle the rest
				Dim response as object() = gateway.sendMessage(recipients, message, sender)
				
				Dim result as object
				for each result in response
					System.Console.WriteLine("Status: " + result("status"))
					System.Console.WriteLine("MessageID: " + result("messageId"))
					System.Console.WriteLine("phoneNumber: " + result("number"))
					System.Console.WriteLine("Cost: " + result("cost"))
				next
		catch ex As AfricasTalkingGatewayException
			System.Console.WriteLine(ex.Message())
		End Try 
	End Sub
End Class

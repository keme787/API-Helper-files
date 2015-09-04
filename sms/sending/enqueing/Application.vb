Imports System.IO
Imports System.Collections
Imports System.Collections.Generic

Public Class Application
	Public Shared Sub Main()
			
			Dim username As String = "myAfricasTalkingUsername"
			Dim apikey As String   = "myAPIKey"
			
			Dim recipients As String = "+254711XXXYYY,+254733YYYZZZ"
			
			Dim message As String = "I'm a lumberjack and its ok, I sleep all night and I work all day"
			
			Dim sender As String = Nothing 'Dim sender As String = "shortCode or senderId";
			
			Dim bulkSMSMode As Integer = 1 ' This should always be 1 for bulk messages
			
			' enqueue flag is used to queue messages incase you are sending a high volume.
			' The default value is 0.
			Dim options As New Hashtable()
			options("enqueue") = 1;
			
			Dim gateway As New AfricasTalkingGateway(username, apikey)
			
			Try
			
				 Dim response as object() = gateway.sendMessage(recipients, message, sender, bulkSMSMode, options)
				
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

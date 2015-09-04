Imports System.IO
Imports System.Collections
Imports System.Collections.Generic

Public Class Application
	Public Shared Sub Main()
	 
	 	Dim username As String = "myAfricasTalkingUsername"
	 	Dim apikey As String   = "myAPIKey"
	 
	 	Dim recipients As String = "+254711XXXYYY,+254722YYYZZZ"
	 
	 	Dim shortCode As String = "XXXXX"
	 	Dim keyword As String   = "premiumKeyword" ' Dim keyword As String = Nothing
	 
	 	Dim bulkSMSMode As Integer = 0
	 	
	 	' Create a hashtable which would hold parameters keyword, retryDurationInHours and linkId
	 	' linkId is received from the message sent by subscriber to your onDemand service
	   Dim linkId As String = "messageLinkId"
	 	
	 	Dim options As New Hashtable();
	 	options("keyword")              = keyword
	 	options("linkId")               = linkId
	 	options("retryDurationInHours") = "No of hrs to retry eg. 6"
	 	
	 	Dim message As String = "Get your daily message and thats how we roll."
	 	
	 	Dim gateway As New AfricasTalkingGateway(username, apikey)
			
			
			Try
			
				Dim response as object()= gateway.sendMessage(recipients, message, shortCode, bulkSMSMode, options)
				
				Dim result as object
				for each result in response
					System.Console.WriteLine("Status: " + result("status"))
					System.Console.WriteLine("MessageID: " + result("messageId"))
					System.Console.WriteLine("phoneNumber: " + result("number"))
				next
				
		catch ex As AfricasTalkingGatewayException
			System.Console.WriteLine(ex.Message())
			
		End Try 
		
	End Sub
End Class

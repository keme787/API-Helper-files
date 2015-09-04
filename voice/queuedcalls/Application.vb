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
			' Comma-separate them if they are more than one
			Dim phoneNumbers As String = "+254711082XXX,+254205134YYY"
			
			' Wrap the call in a try-catch block.
			' Any gateway error will be captured by our custom Exception class below
			
			Try
			
				Dim results As Object() = gateway.getNumQueuedCalls(phoneNumbers)
				
				Dim result As Object
				
				for each result in results
				 Dim numQueuedCalls As Integer = result("numCalls")
					System.Console.WriteLine ("Phone number: " + result("phoneNumber"))
					System.Console.WriteLine ("Queue name: " + result("queueName"))
					System.Console.WriteLine ("Phone number: " + CType(numQueuedCalls, String))
				next
				
			catch ex As AfricasTalkingGatewayException
				System.Console.WriteLine(ex.Message())
				
			End Try 
	End Sub
End Class
}


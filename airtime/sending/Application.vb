Imports System.IO
Imports System.Collections
Imports System.Collections.Generic

Public Class Application
	Public Shared Sub Main()
		
			' Specify your login credentials
			
			Dim username As String = "myAfricasTalkingUsername"
			Dim apikey As String   = "myAPIKey"
			
			' Specify an list to hold the airtime recipient numbers and the amount to be sent
			
			Dim airtimeRecipientsList As New List(Of Hashtable)()
			
			' Declare hashtable to hold the first recipient and amount sent to them
			' Please ensure you include the country code for phone numbers (+254 for Kenya in this case)
			' Specify the country currency and the amount as shown below (KES for Kenya in this case)
			
			Dim recipient1 As New Hashtable()
			recipient1("phoneNumber") = "+254711XXXYYY"
			recipient1("amount")      = "KES XX"
			
			' Add the recipient to airtimeRecipientsList
			airtimeRecipientsList.add(recipient1)
			
			
			' Declare hashtable to hold the second recipient
			
			Dim recipient2 As New Hashtable()
			recipient2("phoneNumber") = "+254733YYYZZZ"
			recipient2("amount")      = "KES YY"
			
			' Add the recipient to airtimeRecipientsList
			airtimeRecipientsList.add(recipient2)
			
			' Create a new instance of our awesome gateway class
			Dim gateway As New AfricasTalkingGateway(username, apikey)
			
			
			Try
			 ' Hit send and we will handle the rest
				Dim response as object()= gateway.sendAirtime(airtimeRecipientsList)
				
				Dim result as object
				for each result in response
					System.Console.WriteLine("Status: " + result("status"))
					System.Console.WriteLine("RequestID: " + result("requestId"))
					System.Console.WriteLine("phoneNumber: " + result("phoneNumber"))
					System.Console.WriteLine("Discount: " + result("discount"))
					System.Console.WriteLine("amount: " + result("requestId"))
					
					' Incase the status result is Failed
					System.Console.WriteLine("ErrorMessage: " + result("errorMessage"))
				next
		catch ex As AfricasTalkingGatewayException
			System.Console.WriteLine(ex.Message())
		End Try 
	End Sub
End Class

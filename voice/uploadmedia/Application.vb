Imports System.IO
Imports System.Collections
Imports System.Collections.Generic

Public Class Application
	Public Shared Sub Main()
		
			' Specify your login credentials
			
			Dim username As String = "myAfricasTalkingUsername"
			Dim apikey As String   = "myAPIKey"
			
			' Specify the url of the online media file to upload
			Dim onlineUrlMedia As String = "http://onlineMediaUrl.com/file.wav"
			
			' Create a new instance of our awesome gateway class
			Dim gateway As New AfricasTalkingGateway(username, apikey)
			
			
			Try
			
				gateway.uploadMediaFile(onlineUrlMediaFile)
				System.Console.WriteLine("File upload initiated. Time for song and dance!");

			catch ex As AfricasTalkingGatewayException
				System.Console.WriteLine(ex.Message())
		End Try 
	End Sub
End Class


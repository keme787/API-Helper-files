#! /usr/bin/python

#Import our gateway class and custom Exception class
from AfricasTalkingGateway import AfricasTalkingGateway, AfricasTalkingGatewayException

#Specify your credentials
username = "myAfricasTalkingUsername"
apiKey   = "myAfricasTalkingAPIKey"

#Specify the number that you want to subscribe
#Please ensure you include the country code (+254 for Kenya in this case)
phoneNumber   = "+254711YYYZZZ";
	
#Specify your Africa's Talking short code and keyword
shortCode = "myAfricasTalkingShortCode";
keyword   = "myAfricasTalkingKeyword";
		
#Create an instance of our awesome gateway class and pass your credentials
gateway = AfricasTalkingGateway(username, apiKey);
		
#Thats it, submit data and we'll take care of the rest. Any errors will
#be captured in the Exception class as shown below

try:
	response = gateway.createSubscription (phoneNumber, shortCode, keyword)
except AfricasTalkingGatewayException as e:
	print "Error:%s" %str(e)
else:
	#Only status Success signifies the subscription was successfully
	print "Status: %s \n Description: %s" %(response.status, response.description)

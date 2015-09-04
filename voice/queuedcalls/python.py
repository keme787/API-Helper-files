#! /usr/bin/python

# Be sure to import helper gateway class
from AfricasTalkingGateway import AfricasTalkingGateway, AfricasTalkingGatewayException

# Specify your login credentials
username = "MyAfricasTalking_Username"
apikey   = "MyAfricasTalking_APIKey"

# Specify your Africa's Talking phone number in international format 
#Comma separate them if they are more than one
phoneNumbers = "+254711082XYZ,+254205134YYY"

# Create a new instance of our awesome gateway class
gateway  = AfricasTalkingGateway(username, apikey)

# Wrap the call in a try-catch block
# Any gateway errors will be captured by our custom Exception class below, 
try:
	# Get queued calls
	queuedcalls = gateway.getNumQueuedCalls(phoneNumbers)
	
	for result in queuedCalls:
		print "phoneNumber: %s; queueName: %s; number of queued calls: %s \n" % (
		                                                          result['phoneNumber'],
		                                                          result['queueName'],
		                                                          result['numCalls']
		                                                         )
except AfricasTalkingGatewayException, e:
	print 'Encountered an error while making the call: %s' % str(e)

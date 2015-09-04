#! /usr/bin/python

# Be sure to import helper gateway class
from AfricasTalkingGateway import AfricasTalkingGateway, AfricasTalkingGatewayException

# Specify your login credentials
username = "MyAfricasTalking_Username"
apikey   = "MyAfricasTalking_APIKey"

# Create a new instance of our awesome gateway class
gateway  = AfricasTalkingGateway(username, apikey)

# Any gateway errors will be captured by our custom Exception class below, 
# so wrap the call in a try-catch block
try:
	user = gateway.getUserData()
	print user['balance']
except AfricasTalkingGatewayException, e:
	print 'Error: %s' % str(e)

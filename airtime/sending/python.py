#! /usr/bin/python

# Import the helper gateway class
from AfricasTalkingGateway import AfricasTalkingGateway, AfricasTalkingGatewayException

# Specify your login credentials
username   = "MyUsername";
apikey     = "MyAPIKey";

# Specify an array of dicts to hold the recipients and the amount to send
recipients = []

#Append the first recipient to array
recipients.append({"phoneNumber" : "+2547XXAAABBB", 
               "amount"      : "KES XX"})

#Append another recipient for many clients
recipients.append({"phoneNumber" : "+2547XXYYYZZZ", 
               "amount"      : "KES XX"})

# Create a new instance of our awesome gateway class
gateway    = AfricasTalkingGateway(username, apikey)

try:
    # Thats it, hit send and we'll take care of the rest. 
    responses = gateway.sendAirtime(recipients)
    for response in responses:
        print "phoneNumber=%s; amount=%s; status=%s; discount=%s; requestId=%s" % (
                                                                       response['phoneNumber'],
                                                                       response['amount'],
                                                                       response['status'],
                                                                       response['discount']
                                                                       response['requestId']
                                                                      )

except AfricasTalkingGatewayException, e:
    print 'Encountered an error while sending airtime: %s' % str(e)

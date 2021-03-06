#! /usr/bin/python

from AfricasTalkingGateway import AfricasTalkingGateway, AfricasTalkingGatewayException

username = "MyAfricasTalkingUsername"
apikey   = "MyAfricasTalkingAPIKey"

to      = "+254711XXXYYY,+254722YYYZZZ"


message = "Get your daily message and thats how we roll.";

# Specify your premium shortCode and keyword
# Set keyword as None where not used (Mostly for onDemand services)

shortCode = "XXXXX"
keyword   = "premiumKeyword" # keyword = None

# Set the bulkSMSMode flag to 0 so that the subscriber gets charged
bulkSMSMode = 0

# Set the enqueue flag to 0 so that your message will not be queued or to 1 for many messages
enqueue    = 0

# Incase of an onDemand service, specify the link id. else set it to none
# linkId is received from the message sent by subscriber to your onDemand service
linkId = "messageLinkId" #linkId = None

# Specify retryDurationInHours: The numbers of hours our API should retry to send the message
# incase it doesn't go through. It is optional
retryDurationInHours = "No of hours to retry"

gateway = AfricasTalkingGateway(username, apikey)

try:
    
    recipients = gateway.sendMessage(to, message, shortCode, bulkSMSMode, enqueue, keyword, linkId, retryDurationInHours)
    for recipient in recipients:
        print 'number=%s;status=%s;messageId=%s' % (recipient['number'],
                                                    recipient['status'],
                                                    recipient['messageId'])
except AfricasTalkingGatewayException, e:
    print 'Encountered an error while sending: %s' % str(e)

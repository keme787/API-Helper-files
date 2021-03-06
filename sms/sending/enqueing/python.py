#! /usr/bin/python

from AfricasTalkingGateway import AfricasTalkingGateway, AfricasTalkingGatewayException

username = "MyAfricasTalkingUsername"
apikey   = "MyAfricasTalkingAPIKey"

to      = "+254711XXXYYY,+254733YYYZZZ"

message = "I'm a lumberjack and it's ok, I sleep all night and I work all day"

sender = None # sender = "shortCode or sender id"

bulkSMSMode = 1    # This should always be 1 for bulk messages

# enqueue flag is used to queue messages incase you are sending a high volume.
# The default value is 0.
enqueue = 1

gateway = AfricasTalkingGateway(username, apikey)

try:
    
    results = gateway.sendMessage(to, message, sender, bulkSMSMode, enqueue)
    
    for recipient in results:
        # Note that only the Status "Success" means the message was sent
        print 'number=%s;status=%s;messageId=%s;cost=%s' % (recipient['number'],
                                                            recipient['status'],
                                                            recipient['messageId'],
                                                            recipient['cost'])
except AfricasTalkingGatewayException, e:
    print 'Encountered an error while sending: %s' % str(e)

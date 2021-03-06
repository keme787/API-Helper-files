#! /usr/bin/python

from AfricasTalkingGateway import AfricasTalkingGateway, AfricasTalkingGatewayException

username = "MyAfricasTalkingUsername"
apikey   = "MyAfricasTalkingAPIKey"

to      = "+254711XXXYYY,+254733YYYZZZ"

message = "I'm a lumberjack and it's ok, I sleep all night and I work all day"

# Specify your AfricasTalking shortCode or sender id
sender = "shortCode or senderId"

gateway = AfricasTalkingGateway(username, apikey)

try:
    
    results = gateway.sendMessage(to, message, sender)
    
    for recipient in results:
        # Note that only the Status "Success" means the message was sent
        print 'number=%s;status=%s;messageId=%s;cost=%s' % (recipient['number'],
                                                            recipient['status'],
                                                            recipient['messageId'],
                                                            recipient['cost'])
except AfricasTalkingGatewayException, e:
    print 'Encountered an error while sending: %s' % str(e)

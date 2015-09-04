require './AfricasTalkingGateway'

# Specify your login credentials
username = "MyAfricasTalkingUsername"
apikey   = "MyAfricasTalkingAPIKey"

to      = "+254711XXXYYY,+254722YYYZZZ"

# Specify your premium shortCode and keyword
# Set keyword as None where not used (Mostly for onDemand services)

shortCode = "XXXXX"
keyword   = "premiumKeyword" # keyword = nil

# Set the bulkSMSMode flag to 0 so that the subscriber gets charged
bulkSMSMode = 0

# Set the enqueue flag to 0 so that your message will not be queued or to 1 for many messages
enqueue    = 0

# Incase of an onDemand service, specify the link id. else set it to nil
# linkId is received from the message sent by subscriber to your onDemand service

linkId     = "messageLinkId" # linkId = nil

# Specify retryDurationInHours: The numbers of hours our API should retry to send the message
# incase it doesn't go through. It is optional
retryDurationInHours = "No of hours to retry"

# And of course we want our recipients to get our daily quote
message = "Get your daily message and thats how we roll."

gateway = AfricasTalkingGateway.new(username, apikey)

# Any gateway error will be captured by our custom Exception class below,
# so wrap the call in a try-catch block
begin

  reports = gateway.sendMessage(to, message, shortCode, bulkSMSMode, enqueue, keyword, linkId, retryDurationInHours)
  reports.each {|x|
    puts 'number=' + x.number + ';status=' + x.status + ';messageId=' + x.messageId
  }
rescue AfricasTalkingGatewayException => ex
  puts 'Encountered an error: ' + ex.message
end

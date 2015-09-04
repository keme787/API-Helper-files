require './AfricasTalkingGateway'

username = "MyAfricasTalkingUsername";
apikey   = "MyAfricasTalkingAPIKey";

to      = "+254711XXXYYY,+254733YYYZZZ";

message = "I'm a lumberjack and it's ok, I sleep all night and I work all day"

sender = nil # sender = "shortCode or sender id"

bulkSMSMode = 1    # This should always be 1 for bulk messages

# enqueue flag is used to queue messages incase you are sending a high volume.
# The default value is 0.
enqueue = 1

gateway = AfricasTalkingGateway.new(username, apikey)

begin

  reports = gateway.sendMessage(to, message, sender, bulkSMSMode, enqueue)
  
  reports.each {|x|
    puts 'number=' + x.number + ';status=' + x.status + ';messageId=' + x.messageId + ';cost=' + x.cost
  }
rescue AfricasTalkingGatewayException => ex
  puts 'Encountered an error: ' + ex.message
end

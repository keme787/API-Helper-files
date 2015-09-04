require './AfricasTalkingGateway'

username = "MyAfricasTalkingUsername";
apikey   = "MyAfricasTalkingAPIKey";

to      = "+254711XXXYYY,+254733YYYZZZ";

message = "I'm a lumberjack and it's ok, I sleep all night and I work all day"

# Specify your AfricasTalking shortCode or sender id
sender = "shortCode or senderId"

gateway = AfricasTalkingGateway.new(username, apikey)

begin
  # Thats it, hit send and we'll take care of the rest.
  reports = gateway.sendMessage(to, message, sender)
  
  reports.each {|x|
    puts 'number=' + x.number + ';status=' + x.status + ';messageId=' + x.messageId + ';cost=' + x.cost
  }
rescue AfricasTalkingGatewayException => ex
  puts 'Encountered an error: ' + ex.message
end

# Include the helper gateway class
require './AfricasTalkingGateway'

# Specify your login credentials
username = "MyAfricasTalking_Username";
apikey   = "MyAfricasTalking_APIKey";

# Specify your AfricasTalking phone number in the international format(Comma separate them if many)
phoneNumbers = "+254711082XYZ,+254205134YYY";

# Create a new instance of our awesome gateway class
gateway  = AfricasTalkingGateway.new(username, apikey)

# Any gateway errors will be captured by our custom Exception class below,
# so wrap the call in a try-catch block
begin
  results = gateway.getNumQueuedCalls(phoneNumbers)
  results.each{|res|
  	puts "Phone number: " + res.phoneNumber + "; Queue name: " + res.queueName + "; Number of queued calls: " + res.numCalls + "\n";
  }

rescue AfricasTalkingGatewayException => ex
  puts 'Encountered an error: ' + ex.message
end


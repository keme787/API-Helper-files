# Include the helper gateway class
require 'AfricasTalkingGateway'

# Specify your login credentials
username = "MyAfricasTalking_Username";
apikey   = "MyAfricasTalking_APIKey";


# Create a new instance of our awesome gateway class
gateway = AfricasTalkingGateway.new(username, apikey)

# Any gateway errors will be captured by our custom Exception class below,
# so wrap the call in a try-catch block
begin
	user = gateway.getUserData()
	puts user['balance']
rescue AfricasTalkingGatewayException => ex
	puts "Encountered an error: " + ex.message
end



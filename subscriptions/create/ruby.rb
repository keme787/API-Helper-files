# Include the helper gateway class
require './AfricasTalkingGateway'

# Specify your login credentials
username = "MyAfricasTalkingUsername";
apikey   = "MyAfricasTalkingAPIKey";

#Specify the number that you want to subscribe
#Please ensure you include the country code (+254 for Kenya in this case)
phoneNumber   = "+254711YYYZZZ";
	
#Specify your Africa's Talking short code and keyword
shortCode = "myAfricasTalkingShortCode";
keyword   = "myAfricasTalkingKeyword";

# Create a new instance of our awesome gateway class
gateway = AfricasTalkingGateway.new(username, apikey)

# Any gateway error will be captured by our custom Exception class below,
# so wrap the call in a try-catch block
begin
  result = gateway.createSubscription(phoneNumber, shortCode, keyword)
  puts 'status=' + result['status'] + ' ;Description=' + result['description']
rescue AfricasTalkingGatewayException => ex
  puts 'Encountered an error: ' + ex.message
end

# DONE!

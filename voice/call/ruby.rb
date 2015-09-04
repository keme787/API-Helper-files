# Include the helper gateway class
require './AfricasTalkingGateway'

# Specify your login credentials
username = "MyAfricasTalking_Username";
apikey   = "MyAfricasTalking_APIKey";

# Specify your Africa's Talking phone number in international format
callFrom = "+254711082XYZ";

# Specify the numbers that you want to call to in a comma-separated list
# Please ensure you include the country code (+254 for Kenya in this case)
callTo   = "+254711XXXYYY,+254733YYYZZZ";

# Create a new instance of our awesome gateway class
gateway  = AfricasTalkingGateway.new(username, apikey)

# Any gateway errors will be captured by our custom Exception class below,
# so wrap the call in a try-catch block
begin
  # Make the call
  gateway.call(callFrom, callTo)
  puts "Calls have been initiated. Time for song and dance!\n";
  # Our API will now contact your callback URL once recipient answers the call!
rescue AfricasTalkingGatewayException => ex
  puts 'Encountered an error: ' + ex.message
end

# DONE!

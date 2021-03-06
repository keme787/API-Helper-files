# Include the helper gateway class
require './AfricasTalkingGateway'

# Specify your login credentials
username = "MyAfricasTalkingUsername";
apikey   = "MyAfricasTalkingAPIKey";

#Create an array to hold all the recipients
recipients = Array.new

#Add the first recipient
recipients << {"phoneNumber" => "+254711XXXYYY", "amount" => "KES XX"}

#Another reciepient
recipients << {"phoneNumber" => "+254733YYYZZZ", "amount" => "KES YY"}

# Create a new instance of our awesome gateway class
gateway = AfricasTalkingGateway.new(username, apikey)

# Any gateway errors will be captured by our custom Exception class below,
# so wrap the call in a try-catch block
begin
  # Thats it, hit send and we'll take care of the rest.
  results = gateway.sendAirtime(recipients)
  results.each {|x|
    # Note that only the Status "Success" means the airtime was sent
    puts 'number=' + x.phoneNumber + '; status=' + x.status + '; requestId=' + x.requestId + '; amount=' + x.amount + "; discount=" + x.discount
	
	#incase the status is not equal to success, it is important to list the error message
	puts 'ErrorMessage=' + x.errorMessage
  }
rescue AfricasTalkingGatewayException => ex
  puts 'Encountered an error: ' + ex.message
end

# DONE!

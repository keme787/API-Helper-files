# Be sure to import the helper gateway class
require './AfricasTalkingGateway'

# Specify your login credentials
username = 'MyUsername'
apikey   = 'MyApikey'

# Create a new instance of our awesome gateway class
gateway = AfricasTalkingGateway.new(username, apikey)

# Any gateway errors will be captured by our custom Exception class below,
# so wrap the call in a try-catch block
begin
  # Our gateway will return 100 subscribers at a time back to you, starting with
  # what you currently believe is the lastReceivedId. Specify 0 for the first
  # time you access the gateway, and the ID of the last message we sent you
  # on subsequent results
  last_received_id = 0

  while true
    subscribers = gateway.fetchPremiumSubscriptions(last_received_id)
    subscribers.each {|x|
      puts "id = #{x.id}; phone number = #{x.phoneNumber}"
      last_received_id = x.id
    }
    break if subscribers.length == 0
  end

rescue AfricasTalkingGatewayException => ex

  puts 'Encountered an error: ' + ex.message

end

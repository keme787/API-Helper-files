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
  # Our gateway will return 10 messages at a time back to you, starting with
  # what you currently believe is the lastReceivedId. Specify 0 for the first
  # time you access the gateway, and the ID of the last message we sent you
  # on subsequent results
  last_received_id = 0

  while true
    messages = gateway.fetch_messages(last_received_id)
    messages.each {|x|
      puts 'from=' + x.from + 'to=' + x.to + ';text=' + x.text + ';linkId=' + x.linkId + ';date=' + x.date
      last_received_id = x.id
    }
    break if messages.length == 0
  end

rescue AfricasTalkingGatewayException => ex

  puts 'Encountered an error: ' + ex.message

end

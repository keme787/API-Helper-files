# Include the helper gateway class
require './AfricasTalkingGateway'

# Specify your login credentials
username = "MyAfricasTalking_Username";
apikey   = "MyAfricasTalking_APIKey";

# Specify your the url of file to be uploaded
file_url = "http://onlineMediaUrl.com/file.wav";

# Create a new instance of our awesome gateway class
gateway  = AfricasTalkingGateway.new(username, apikey)

# Any gateway errors will be captured by our custom Exception class below,
# so wrap the call in a try-catch block
begin
  gateway.uploadMediaFile(file_url)
  puts "File upload initiated. Time for song and dance!\n";

rescue AfricasTalkingGatewayException => ex
  puts 'Encountered an error: ' + ex.message
end


#! /usr/bin/python

# Be sure to import helper gateway class
from AfricasTalkingGateway import AfricasTalkingGateway, AfricasTalkingGatewayException

# Specify your login credentials
username = "MyAfricasTalking_Username";
apikey   = "MyAfricasTalking_APIKey";

# Specify the url of the file to be uploaded
fileUrl = "http://onlineMediaUrl.com/file.wav";

# Create a new instance of our awesome gateway class
gateway  = AfricasTalkingGateway(username, apikey)

# Any gateway errors will be captured by our custom Exception class below, 
# so wrap the call in a try-catch block
try:
    # Make the call
    gateway.upladMediaFile(fileUrl)
    print "File upload initiated. Time for song and dance!\n";
except AfricasTalkingGatewayException, e:
    print 'Encountered an error while uploading the file: %s' % str(e)


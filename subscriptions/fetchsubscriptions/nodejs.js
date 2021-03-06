// Import the required libraries
var https = require('https');

// Your login credentials
var username  = 'MyUsername';
var apikey    = 'MyApiKey';

var shortCode = "12345";
var keyword   = "myAfricasTalkingKeyword";

function fetchPremiumSubscriptions(lastReceivedId_) {
	//create request parameters
	var request_parameters = {
                host    : 'api.africastalking.com',
                port    : 443,
                path    : '/version1/subscription?username=' + username + '&shortCode=' + shortCode_ + '&keyword=' + keyword_ + '&lastReceivedId=' + lastReceivedId_,
                
                method  : 'GET',
                
                rejectUnauthorized : false,
                requestCert        : true,
                agent              : false,
                
                headers : {
                	      'apikey' : apikey,
                	      'Accept' : 'application/json'
                	     }
           }
											
		var request = https.request(request_parameters, function (response) {
      	response.setEncoding('utf8');
      	response.on('data', function (data_chunk) {
      		try {
      			if (response.statusCode != 200)
      				throw data_chunk;
      				
      			var jsObject = JSON.parse(data_chunk);
      			var subscription_data = jsObject.SubscriptionData.Subscriptions;
      			if (subscription.length > 0) {
        			for (subscription in subscription_data) {
        			   var logStr   = 'Number : ' + subscription.phoneNumber;
        			   logStr      += ';id : ' + subscription.id;
        			   lastReceivedId_ = subscription.id;
        			   console.log(logStr);
        		 }
        		 
        		 //fetch subscriptions recursively
        		 fetchPremiumSubscriptions(lastReceivedId_);
        		}
      		}
      		catch (error) {
      			console.log('Error: ' + error);
      		}
      	});
      });
	request.end();
	
}

var lastReceivedId = 0;

//Call get user function;
fetchPremiumSubscriptions(lastReceivedId_);

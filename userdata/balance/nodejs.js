// Import the required libraries
var https = require('https');

// Your login credentials
var username = 'MyUsername';
var apikey   = 'MyApiKey';

function getUserData() {
	//create request parameters
	var request_parameters = {
		 host    : 'api.africastalking.com',
		 port    : 443,
		 path    : '/version1/user?username=' + username,
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
    			var userData = jsObject.UserData;
    			var logStr   = 'Balance : ' + jsObject.balance;
    			console.log(logStr);
    		}
    		catch (error) {
    			console.log('Error: ' + error);
    		}
    	});
    });
	request.end();
	
}

console.log("Call get user function");
getUserData();

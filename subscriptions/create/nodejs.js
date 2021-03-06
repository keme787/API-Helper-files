//import the required libraries

var querystring = require('querystring');
var https       = require('https');


//Set your AfricasTalking API login credentials
var username = "myAfricasTalkingUsername";
var apiKey   = "myAfricasTalkingAPIkey";

//create createSubscription function
function createSubscription(phoneNumber_, shortCode_, keyword_) {
	
	//Build post string from object
	var post_data = querystring.stringify({
	      'username'    : username,
	      'phoneNumber' : phoneNumber_,
	      'shortCode'   : shortCode_,
	      'keyword'     : keyword_	
	});
	
	//Create request parameters
	var request_parameters = {
       host : 'api.africastalking.com',
       port : 443,
       path : '/version1/subscription/create',
       
       method : 'POST',
       
       rejectUnauthorized : false,
       requestCert        : true,
       agent              : false,
       
       headers : {
       	          
            'Content-Type'    : 'application/x-www-form-urlencoded',
            'Content-Length'  : post_data.length,
            'apikey'          : apiKey,
            'Accept'          : 'application/json'
         }
    };
	                        
 var post_request = https.request(request_parameters, function (response) {
 	  response.setEncoding('utf8');
 	  response.on('data', function (data_chunk) {
 	  	try {
 	  	   if (response.statusCode != 201)
 	  	    throw data_chunk;
 	  	   
 	  	   var jsObject = JSON.parse(response);
 	  	   var logStr   = "Status : "     + jsObject.status;
 	  	   logStr       = "; Description" + jsObject.description;
 	  	   console.log(logStr);
 	  	 }
 	  	 catch(error) {
 	  	  console.log("Error:" + error);
 	  	 }
 	  });
 });
 
 post_request.write(post_data);
 post_request.end();
}

var phoneNumber = "+254722XXXYYY";
var shortCode   = "12345";
var keyword     = "myKeyword";

//call the function
createSubscription(phoneNumber, shortCode, keyword);

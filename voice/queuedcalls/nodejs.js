// Import the required libraries
var querystring = require('querystring');
var https       = require('https');

// Your login credentials
var username  = 'MyUsername';
var apikey    = 'MyApiKey';

// Specify your AfricasTalking phone number in the international format
// Comma separate the  numbers if they are more than one
var phoneNumbers = "+254711082XXX,+254205134YYY";

//set queueName = null if no queue name is set
var queueName = "myQueueName";

function getQueuedCalls() {
	//Build post string from object
	var post_data = {
		                 'username'     : username,
		                 'phoneNumbers'  : phoneNumbers
		               }
	
	if(queueName)
	 post_data.queueName = queueName;
	
	post_data = querystring.stringify(post_data);
	
	//create request parameters
	var request_parameters = {
       host               : 'voice.africastalking.com',
       port               : 443,
       path               : '/queueStatus',
       method             : 'POST',
       
       rejectUnauthorized : false,
       requestCert        : true,
       agent              : false,

       headers : {

         'Content-Type'    : 'application/x-www-form-urlencoded',
         'Content-Length'  : post_data.length,
         'apikey'          : apikey,
         'Accept'          : 'application/json'
      }
	 }
	 
	 var request = https.request(request_parameters, function (response) {
			response.setEncoding('utf8');
			response.on('data', function (data_chunk) {
			 try {
			 	var jsObject = JSON.parse(data_chunk);
			 	if(jsObject.status != "Success")
			 	 throw jsObject.errorMessage;
			 	 
			 	 var entries = jsObject.entries;
			 	 var logStr = "";
			 	 
			 	 for(result in entries) {
			 	 	logStr  += '\nPhone numbers : ' + entries.phoneNumber;
			 	 	logStr  += ';Queue name : ' + entries.queueName;
			 	 	logStr  += ';Number of queued calls : ' + entries.numCalls;
			 	 }
			 	 console.log(logStr);
   		}
   		catch (error) {
   			console.log('Error: ' + error);
   			}
   		});
   	});
	
	request.write(post_data);
	request.end();
	
}
//Call get user function;
getQueuedCalls();

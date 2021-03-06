//Import the required libraries
querystring = require('querystring');
https       = require('https');

var username = "myAfricasTalkingUsername";
var apiKey   = "myAfricasTalkingAPIkey";

//create the call function
function uploadMediaFile(locationURL_) {
	//Build post string from object
	
 var post_data = querystring.stringify({
       'username'  : username,
       'url'       : locationURL_
 });
 
 //create the request parameter object
 
 var request_parameters = {
	     host    : 'voice.africastalking.com',
	     port    : 443,
	     path    : '/mediaUpload',
	     
	     method  : 'POST',
	     
	     rejectUnauthorized : false,
	     requestCert        : true,
	     agent              : false,
	     
	     headers : { 
         'Content-Type'   : 'application/x-www-form-urlencoded',
         'Content-Length' : post_data.length,
         'apikey'         : apiKey,
         'Accept'         : 'application/json'
      }
	  }
                         
  request = https.request(request_parameters, function (response) {
  	response.setEncoding('utf8');
  	response.on('data', function (data_chunk) {
  		try {
  			var jsObject = JSON.parse(data_chunk);
  			if(jsObject.Status != "Success")
  			 throw jsObject.ErrorMessage;
  			 
  			 console.log('File uploaded. Time for song and dance');
  		}
  		catch (error) {
  			console.log("Error: " + error);
  			}
  		});
  	});
  
  request.write(post_data);
  request.end();
}

var url = "http://onlineMediaUrl.com/file.wav";

//call the function
uploadMediaFile(url);

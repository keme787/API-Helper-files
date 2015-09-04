var querystring = require('querystring');
var https       = require('https');

var username = 'MyAfricasTalkingUsername';
var apikey   = 'MyAfricasTalkingApiKey';

function sendMessage() {
	
	    var to      = '+254721XXXYYY';
	    
	    var shortCode = "XXXXX";
	    var keyword = "premiumKeyword"; // var keyword = null
	    
	    var bulkSMSMode = 0;
	    
	    // Set the linkId parameter
	    // linkId is received from the message sent by subscriber to your onDemand service
	    
	    var linkId = "messageLinkId";
	         
	    var retryDurationInHours = "No. of hours to retry";
	    
	    var message = "Get your daily message and thats how we roll.";
	    
    // Build the post string from an object
    var post_data = querystring.stringify({
	    'username'             : username,
	    'to'                   : to,
	    'message'              : message,
	    'from'                 : shortCode,
	    'keyword'              : keyword,
	    'linkId'               : linkId,
	    'retryDurationInHours' : retryDurationInHours
	});
	
	var post_options = {
		host   : 'api.africastalking.com',
		path   : '/version1/messaging',
		method : 'POST',
		
		rejectUnauthorized : false,
		requestCert        : true,
		agent              : false,
		
		headers: {
		    'Content-Type' : 'application/x-www-form-urlencoded',
		    'Content-Length': post_data.length,
		    'Accept': 'application/json',
		    'apikey': apikey
		}
	};
    
    var post_req = https.request(post_options, function(response) {
	    response.setEncoding('utf8');
	    response.on('data', function (chunk) {
	    	try {
	    		if(response.statusCode != 201)
	    		 throw chunk;
	    		 
	    		 var jsObject   = JSON.parse(chunk);
	    		 var recipients = jsObject.SMSMessageData.Recipients;
	    		 if ( recipients.length > 0 ) {
	    		 	for (var i = 0; i < recipients.length; ++i ) {
	    		 		var logStr  = 'number=' + recipients[i].number;
	    		 		logStr     += ';messageId='   + recipients[i].messageId;
	    		 		logStr     += ';status=' + recipients[i].status;
	    		 		console.log(logStr);
		    		}
		    	}
		    }
		   
		   catch(errorStr) {
		     console.log(errorStr);
		   }
		});
	});
    
    post_req.write(post_data);
    post_req.end();
}

sendMessage();


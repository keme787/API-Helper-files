// We need this to build our post string
var querystring = require('querystring');
var https       = require('https');

// Your login credentials
var username = 'MyUsername';
var apikey   = 'MyApiKey';

function fetchMessages(lastReceivedId_) {
    // Build the post string from an object
    var options = {
		host: 'api.africastalking.com',
		port: '443',
		path: '/version1/messaging?username=' + username + '&lastReceivedId=' + lastReceivedId_,
		method: 'GET',
		
		rejectUnauthorized : false,
		requestCert        : true,
		agent              : false,
  
		headers: {
		    'Accept': 'application/json',
		    'apikey': apikey
		}
    };
    
    var request = https.request(options, function(res) {
	    res.setEncoding('utf8');
	    res.on('data', function (chunk) {
		    var jsObject = JSON.parse(chunk);
		    var messages = jsObject.SMSMessageData.Messages;
		    if ( messages.length > 0 ) {
			for (var i = 0; i < messages.length; ++i ) {
			    var logStr  = 'from=' + messages[i].from;
			    logStr     += ';to='   + messages[i].to;
			    logStr     += ';message=' + messages[i].text;
			    logStr     += ';linkId=' + messages[i].linkId;
			    logStr     += ';date=' + messages[i].date;
			    logStr     += ';id=' + messages[i].id;
			    lastReceivedId_ = messages[i].id;
			    console.log(logStr);
			}
			
			// Recursively fetch messages
			fetchMessages(lastReceivedId_);
			
		    } 
		});
	});
    
    request.end();
    console.log('LastReceivedId: ' + lastReceivedId_);
}

var lastReceivedId = 0;
fetchMessages(lastReceivedId);

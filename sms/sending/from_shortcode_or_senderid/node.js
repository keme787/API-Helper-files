var querystring = require('querystring');
var https       = require('https');

var username = 'MyAfricasTalkingUsername';
var apikey   = 'MyAfricasTalkingApiKey';

function sendMessage() {
	
	var to      = '+254721XXXYYY,+852YYYZZZ,+1XXXYYYZZZ';
	
	var message = "I'm a lumberjack and its ok, I sleep all night and I work all day";
	
	// Specify your AfricasTalking shortCode or sender id
	var from = "shortCode or senderId";
	
	var post_data = querystring.stringify({
		 'username' : username,
		 'to'       : to,
		 'message'  : message,
		 'from'     : from
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
	var post_req = https.request(post_options, function(res) {
		
		res.setEncoding('utf8');
		res.on('data', function (chunk) {
			var jsObject   = JSON.parse(chunk);
			var recipients = jsObject.SMSMessageData.Recipients;
			if ( recipients.length > 0 ) {
				for (var i = 0; i < recipients.length; ++i ) {
					var logStr  = 'number=' + recipients[i].number;
					logStr     += ';cost='   + recipients[i].cost;
					logStr     += ';status=' + recipients[i].status;
					console.log(logStr);
					}
				} else {
					console.log('Error while sending: ' + jsObject.SMSMessageData.Message);
				}
		});
	});
	
	post_req.write(post_data);
	
	post_req.end();
}

//Call sendMessage method
sendMessage();


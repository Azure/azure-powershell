var http = require("http");
var port = process.env.port || 1337;
var url = require("url");
var mc = require("mc");
var mcclient = new mc.Client('localhost_ClientRole');
mcclient.connect(function() {
    console.log("Connected to the localhost memcache on port 11211!");
});
    

function start(route, handle) {
     function onRequest(request, response) {
         var postData = "";    
         var pathname = url.parse(request.url).pathname;
         console.log("Request for " + pathname + " received.");

         request.setEncoding("utf8"); 
         request.addListener("data", function (postDataChunk) {
             postData += postDataChunk; 
             console.log("Received POST data chunk '" + postDataChunk + "'.");
         }); 
         request.addListener("end", function () {
              route(handle, pathname, response, postData,mcclient);
         });
      }
   
    http.createServer(onRequest).listen(port); 
    console.log("Server has started.");
}
exports.start = start;
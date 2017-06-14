var querystring = require("querystring");
function get(response, postData, mcclient) {
    
    response.writeHead(200, { "Content-Type": "text/html" });
    response.write('<head><meta http-equiv="Content-Type" content="text/html;charset=UTF-8" /></head><body>');
    var key = querystring.parse(postData).key;
    mcclient.get(key, function (err, cacheresponse) {
        if (!err) {
            response.write('The Value With Key <b> ' + key + '</b> Is <b> ' + cacheresponse[key] + '</b></br>');
            response.write('<a href="additem">Add New Item</a></br><a href="getitem">Get Existing Item</a></body></html>');
            response.end();

        } else {
            response.write('Not Found or Something Went Wrong</br>');
            response.write('<a href="additem">Add New Item</a></br><a href="getitem">Get Existing Item</a></body></html>');
            response.end();
        }
    });
    
}

function add(response,postData,mcclient) {
    var key = querystring.parse(postData).key;
    var value = querystring.parse(postData).value;
    mcclient.add(key, value, { flags: 0, exptime: 0 }, function (err, status) {
        if (!err) {
            response.writeHead(200, { "Content-Type": "text/html" });
            response.write('<head><meta http-equiv="Content-Type" content="text/html;charset=UTF-8" /></head><body>');
            response.write('Item Saved</br>');
            response.write('<a href="additem">Add New Item</a></br><a href="getitem">Get Existing Item</a></body></html>');
            response.end();

        } else {
            response.writeHead(200, { "Content-Type": "text/plain" });
            response.write("Error saving to cache");
            response.end();
        }
        
    });
}

function additem(response, postData, mcclient) {
    
    response.writeHead(200, { "Content-Type": "text/html" });
    response.write('<head><meta http-equiv="Content-Type" content="text/html;charset=UTF-8" /><form action="/add" method="post">Key <input name="key" type="text"/></br>Value <input name="value" type="text"/></br><input type="submit" value="Add To Cache" /></form></html>');
    response.end();

}
function getitem(response, postData, mcclient) {

    response.writeHead(200, { "Content-Type": "text/html" });
    response.write('<head><meta http-equiv="Content-Type" content="text/html;charset=UTF-8" /><form action="/get" method="post">Key <input name="key" type="text"/></br><input type="submit" value="Get From Cache" /></form></html>');
    response.end();

}
exports.get = get;
exports.additem = additem;
exports.getitem = getitem;
exports.add = add;
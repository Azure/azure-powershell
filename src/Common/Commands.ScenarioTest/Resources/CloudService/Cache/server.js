var index = require("./index");
var router = require("./router");
var requestHandlers = require("./requestHandlers");

var handle = {}
handle["/"] = requestHandlers.additem;
handle["/get"] = requestHandlers.get;
handle["/additem"] = requestHandlers.additem;
handle["/getitem"] = requestHandlers.getitem;
handle["/add"] = requestHandlers.add;
index.start(router.route, handle);
function handler(event) {
    var request = event.request;
    var response = event.response;
    var now = event.context.now;

    // Set 403 Forbidden status code
    response.response_code = 403;

    // Add header to indicate the request was rejected
    response.headers['X-Request-Rejected'] = "true";
    return event;
}

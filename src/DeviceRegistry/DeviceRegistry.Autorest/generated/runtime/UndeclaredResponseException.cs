/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using static Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime.Extensions;

    public class RestException : Exception, IDisposable
    {
        public System.Net.HttpStatusCode StatusCode { get; set; }
        public string Code { get; protected set; }
        protected string message;
        public HttpRequestMessage RequestMessage { get; protected set; }
        public HttpResponseHeaders ResponseHeaders { get; protected set; }

        public string ResponseBody { get; protected set; }
        public string ClientRequestId { get; protected set; }
        public string RequestId { get; protected set; }

        public override string Message => message;
        public string Action { get; protected set; }

        public RestException(System.Net.Http.HttpResponseMessage response)
        {
            StatusCode = response.StatusCode;
            //CloneWithContent will not work here since the content is disposed after sendAsync
            //Besides, it seems there is no need for the request content cloned here.
            RequestMessage = response.RequestMessage.Clone();
            ResponseBody = response.Content.ReadAsStringAsync().Result;
            ResponseHeaders = response.Headers;

            RequestId = response.GetFirstHeader("x-ms-request-id");
            ClientRequestId = response.GetFirstHeader("x-ms-client-request-id");

            try
            {
                // try to parse the body as JSON, and see if a code and message are in there.
                var json = Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime.Json.JsonNode.Parse(ResponseBody) as Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime.Json.JsonObject;

                // error message could be in properties.statusMessage
                { message = If(json?.Property("properties"), out var p)
                    && If(p?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime.Json.JsonString>("statusMessage"), out var sm)
                    ? (string)sm : (string)Message; }

                // see if there is an error block in the body
                json = json?.Property("error") ?? json;

                { Code = If(json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime.Json.JsonString>("code"), out var c) ? (string)c : (string)StatusCode.ToString(); }
                { message = If(json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime.Json.JsonString>("message"), out var m) ? (string)m : (string)Message; }
                { Action = If(json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime.Json.JsonString>("action"), out var a) ? (string)a : (string)Action; }
            }
#if DEBUG
            catch (System.Exception E)
            {
                System.Console.Error.WriteLine($"{E.GetType().Name}/{E.Message}/{E.StackTrace}");
            }
#else 
            catch
            {
                // couldn't get the code/message from the body response. 
                // In this case, we will assume the response is the expected error message
                if(!string.IsNullOrEmpty(ResponseBody)) {
                    message = ResponseBody;
                }
            }
#endif
            if (string.IsNullOrEmpty(message))
            {
                if (StatusCode >= System.Net.HttpStatusCode.BadRequest && StatusCode < System.Net.HttpStatusCode.InternalServerError)
                {
                    message = $"The server responded with a Request Error, Status: {StatusCode}";
                }
                else if (StatusCode >= System.Net.HttpStatusCode.InternalServerError)
                {
                    message = $"The server responded with a Server Error, Status: {StatusCode}";
                }
                else
                {
                    message = $"The server responded with an unrecognized response, Status: {StatusCode}";
                }
            }
        }

        public void Dispose()
        {
            ((IDisposable)RequestMessage).Dispose();
        }
    }

    public class RestException<T> : RestException
    {
        public T Error { get; protected set; }
        public RestException(System.Net.Http.HttpResponseMessage response, T error) : base(response)
        {
            Error = error;
        }
    }


    public class UndeclaredResponseException : RestException
    {
        public UndeclaredResponseException(System.Net.Http.HttpResponseMessage response) : base(response)
        {

        }
    }
}
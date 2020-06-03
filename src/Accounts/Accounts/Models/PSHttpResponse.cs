using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Profile.Models
{
    public class PSHttpResponse
    {
        public HttpResponseHeaders Headers { get; }

        public string Version { get; set; }

        public int StatusCode { get; set; }

        public string Method { get; set; }

        public string Content { get; set; }

        public PSHttpResponse(AzureOperationResponse<string> response)
        {         
            this.Headers = response.Response.Headers;
            this.Version = response.Response.Version.ToString();
            this.StatusCode = (int)response.Response.StatusCode;
            this.Method = response.Response.RequestMessage.Method.Method;
            this.Content = response.Body;
        }
    }
}

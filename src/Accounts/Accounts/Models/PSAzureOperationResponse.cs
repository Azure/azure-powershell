using System;
using System.Net.Http;
using System.Net;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Profile.Models
{
    public class PSAzureOperationResponse
    {
        public string CorrelationId { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public HttpMethod Method { get; set; }

        public bool IsSuccessStatusCode { get; set; }

        public string ReasonPhrase { get; set; }

    }

    public class PSAzureOperationResponse<T> : PSAzureOperationResponse
    {
        public T Body { get; set; }

        public PSAzureOperationResponse(AzureOperationResponse<T> response)
        {
            this.Body = response.Body;
            this.StatusCode = response.Response.StatusCode;
            this.Method = response.Request.Method;
            this.IsSuccessStatusCode = response.Response.IsSuccessStatusCode;
            this.ReasonPhrase = response.Response.ReasonPhrase;
            this.CorrelationId = response.RequestId;
        }

    }
}

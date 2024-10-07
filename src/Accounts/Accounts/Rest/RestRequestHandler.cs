using System;
using Microsoft.Azure.Commands.Common.Exceptions;
using System.IO;
using System.Management.Automation;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Internal.Common;

namespace Microsoft.Azure.Commands.Profile.Rest
{
	public class RestRequestHandler
	{
        private string Method;
        private IAzureRestClient serviceClient;
        private InvokeAzRestMethodCommand Parent;

        public RestRequestHandler(InvokeAzRestMethodCommand parent, IAzureRestClient serviceClient, string Method)
		{
            this.Parent = parent;
            this.Method = Method;
            this.serviceClient = serviceClient;
		}

		public AzureOperationResponse<string> ExecuteRestRequest(string Path, string ApiVersion, string Payload)
		{
			AzureOperationResponse<string> response = null;

            switch (this.Method.ToUpper())
            {
                case "GET":
                    response = serviceClient
                    .Operations
                    .GetResourceWithFullResponse(Path, ApiVersion);
                    break;
                case "POST":
                    if (Parent.ShouldProcess(Path, "POST"))
                    {
                        response = serviceClient
                        .Operations
                        .PostResourceWithFullResponse(Path, ApiVersion, Payload);
                    }
                    break;
                case "PUT":
                    if (Parent.ShouldProcess(Path, "PUT"))
                    {
                        response = serviceClient
                        .Operations
                        .PutResourceWithFullResponse(Path, ApiVersion, Payload);
                    }
                    break;
                case "PATCH":
                    if (Parent.ShouldProcess(Path, "PATCH"))
                    {
                        response = serviceClient
                        .Operations
                        .PatchResourceWithFullResponse(Path, ApiVersion, Payload);
                    }
                    break;
                case "DELETE":
                    if (Parent.ShouldProcess(Path, "DELETE"))
                    {
                        response = serviceClient
                        .Operations
                        .DeleteResourceWithFullResponse(Path, ApiVersion);
                    }
                    break;
                default:
                    throw new AzPSArgumentException("Invalid HTTP Method", nameof(Method));
            }


            return response;
		}
        

	}
}


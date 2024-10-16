using System;
using Microsoft.Azure.Commands.Common.Exceptions;
using System.IO;
using System.Management.Automation;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Internal.Common;
using System.Linq;

namespace Microsoft.Azure.Commands.Profile.Rest
{
    public interface LRORequest
    {


        string DetermineFinalUri(AzureOperationResponse<string> response);
        string DeterminePollingUri(AzureOperationResponse<string> response);
        bool IsTerminalStatus(AzureOperationResponse<string> response);
        string GetProvisioningState(AzureOperationResponse<string> response);
        

    }


	public class LRORequestFactory
	{
        private string Path;
        private string PollFrom, FinalResultFrom;

        public LRORequestFactory(string Path, string PollFrom, string FinalResultFrom)
		{
            this.Path = Path;
            this.PollFrom = PollFrom;
            this.FinalResultFrom = FinalResultFrom;
        }

        public LRORequest CreateRequestType(string Method)
        {

            switch (Method.ToUpper())
            {
                case "POST":
                    break;
                case "PUT":
                    return new LROPutPatchRequest(this.Path, this.PollFrom, this.FinalResultFrom);
                case "PATCH":
                    return new LROPutPatchRequest(this.Path, this.PollFrom, this.FinalResultFrom);
                case "DELETE":
                    break;
                default:
                    throw new AzPSArgumentException("Invalid HTTP Method", nameof(Method));
            }

            throw new AzPSArgumentNullException("Invalid request type to perform LRO", nameof(Method));
        }
        

    }
}


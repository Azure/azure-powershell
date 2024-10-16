using System;
using System.Linq;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Profile.Rest
{
	public class LROPutPatchRequest : LRORequest
	{
        private string Path;
        private string PollFrom, FinalResultFrom;


        public LROPutPatchRequest(string Path, string PollFrom, string FinalResultFrom)
		{
            this.Path = Path;
            this.PollFrom = PollFrom;
            this.FinalResultFrom = FinalResultFrom;
		}


        public string DetermineFinalUri(AzureOperationResponse<string> response)
        {
            /*
                final-state-via SHOULD BE one of

                azure-async-operation - poll until terminal state, skip any final GET on Location or Origin-URI and use the final response at the uri pointed to by the header Azure-AsyncOperation.
                location - poll until terminal state, if the initial response had a Location header, a final GET will be done. Default behavior for POST operation.
                original-uri - poll until terminal state, a final GET will be done at the original resource URI. Default behavior for PUT operations.
                operation-location - poll until terminal state, skip any final GET on Location or Origin-URI and use the final response at the uri pointed to by the header Operation-Location
            */

            /*
             * Priority sequence => 
             * PUT => azure-async-operation, location
             * POST => operation-location
             */

            if (FinalResultFrom.Equals("Location", StringComparison.OrdinalIgnoreCase) && response.Response.Headers.Contains("Location"))
            {
                return response.Response.Headers.GetValues("Location").FirstOrDefault();
            }
            return this.Path; // Default to original URI
        }

        public string DeterminePollingUri(AzureOperationResponse<string> response)
        {
            var ResponseMsg = response.Response;
            
            string[] priority = { "Azure-AsyncOperation", "Location" };

            string preferredHeader = null;

            if(!string.IsNullOrEmpty(PollFrom))
            {
                preferredHeader = PollFrom;
            }
            else
            {
                for (int i = 0; i < priority.Length; i++)
                {
                    if (priority[i].ToUpper().Equals(PollFrom.ToUpper()) && ResponseMsg.Headers.Contains(priority[i]))
                    {
                        preferredHeader = priority[i];
                        break;
                    }
                }
            }
            

            if (!string.IsNullOrEmpty(preferredHeader))
            {
                return ResponseMsg.Headers.GetValues(preferredHeader).FirstOrDefault();
            }

            return this.Path; // Default to original URI
        }

        public bool IsTerminalStatus(AzureOperationResponse<string> response)
        {
            var ResponseMsg = response.Response;
            return ResponseMsg.StatusCode == System.Net.HttpStatusCode.OK ||
                   ResponseMsg.StatusCode == System.Net.HttpStatusCode.Created ||
                   ResponseMsg.StatusCode == System.Net.HttpStatusCode.Accepted;
        }

        public string GetProvisioningState(AzureOperationResponse<string> response)
        {
            var content = response.Body;
            var json = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(content);
            return json["status"]?.ToString() ?? json["properties"]?["provisioningState"]?.ToString();
        }


    }
}


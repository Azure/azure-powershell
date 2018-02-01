using System;

namespace Microsoft.Azure.Commands.ManagementGroups.Common
{
    using System.Collections.Generic;
    using Microsoft.Rest.Azure;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    static class Utility
    {
        // TODO (sepancha 12/9/2017) - This is temporary until I can figure out a better way to deal with error handling.
        public static void HandleErrorResponseException(ErrorResponseException ex)
        {
            if (!string.IsNullOrEmpty(ex.Response.Content))
            {
                Dictionary<string, object> content;
                try
                {
                    content = JsonConvert.DeserializeObject<Dictionary<string, object>>(ex.Response.Content);
                }
                catch
                {
                    throw ex;
                }

                if (content.ContainsKey("Message"))
                {
                    throw new CloudException(content["Message"].ToString());
                }

                if (content.ContainsKey("error"))
                {
                    JObject errorResponse = (JObject)content["error"];
                    JToken errorMessage;
                    if (errorResponse.TryGetValue("message", StringComparison.InvariantCultureIgnoreCase, out errorMessage))
                    {
                        throw new CloudException(errorMessage.ToString());
                    }
                }
            }
            else
            {
                throw ex;
            }
        }
    }
}

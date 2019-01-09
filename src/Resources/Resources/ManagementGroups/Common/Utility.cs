// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.ManagementGroups.Models;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Resources.ManagementGroups.Common
{
    static class Utility
    {
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

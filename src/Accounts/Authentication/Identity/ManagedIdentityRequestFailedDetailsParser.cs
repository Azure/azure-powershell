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
//

using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Azure.PowerShell.Authenticators.Identity.Core;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Microsoft.Azure.PowerShell.Authenticators.Identity
{
    internal class ManagedIdentityRequestFailedDetailsParser : RequestFailedDetailsParser
    {
        public override bool TryParse(Response response, out ResponseError error, out IDictionary<string, string> data)
        {
            data = new Dictionary<string, string>();
            error = null;
            try
            {
                // The response content is buffered at this point.
                string content = response.Content.ToString();

                // Optimistic check for JSON object we expect
                if (content == null || !content.StartsWith("{", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                var message = ManagedIdentitySource.GetMessageFromResponse(response, false, CancellationToken.None).EnsureCompleted();
                error = new ResponseError(null, message);
                return true;
            }
            catch
            {
                error = new ResponseError(null, ManagedIdentitySource.UnexpectedResponse);
                return true;
            }
        }
    }
}

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

namespace Microsoft.Azure.Commands.DeploymentManager.Models
{
    using Microsoft.Azure.Management.DeploymentManager.Models;
    using System.Collections.Generic;

    public class PSRestResponse
    {
        public PSRestResponse()
        {
        }

        public PSRestResponse(RestResponse restResponse)
        {
            this.SuccessStatusCodes = restResponse.SuccessStatusCodes;
            this.Regex = new PSRestResponseRegex(restResponse.Regex);
        }

		public IList<string> SuccessStatusCodes { get; set; }

		public PSRestResponseRegex Regex { get; set; }

        internal RestResponse ToSdkType()
        {
            return new RestResponse(
                successStatusCodes: this.SuccessStatusCodes,
                regex: this.Regex.ToSdkType());
        }
    }
}

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
    using System;
    using Microsoft.Azure.Management.DeploymentManager.Models;

    public class PSApiKeyAuthentication : PSRestRequestAuthentication
    {
        public PSApiKeyAuthentication(): base(PSRestAuthType.ApiKey)
        {
        }
        
        public PSApiKeyAuthentication(ApiKeyAuthentication apiKeyAuthentication) : base(PSRestAuthType.ApiKey)
        {
            this.Name = apiKeyAuthentication.Name;
            this.In = (PSRestAuthLocation)Enum.Parse(typeof(PSRestAuthLocation), apiKeyAuthentication.InProperty.ToString(), ignoreCase: true);
            this.Value = apiKeyAuthentication.Value;
        }

        public string Name { get; set; }

        public PSRestAuthLocation In { get; set; }

        public string Value { get; set; }

        internal override RestRequestAuthentication ToSdkType()
        {
            return new ApiKeyAuthentication(
                name: this.Name,
                inProperty: (RestAuthLocation)Enum.Parse(typeof(RestAuthLocation), this.In.ToString(), ignoreCase: true),
                value: this.Value);
        }
    }
}

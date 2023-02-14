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

using Microsoft.Azure.Commands.Network.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureCustomErrorBase : NetworkBaseCmdlet
    {
        [Parameter(
                Mandatory = true,
                HelpMessage = "Status code of the application gateway customer error.")]
        [ValidateNotNullOrEmpty]
        public string StatusCode { get; set; }

        [Parameter(
                Mandatory = true,
                HelpMessage = "Error page URL of the application gateway customer error.")]
        [ValidateNotNullOrEmpty]
        public string CustomErrorPageUrl { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        public PSApplicationGatewayCustomError NewObject()
        {
            PSApplicationGatewayCustomError customError = new PSApplicationGatewayCustomError()
            {
                StatusCode = this.StatusCode,
                CustomErrorPageUrl = this.CustomErrorPageUrl
            };
            return customError;
        }
    }

    public class AzureApplicationGatewayCustomErrorBase : AzureCustomErrorBase
    {
    }

    public class AzureApplicationGatewayHttpListenerCustomErrorBase : AzureCustomErrorBase
    {
    }
}

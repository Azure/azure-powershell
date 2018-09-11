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
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewayProbeHealthResponseMatchBase : NetworkBaseCmdlet
    {

        [Parameter(
            HelpMessage = "Body that must be contained in the health response. Default value is empty")]
        [ValidateNotNullOrEmpty]
        public string Body { get; set; }

        [Parameter(
            HelpMessage = "Allowed ranges of healthy status codes. Default range of healthy status codes is 200 - 399")]
        [ValidateNotNullOrEmpty]
        public List<string> StatusCode { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        protected PSApplicationGatewayProbeHealthResponseMatch NewObject()
        {
            return new PSApplicationGatewayProbeHealthResponseMatch()
            {
                Body = this.Body,
                StatusCodes = this.StatusCode
            };
        }
    }
}

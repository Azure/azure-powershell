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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayCustomError"),
        OutputType(typeof(PSApplicationGatewayCustomError))]
    public class AddAzureApplicationGatewayCustomErrorCommand : AzureApplicationGatewayCustomErrorBase
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The Application Gateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var customError = this.ApplicationGateway.CustomErrorConfigurations.SingleOrDefault(resource => string.Equals(resource.StatusCode, this.StatusCode));

            if (customError != null)
            {
                throw new ArgumentException("Custom Error with the specified status code already exists in this ApplicationGateway");
            }

            customError = base.NewObject();
            this.ApplicationGateway.CustomErrorConfigurations.Add(customError);

            WriteObject(this.ApplicationGateway);
        }
    }
}
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
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayAutoscaleConfiguration", SupportsShouldProcess = true), OutputType(typeof(PSApplicationGateway))]
    public class UpdateAzureApplicationGatewayAutoscaleConfigurationCommand : AzureApplicationGatewayAutoscaleConfigurationBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The applicationGateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        [Parameter(
            HelpMessage = "Minimum capacity units that will always be available [and charged] for application gateway.",
            Mandatory = false)]
        public override int MinCapacity { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess("AzureApplicationGatewayAutoscaleConfiguration", Microsoft.Azure.Commands.Network.Properties.Resources.CreatingResourceMessage))
            {
                base.ExecuteCmdlet();
                if (ApplicationGateway.AutoscaleConfiguration == null)
                {
                    throw new ArgumentException("AutoscaleConfigurations does not exist");
                }

                if (MyInvocation.BoundParameters.ContainsKey("MinCapacity"))
                {
                    ApplicationGateway.AutoscaleConfiguration.MinCapacity = this.MinCapacity;
                }

                if (MyInvocation.BoundParameters.ContainsKey("MaxCapacity"))
                {
                    ApplicationGateway.AutoscaleConfiguration.MaxCapacity = this.MaxCapacity;
                }

                WriteObject(this.ApplicationGateway);
            }
        }
    }
}

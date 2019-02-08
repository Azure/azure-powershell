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
    public class AzureApplicationGatewayAutoscaleConfigurationBase : NetworkBaseCmdlet
    {
        [Parameter(
            HelpMessage = "Minimum capacity units that will always be available [and charged] for application gateway.",
            Mandatory = true)]
        public int MinCapacity { get; set; }

        [Parameter(
            HelpMessage = "Maximum capacity units that will always be available [and charged] for application gateway.",
            Mandatory = false)]
        public int? MaxCapacity { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        public PSApplicationGatewayAutoscaleConfiguration NewObject()
        {
            var autoscaleConfiguration = new PSApplicationGatewayAutoscaleConfiguration();
            autoscaleConfiguration.MinCapacity = this.MinCapacity;
            autoscaleConfiguration.MaxCapacity = this.MaxCapacity;
            return autoscaleConfiguration;
        }
    }
}

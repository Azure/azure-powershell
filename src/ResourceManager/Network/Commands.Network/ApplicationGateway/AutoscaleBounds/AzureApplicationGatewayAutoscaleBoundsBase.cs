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
    public class AzureApplicationGatewayAutoscaleBoundsBase : NetworkBaseCmdlet
    {

        [Parameter(
            HelpMessage = "Lower bound on number of Application Gateway instances.")]
        [ValidateNotNullOrEmpty]
        public int Min { get; set; }

        [Parameter(
            HelpMessage = "Upper bound on number of Application Gateway instances.")]
        [ValidateNotNullOrEmpty]
        public int Max { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        protected PSApplicationGatewayAutoscaleBounds NewObject()
        {
            return new PSApplicationGatewayAutoscaleBounds()
            {
                Min = this.Min,
                Max = this.Max
            };
        }
    }
}

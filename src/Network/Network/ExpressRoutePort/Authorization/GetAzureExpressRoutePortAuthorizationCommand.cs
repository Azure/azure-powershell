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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRoutePortAuthorization"), OutputType(typeof(PSExpressRoutePortAuthorization))]
    public class GetAzureExpressRoutePortAuthorizationCommand : NetworkBaseCmdlet
    {
        [Parameter(
           Mandatory = false,
           HelpMessage = "The name of the Authorization")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The ExpressRoutePort Object")]
        public PSExpressRoutePort ExpressRoutePortObject { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (!string.IsNullOrEmpty(this.Name))
            {
                var getExpressRoutePortAuthorization = this.NetworkClient.NetworkManagementClient.ExpressRoutePortAuthorizations.GetWithHttpMessagesAsync(this.ExpressRoutePortObject.ResourceGroupName, this.ExpressRoutePortObject.Name, this.Name).GetAwaiter().GetResult().Body;
                var psExpressRoutePortAuthorization = NetworkResourceManagerProfile.Mapper.Map<PSExpressRoutePortAuthorization>(getExpressRoutePortAuthorization);
                WriteObject(psExpressRoutePortAuthorization);
            }
            else
            {

                var listExpressRoutePortAuthorizations = this.NetworkClient.NetworkManagementClient.ExpressRoutePortAuthorizations.ListWithHttpMessagesAsync(this.ExpressRoutePortObject.ResourceGroupName, this.ExpressRoutePortObject.Name).GetAwaiter().GetResult().Body;
                var psExpressRoutePortAuthorizations = new List<PSExpressRoutePortAuthorization>();
                if (listExpressRoutePortAuthorizations != null)
                {
                    psExpressRoutePortAuthorizations = NetworkResourceManagerProfile.Mapper.Map<List<PSExpressRoutePortAuthorization>>(listExpressRoutePortAuthorizations);
                }

                WriteObject(psExpressRoutePortAuthorizations, true);
            }
        }
    }
}

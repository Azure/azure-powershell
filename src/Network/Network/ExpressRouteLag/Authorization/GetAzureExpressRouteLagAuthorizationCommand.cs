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
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteLagAuthorization"), OutputType(typeof(PSExpressRouteLagAuthorization))]
    public class GetAzureExpressRouteLagAuthorizationCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the authorization.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The ExpressRoute LAG object.")]
        [ValidateNotNull]
        public PSExpressRouteLag ExpressRouteLagObject { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!string.IsNullOrEmpty(this.Name))
            {
                var authorization = this.NetworkClient.NetworkManagementClient.ExpressRouteLagAuthorizations.Get(
                    this.ExpressRouteLagObject.ResourceGroupName,
                    this.ExpressRouteLagObject.Name,
                    this.Name);
                var psAuthorization = NetworkResourceManagerProfile.Mapper.Map<PSExpressRouteLagAuthorization>(authorization);
                WriteObject(psAuthorization);
                return;
            }

            var authorizationPage = this.NetworkClient.NetworkManagementClient.ExpressRouteLagAuthorizations.List(
                this.ExpressRouteLagObject.ResourceGroupName,
                this.ExpressRouteLagObject.Name);
            var authorizations = ListNextLink<ExpressRouteLagAuthorization>.GetAllResourcesByPollingNextLink(
                authorizationPage,
                this.NetworkClient.NetworkManagementClient.ExpressRouteLagAuthorizations.ListNext);
            var psAuthorizations = NetworkResourceManagerProfile.Mapper.Map<List<PSExpressRouteLagAuthorization>>(authorizations);
            WriteObject(psAuthorizations, true);
        }
    }
}

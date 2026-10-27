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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteLagAuthorizationKey", DefaultParameterSetName = ByNameParameterSet), OutputType(typeof(PSExpressRouteAuthorizationKey))]
    public class GetAzureExpressRouteLagAuthorizationKeyCommand : NetworkBaseCmdlet
    {
        private const string ByNameParameterSet = "ByName";
        private const string ByParentObjectParameterSet = "ByParentObject";

        [Parameter(
            Mandatory = true,
            ParameterSetName = ByNameParameterSet,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ByNameParameterSet,
            HelpMessage = "The name of the ExpressRoute LAG.")]
        [ResourceNameCompleter("Microsoft.Network/expressRouteLags", "ResourceGroupName")]
        [Alias("LagName")]
        [ValidateNotNullOrEmpty]
        public string ExpressRouteLagName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = ByParentObjectParameterSet,
            HelpMessage = "The ExpressRoute LAG object.")]
        [ValidateNotNull]
        public PSExpressRouteLag ExpressRouteLagObject { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the authorization.")]
        [Alias("AuthorizationName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            var resourceGroupName = this.ResourceGroupName;
            var lagName = this.ExpressRouteLagName;

            if (this.ParameterSetName.Equals(ByParentObjectParameterSet))
            {
                resourceGroupName = this.ExpressRouteLagObject.ResourceGroupName;
                lagName = this.ExpressRouteLagObject.Name;
            }

            var authorizationKey = this.NetworkClient.NetworkManagementClient.ExpressRouteLagAuthorizations.ListKeys(
                resourceGroupName,
                lagName,
                this.Name);
            var psAuthorizationKey = NetworkResourceManagerProfile.Mapper.Map<PSExpressRouteAuthorizationKey>(authorizationKey);
            WriteObject(psAuthorizationKey);
        }
    }
}

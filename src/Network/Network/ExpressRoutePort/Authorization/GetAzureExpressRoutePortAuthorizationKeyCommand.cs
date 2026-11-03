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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRoutePortAuthorizationKey", DefaultParameterSetName = ByNameParameterSet), OutputType(typeof(PSExpressRouteAuthorizationKey))]
    public class GetAzureExpressRoutePortAuthorizationKeyCommand : NetworkBaseCmdlet
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
            HelpMessage = "The name of the ExpressRoute port.")]
        [ResourceNameCompleter("Microsoft.Network/expressRoutePorts", "ResourceGroupName")]
        [Alias("PortName")]
        [ValidateNotNullOrEmpty]
        public string ExpressRoutePortName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = ByParentObjectParameterSet,
            HelpMessage = "The ExpressRoute port object.")]
        [ValidateNotNullOrEmpty]
        public PSExpressRoutePort ExpressRoutePortObject { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the authorization.")]
        [Alias("AuthorizationName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            string resourceGroupName = this.ResourceGroupName;
            string portName = this.ExpressRoutePortName;

            if (ParameterSetName.Equals(ByParentObjectParameterSet))
            {
                resourceGroupName = this.ExpressRoutePortObject.ResourceGroupName;
                portName = this.ExpressRoutePortObject.Name;
            }

            // The authorization key is secret and is masked by the standard GET; retrieve it via the live listKeys action.
            var authorizationKey = this.NetworkClient.NetworkManagementClient.ExpressRoutePortAuthorizations.ListKeysWithHttpMessagesAsync(resourceGroupName, portName, this.Name).GetAwaiter().GetResult().Body;
            var psAuthorizationKey = NetworkResourceManagerProfile.Mapper.Map<PSExpressRouteAuthorizationKey>(authorizationKey);
            WriteObject(psAuthorizationKey);
        }
    }
}

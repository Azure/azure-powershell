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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerScopeConnection", SupportsShouldProcess = true), OutputType(typeof(PSNetworkManagerScopeConnection))]
    public class NewAzNetworkManagerScopeConnectionCommand : NetworkManagerScopeConnectionBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager name.")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Tenant Id of the resource you'd like to manage.")]
        public string TenantId { get; set; }

        [Parameter(
         Mandatory = true,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "Resource Id of the subscription or management group to be managed. Resource IDs should be in the form '/subscriptions/{subscriptionId}' or '/providers/Microsoft.Management/managementGroups/{managementGroupId}'.")]
        public string ResourceId { get; set; }

        [Parameter(
         Mandatory = false,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "Description.")]
        public virtual string Description { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource.")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = this.IsNetworkManagerScopeConnectionPresent(this.ResourceGroupName, this.NetworkManagerName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var scopeConnection = this.CreateNetworkManagerScopeConnection();
                    WriteObject(scopeConnection);
                },
                () => present);
        }

        private PSNetworkManagerScopeConnection CreateNetworkManagerScopeConnection()
        {
            var mncc = new PSNetworkManagerScopeConnection();
            mncc.TenantId = this.TenantId;
            mncc.ResourceId = this.ResourceId;

            if (!string.IsNullOrEmpty(this.Description))
            {
                mncc.Description = this.Description;
            }

            // Map to the sdk object
            var mnccModel = NetworkResourceManagerProfile.Mapper.Map<MNM.ScopeConnection>(mncc);
            this.NullifyNetworkManagerScopeConnectionIfAbsent(mnccModel);

            // Execute the Create NetworkManagerScopeConnection call
            this.NetworkManagerScopeConnectionClient.CreateOrUpdate(mnccModel, this.ResourceGroupName, this.NetworkManagerName, this.Name);
            var psNetworkManagerScopeConnection = this.GetNetworkManagerScopeConnection(this.ResourceGroupName, this.NetworkManagerName, this.Name);
            return psNetworkManagerScopeConnection;
        }
    }
}

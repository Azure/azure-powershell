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
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityPartnerProvider", DefaultParameterSetName= SecurityPartnerProviderParameterSetName.ByName, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureSecurityPartnerProviderCommand : SecurityPartnerProviderBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            ParameterSetName = SecurityPartnerProviderParameterSetName.ByName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/securityPartnerProviders", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            ParameterSetName = SecurityPartnerProviderParameterSetName.ByName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = SecurityPartnerProviderParameterSetName.ByObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The securityPartnerProvider input object.")]
        [ValidateNotNullOrEmpty]
        public PSSecurityPartnerProvider SecurityPartnerProvider { get; set; }

        [Parameter(
            ParameterSetName = SecurityPartnerProviderParameterSetName.ByResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The securityPartnerProvider resource Id.")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/securityPartnerProviders")]
        public string ResourceId { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            if (ParameterSetName.Equals(SecurityPartnerProviderParameterSetName.ByObject, StringComparison.OrdinalIgnoreCase))
            {
                Name = SecurityPartnerProvider.Name;
                ResourceGroupName = SecurityPartnerProvider.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(SecurityPartnerProviderParameterSetName.ByResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                Name = parsedResourceId.ResourceName;
                ResourceGroupName = parsedResourceId.ResourceGroupName;
            }

            base.Execute();
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, Name),
                Properties.Resources.RemoveResourceMessage,
                Name,
                () =>
                {
                    this.SecurityPartnerProviderClient.Delete(this.ResourceGroupName, this.Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}

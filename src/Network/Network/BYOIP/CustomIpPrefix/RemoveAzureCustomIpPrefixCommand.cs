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

namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CustomIpPrefix", SupportsShouldProcess = true, DefaultParameterSetName = DeleteByNameParameterSet), OutputType(typeof(bool))]
    public class RemoveAzureCustomIpPrefixCommand : CustomIpPrefixBaseCmdlet
    {
        private const string DeleteByNameParameterSet = "DeleteByNameParameterSet";
        private const string DeleteByInputObjectParameterSet = "DeleteByInputObjectParameterSet";
        private const string DeleteByResourceIdParameterSet = "DeleteByResourceIdParameterSet";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = DeleteByNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/customIpPrefix", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = DeleteByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true, 
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id.",
            ParameterSetName = DeleteByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceId { get; set; }

        [Parameter(
            Mandatory = true, 
            ValueFromPipeline = true,
            HelpMessage = "A customIpPrefix object.",
            ParameterSetName = DeleteByInputObjectParameterSet)]
        [ValidateNotNull]
        public PSCustomIpPrefix InputObject { get; set; }

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
            base.Execute();

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }

            ConfirmAction(
                Force.IsPresent,
                string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.RemovingResource, Name),
                Microsoft.Azure.Commands.Network.Properties.Resources.RemoveResourceMessage,
                Name,
                () =>
                {
                    if (this.ShouldProcess(this.Name, $"Deleting CustomIpPrefix: {this.Name} in ResourceGroup: {this.ResourceGroupName}"))
                    {
                        this.CustomIpPrefixClient.Delete(this.ResourceGroupName, this.Name);
                        if (PassThru)
                        {
                            WriteObject(true);
                        }
                    }
                });
        }
    }
}

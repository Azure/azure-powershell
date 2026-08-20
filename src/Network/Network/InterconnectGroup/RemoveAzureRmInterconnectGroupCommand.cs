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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "InterconnectGroup", SupportsShouldProcess = true, DefaultParameterSetName = DeleteByNameParameterSet), OutputType(typeof(bool))]
    public partial class RemoveAzureRmInterconnectGroupCommand : InterconnectGroupBaseCmdlet
    {
        private const string DeleteByNameParameterSet = "DeleteByNameParameterSet";
        private const string DeleteByInputObjectParameterSet = "DeleteByInputObjectParameterSet";
        private const string DeleteByResourceIdParameterSet = "DeleteByResourceIdParameterSet";

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name of the interconnect group.",
            ParameterSetName = DeleteByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the interconnect group.",
            ParameterSetName = DeleteByNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/interconnectGroups", "ResourceGroupName")]
        [Alias("ResourceName", "InterconnectGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The interconnect group object to delete.",
            ParameterSetName = DeleteByInputObjectParameterSet)]
        [ValidateNotNull]
        [Alias("InterconnectGroup")]
        public PSInterconnectGroup InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the interconnect group.",
            ParameterSetName = DeleteByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("InterconnectGroupId")]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to delete resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Returns an object representing the item on which this operation is being performed.")]
        public SwitchParameter PassThru { get; set; }

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
                string.Format(Properties.Resources.RemovingResource, Name),
                Properties.Resources.RemoveResourceMessage,
                Name,
                () =>
                {
                    this.InterconnectGroupClient.Delete(this.ResourceGroupName, this.Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}

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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;


namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.EdgeStorageContainers
{
    [Cmdlet(VerbsLifecycle.Invoke,
         Constants.EdgeStorageContainer,
         DefaultParameterSetName = InvokeByNameParameterSet,
         SupportsShouldProcess = true),
     OutputType(typeof(PSStackEdgeStorageContainer))]
    public class StackEdgeStorageContainerInvokeCmdlet : AzureStackEdgeCmdletBase
    {
        private const string InvokeByResourceIdParameterSet = "InvokeByResourceIdParameterSet";
        private const string InvokeByNameParameterSet = "InvokeByNameParameterSet";
        private const string InvokeByInputObjectParameterSet = "InvokeByInputObjectParameterSet";

        [Parameter(Mandatory = true,
            ParameterSetName = InvokeByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceIdHelpMessage,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = InvokeByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = InvokeByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        public string DeviceName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = InvokeByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.NameHelpMessage,
            Position = 2)]
        [ValidateNotNullOrEmpty]
        public string EdgeStorageAccountName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = InvokeByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.NameHelpMessage,
            Position = 3)]
        [ValidateNotNullOrEmpty]
        [Alias(HelpMessageEdgeStorageContainer.EdgeStorageContainerNameAlias)]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = InvokeByInputObjectParameterSet,
            HelpMessage = HelpMessageEdgeStorageContainer.EdgeStorageAccountObjectHelpMessage)]
        [ValidateNotNull]
        [Alias(HelpMessageEdgeStorageContainer.EdgeStorageContainerAlias)]
        public PSStackEdgeStorageContainer InputObject;

        [Parameter(Mandatory = false,
            HelpMessage = HelpMessageEdgeStorageContainer.RefreshDataHelpMessage)]
        public SwitchParameter RefreshData { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.PassThruHelpMessage)]
        public SwitchParameter PassThru;

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        private bool RefreshContainer()
        {
            this.StackEdgeManagementClient.Containers.Refresh(
                this.DeviceName,
                this.EdgeStorageAccountName,
                this.Name,
                this.ResourceGroupName);
            return true;
        }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new StackEdgeStorageResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.DeviceName = resourceIdentifier.DeviceName;
                this.EdgeStorageAccountName = resourceIdentifier.EdgeStorageAccountName;
                this.Name = resourceIdentifier.Name;
            }

            if (this.IsParameterBound(c => this.InputObject))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.DeviceName = this.InputObject.DeviceName;
                this.EdgeStorageAccountName = this.InputObject.EdgeStorageAccountName;
                this.Name = this.InputObject.Name;
            }

            if (this.ShouldProcess(this.Name,
                "Invoking Action"))
            {
                var refreshed = RefreshContainer();
                if (this.PassThru.IsPresent)
                {
                    WriteObject(refreshed);
                }
            }
        }
    }
}
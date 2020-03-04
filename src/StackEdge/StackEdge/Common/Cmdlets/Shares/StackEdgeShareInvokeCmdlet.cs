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


namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.Shares
{
    [Cmdlet(VerbsLifecycle.Invoke,
         Constants.Share, SupportsShouldProcess = true,
         DefaultParameterSetName = GetByNameParameterSet),
     OutputType(typeof(bool))]
    public class StackEdgeShareInvokeCmdlet : AzureStackEdgeCmdletBase
    {
        private const string GetByNameParameterSet = "InvokeByNameParameterSet";
        private const string GetByResourceIdParameterSet = "InvokeByResourceIdParameterSet";
        private const string InvokeByInputObjectParameterSet = "InvokeByInputObjectParameterSet";

        [Parameter(Mandatory = true,
            ParameterSetName = GetByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        public string DeviceName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.NameHelpMessage,
            Position = 2)]
        [ValidateNotNullOrEmpty]
        [Alias(HelpMessageShare.NameAlias)]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = InvokeByInputObjectParameterSet,
            HelpMessage = Constants.InputObjectHelpMessage)]
        [ValidateNotNull]
        [Alias(HelpMessageShare.InputObjectAlias)]
        public PSStackEdgeShare InputObject;

        [Parameter(Mandatory = false,
            HelpMessage = HelpMessageShare.RefreshDataHelpMessage)]
        [ValidateNotNull]
        public SwitchParameter RefreshData;

        [Parameter(Mandatory = false, HelpMessage = Constants.PassThruHelpMessage)]
        public SwitchParameter PassThru;

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        private bool ShareRefreshData()
        {
            this.StackEdgeManagementClient.Shares.Refresh(
                this.DeviceName,
                this.Name,
                this.ResourceGroupName);
            return true;
        }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => this.InputObject))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.DeviceName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new StackEdgeResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.DeviceName = resourceIdentifier.DeviceName;
                this.Name = resourceIdentifier.ResourceName;
            }

            if (this.ShouldProcess(this.Name,
                string.Format("Invoking '{0}' in device '{1}' with name '{2}'.",
                    HelpMessageShare.ObjectName, this.DeviceName, this.Name)))
            {
                var refreshed = ShareRefreshData();
                if (this.PassThru.IsPresent)
                {
                    WriteObject(refreshed);
                }
            }
        }
    }
}
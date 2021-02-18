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

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.Bandwidth
{
    using HelpMessageConstants = HelpMessageBandwidthSchedule;

    [Cmdlet(VerbsCommon.Remove, Constants.BandwidthSchedule, DefaultParameterSetName = DeleteByNameParameterSet,
         SupportsShouldProcess = true
     ),
     OutputType(typeof(bool))]
    public class StackEdgeBandwidthRemoveCmdletBase : AzureStackEdgeCmdletBase
    {
        private const string DeleteByNameParameterSet = "DeleteByNameParameterSet";
        private const string DeleteByInputObjectParameterSet = "DeleteByInputObjectParameterSet";
        private const string DeleteByResourceIdParameterSet = "DeleteByResourceIdParameterSet";

        [Parameter(Mandatory = true, 
            ParameterSetName = DeleteByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, 
            ParameterSetName = DeleteByInputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = Constants.InputObjectHelpMessage
        )]
        [ValidateNotNull]
        [Alias(HelpMessageConstants.InputObjectAlias)]
        public PSStackEdgeBandWidthSchedule InputObject { get; set; }

        [Parameter(Mandatory = true, 
            ParameterSetName = DeleteByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage, 
            Position = 0)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, 
            ParameterSetName = DeleteByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.DeviceNameHelpMessage, 
            Position = 1)]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Parameter(Mandatory = true, 
            ParameterSetName = DeleteByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.NameHelpMessage, 
            Position = 2)]
        [ValidateNotNullOrEmpty]
        [Alias(HelpMessageBandwidthSchedule.NameAlias)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.PassThruHelpMessage)]
        public SwitchParameter PassThru;

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        private bool Remove()
        {
            BandwidthSchedulesOperationsExtensions.Delete(
                this.StackEdgeManagementClient.BandwidthSchedules,
                this.DeviceName,
                this.Name,
                this.ResourceGroupName);
            return true;
        }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new StackEdgeResourceIdentifier(this.ResourceId);
                this.DeviceName = resourceIdentifier.DeviceName;
                this.Name = resourceIdentifier.ResourceName;
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.DeviceName = this.InputObject.DeviceName;
                this.Name = this.InputObject.Name;
            }

            if (this.ShouldProcess(this.Name,
                string.Format("Removing '{0}' in device '{1}' with name '{2}'.",
                    HelpMessageBandwidthSchedule.ObjectName, this.DeviceName, this.Name)))
            {
                Remove();
                if (this.PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
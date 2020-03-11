﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.Devices
{
    [Cmdlet(VerbsCommon.Remove, Constants.Device, DefaultParameterSetName = DeleteByNameParameterSet,
         SupportsShouldProcess = true
     ),
     OutputType(typeof(bool))]
    public class StackEdgeDeviceRemoveCmdletBase : AzureStackEdgeCmdletBase
    {
        private const string DeleteByNameParameterSet = "DeleteByNameParameterSet";
        private const string DeleteByInputObjectParameterSet = "DeleteByInputObjectParameterSet";
        private const string DeleteByResourceIdParameterSet = "DeleteByResourceIdParameterSet";

        [Parameter(Mandatory = true,
            ParameterSetName = DeleteByResourceIdParameterSet,
            HelpMessage = Constants.ResourceIdHelpMessage,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = DeleteByInputObjectParameterSet,
            HelpMessage = Constants.InputObjectHelpMessage,
            ValueFromPipeline = true)]
        [ValidateNotNull]
        [Alias(HelpMessageDevice.InputObjectAlias)]
        public PSStackEdgeDevice DeviceObject { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = DeleteByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = DeleteByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.NameHelpMessage,
            Position = 1)]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias(HelpMessageDevice.NameAlias)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.PassThruHelpMessage)]
        public SwitchParameter PassThru;

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        private bool Remove()
        {
            DevicesOperationsExtensions.Delete(
                this.StackEdgeManagementClient.Devices,
                this.Name,
                this.ResourceGroupName);
            return true;
        }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new StackEdgeResourceIdentifier(this.ResourceId);
                this.Name = resourceIdentifier.ResourceName;
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            }

            if (this.IsParameterBound(c => c.DeviceObject))
            {
                this.ResourceGroupName = this.DeviceObject.ResourceGroupName;
                this.Name = this.DeviceObject.Name;
            }

            if (this.ShouldProcess(this.Name,
                string.Format("Removing '{0}' with name '{1}'.",
                    HelpMessageDevice.ObjectName, this.Name)))
            {
                var removed = Remove();
                if (this.PassThru.IsPresent)
                {
                    WriteObject(removed);
                }
            }
        }
    }
}
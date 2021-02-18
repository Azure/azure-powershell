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
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;


namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.Triggers
{
    [Cmdlet(VerbsCommon.Get, Constants.Trigger, DefaultParameterSetName = ListParameterSet),
     OutputType(typeof(PSStackEdgeTrigger))]
    public class StackEdgeTriggerGetCmdlet : AzureStackEdgeCmdletBase
    {
        private const string ListParameterSet = "ListParameterSet";
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";
        private const string GetByParentObjectParameterSet = "GetByParentObjectParameterSet";

        [Parameter(Mandatory = true,
            ParameterSetName = GetByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ListParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = GetByNameParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ListParameterSet,
            HelpMessage = Constants.DeviceNameHelpMessage,
            ValueFromPipelineByPropertyName = true,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            HelpMessage = Constants.DeviceNameHelpMessage,
            ValueFromPipelineByPropertyName = true,
            Position = 1)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        public string DeviceName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.NameHelpMessage,
            Position = 2)]
        [Parameter(Mandatory = false,
            ParameterSetName = GetByParentObjectParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessageTrigger.NameHelpMessage
        )]
        [ValidateNotNullOrEmpty]
        [Alias(HelpMessageTrigger.NameAlias)]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetByParentObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = Constants.PsDeviceObjectHelpMessage)]
        [ValidateNotNull]
        [Alias(Constants.DeviceAlias)]
        public PSStackEdgeDevice DeviceObject;

        private Trigger GetResourceModel()
        {
            return this.StackEdgeManagementClient.Triggers.Get(this.DeviceName, this.Name, this.ResourceGroupName);
        }

        private List<PSStackEdgeTrigger> ListResourceByName()
        {
            var resourceModel = GetResourceModel();
            return new List<PSStackEdgeTrigger>() {PSStackEdgeTrigger.PSStackEdgeTriggerObject(resourceModel)};
        }

        private IPage<Trigger> ListResourceModel()
        {
            return this.StackEdgeManagementClient.Triggers.ListByDataBoxEdgeDevice(
                this.DeviceName,
                this.ResourceGroupName);
        }

        private IPage<Trigger> ListResourceModel(string nextPageLink)
        {
            return this.StackEdgeManagementClient.Triggers.ListByDataBoxEdgeDeviceNext(
                nextPageLink
            );
        }

        private List<PSStackEdgeTrigger> ListPSResourceModels()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                return ListResourceByName();
            }

            var resourceModel = ListResourceModel();
            var paginatedResult = new List<Trigger>(resourceModel);
            while (!string.IsNullOrEmpty(resourceModel.NextPageLink))
            {
                resourceModel = ListResourceModel(resourceModel.NextPageLink);
                paginatedResult.AddRange(resourceModel);
            }

            return paginatedResult.Select(PSStackEdgeTrigger.PSStackEdgeTriggerObject).ToList();
        }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => this.DeviceObject))
            {
                this.ResourceGroupName = this.DeviceObject.ResourceGroupName;
                this.DeviceName = this.DeviceObject.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new StackEdgeResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.DeviceName = resourceIdentifier.DeviceName;
                this.Name = resourceIdentifier.ResourceName;
            }

            var results = ListPSResourceModels();
            WriteObject(results, true);
        }
    }
}
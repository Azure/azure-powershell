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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using ResourceModel = Microsoft.Azure.Management.DataBoxEdge.Models.Trigger;
using PSResourceModel = Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.PSDataBoxEdgeTrigger;
using PSTopLevelResourceModel = Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.PSDataBoxEdgeDevice;


namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Cmdlets.Triggers
{
    [Cmdlet(VerbsCommon.Get, Constants.Trigger, DefaultParameterSetName = ListParameterSet),
     OutputType(typeof(PSResourceModel))]
    public class DataBoxEdgeTriggerGetCmdlet : AzureDataBoxEdgeCmdletBase
    {
        private const string ListParameterSet = "ListParameterSet";
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";
        private const string GetByParentObjectParameterSet = "GetByParentObjectParameterSet";

        [Parameter(Mandatory = true,
            ParameterSetName = GetByResourceIdParameterSet,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ListParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ListParameterSet,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        public string DeviceName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            HelpMessage = Constants.NameHelpMessage,
            Position = 2)]
        [Parameter(Mandatory = false,
            ParameterSetName = GetByParentObjectParameterSet,
            HelpMessage = HelpMessageTrigger.NameHelpMessage
        )]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true,
            ParameterSetName = GetByParentObjectParameterSet,
            HelpMessage = Constants.PsDeviceObjectHelpMessage)]
        [ValidateNotNull]
        public PSTopLevelResourceModel DeviceObject;

        private ResourceModel GetResourceModel()
        {
            return this.DataBoxEdgeManagementClient.Triggers.Get(this.DeviceName, this.Name, this.ResourceGroupName);
        }

        private List<PSResourceModel> ListResourceByName()
        {
            var resourceModel = GetResourceModel();
            return new List<PSResourceModel>() {PSResourceModel.PSDataBoxEdgeTriggerObject(resourceModel)};
        }

        private IPage<ResourceModel> ListResourceModel()
        {
            return this.DataBoxEdgeManagementClient.Triggers.ListByDataBoxEdgeDevice(
                this.DeviceName,
                this.ResourceGroupName);
        }

        private IPage<ResourceModel> ListResourceModel(string nextPageLink)
        {
            return this.DataBoxEdgeManagementClient.Triggers.ListByDataBoxEdgeDeviceNext(
                
                nextPageLink
            );
        }

        private List<PSResourceModel> ListPSResourceModels()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                return ListResourceByName();
            }

            var resourceModel = ListResourceModel();
            var paginatedResult = new List<ResourceModel>(resourceModel);
            while (!string.IsNullOrEmpty(resourceModel.NextPageLink))
            {
                resourceModel = ListResourceModel(resourceModel.NextPageLink);
                paginatedResult.AddRange(resourceModel);
            }

            return paginatedResult.Select(PSResourceModel.PSDataBoxEdgeTriggerObject).ToList();
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
                var resourceIdentifier = new DataBoxEdgeResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.DeviceName = resourceIdentifier.DeviceName;
                this.Name = resourceIdentifier.ResourceName;
            }

            var results = ListPSResourceModels();
            WriteObject(results, true);
        }
    }
}
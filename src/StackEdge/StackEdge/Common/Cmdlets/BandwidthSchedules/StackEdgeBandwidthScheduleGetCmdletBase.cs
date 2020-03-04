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


namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.Bandwidth
{
    [Cmdlet(VerbsCommon.Get, Constants.BandwidthSchedule, DefaultParameterSetName = ListParameterSet
     ),
     OutputType(typeof(PSStackEdgeBandWidthSchedule))]
    public class StackEdgeBandwidthGetCmdletBase : AzureStackEdgeCmdletBase
    {
        private const string ListParameterSet = "ListParameterSet";
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";
        private const string GetByParentObjectParameterSet = "GetByParentObjectParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = GetByResourceIdParameterSet,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, 
            ParameterSetName = ListParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            ValueFromPipelineByPropertyName = true,
            Position = 0)]
        [Parameter(Mandatory = true, 
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage, 
            Position = 0)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, 
            ParameterSetName = ListParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.DeviceNameHelpMessage, 
            Position = 1)]
        [Parameter(Mandatory = true, 
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.DeviceNameHelpMessage, 
            Position = 1)]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Parameter(Mandatory = true, 
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.NameHelpMessage,
            Position = 2)]
        [Parameter(Mandatory = false,
            ParameterSetName = GetByParentObjectParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.NameHelpMessage
        )]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("bandwidthSchedules", nameof(ResourceGroupName), nameof(DeviceName))]
        [Alias(HelpMessageBandwidthSchedule.NameAlias)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, 
            ValueFromPipeline = true,
            ParameterSetName = GetByParentObjectParameterSet,
            HelpMessage = Constants.PsDeviceObjectHelpMessage)]
        [ValidateNotNull]
        [Alias(Constants.DeviceAlias)]
        public PSStackEdgeDevice DeviceObject;

        private BandwidthSchedule GetResourceModel()
        {
            return this.StackEdgeManagementClient.BandwidthSchedules.Get(
                this.DeviceName,
                this.Name,
                this.ResourceGroupName);
        }

        private List<PSStackEdgeBandWidthSchedule> GetByResourceName()
        {
            var resourceModel = GetResourceModel();
            return new List<PSStackEdgeBandWidthSchedule>() {new PSStackEdgeBandWidthSchedule(resourceModel)};
        }

        private IPage<BandwidthSchedule> ListResourceModel()
        {
            return this.StackEdgeManagementClient.BandwidthSchedules.ListByDataBoxEdgeDevice(
                this.DeviceName,
                this.ResourceGroupName);
        }

        private IPage<BandwidthSchedule> ListResourceModel(string nextPageLink)
        {
            return this.StackEdgeManagementClient.BandwidthSchedules.ListByDataBoxEdgeDeviceNext(
                nextPageLink
            );
        }

        private List<PSStackEdgeBandWidthSchedule> ListPSResourceModels()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                return GetByResourceName();
            }

            var resourceModel = ListResourceModel();
            var paginatedResult = new List<BandwidthSchedule>(resourceModel);
            while (!string.IsNullOrEmpty(resourceModel.NextPageLink))
            {
                resourceModel = ListResourceModel(resourceModel.NextPageLink);
                paginatedResult.AddRange(resourceModel);
            }

            return paginatedResult.Select(t => new PSStackEdgeBandWidthSchedule(t)).ToList();
        }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new StackEdgeResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.DeviceName = resourceIdentifier.DeviceName;
                this.Name = resourceIdentifier.ResourceName;
            }

            if (this.IsParameterBound(c => this.DeviceObject))
            {
                this.ResourceGroupName = this.DeviceObject.ResourceGroupName;
                this.DeviceName = this.DeviceObject.Name;
            }

            var results = ListPSResourceModels();
            WriteObject(results, true);
        }
    }
}
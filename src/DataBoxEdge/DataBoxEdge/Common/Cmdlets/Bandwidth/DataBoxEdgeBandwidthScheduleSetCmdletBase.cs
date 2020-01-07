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
using Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using ResourceModel = Microsoft.Azure.Management.DataBoxEdge.Models.BandwidthSchedule;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Cmdlets.Bandwidth
{
    using PSResourceModel = PSDataBoxEdgeBandWidthSchedule;

    [Cmdlet(VerbsCommon.Set, Constants.BandwidthSchedule, DefaultParameterSetName = UpdateByNameParameterSet,
         SupportsShouldProcess = true
     ),
     OutputType(typeof(PSResourceModel))]
    public class DataBoxEdgeBandwidthSetCmdletBase : AzureDataBoxEdgeCmdletBase
    {
        private const string UpdateByResourceIdParameterSet = "UpdateByResourceIdParameterSet";

        private const string UpdateByResourceIdParameterUnlimitedBandwidthSet =
            "UpdateByResourceIdParameterUnlimitedBandwidthSet";

        private const string UpdateByResourceIdParameterBandwidthSet = "UpdateByResourceIdParameterBandwidthSet";


        private const string UpdateByInputObjectParameterSet = "UpdateByInputObjectParameterSet";

        private const string UpdateByInputObjectParameterUnlimitedBandwidthSet =
            "UpdateByInputObjectParameterUnlimitedBandwidthSet";

        private const string UpdateByInputObjectParameterBandwidthSet = "UpdateByInputObjectParameterBandwidthSet";

        private const string UpdateByNameParameterSet = "UpdateByNameParameterSet";
        private const string UpdateByNameParameterUnlimitedBandwidthSet = "UpdateByNameParameterUnlimitedBandwidthSet";
        private const string UpdateByNameParameterBandwidthSet = "UpdateByNameParameterBandwidthSet";


        [Parameter(Mandatory = true, ParameterSetName = UpdateByResourceIdParameterSet,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByResourceIdParameterUnlimitedBandwidthSet,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByResourceIdParameterBandwidthSet,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByInputObjectParameterSet,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByInputObjectParameterUnlimitedBandwidthSet,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByInputObjectParameterBandwidthSet,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSResourceModel InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage, Position = 0)]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterUnlimitedBandwidthSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage, Position = 0)]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterBandwidthSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet,
            HelpMessage = Constants.DeviceNameHelpMessage, Position = 1)]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterUnlimitedBandwidthSet,
            HelpMessage = Constants.DeviceNameHelpMessage, Position = 1)]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterBandwidthSet,
            HelpMessage = Constants.DeviceNameHelpMessage, Position = 1)]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet,
            HelpMessage = Constants.NameHelpMessage, Position = 2)]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterUnlimitedBandwidthSet,
            HelpMessage = Constants.NameHelpMessage, Position = 2)]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterBandwidthSet,
            HelpMessage = Constants.NameHelpMessage, Position = 2)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageBandwidthSchedule.StartTime)]
        [ValidateNotNullOrEmpty]
        public string StartTime { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageBandwidthSchedule.StopTime)]
        [ValidateNotNullOrEmpty]
        public string StopTime { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageBandwidthSchedule.DaysOfWeek)]
        [ValidateNotNullOrEmpty]
        public string[] DaysOfWeek { get; set; }


        [Parameter(Mandatory = true, HelpMessage = HelpMessageBandwidthSchedule.Bandwidth,
            ParameterSetName = UpdateByResourceIdParameterBandwidthSet)]
        [Parameter(Mandatory = true, HelpMessage = HelpMessageBandwidthSchedule.Bandwidth,
            ParameterSetName = UpdateByInputObjectParameterBandwidthSet)]
        [Parameter(Mandatory = true, HelpMessage = HelpMessageBandwidthSchedule.Bandwidth,
            ParameterSetName = UpdateByNameParameterBandwidthSet)]
        [ValidateNotNullOrEmpty]
        public int Bandwidth { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageBandwidthSchedule.UnlimitedBandwidth,
            ParameterSetName = UpdateByResourceIdParameterUnlimitedBandwidthSet)]
        [Parameter(Mandatory = true, HelpMessage = HelpMessageBandwidthSchedule.UnlimitedBandwidth,
            ParameterSetName = UpdateByInputObjectParameterUnlimitedBandwidthSet)]
        [Parameter(Mandatory = true, HelpMessage = HelpMessageBandwidthSchedule.UnlimitedBandwidth,
            ParameterSetName = UpdateByNameParameterUnlimitedBandwidthSet)]
        [ValidateNotNullOrEmpty]
        public Boolean UnlimitedBandwidth { get; set; }


        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        private ResourceModel GetResourceModel()
        {
            return BandwidthSchedulesOperationsExtensions.Get(
                this.DataBoxEdgeManagementClient.BandwidthSchedules,
                this.DeviceName,
                this.Name,
                this.ResourceGroupName);
        }

        private PSResourceModel UpdateResourceModel()
        {
            var resourceModel = GetResourceModel();

            if (this.DaysOfWeek != null && this.DaysOfWeek.Length != 0)
            {
                var days = new List<string>(this.DaysOfWeek);
                resourceModel.Days = days;
            }

            if (this.Bandwidth > 0)
            {
                resourceModel.RateInMbps = Bandwidth;
            }

            if (UnlimitedBandwidth)
            {
                resourceModel.RateInMbps = 0;
            }


            if (!string.IsNullOrEmpty(this.StartTime))
            {
                resourceModel.Start = this.StartTime;
            }

            if (!string.IsNullOrEmpty(this.StartTime))
            {
                resourceModel.Stop = this.StopTime;
            }

            return new PSResourceModel(
                BandwidthSchedulesOperationsExtensions.CreateOrUpdate(
                    this.DataBoxEdgeManagementClient.BandwidthSchedules,
                    this.DeviceName,
                    this.Name,
                    resourceModel,
                    this.ResourceGroupName));
        }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new DataBoxEdgeResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.DeviceName = resourceIdentifier.DeviceName;
                this.Name = resourceIdentifier.ResourceName;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.DeviceName = this.InputObject.DeviceName;
                this.Name = this.InputObject.Name;
            }

            if (this.ShouldProcess(this.Name,
                string.Format("Updating '{0}' in device '{1}' with name '{2}'.",
                    HelpMessageBandwidthSchedule.ObjectName, this.DeviceName, this.Name)))
            {
                var result = UpdateResourceModel();
                WriteObject(result);
            }
        }
    }
}
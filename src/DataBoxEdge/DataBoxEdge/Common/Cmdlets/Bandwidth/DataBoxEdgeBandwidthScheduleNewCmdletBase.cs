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
using System.Collections.Generic;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using ResourceModel = Microsoft.Azure.Management.DataBoxEdge.Models.BandwidthSchedule;
using PSResourceModel = Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.PSDataBoxEdgeBandWidthSchedule;
using Resource = Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Resources.Resource;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Cmdlets.Bandwidth
{
    [Cmdlet(VerbsCommon.New,
         Constants.BandwidthSchedule,
         DefaultParameterSetName = BandwidthParameterSet,
         SupportsShouldProcess = true),
     OutputType(typeof(PSResourceModel))]
    public class DataBoxEdgeBandwidthNewCmdletBase : AzureDataBoxEdgeCmdletBase
    {
        private const string BandwidthParameterSet = "BandwidthParameterSet";
        private const string UnlimitedBandwidthParameterSet = "UnlimitedBandwidthParameterSet";

        [Parameter(Mandatory = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }


        [Parameter(Mandatory = true,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]

        public string DeviceName { get; set; }


        [Parameter(Mandatory = true,
            HelpMessage = Constants.NameHelpMessage,
            Position = 2)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageBandwidthSchedule.StartTime)]
        [ValidateNotNullOrEmpty]
        public string StartTime { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageBandwidthSchedule.StopTime)]
        [ValidateNotNullOrEmpty]
        public string StopTime { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageBandwidthSchedule.DaysOfWeek)]
        [ValidateNotNullOrEmpty]
        public string[] DaysOfWeek { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = BandwidthParameterSet,
            HelpMessage = HelpMessageBandwidthSchedule.Bandwidth)]
        [ValidateNotNullOrEmpty]
        public int Bandwidth { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UnlimitedBandwidthParameterSet,
            HelpMessage = HelpMessageBandwidthSchedule.NewUnlimitedBandwidth)]
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

        private string GetResourceNotFoundMessage()
        {
            return string.Format("'{0}'{1}{2}'.",
                HelpMessageBandwidthSchedule.ObjectName, Constants.ResourceAlreadyExists, this.Name);
        }

        private bool DoesResourceExists()
        {
            try
            {
                var resource = GetResourceModel();
                if (resource == null) return false;
                var msg = GetResourceNotFoundMessage();
                throw new Exception(msg);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }
        }

        private PSResourceModel CreateResourceModel()
        {
            if (this.IsParameterBound(c => c.UnlimitedBandwidth))
            {
                Bandwidth = UnlimitedBandwidth ? 0 : 20;
            }


            var days = new List<string>(this.DaysOfWeek);
            var resourceModel = new ResourceModel(
                this.StartTime,
                this.StopTime,
                Bandwidth,
                days,
                null,
                this.Name
            );
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
            if (this.ShouldProcess(this.Name,
                string.Format("Creating a new '{0}' in device '{1}' with name '{2}'.",
                    HelpMessageBandwidthSchedule.ObjectName, this.DeviceName, this.Name)))
            {
                DoesResourceExists();
                var results = new List<PSResourceModel>
                {
                    CreateResourceModel()
                };
                WriteObject(results, true);
            }
        }
    }
}
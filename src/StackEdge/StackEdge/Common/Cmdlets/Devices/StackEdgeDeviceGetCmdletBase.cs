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

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.Devices
{
    [Cmdlet(VerbsCommon.Get, Constants.Device, DefaultParameterSetName = ListByParameterSet
     ),
     OutputType(typeof(PSStackEdgeDevice))
    ]
    [OutputType(typeof(PSStackEdgeAlert))]
    [OutputType(typeof(PSStackEdgeNetworkAdapter))]
    [OutputType(typeof(PSStackEdgeUpdateSummary))]
    [OutputType(typeof(PSStackEdgeDeviceExtendedInfo))]
    public class StackEdgeDeviceGetCmdletBase : AzureStackEdgeCmdletBase
    {
        private const string ListByParameterSet = "ListByParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";
        private const string GetByNameParameterSet = "GetByNameParameterSet";


        [Parameter(Mandatory = true,
            ParameterSetName = GetByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ListByParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            ValueFromPipelineByPropertyName = true,
            Position = 0)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            ValueFromPipelineByPropertyName = true,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 1)]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias(HelpMessageDevice.NameAlias)]
        public string Name { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ListByParameterSet,
            HelpMessage = HelpMessageDevice.ExtendedInfoHelpMessage)]
        [Parameter(Mandatory = false,
            ParameterSetName = GetByResourceIdParameterSet,
            HelpMessage = HelpMessageDevice.ExtendedInfoHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ExtendedInfo { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ListByParameterSet,
            HelpMessage = HelpMessageDevice.NetworkSettingHelpMessage)]
        [Parameter(Mandatory = false,
            ParameterSetName = GetByResourceIdParameterSet,
            HelpMessage = HelpMessageDevice.NetworkSettingHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter NetworkSetting { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ListByParameterSet,
            HelpMessage = HelpMessageDevice.AlertHelpMessage)]
        [Parameter(Mandatory = false,
            ParameterSetName = GetByResourceIdParameterSet,
            HelpMessage = HelpMessageDevice.AlertHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Alert { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ListByParameterSet,
            HelpMessage = HelpMessageDevice.UpdateSummaryHelpMessage)]
        [Parameter(Mandatory = false,
            ParameterSetName = GetByResourceIdParameterSet,
            HelpMessage = HelpMessageDevice.UpdateSummaryHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter UpdateSummary { get; set; }

        private DataBoxEdgeDevice GetResourceModel()
        {
            return this.StackEdgeManagementClient.Devices.Get(
                this.Name,
                this.ResourceGroupName);
        }

        private IPage<DataBoxEdgeDevice> ListResourceModel()
        {
            if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                return this.StackEdgeManagementClient.Devices.ListByResourceGroup(
                    this.ResourceGroupName);
            }

            return this.StackEdgeManagementClient.Devices.ListBySubscription();
        }

        private IPage<DataBoxEdgeDevice> ListResourceModel(string nextPageLink)
        {
            if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                return this.StackEdgeManagementClient.Devices.ListByResourceGroupNext(
                    nextPageLink);
            }

            return this.StackEdgeManagementClient.Devices.ListBySubscriptionNext(
                nextPageLink
            );
        }

        private List<PSStackEdgeDevice> GetByResourceName()
        {
            var resourceModel = GetResourceModel();
            var psDevice = new PSStackEdgeDevice(resourceModel);
            return new List<PSStackEdgeDevice>() {psDevice};
        }

        private List<PSStackEdgeDevice> ListForEverything()
        {
            var results = new List<PSStackEdgeDevice>();
            if (!string.IsNullOrEmpty(this.Name))
            {
                results = GetByResourceName();
            }
            else
            {
                var resourceModels = ListResourceModel();
                var paginatedResult = new List<DataBoxEdgeDevice>(resourceModels);
                while (!string.IsNullOrEmpty(resourceModels.NextPageLink))
                {
                    resourceModels = ListResourceModel(resourceModels.NextPageLink);
                    paginatedResult.AddRange(resourceModels);
                }

                results = paginatedResult.Select(t => new PSStackEdgeDevice(t)).ToList();
            }

            foreach (var psDevice in results)
            {
                if (this.ExtendedInfo.IsPresent)
                {
                    psDevice.ExtendedInfo = GetExtendedInfo(psDevice.Name, psDevice.ResourceGroupName);
                }

                if (this.NetworkSetting.IsPresent)
                {
                    psDevice.NetworkSetting = GetNetworkSettings(psDevice.Name, psDevice.ResourceGroupName);
                }

                if (this.UpdateSummary.IsPresent)
                {
                    psDevice.UpdateSummary = GetUpdatedSummary(psDevice.Name, psDevice.ResourceGroupName);
                }

                if (this.Alert.IsPresent)
                {
                    psDevice.Alert = GetAlert(psDevice.Name, psDevice.ResourceGroupName);
                }
            }

            return results;
        }

        private IList<PSStackEdgeNetworkAdapter> GetNetworkSettings(string deviceName, string resourceGroupName)
        {
            var networkSettings = new PSStackEdgeNetworkSetting(
                this.StackEdgeManagementClient.Devices.GetNetworkSettings(
                    deviceName, resourceGroupName));
            return networkSettings.NetworkAdapters;
        }

        private PSStackEdgeDeviceExtendedInfo GetExtendedInfo(string deviceName, string resourceGroupName)
        {
            return new PSStackEdgeDeviceExtendedInfo(this.StackEdgeManagementClient.Devices.GetExtendedInformation(
                deviceName, resourceGroupName));
        }

        private PSStackEdgeUpdateSummary GetUpdatedSummary(string deviceName, string resourceGroupName)
        {
            return new PSStackEdgeUpdateSummary(this.StackEdgeManagementClient.Devices.GetUpdateSummary(
                deviceName, resourceGroupName));
        }


        private List<PSStackEdgeAlert> GetAlert(string deviceName, string resourceGroupName)
        {
            var alerts = new StackEdgeAlert(this.StackEdgeManagementClient, resourceGroupName, deviceName)
                .Get();
            return alerts;
        }

        public override void ExecuteCmdlet()
        {
            var results = new List<PSStackEdgeDevice>();
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new StackEdgeResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }

            results = ListForEverything();


            WriteObject(results, true);
        }
    }
}
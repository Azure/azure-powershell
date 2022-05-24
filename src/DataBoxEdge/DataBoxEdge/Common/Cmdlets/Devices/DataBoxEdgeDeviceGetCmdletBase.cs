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
using Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using ResourceModel = Microsoft.Azure.Management.DataBoxEdge.Models.DataBoxEdgeDevice;
using PSResourceModel = Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.PSDataBoxEdgeDevice;


namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Cmdlets.Devices
{
    [Cmdlet(VerbsCommon.Get, Constants.Device, DefaultParameterSetName = ListByParameterSet
     ),
     OutputType(typeof(PSResourceModel)),
    ]
    [OutputType(typeof(PSDataBoxEdgeNetworkAdapter), ParameterSetName =
        new[] {GetExtendedInfoParameterSet, GetExtendedInfoByResourceIdParameterSet})]
    [OutputType(typeof(PSDataBoxEdgeDeviceExtendedInfo), ParameterSetName =
        (new[] {GetExtendedInfoParameterSet, GetExtendedInfoByResourceIdParameterSet}))]
    [OutputType(typeof(PSDataBoxEdgeUpdateSummary), ParameterSetName =
        (new[] {GetSummaryUpdateByResourceIdParameterSet, GetSummaryUpdateParameterSet}))]
    [OutputType(typeof(PSDataBoxEdgeAlert), ParameterSetName =
        (new[] {GetAlertParameterSet, GetAlertByResourceIdParameterSet}))]
    public class DataBoxEdgeDeviceGetCmdletBase : AzureDataBoxEdgeCmdletBase
    {
        private const string ListByParameterSet = "ListByParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";
        private const string GetByNameParameterSet = "GetByNameParameterSet";

        private const string GetExtendedInfoParameterSet = "GetExtendedInfoParameterSet";
        private const string GetNetworkSettingParameterSet = "GetNetworkSettingParameterSet";
        private const string GetSummaryUpdateParameterSet = "GetSummaryUpdateParameterSet";
        private const string GetAlertParameterSet = "GetAlertParameterSet";

        private const string GetExtendedInfoByResourceIdParameterSet = "GetExtendedInfoByResourceIdParameterSet";
        private const string GetNetworkSettingByResourceIdParameterSet = "GetNetworkSettingByResourceIdParameterSet";
        private const string GetSummaryUpdateByResourceIdParameterSet = "GetSummaryUpdateByResourceIdParameterSet";
        private const string GetAlertByResourceIdParameterSet = "GetAlertByResourceIdParameterSet";

        [Parameter(Mandatory = true,
            ParameterSetName = GetByResourceIdParameterSet,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetExtendedInfoByResourceIdParameterSet,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetNetworkSettingByResourceIdParameterSet,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetSummaryUpdateByResourceIdParameterSet,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetAlertByResourceIdParameterSet,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ListByParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetSummaryUpdateParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetNetworkSettingParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetExtendedInfoParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetAlertParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetSummaryUpdateParameterSet,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetNetworkSettingParameterSet,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetExtendedInfoParameterSet,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetAlertParameterSet,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetExtendedInfoParameterSet,
            HelpMessage = HelpMessageDevice.ExtendedInfoHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetExtendedInfoByResourceIdParameterSet,
            HelpMessage = HelpMessageDevice.ExtendedInfoHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ExtendedInfo { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetNetworkSettingParameterSet,
            HelpMessage = HelpMessageDevice.NetworkSettingHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetNetworkSettingByResourceIdParameterSet,
            HelpMessage = HelpMessageDevice.NetworkSettingHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter NetworkSetting { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetAlertParameterSet,
            HelpMessage = HelpMessageDevice.AlertHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetAlertByResourceIdParameterSet,
            HelpMessage = HelpMessageDevice.AlertHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Alert { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetSummaryUpdateParameterSet,
            HelpMessage = HelpMessageDevice.UpdateSummaryHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetSummaryUpdateByResourceIdParameterSet,
            HelpMessage = HelpMessageDevice.UpdateSummaryHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter UpdateSummary { get; set; }

        private ResourceModel GetResourceModel()
        {
            return DevicesOperationsExtensions.Get(
                this.DataBoxEdgeManagementClient.Devices,
                this.Name,
                this.ResourceGroupName);
        }

        private IPage<ResourceModel> ListResourceModel()
        {
            if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                return DevicesOperationsExtensions.ListByResourceGroup(
                    this.DataBoxEdgeManagementClient.Devices,
                    this.ResourceGroupName);
            }

            return DevicesOperationsExtensions.ListBySubscription(
                this.DataBoxEdgeManagementClient.Devices);
        }

        private IPage<ResourceModel> ListResourceModel(string nextPageLink)
        {
            if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                return DevicesOperationsExtensions.ListByResourceGroupNext(
                    this.DataBoxEdgeManagementClient.Devices,
                    nextPageLink);
            }

            return DevicesOperationsExtensions.ListBySubscriptionNext(
                this.DataBoxEdgeManagementClient.Devices,
                nextPageLink
            );
        }

        private List<PSResourceModel> GetByResourceName()
        {
            var resourceModel = GetResourceModel();
            return new List<PSResourceModel>() {new PSResourceModel(resourceModel)};
        }

        private List<PSResourceModel> ListForEverything()
        {
            var results = new List<PSResourceModel>();
            if (!string.IsNullOrEmpty(this.Name))
            {
                return GetByResourceName();
            }
            else
            {
                var resourceModels = ListResourceModel();
                var paginatedResult = new List<ResourceModel>(resourceModels);
                while (!string.IsNullOrEmpty(resourceModels.NextPageLink))
                {
                    resourceModels = ListResourceModel(resourceModels.NextPageLink);
                    paginatedResult.AddRange(resourceModels);
                }

                results = paginatedResult.Select(t => new PSResourceModel(t)).ToList();
            }

            return results;
        }

        private IList<PSDataBoxEdgeNetworkAdapter> GetNetworkSettings()
        {
            var networkSettings = new PSDataBoxEdgeNetworkSetting(DevicesOperationsExtensions.GetNetworkSettings(
                this.DataBoxEdgeManagementClient.Devices,
                this.Name,
                this.ResourceGroupName));
            return networkSettings.NetworkAdapters;
        }

        private PSDataBoxEdgeDeviceExtendedInfo GetExtendedInfo()
        {
            return new PSDataBoxEdgeDeviceExtendedInfo(DevicesOperationsExtensions.GetExtendedInformation(
                this.DataBoxEdgeManagementClient.Devices,
                this.Name,
                this.ResourceGroupName));
        }

        private PSDataBoxEdgeUpdateSummary GetUpdatedSummary()
        {
            return new PSDataBoxEdgeUpdateSummary(DevicesOperationsExtensions.GetUpdateSummary(
                this.DataBoxEdgeManagementClient.Devices,
                this.Name,
                this.ResourceGroupName));
        }


        private List<PSDataBoxEdgeAlert> GetAlert()
        {
            var alerts = new DataBoxEdgeAlert(this.DataBoxEdgeManagementClient, this.ResourceGroupName, this.Name)
                .Get();
            return alerts;
        }

        public override void ExecuteCmdlet()
        {
            var results = new List<PSResourceModel>();
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new DataBoxEdgeResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }

            results = ListForEverything();
            if (this.ExtendedInfo.IsPresent)
            {
                WriteObject(GetExtendedInfo(), true);
            }
            else if (this.NetworkSetting.IsPresent)
            {
                WriteObject(GetNetworkSettings(), enumerateCollection: true);
            }
            else if (this.UpdateSummary.IsPresent)
            {
                var info = GetUpdatedSummary();
                WriteObject(info, enumerateCollection: true);
            }
            else if (this.Alert.IsPresent)
            {
                WriteObject(GetAlert(), enumerateCollection: true);
            }
            else
            {
                WriteObject(results, true);
            }
        }
    }
}
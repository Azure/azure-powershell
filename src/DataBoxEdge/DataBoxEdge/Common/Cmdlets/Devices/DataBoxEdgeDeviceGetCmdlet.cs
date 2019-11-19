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
using Microsoft.Azure.Management.EdgeGateway;
using Microsoft.Azure.Management.EdgeGateway.Models;
using Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;


namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Cmdlets.Devices
{
    [Cmdlet(VerbsCommon.Get, Constants.Device, DefaultParameterSetName = ListByParameterSet
     ),
     OutputType(typeof(PSDataBoxEdgeDevice)),
    ]
    [OutputType(typeof(PSDataBoxEdgeNetworkAdapter), ParameterSetName =
        new[] {GetExtendedInfoParameterSet, GetExtendedInfoByResourceIdParameterSet})]
    [OutputType(typeof(PSDataBoxEdgeDeviceExtendedInfo), ParameterSetName =
        (new[] {GetExtendedInfoParameterSet, GetExtendedInfoByResourceIdParameterSet}))]
    [OutputType(typeof(PSDataBoxEdgeUpdateSummary), ParameterSetName =
        (new[] {GetSummaryUpdateByResourceIdParameterSet, GetSummaryUpdateParameterSet}))]
    public class DataBoxEdgeDeviceGetCmdlet : AzureDataBoxEdgeCmdletBase
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
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetExtendedInfoByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetNetworkSettingByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetSummaryUpdateByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetAlertByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ListByParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetSummaryUpdateParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetNetworkSettingParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetExtendedInfoParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetAlertParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            ValueFromPipelineByPropertyName = true,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetSummaryUpdateParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            ValueFromPipelineByPropertyName = true,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetNetworkSettingParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            ValueFromPipelineByPropertyName = true,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetExtendedInfoParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            ValueFromPipelineByPropertyName = true,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetAlertParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            ValueFromPipelineByPropertyName = true,
            Position = 1)]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias("DeviceName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetExtendedInfoParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetExtendedInfoByResourceIdParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ExtendedInfo { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetNetworkSettingParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetNetworkSettingByResourceIdParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage)]
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
            HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetSummaryUpdateByResourceIdParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter UpdateSummary { get; set; }

        private DataBoxEdgeDevice GetResource()
        {
            return this.DataBoxEdgeManagementClient.Devices.Get(
                this.Name,
                this.ResourceGroupName);
        }

        private IPage<DataBoxEdgeDevice> ListResource()
        {
            if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                return this.DataBoxEdgeManagementClient.Devices.ListByResourceGroup(
                    this.ResourceGroupName);
            }

            return this.DataBoxEdgeManagementClient.Devices.ListBySubscription();
        }

        private IPage<DataBoxEdgeDevice> ListResource(string nextPageLink)
        {
            if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                return this.DataBoxEdgeManagementClient.Devices.ListByResourceGroupNext(
                    nextPageLink);
            }

            return this.DataBoxEdgeManagementClient.Devices.ListBySubscriptionNext(
                nextPageLink
            );
        }

        private List<PSDataBoxEdgeDevice> GetResourceByName()
        {
            var resource = GetResource();
            return new List<PSDataBoxEdgeDevice>() {new PSDataBoxEdgeDevice(resource)};
        }

        private List<PSDataBoxEdgeDevice> ListForEverything()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                return GetResourceByName();
            }

            var listResource = ListResource();
            var paginatedResult = new List<DataBoxEdgeDevice>(listResource);
            while (!string.IsNullOrEmpty(listResource.NextPageLink))
            {
                listResource = ListResource(listResource.NextPageLink);
                paginatedResult.AddRange(listResource);
            }

            return paginatedResult.Select(t => new PSDataBoxEdgeDevice(t)).ToList();
        }

        private IList<PSDataBoxEdgeNetworkAdapter> GetNetworkSettings()
        {
            var networkSettings = new PSDataBoxEdgeNetworkSetting(
                this.DataBoxEdgeManagementClient.Devices.GetNetworkSettings(
                    this.Name,
                    this.ResourceGroupName));
            return networkSettings.NetworkAdapters;
        }

        private PSDataBoxEdgeDeviceExtendedInfo GetExtendedInfo()
        {
            return new PSDataBoxEdgeDeviceExtendedInfo(this.DataBoxEdgeManagementClient.Devices.GetExtendedInformation(
                this.Name,
                this.ResourceGroupName));
        }

        private PSDataBoxEdgeUpdateSummary GetUpdatedSummary()
        {
            return new PSDataBoxEdgeUpdateSummary(this.DataBoxEdgeManagementClient.Devices.GetUpdateSummary(
                this.Name,
                this.ResourceGroupName));
        }


        private List<PSDataBoxEdgeAlert> GetAlert()
        {
            var alerts = new DataBoxEdgeDeviceAlert(this.DataBoxEdgeManagementClient, this.ResourceGroupName, this.Name)
                .Get();
            return alerts;
        }

        public override void ExecuteCmdlet()
        {
            var results = new List<PSDataBoxEdgeDevice>();
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
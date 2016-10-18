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

namespace Microsoft.Azure.Commands.Management.IotHub
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Linq;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;

    [Cmdlet(VerbsCommon.Set, "AzureRmIotHub")]
    [OutputType(typeof(PSIotHub))]
    public class SetAzureRmIotHub : IotHubBaseCmdlet
    {
        const string UpdateSkuParameterSet = "UpdateSku";
        const string UpdateEventHubEndpointPropertiesParameterSet = "UpdateEventHubEndpointProperties";
        const string UpdateFileUploadPropertiesParameterSet = "UpdateFileUploadProperties";
        const string UpdateCloudToDevicePropertiesParameterSet = "UpdateCloudToDeviceProperties";
        const string UpdateOperationsMonitoringPropertiesParameterSet = "UpdateOperationsMonitoringProperties";

        [Parameter(
            Position = 0,
            ParameterSetName = UpdateSkuParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name")]
        [Parameter(
            Position = 0,
            ParameterSetName = UpdateEventHubEndpointPropertiesParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name")]
        [Parameter(
            Position = 0,
            ParameterSetName = UpdateFileUploadPropertiesParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name")]
        [Parameter(
            Position = 0,
            ParameterSetName = UpdateCloudToDevicePropertiesParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name")]
        [Parameter(
            Position = 0,
            ParameterSetName = UpdateOperationsMonitoringPropertiesParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            ParameterSetName = UpdateSkuParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name")]
        [Parameter(
            Position = 1,
            ParameterSetName = UpdateEventHubEndpointPropertiesParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name")]
        [Parameter(
            Position = 1,
            ParameterSetName = UpdateFileUploadPropertiesParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name")]
        [Parameter(
            Position = 1,
            ParameterSetName = UpdateCloudToDevicePropertiesParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name")]
        [Parameter(
            Position = 1,
            ParameterSetName = UpdateOperationsMonitoringPropertiesParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = UpdateSkuParameterSet,
            Mandatory = true,
            HelpMessage = "SkuName")]
        [ValidateNotNullOrEmpty]
        public PSIotHubSku SkuName { get; set; }

        [Parameter(
            ParameterSetName = UpdateSkuParameterSet,
            Mandatory = true,
            HelpMessage = "Units")]
        [ValidateNotNullOrEmpty]
        public long Units { get; set; }

        [Parameter(
            ParameterSetName = UpdateEventHubEndpointPropertiesParameterSet,
            Mandatory = true,
            HelpMessage = "EventHubRetentionTimeInDays")]
        [ValidateNotNullOrEmpty]
        public long EventHubRetentionTimeInDays { get; set; }

        [Parameter(
            ParameterSetName = UpdateFileUploadPropertiesParameterSet,
            Mandatory = false,
            HelpMessage = "FileUploadStorageConnectionString")]
        [ValidateNotNullOrEmpty]
        public string FileUploadStorageConnectionString { get; set; }

        [Parameter(
            ParameterSetName = UpdateFileUploadPropertiesParameterSet,
            Mandatory = false,
            HelpMessage = "FileUploadContainerName")]
        [ValidateNotNullOrEmpty]
        public string FileUploadContainerName { get; set; }

        [Parameter(
            ParameterSetName = UpdateFileUploadPropertiesParameterSet,
            Mandatory = false,
            HelpMessage = "FileUploadSasUriTtl")]
        [ValidateNotNullOrEmpty]
        public TimeSpan FileUploadSasUriTtl { get; set; }

        [Parameter(
            ParameterSetName = UpdateFileUploadPropertiesParameterSet,
            Mandatory = false,
            HelpMessage = "FileUploadNotificationTtl")]
        [ValidateNotNullOrEmpty]
        public TimeSpan FileUploadNotificationTtl { get; set; }

        [Parameter(
            ParameterSetName = UpdateFileUploadPropertiesParameterSet,
            Mandatory = false,
            HelpMessage = "fileUploadNotificationMaxDeliveryCount")]
        [ValidateNotNullOrEmpty]
        public int? FileUploadNotificationMaxDeliveryCount { get; set; }

        [Parameter(
            ParameterSetName = UpdateFileUploadPropertiesParameterSet,
            Mandatory = true,
            HelpMessage = "EnableFileUploadNotifications")]
        [ValidateNotNullOrEmpty]
        public bool EnableFileUploadNotifications { get; set; }

        [Parameter(
            ParameterSetName = UpdateCloudToDevicePropertiesParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "CloudToDevice")]
        [ValidateNotNullOrEmpty]
        public PSCloudToDeviceProperties CloudToDevice { get; set; }

        [Parameter(
            ParameterSetName = UpdateOperationsMonitoringPropertiesParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "OperationsMonitoringProperties")]
        [ValidateNotNullOrEmpty]
        public PSOperationsMonitoringProperties OperationsMonitoringProperties { get; set; }

        public override void ExecuteCmdlet()
        {
            IotHubDescription iotHubDescription = this.IotHubClient.IotHubResource.Get(this.ResourceGroupName, this.Name);

            switch (ParameterSetName)
            {
                case UpdateSkuParameterSet:

                    var psIotHubSku = new PSIotHubSkuInfo()
                    {
                        Name = this.SkuName,
                        Capacity = this.Units
                    };

                    iotHubDescription.Sku = IotHubUtils.ToIotHubSku(psIotHubSku);
                    break;
                case UpdateEventHubEndpointPropertiesParameterSet:

                    iotHubDescription.Properties.EventHubEndpoints["events"].RetentionTimeInDays = this.EventHubRetentionTimeInDays;
                    iotHubDescription.Properties.EventHubEndpoints["operationsMonitoringEvents"].RetentionTimeInDays = this.EventHubRetentionTimeInDays;
                    break;
                case UpdateFileUploadPropertiesParameterSet:

                    iotHubDescription.Properties.EnableFileUploadNotifications = this.EnableFileUploadNotifications;

                    if (this.FileUploadStorageConnectionString != null)
                    {
                        iotHubDescription.Properties.StorageEndpoints["$default"].ConnectionString = this.FileUploadStorageConnectionString;
                    }

                    if (this.FileUploadContainerName != null)
                    {
                        iotHubDescription.Properties.StorageEndpoints["$default"].ContainerName = this.FileUploadContainerName;
                    }

                    if (this.FileUploadSasUriTtl != null)
                    {
                        iotHubDescription.Properties.StorageEndpoints["$default"].SasTtlAsIso8601 = this.FileUploadSasUriTtl;
                    }

                    if (this.FileUploadNotificationTtl != null)
                    {
                        iotHubDescription.Properties.MessagingEndpoints["fileNotifications"].TtlAsIso8601 = this.FileUploadNotificationTtl;
                    }

                    if (this.FileUploadNotificationMaxDeliveryCount != null)
                    {
                        iotHubDescription.Properties.MessagingEndpoints["fileNotifications"].MaxDeliveryCount = (int)this.FileUploadNotificationMaxDeliveryCount;
                    }

                    break;
                case UpdateCloudToDevicePropertiesParameterSet:

                    if (this.CloudToDevice != null)
                    {
                        iotHubDescription.Properties.CloudToDevice = IotHubUtils.ToCloudToDeviceProperties(this.CloudToDevice);
                    }

                    break;
                case UpdateOperationsMonitoringPropertiesParameterSet:

                    if (this.OperationsMonitoringProperties != null)
                    {
                        iotHubDescription.Properties.OperationsMonitoringProperties = IotHubUtils.ToOperationsMonitoringProperties(this.OperationsMonitoringProperties);
                    }

                    break;
                default:
                    throw new ArgumentException("BadParameterSetName");
            }

            this.IotHubClient.IotHubResource.CreateOrUpdate(this.ResourceGroupName, this.Name, iotHubDescription);
            IotHubDescription updatedIotHubDescription = this.IotHubClient.IotHubResource.Get(this.ResourceGroupName, this.Name);
            this.WriteObject(IotHubUtils.ToPSIotHub(updatedIotHubDescription), false);
        }
    }
}

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
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;

    [Cmdlet(VerbsCommon.Set, "AzureRmIotHub", DefaultParameterSetName = "UpdateSku", SupportsShouldProcess = true)]
    [OutputType(typeof(PSIotHub))]
    public class SetAzureRmIotHub : IotHubBaseCmdlet
    {
        const string UpdateSkuParameterSet = "UpdateSku";
        const string UpdateEventHubEndpointPropertiesParameterSet = "UpdateEventHubEndpointProperties";
        const string UpdateFileUploadPropertiesParameterSet = "UpdateFileUploadProperties";
        const string UpdateCloudToDevicePropertiesParameterSet = "UpdateCloudToDeviceProperties";
        const string UpdateOperationsMonitoringPropertiesParameterSet = "UpdateOperationsMonitoringProperties";

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Resource Group")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = UpdateSkuParameterSet,
            Mandatory = true,
            HelpMessage = "Name of the Sku")]
        [ValidateNotNullOrEmpty]
        public PSIotHubSku SkuName { get; set; }

        [Parameter(
            ParameterSetName = UpdateSkuParameterSet,
            Mandatory = false,
            HelpMessage = "Number of Units")]
        [ValidateNotNullOrEmpty]
        public long Units { get; set; }

        [Parameter(
            ParameterSetName = UpdateEventHubEndpointPropertiesParameterSet,
            Mandatory = true,
            HelpMessage = "RetentionTimeInDays for Eventhub")]
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
            Mandatory = true,
            HelpMessage = "Properties for CloudToDevice Messages")]
        [ValidateNotNullOrEmpty]
        public PSCloudToDeviceProperties CloudToDevice { get; set; }

        [Parameter(
            ParameterSetName = UpdateOperationsMonitoringPropertiesParameterSet,
            Mandatory = true,
            HelpMessage = "OperationsMonitoringProperties")]
        [ValidateNotNullOrEmpty]
        public PSOperationsMonitoringProperties OperationsMonitoringProperties { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, Properties.Resources.UpdateIotHub))
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
}

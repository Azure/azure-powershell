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

namespace Microsoft.Azure.Commands.Management.IotHub.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The properties related to storage container endpoint types.
    /// </summary>
    public partial class PSRoutingStorageContainerProperties
    {
        /// <summary>
        /// Gets or sets the connection string of the storage account.
        /// </summary>
        [JsonProperty(PropertyName = "connectionString")]
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the name that identifies this endpoint. The name can
        /// only include alphanumeric characters, periods, underscores, hyphens
        /// and has a maximum length of 64 characters. The following names are
        /// reserved:  events, operationsMonitoringEvents, fileNotifications,
        /// $default. Endpoint names must be unique across endpoint types.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the subscription identifier of the storage account.
        /// </summary>
        [JsonProperty(PropertyName = "subscriptionId")]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group of the storage account.
        /// </summary>
        [JsonProperty(PropertyName = "resourceGroup")]
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets the name of storage container in the storage account.
        /// </summary>
        [JsonProperty(PropertyName = "containerName")]
        public string ContainerName { get; set; }

        /// <summary>
        /// Gets or sets file name format for the blob. Default format is
        /// {iothub}/{partition}/{YYYY}/{MM}/{DD}/{HH}/{mm}. All parameters are
        /// mandatory but can be reordered.
        /// </summary>
        [JsonProperty(PropertyName = "fileNameFormat")]
        public string FileNameFormat { get; set; }

        /// <summary>
        /// Gets or sets time interval at which blobs are written to storage.
        /// Value should be between 60 and 720 seconds. Default value is 300
        /// seconds.
        /// </summary>
        [JsonProperty(PropertyName = "batchFrequencyInSeconds")]
        public int? BatchFrequencyInSeconds { get; set; }

        /// <summary>
        /// Gets or sets maximum number of bytes for each blob written to
        /// storage. Value should be between 10485760(10MB) and
        /// 524288000(500MB). Default value is 314572800(300MB).
        /// </summary>
        [JsonProperty(PropertyName = "maxChunkSizeInBytes")]
        public int? MaxChunkSizeInBytes { get; set; }

        /// <summary>
        /// Gets or sets encoding that is used to serialize messages to blobs.
        /// Supported values are 'avro' and 'avrodeflate'. Default value is
        /// 'avro'.
        /// </summary>
        [JsonProperty(PropertyName = "encoding")]
        public string Encoding { get; set; }
    }

    /// <summary>
    /// The properties related to storage container endpoint type.
    /// </summary>
    public partial class PSRoutingStorageContainerEndpoint : PSRoutingStorageContainerProperties
    {
    }
}

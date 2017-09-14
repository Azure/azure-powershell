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

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    class Nouns
    {
        public const string Prefix = "Azs";
        public const string StoragePrefix = "Storage";

        // Metrics
        public const string Metric = "Metric";
        public const string MetricDefinition = "MetricDefinition";

        // farm
        public const string AdminFarm = Prefix + StoragePrefix + "Farm";
        public const string AdminFarmMetric = AdminFarm + Metric;
        public const string AdminFarmMetricDefinition = AdminFarm + MetricDefinition;

        // service Metrics
        public const string AdminTableService = Prefix + "TableService";
        public const string AdminQueueService = Prefix + "QueueService";
        public const string AdminBlobService = Prefix + "BlobService";

        public const string AdminTableServiceMetric = AdminTableService + Metric;
        public const string AdminTableServiceMetricDefinition = AdminTableService + MetricDefinition;

        public const string AdminQueueServiceMetric = AdminQueueService + Metric;
        public const string AdminQueueServiceMetricDefinition = AdminQueueService + MetricDefinition;

        public const string AdminBlobServiceMetric = AdminBlobService + Metric;
        public const string AdminBlobServiceMetricDefinition = AdminBlobService + MetricDefinition;

        // share 
        public const string AdminShare = Prefix + StoragePrefix + "Share";
        public const string AdminShareMetric = AdminShare + Metric;
        public const string AdminShareMetricDefinition = AdminShare + MetricDefinition;

        // storage account
        public const string AdminStorageAccount = Prefix + "StorageAccount";
        public const string AdminOnDemandGc = Prefix + "ReclaimStorageCapacity";
        public const string AdminOnDemandGcStatus = Prefix + "ReclaimStorageCapacityStatus";

        // acquisition
        public const string AdminAcquisition = Prefix + StoragePrefix + "Acquisition";

        // storage account deletion operation
        public const string AdminStorageAccountDeletion = Prefix + "DeletedStorageAccount";

        // quota
        public const string AdminQuota = Prefix + StoragePrefix + "Quota";

        // Container Migration
        public const string AdminContainer                      = Prefix + StoragePrefix + "Container";
        public const string AdminContainerMigration             = Prefix + StoragePrefix + "ContainerMigration";
        public const string AdminContainerMigrationStatus       = Prefix + StoragePrefix + "ContainerMigrationStatus";
    }
}

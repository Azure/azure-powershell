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

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    class Nouns
    {
        public const string Prefix = "ACS";

        public const string Metric = "Metric";

        public const string MetricDefinition = "MetricDefinition";


        // farm
        public const string AdminFarm = Prefix + "Farm";

        public const string AdminFarmMetric = AdminFarm + Metric;

        public const string AdminFarmMetricDefinition = AdminFarm + MetricDefinition;

        public const string AdminFarmEvent = Prefix + "Event";

        public const string AdminFarmEventQuery = Prefix + "EventQuery";

        // LogCollect
        public const string Log = Prefix + "Log";

        // node
        public const string AdminNode = Prefix + "Node";

        public const string AdminNodeMetric = AdminNode + Metric;

        public const string AdminNodeMetricDefinition = AdminNode + MetricDefinition;

        // blob server role instance
        public const string AdminBlobServerRoleInstance = Prefix + "BlobServerRoleInstance";

        // role instance
        public const string AdminRoleInstance = Prefix + "RoleInstance";

        // role instance
        public const string AdminRoleInstanceSettingsPullNow = Prefix + "RoleInstancePullSettings";

        public const string AdminRoleInstanceMetric = AdminRoleInstance + Metric;

        public const string AdminRoleInstanceMetricDefinition = AdminRoleInstance + MetricDefinition;

        // service
        public const string AdminTableService = Prefix + "TableService";
        public const string AdminBlobService = Prefix + "BlobService";
        public const string AdminManagementService = Prefix + "ManagementService";

        public const string AdminTableServiceMetric = AdminTableService + Metric;
        public const string AdminTableServiceMetricDefinition = AdminTableService + MetricDefinition;

        public const string AdminBlobServiceMetric = AdminBlobService + Metric;
        public const string AdminBlobServiceMetricDefinition = AdminBlobService + MetricDefinition;

        public const string AdminManagementServiceMetric = AdminManagementService + Metric;
        public const string AdminManagementServiceMetricDefinition = AdminManagementService + MetricDefinition;

        // share 
        public const string AdminShare = Prefix + "Share";

        public const string AdminShareMetric = AdminShare + Metric;

        public const string AdminShareMetricDefinition = AdminShare + MetricDefinition;

        // fault 
        public const string AdminFault = Prefix + "Fault";

        // role instance
        public const string AdminInstance = Prefix + "Instance";

        // storage account
        public const string AdminStorageAccount = Prefix + "StorageAccount";

        // storage account deletion operation
        public const string AdminStorageAccountDeletion = Prefix + "StorageAccountDeletion";
    }
}

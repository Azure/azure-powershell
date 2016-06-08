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

namespace Microsoft.Azure.Commands.Batch.Utils
{
    public class Constants
    {
        public const int DefaultMaxCount = 1000;

        // ARM cmdlet nouns
        public const string AzureRmBatchAccount = "AzureRmBatchAccount";
        public const string AzureRmBatchAccountKey = "AzureRmBatchAccountKey";
        public const string AzureRmBatchAccountKeys = "AzureRmBatchAccountKeys";
        public const string AzureRmBatchSubscriptionQuotas = "AzureRmBatchSubscriptionQuotas";
        public const string AzureRmBatchApplication = "AzureRmBatchApplication";
        public const string AzureRmBatchApplicationPackage = "AzureRmBatchApplicationPackage";

        // Batch Service cmdlet nouns
        public const string AzureBatchPool = "AzureBatchPool";
        public const string AzureBatchPoolUsageMetrics = "AzureBatchPoolUsageMetrics";
        public const string AzureBatchPoolResize = "AzureBatchPoolResize";
        public const string AzureBatchComputeNode = "AzureBatchComputeNode";
        public const string AzureBatchComputeNodeScheduling = "AzureBatchComputeNodeScheduling";
        public const string AzureBatchComputeNodeUser = "AzureBatchComputeNodeUser";
        public const string AzureBatchJobSchedule = "AzureBatchJobSchedule";
        public const string AzureBatchJob = "AzureBatchJob";
        public const string AzureBatchJobStatistics = "AzureBatchJobStatistics";
        public const string AzureBatchTask = "AzureBatchTask";
        public const string AzureBatchSubtask = "AzureBatchSubtask";
        public const string AzureBatchNodeFile = "AzureBatchNodeFile";
        public const string AzureBatchNodeFileContent = "AzureBatchNodeFileContent";
        public const string AzureBatchRemoteDesktopProtocolFile = "AzureBatchRemoteDesktopProtocolFile";
        public const string AzureBatchRemoteLoginSettings = "AzureBatchRemoteLoginSettings";
        public const string AzureBatchAutoScale = "AzureBatchAutoScale";
        public const string AzureBatchPoolOSVersion = "AzureBatchPoolOSVersion";
        public const string AzureBatchPoolStatistics = "AzureBatchPoolStatistics";
        public const string AzureBatchCertificate = "AzureBatchCertificate";
        public const string AzureBatchCertificateDeletion = "AzureBatchCertificateDeletion";
        public const string AzureBatchNodeAgentSku = "AzureBatchNodeAgentSku";

        // Parameter sets
        public const string IdParameterSet = "Id";
        public const string ODataFilterParameterSet = "ODataFilter";
        public const string InputObjectParameterSet = "InputObject";
        public const string ParentObjectParameterSet = "ParentObject";
        public const string InputObjectAndPathParameterSet = "InputObject_Path";
        public const string InputObjectAndStreamParameterSet = "InputObject_Stream";
    }
}

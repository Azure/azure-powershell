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

        // Cmdlet nouns

        public const string AzureBatchAccount = "AzureRMBatchAccount";
        public const string AzureBatchAccountKey = "AzureRMBatchAccountKey";
        public const string AzureBatchAccountKeys = "AzureRMBatchAccountKeys";



        public const string AzureBatchPool = "AzureRMBatchPool";
        public const string AzureBatchPoolResize = "AzureRMBatchPoolResize";
        public const string AzureBatchComputeNode = "AzureRMBatchComputeNode";
        public const string AzureBatchComputeNodeUser = "AzureRMBatchComputeNodeUser";
        public const string AzureBatchJobSchedule = "AzureRMBatchJobSchedule";
        public const string AzureBatchJob = "AzureRMBatchJob";
        public const string AzureBatchTask = "AzureRMBatchTask";
        public const string AzureBatchNodeFile = "AzureRMBatchNodeFile";
        public const string AzureBatchNodeFileContent = "AzureRMBatchNodeFileContent";
        public const string AzureBatchRemoteDesktopProtocolFile = "AzureRMBatchRemoteDesktopProtocolFile";
        public const string AzureBatchAutoScale = "AzureRMBatchAutoScale";
        public const string AzureBatchPoolOSVersion = "AzureRMBatchPoolOSVersion";

        // Parameter sets
        public const string IdParameterSet = "Id";
        public const string ODataFilterParameterSet = "ODataFilter";
        public const string InputObjectParameterSet = "InputObject";
        public const string ParentObjectParameterSet = "ParentObject";
        public const string InputObjectAndPathParameterSet = "InputObject_Path";
        public const string InputObjectAndStreamParameterSet = "InputObject_Stream";
    }
}

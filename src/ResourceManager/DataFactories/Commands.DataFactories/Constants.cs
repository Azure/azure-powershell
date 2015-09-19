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

using System;

namespace Microsoft.Azure.Commands.DataFactories
{
    internal static class Constants
    {
        public static readonly TimeSpan DefaultSliceActivePeriodDuration = TimeSpan.FromHours(48);

        public const string DataFactory = "AzureRMDataFactory";

        public const string LinkedService = "AzureRMDataFactoryLinkedService";

        public const string Gateway = "AzureRMDataFactoryGateway";

        public const string GatewayKey = "AzureRMDataFactoryGatewayKey";

        public const string EncryptString = "AzureRMDataFactoryEncryptValue";

        public const string Dataset = "AzureRMDataFactoryDataset";

        public const string Pipeline = "AzureRMDataFactoryPipeline";

        public const string PipelineActivePeriod = "AzureRMDataFactoryPipelineActivePeriod";

        public const string Run = "AzureRMDataFactoryRun";

        public const string DataSlice = "AzureRMDataFactorySlice";

        public const string SliceStatus = "AzureRMDataFactorySliceStatus";

        public const string Hub = "AzureRMDataFactoryHub";

        public const string RunLog = "AzureRMDataFactoryLog";
    }
}
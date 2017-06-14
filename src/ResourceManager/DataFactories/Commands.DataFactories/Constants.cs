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

        public const string DataFactory = "AzureRmDataFactory";

        public const string LinkedService = "AzureRmDataFactoryLinkedService";

        public const string Gateway = "AzureRmDataFactoryGateway";

        public const string ActivityWindows = "AzureRmDataFactoryActivityWindow";

        public const string GatewayKey = "AzureRmDataFactoryGatewayKey";

        public const string EncryptString = "AzureRmDataFactoryEncryptValue";

        public const string Dataset = "AzureRmDataFactoryDataset";

        public const string Pipeline = "AzureRmDataFactoryPipeline";

        public const string PipelineActivePeriod = "AzureRmDataFactoryPipelineActivePeriod";

        public const string Run = "AzureRmDataFactoryRun";

        public const string DataSlice = "AzureRmDataFactorySlice";

        public const string SliceStatus = "AzureRmDataFactorySliceStatus";

        public const string Hub = "AzureRmDataFactoryHub";

        public const string RunLog = "AzureRmDataFactoryLog";
    }
}

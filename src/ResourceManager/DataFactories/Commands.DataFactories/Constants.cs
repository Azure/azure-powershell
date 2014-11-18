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

        public const string DataFactory = "AzureDataFactory";

        public const string LinkedService = "AzureDataFactoryLinkedService";

        public const string Gateway = "AzureDataFactoryGateway";

        public const string GatewayKey = "AzureDataFactoryGatewayKey";

        public const string EncryptString = "AzureDataFactoryEncryptValue";

        public const string Table = "AzureDataFactoryTable";

        public const string Pipeline = "AzureDataFactoryPipeline";

        public const string PipelineActivePeriod = "AzureDataFactoryPipelineActivePeriod";

        public const string Run = "AzureDataFactoryRun";

        public const string DataSlice = "AzureDataFactorySlice";

        public const string SliceStatus = "AzureDataFactorySliceStatus";

        public const string Hub = "AzureDataFactoryHub";

        public const string RunLog = "AzureDataFactoryLog";
    }
}
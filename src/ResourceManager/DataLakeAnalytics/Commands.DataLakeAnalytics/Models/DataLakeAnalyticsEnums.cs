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

namespace Microsoft.Azure.Commands.DataLakeAnalytics.Models
{
    public class DataLakeAnalyticsEnums
    {
        public enum CatalogItemType
        {
            Database,
            Schema,
            Assembly,
            Table,
            TablePartition,
            TableValuedFunction,
            TableStatistics,
            ExternalDataSource,
            View,
            Procedure,
            Secret,
            Credential,
            Types
        }

        // TODO: once we support creating other catalog types, move this up into CatalogItemType
        public enum CreatableCatalogItemType
        {
            Secret
        }

        public enum DataSourceType
        {
            DataLakeStore,
            Blob
        }

        public enum ExtendedJobData
        {
            None,
            All,
            DebugInfo,
            Statistics
        };
    }
}
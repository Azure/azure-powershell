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

using System.Collections.Generic;
using Microsoft.Azure.Management.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSLinkedStorageAccountsResource
    {
        public PSLinkedStorageAccountsResource(PSDataSourceType? dataSourceType = default(PSDataSourceType?), IList<string> storageAccountIds = default(IList<string>))
        {
            DataSourceType = dataSourceType;
            StorageAccountIds = storageAccountIds;
        }

        public PSLinkedStorageAccountsResource(LinkedStorageAccountsResource resource)
        {
            DataSourceType = "CustomLogs".Equals(resource.DataSourceType.Value)
                ? PSDataSourceType.CustomLogs
                : PSDataSourceType.AzureWatson;

            StorageAccountIds = resource.StorageAccountIds;
        }

        public PSDataSourceType? DataSourceType { get; private set; }

        public IList<string> StorageAccountIds { get; set; }
    }
}

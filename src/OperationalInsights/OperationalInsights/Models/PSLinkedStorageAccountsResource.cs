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
using System.Linq;
using Microsoft.Azure.Management.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSLinkedStorageAccountsResource
    {
        public PSLinkedStorageAccountsResource(string id, string name, string type = default(string), string dataSourceType = default(string), IList<string> storageAccountIds = default(IList<string>))
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.DataSourceType = getPSDataSourceType(dataSourceType);
            this.StorageAccountIds = storageAccountIds;
        }

        public PSLinkedStorageAccountsResource(LinkedStorageAccountsResource resource)
        {
            this.Id = resource.Id;
            this.Name = resource.Name;
            this.Type = resource.Type;
            this.DataSourceType = getPSDataSourceType(resource.DataSourceType.ToString());
            this.StorageAccountIds = resource.StorageAccountIds;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Type { get; private set; }

        public PSDataSourceType? DataSourceType { get; private set; }

        public IList<string> StorageAccountIds { get; set; }

        public static DataSourceType getDataSourceType(string type)
        {
            return "CustomLogs".Equals(type)
                ? Microsoft.Azure.Management.OperationalInsights.Models.DataSourceType.CustomLogs
                : Microsoft.Azure.Management.OperationalInsights.Models.DataSourceType.AzureWatson;
        }

        private PSDataSourceType getPSDataSourceType(string type)
        {
            return "CustomLogs".Equals(type)
                ? PSDataSourceType.CustomLogs
                : PSDataSourceType.AzureWatson;
        }
    }
}

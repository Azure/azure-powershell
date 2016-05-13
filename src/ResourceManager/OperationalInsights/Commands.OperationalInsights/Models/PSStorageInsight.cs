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

using Microsoft.Azure.Management.OperationalInsights.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    using System.Linq;

    public class PSStorageInsight
    {
        public PSStorageInsight()
        {
        }

        public PSStorageInsight(StorageInsight storageInsight, string resourceGroupName, string workspaceName)
        {
            if (storageInsight == null)
            {
                throw new ArgumentNullException("storageInsight");
            }

            this.ResourceGroupName = resourceGroupName;
            this.WorkspaceName = workspaceName;
            this.Name = storageInsight.Name;
            this.ResourceId = storageInsight.Id;

            if (storageInsight.Properties != null)
            {
                this.StorageAccountResourceId = storageInsight.Properties.StorageAccount != null ? storageInsight.Properties.StorageAccount.Id : null;
                this.Tables = storageInsight.Properties.Tables.ToList();
                this.Containers = storageInsight.Properties.Containers.ToList();
                this.State = storageInsight.Properties.Status != null ? storageInsight.Properties.Status.State : null;
            }
        }

        public string Name { get; set; }

        public string ResourceId { get; set; }

        public string ResourceGroupName { get; set; }

        public string WorkspaceName { get; set; }

        public string StorageAccountResourceId { get; set; }

        public string State { get; set; }

        public List<string> Tables { get; set; }

        public List<string> Containers { get; set; }
    }
}

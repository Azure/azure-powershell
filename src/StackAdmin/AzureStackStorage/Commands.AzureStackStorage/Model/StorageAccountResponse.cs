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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    internal class StorageAccountResponse : ResponseBase
    {
        public StorageAccountResponse(StorageAccountModel model, string farmName)
            : base(model)
        {
            // Manually set those with different names or in root
            this.AccountId = model.Name;
            this.AdminViewId = model.Id;
            this.Location = model.Location;
            this.Type = model.Type;
            this.Tags = model.Tags;
            this.FarmName = farmName;
            this.SubscriptionId = model.Properties.TenantSubscriptionId;
            this.StorageAccountName = model.Properties.TenantAccountName;
            this.ResourceGroupName = model.Properties.TenantResourceGroupName;
        }

        public string AccountId { get; set; }
        public string AdminViewId { get; set; }
        public string TenantViewId { get; set; }
        public StorageAccountType AccountType { get; set; }

        public StorageAccountState State { get; set; }

        public IDictionary<string, string> PrimaryEndpoints { get; set; }

        public string CreationTime { get; set; }

        public string AlternateName { get; set; }

        public RegionStatus StatusOfPrimary { get; set; }

        public Guid SubscriptionId { get; set; }

        public string StorageAccountName { get; set; }

        public string ResourceGroupName { get; set; }

        public StorageAccountOperation CurrentOperation { get; set; }

        public string CustomDomain { get; set; }
        public int AcquisitionOperationCount { get; set; }
        public DateTime? DeletedTime { get; set; }

        public StorageAccountStatus AccountStatus { get; set; }

        public DateTime? RecoveredTime { get; set; }

        public DateTime? RecycledTime { get; set; }
    }
}

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

using Microsoft.AzureStack.Management.StorageAdmin.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    internal class StorageAccountResponse : ResponseBase
    {
        public StorageAccountResponse(StorageAccountModel model, string farmName)
            : base(model)
        {
            // Manually set those with different names or in root
            this.AccountId = long.Parse(model.Name, CultureInfo.InvariantCulture);
            this.AdminViewId = model.Id;
            this.Location = model.Location;
            this.WacAccountId = model.Properties.AccountId;
            this.ResourceType = model.ResourceType;
            this.Type = model.Type;
            this.Tags = model.Tags;
            this.FarmName = farmName;
        }

        public string ResourceType { get; set; }
        public long AccountId { get; set; }
        public string AdminViewId { get; set; }
        public string TenantViewId { get; set; }
        public StorageAccountType AccountType { get; set; }

        public StorageAccountState State { get; set; }

        public IDictionary<string, string> PrimaryEndpoints { get; set; }

        public string CreationTime { get; set; }

        public string AlternateName { get; set; }

        public RegionStatus StatusOfPrimary { get; set; }

        public Guid TenantSubscriptionId { get; set; }

        public string TenantAccountName { get; set; }

        public string TenantResourceGroupName { get; set; }

        public StorageAccountOperation CurrentOperation { get; set; }

        public string CustomDomain { get; set; }
        public int AcquisitionOperationCount { get; set; }
        public DateTime? DeletedTime { get; set; }

        public StorageAccountStatus AccountStatus { get; set; }

        public DateTime? RecoveredTime { get; set; }

        public DateTime? RecycledTime { get; set; }

        public WacAccountPermissions? Permissions { get; set; }

        public ulong? WacAccountId { get; set; }
        public WacAccountStates? WacInternalState { get; set; }
    }
}

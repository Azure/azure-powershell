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

using Microsoft.Azure.Management.DataLake.Store.Models;
using System;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    public class PSDataLakeStoreAccount : DataLakeStoreAccount
    {
        public PSDataLakeStoreAccount(DataLakeStoreAccount baseAccount) :
            base(
                baseAccount.Location,
                baseAccount.Id,
                baseAccount.Name,
                baseAccount.Type,
                baseAccount.Tags,
                baseAccount.Identity,
                baseAccount.ProvisioningState,
                baseAccount.State,
                baseAccount.CreationTime,
                baseAccount.LastModifiedTime,
                baseAccount.Endpoint,
                baseAccount.AccountId,
                baseAccount.EncryptionState,
                baseAccount.EncryptionProvisioningState,
                baseAccount.EncryptionConfig,
                baseAccount.FirewallState,
                baseAccount.FirewallRules,
                baseAccount.TrustedIdProviderState,
                baseAccount.TrustedIdProviders,
                baseAccount.DefaultGroup,
                baseAccount.NewTier,
                baseAccount.CurrentTier,
                baseAccount.FirewallAllowAzureIps)
        {
            // TODO: Work around to null out properties that are returned empty.
            // Swagger deserialization will put a default value of an enum in an empty object.
            // Once the server correctly returns nothing (instead of empty objects), this can
            // be removed.
            if (EncryptionState == Management.DataLake.Store.Models.EncryptionState.Disabled)
            {
                this.EncryptionConfig = null;
            }
        }
    }
}
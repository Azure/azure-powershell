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

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    /// <summary>
    /// Secret attributes from PSH perspective
    /// </summary>
    public sealed class PSKeyVaultManagedStorageAccountAttributes
    {
        public PSKeyVaultManagedStorageAccountAttributes(bool? enabled)
        {
            this.Enabled = enabled;
        }

        internal PSKeyVaultManagedStorageAccountAttributes( bool? enabled, DateTime? created, DateTime? updated, string recoveryLevel ) :
             this(enabled)
        {
            this.Created = created;
            this.Updated = updated;
            this.RecoveryLevel = recoveryLevel;
        }

        internal PSKeyVaultManagedStorageAccountAttributes(Azure.KeyVault.Models.StorageAccountAttributes modelAttributes) :
            this(modelAttributes.Enabled, modelAttributes.Created, modelAttributes.Updated, modelAttributes.RecoveryLevel)
        { }

        public bool? Enabled { get; set; }

        public DateTime? Created { get; private set; }

        public DateTime? Updated { get; private set; }

        public string RecoveryLevel { get; private set; }
    }
}

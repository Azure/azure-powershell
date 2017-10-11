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
using System.Security;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class DeletedSecret : Secret
    {
        public DeletedSecret()
        { }

        /// <summary>
        /// Internal constructor used by KeyVaultDataServiceClient
        /// </summary>
        /// <param name="deletedSecret">secret returned from service</param>
        /// <param name="vaultUriHelper">helper class</param>
        internal DeletedSecret(Azure.KeyVault.Models.DeletedSecretBundle deletedSecret, VaultUriHelper vaultUriHelper) : base(deletedSecret, vaultUriHelper)
        {
            ScheduledPurgeDate = deletedSecret.ScheduledPurgeDate;
            DeletedDate = deletedSecret.DeletedDate;
        }

        public DateTime? ScheduledPurgeDate { get; set; }

        public DateTime? DeletedDate { get; set; }

    }
}

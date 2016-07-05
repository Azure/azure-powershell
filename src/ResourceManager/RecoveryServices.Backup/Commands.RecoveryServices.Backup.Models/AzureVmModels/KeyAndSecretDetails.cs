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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Required details for recovering an encrypted VM.
    /// </summary>
    public class KeyAndSecretDetails
    {
        /// <summary>
        /// URL of the disk encryption key provisioned in key vault.
        /// Disk encryption key is used to encrypt the OS boot volume and data volumes.
        /// </summary>
        public string SecretUrl { get; set; }

        /// <summary>
        /// URL of the Key Encryption Key that encrypts the disk encryption key.
        /// </summary>
        public string KeyUrl { get; set; }

        /// <summary>
        /// Resource ID of the key vault where Key Encryption Key is stored.
        /// </summary>
        public string KeyVaultId { get; set; }

        /// <summary>
        /// Resource ID of the key vault where disk encryption key is stored.
        /// </summary>
        public string SecretVaultId { get; set; }

        /// <summary>
        /// Value of the secret, an encryption key used to 
        /// encrypt the OS boot volume and data volumes.
        /// </summary>
        public string SecretData { get; set; }

        /// <summary>
        /// Value of key encryption key which is used to protect or wrap the secret.
        /// </summary>
        public string KeyBackupData { get; set; }
    }
}
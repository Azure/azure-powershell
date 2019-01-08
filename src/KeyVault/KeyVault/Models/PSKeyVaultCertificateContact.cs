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

using Microsoft.Azure.KeyVault.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyVaultCertificateContact
    {
        public string Email { get; set; }

        public string VaultName { get; set; }

        internal static PSKeyVaultCertificateContact FromKVCertificateContact(Contact contact, string vaultName)
        {
            return new PSKeyVaultCertificateContact
            {
                VaultName = vaultName,
                Email = contact.EmailAddress,
            };
        }

        internal static List<PSKeyVaultCertificateContact> FromKVCertificateContacts(Contacts contacts, string vaultName)
        {
            var result = new List<PSKeyVaultCertificateContact>();

            if (contacts != null && contacts.ContactList != null)
            {
                foreach (var contact in contacts.ContactList)
                {
                    result.Add(FromKVCertificateContact(contact, vaultName));
                }
            }

            return result;
        }
    }
}

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

using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class KeyVaultCertificateAdministratorDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        internal AdministratorDetails ToAdministratorDetails()
        {
            return new AdministratorDetails
            {
                FirstName = FirstName,
                LastName = LastName,
                EmailAddress = EmailAddress,
                Phone = PhoneNumber,
            };
        }

        internal static KeyVaultCertificateAdministratorDetails FromAdministratorDetails(AdministratorDetails administratorDetails)
        {
            if (administratorDetails == null)
            {
                return null;
            }

            return new KeyVaultCertificateAdministratorDetails
            {
                FirstName = administratorDetails.FirstName,
                LastName = administratorDetails.LastName,
                EmailAddress = administratorDetails.EmailAddress,
                PhoneNumber = administratorDetails.Phone,
            };
        }

        internal static List<KeyVaultCertificateAdministratorDetails> FromAdministratorDetails(IEnumerable<AdministratorDetails> administratorDetails)
        {
            if (administratorDetails == null || administratorDetails.Count() == 0)
            {
                return null;
            }

            return administratorDetails.Select(adminDetails => KeyVaultCertificateAdministratorDetails.FromAdministratorDetails(adminDetails)).ToList();
        }

        internal static List<AdministratorDetails> ToAdministratorDetails(IEnumerable<KeyVaultCertificateAdministratorDetails> administratorDetails)
        {
            if (administratorDetails == null || administratorDetails.Count() == 0)
            {
                return null;
            }

            return administratorDetails.Select(adminDetails => adminDetails.ToAdministratorDetails()).ToList();
        }
    }
}

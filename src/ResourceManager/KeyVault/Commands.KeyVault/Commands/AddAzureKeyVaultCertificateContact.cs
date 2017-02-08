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

using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.KeyVault.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;


namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Adds a given certificate contact to Key Vault for certificate management
    /// </summary>
    [Cmdlet(VerbsCommon.Add, CmdletNoun.AzureKeyVaultCertificateContact,
        SupportsShouldProcess = true,
        DefaultParameterSetName = AddParameterSet,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(List<KeyVaultCertificateContact>))]
    public class AddAzureKeyVaultCertificateContact : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string AddParameterSet = "Add";

        #endregion

        /// <summary>
        /// VaultName
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = AddParameterSet,
                   Position = 0,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// EmailAddress
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = AddParameterSet,
                   Position = 1,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the email address of the contact.")]
        [ValidateNotNullOrEmpty]
        public string EmailAddress { get; set; }

        /// <summary>
        /// PassThru parameter
        /// </summary>
        [Parameter(HelpMessage = "This cmdlet does not return an object by default. If this switch is specified, it returns the contact object.")]
        public SwitchParameter PassThru { get; set; }

        protected override void ProcessRecord()
        {
            if (ShouldProcess(EmailAddress, Properties.Resources.AddCertificateContact))
            {
                Contacts existingContacts;

                try
                {
                    existingContacts = this.DataServiceClient.GetCertificateContacts(VaultName);
                }
                catch (KeyVaultErrorException exception)
                {
                    if (exception.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                    {
                        throw;
                    }

                    existingContacts = null;
                }

                List<Contact> newContactList;

                if (existingContacts == null ||
                    existingContacts.ContactList == null)
                {
                    newContactList = new List<Contact>();
                }
                else
                {
                    newContactList = new List<Contact>(existingContacts.ContactList);
                }

                if (newContactList.FindIndex(
                    contact => (string.Compare(contact.EmailAddress, EmailAddress, StringComparison.OrdinalIgnoreCase) == 0)) != -1)
                {
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Provided email address '{0}' already exists.", EmailAddress));
                }

                newContactList.Add(new Contact { EmailAddress = EmailAddress });

                var resultantContacts = this.DataServiceClient.SetCertificateContacts(VaultName, new Contacts { ContactList = newContactList });

                if (PassThru.IsPresent)
                {
                    this.WriteObject(KeyVaultCertificateContact.FromKVCertificateContacts(resultantContacts));
                }
            }
        }
    }
}

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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;


namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Adds a given certificate contact to Key Vault for certificate management
    /// </summary>
    [Cmdlet(VerbsCommon.Add, CmdletNoun.AzureKeyVaultCertificateContact,
        SupportsShouldProcess = true,
        DefaultParameterSetName = InteractiveParameterSet,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(List<PSKeyVaultCertificateContact>))]
    public class AddAzureKeyVaultCertificateContact : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string InteractiveParameterSet = "Interactive";
        private const string InputObjectParameterSet = "ByObject";

        #endregion

        /// <summary>
        /// VaultName
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = InteractiveParameterSet,
                   ValueFromPipelineByPropertyName = true,
                   Position = 0,
                   HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// VaultObject
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = InputObjectParameterSet,
                   Position = 0,
                   ValueFromPipeline = true,
                   HelpMessage = "KeyVault object.")]
        [ValidateNotNullOrEmpty]
        public PSKeyVault InputObject { get; set; }

        /// <summary>
        /// EmailAddress
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 1,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the email address of the contact.")]
        [ValidateNotNullOrEmpty]
        public string[] EmailAddress { get; set; }

        /// <summary>
        /// PassThru parameter
        /// </summary>
        [Parameter(HelpMessage = "If this parameter is specified, all contacts for this KeyVault are returned")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(InputObjectParameterSet))
            {
                VaultName = InputObject.VaultName.ToString();
            }

            if (ShouldProcess(VaultName, Properties.Resources.AddCertificateContact))
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
                
                foreach (var email in EmailAddress)
                {
                    if (newContactList.FindIndex(
                        contact => (string.Compare(contact.EmailAddress, email, StringComparison.OrdinalIgnoreCase) == 0)) == -1)
                    {
                        newContactList.Add(new Contact { EmailAddress = email });
                    }
                }

                var resultantContacts = this.DataServiceClient.SetCertificateContacts(VaultName, new Contacts { ContactList = newContactList });

                if (PassThru.IsPresent)
                {
                    this.WriteObject(PSKeyVaultCertificateContact.FromKVCertificateContacts(resultantContacts, VaultName), true);
                }
            }
        }
    }
}

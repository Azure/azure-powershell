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
using System.Management.Automation;
using System.Security;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Management.Storage;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    /// <summary>
    /// Helper cmdlet to construct instance of SQL Credential AKV based settings class
    /// </summary>
   [Cmdlet(
        VerbsCommon.New,
        AzureVMSqlServerKeyVaultCredentialConfigNoun),
    OutputType(
        typeof(PublicKeyVaultCredentialSettings))]
    public class NewAzureVMSqlServerKeyVaultCredentialConfigCommand : ServiceManagementBaseCmdlet
    {
        /// <summary>
        /// Configuration object friendly name
        /// </summary>
        protected const string AzureVMSqlServerKeyVaultCredentialConfigNoun = "AzureVMSqlServerKeyVaultCredentialConfig";

        [Parameter(
           Mandatory = false,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Enable Key Vault Credential.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Enable { get; set; }

        [Parameter(
           Mandatory = false,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "SQL Server credential name to create.")]
        [ValidateNotNullOrEmpty]
        public string CredentialName { get; set; }

        [Parameter(
           Mandatory = false,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Azure Key Vault service URL")]
        [ValidateNotNullOrEmpty]
        public string AzureKeyVaultUrl { get; set; }

        [Parameter(
           Mandatory = false,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Principal user client identifier.")]
        [ValidateNotNullOrEmpty]
        public string ServicePrincipalName { get; set; }

        [Parameter(
           Mandatory = false,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Principal user client secret.")]
        [ValidateNotNullOrEmpty]
        public SecureString ServicePrincipalSecret { get; set; }

        /// <summary>
        /// Initialzies a new instance of the <see cref="NewAzureVMSqlServerKeyVaultCredentialConfigCommand"/> class.
        /// </summary>
        public NewAzureVMSqlServerKeyVaultCredentialConfigCommand()
        {
        }

        /// <summary>
        /// Creates and returns <see cref="PublicKeyVaultCredentialSettings"/> object.
        /// </summary>
        protected override void ProcessRecord()
        {
            KeyVaultCredentialSettings settings = new KeyVaultCredentialSettings();

            settings.Enable = (this.Enable.IsPresent) ? this.Enable.ToBool() : false;
            
            settings.CredentialName = (this.CredentialName == null) ? null : this.CredentialName;
 
            settings.ServicePrincipalName = (this.ServicePrincipalName == null) ? null : this.ServicePrincipalName;

            settings.ServicePrincipalSecret = (this.ServicePrincipalSecret == null) ? 
                                              null : 
                                              SecureStringHelper.ConvertToUnsecureString(this.ServicePrincipalSecret);

            settings.AzureKeyVaultUrl = (this.AzureKeyVaultUrl == null) ? null : this.AzureKeyVaultUrl;


            WriteObject(settings);
        }
    }
}

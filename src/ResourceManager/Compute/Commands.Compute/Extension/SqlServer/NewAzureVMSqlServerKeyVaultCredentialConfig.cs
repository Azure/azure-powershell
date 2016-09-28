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

using System.Management.Automation;
using System.Security;
using System.Security.Permissions;
using System;
using System.Runtime.InteropServices;

namespace Microsoft.Azure.Commands.Compute
{
    /// <summary>
    /// Helper cmdlet to construct instance of SQL Credential AKV based settings class
    /// </summary>
    [Cmdlet(
         VerbsCommon.New,
         AzureVMSqlServerKeyVaultCredentialConfigNoun,
         SupportsShouldProcess = true),
     OutputType(
         typeof(KeyVaultCredentialSettings))]
    public class NewAzureVMSqlServerKeyVaultCredentialConfigCommand : PSCmdlet
    {
        /// <summary>
        /// Configuration object friendly name
        /// </summary>
        protected const string AzureVMSqlServerKeyVaultCredentialConfigNoun = "AzureVMSqlServerKeyVaultCredentialConfig";

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Enable Key Vault Credential.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Enable { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "SQL Server credential name to create.")]
        [ValidateNotNullOrEmpty]
        public string CredentialName { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Azure Key Vault service URL")]
        [ValidateNotNullOrEmpty]
        public string AzureKeyVaultUrl { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Principal user client identifier.")]
        [ValidateNotNullOrEmpty]
        public string ServicePrincipalName { get; set; }

        [Parameter(
           Mandatory = false,
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
        /// Creates and returns <see cref="KeyVaultCredentialSettings"/> object.
        /// </summary>
        protected override void ProcessRecord()
        {
            string target = "Azure Key Vault";
            string action = "Creation";
            if (ShouldProcess(target, action))
            {
                KeyVaultCredentialSettings settings = new KeyVaultCredentialSettings();
                settings.ResourceGroupName = (this.ResourceGroupName == null) ? null : this.ResourceGroupName;
                settings.Enable = (this.Enable.IsPresent) ? this.Enable.ToBool() : false;
                settings.CredentialName = (this.CredentialName == null) ? null : this.CredentialName;
                settings.ServicePrincipalName = (this.ServicePrincipalName == null) ? null : this.ServicePrincipalName;
                settings.ServicePrincipalSecret = (this.ServicePrincipalSecret == null) ?
                                                  null : ConvertToUnsecureString(ServicePrincipalSecret);
                settings.AzureKeyVaultUrl = (this.AzureKeyVaultUrl == null) ? null : this.AzureKeyVaultUrl;
                WriteObject(settings);
            }
        }

        /// <summary>
        /// convert secure string to regular string
        /// $Issue -  for ARM cmdlets, check if there is a similair helper class library like Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers
        /// </summary>
        /// <param name="securePassword"></param>
        /// <returns></returns>
        private static string ConvertToUnsecureString(SecureString securePassword)
        {
            if (securePassword == null)
            {
                throw new ArgumentNullException("securePassword");
            }

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}

﻿// ----------------------------------------------------------------------------------
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

using System.Collections.Generic;
using System.Security;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    /// <summary>
    /// Autobackup settings to configure managed backup on SQL VM
    /// </summary>
    public class KeyVaultCredentialSettings
    {
        /// <summary>
        /// Defines if the Key Vault Credentails feature is enabled or disabled
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// Key Vault credentails name
        /// </summary>
        public string CredentialName { get; set; }

        /// <summary>
        /// Gets the azure key vault URL.
        /// </summary>
        /// <value>
        /// The azure key vault URL for Credential Management.
        /// </value>
        public string AzureKeyVaultUrl { get; set; }

        /// <summary>
        /// Gets the name of the principal.
        /// </summary>
        /// <value>
        /// The name of the service principal to access the Azure Key Vault.
        /// </value>
        public string ServicePrincipalName { get; set; }

        /// <summary>
        /// Gets the principal secret.
        /// </summary>
        /// <value>
        /// The service principal secret to access the Azure Key Vault.
        /// </value>
        public string ServicePrincipalSecret { get; set; }

        /// <summary>
        /// Gets the credentials
        /// </summary>
        /// <value>
        /// The list of existing credentials for AKV.
        /// </value>
        public List<AzureVMSqlServerKeyVaultCredential> Credentials { get; set; }
    }
}
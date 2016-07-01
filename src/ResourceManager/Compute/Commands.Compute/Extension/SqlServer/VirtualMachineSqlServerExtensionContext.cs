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

using Microsoft.Azure.Commands.Compute.Models;

namespace Microsoft.Azure.Commands.Compute
{
    /// <summary>
    /// SQL VM Extension's context object used by Get-AzureRmVMSqlServerExtension
    /// </summary>
    public class VirtualMachineSqlServerExtensionContext : PSVirtualMachineExtension
    {
        /// <summary>
        /// SQLVM Extension's publisher name 
        /// </summary>
        public const string ExtensionPublishedNamespace = "Microsoft.SqlServer.Management";

        /// <summary>
        /// SQLVM Extension's name
        /// </summary>
        public const string ExtensionPublishedName = "SqlIaaSAgent";

        /// <summary>
        /// SQLVM Extension's default version 
        /// </summary>
        public const string ExtensionDefaultVersion = "1.*";

        /// <summary>
        /// Auto-patching settings
        /// </summary>
        public AutoPatchingSettings AutoPatchingSettings;

        /// <summary>
        /// Auto-backup settings
        /// </summary>
        public AutoBackupSettings AutoBackupSettings;

        /// <summary>
        /// Key Vault Credential settings
        /// </summary>
        public KeyVaultCredentialSettings KeyVaultCredentialSettings;
    }
}

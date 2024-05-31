
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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.NetApp.Models;
using System.Globalization;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using System.Collections.Generic;
using System;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.NetAppFiles.BackupVault
{
    [Cmdlet(
        "Set",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesBackupVault",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesBackupVault))]
    [Alias("Set-AnfBackupVault")]
    public class SetAzureRmNetAppFilesBackupVault: AzureNetAppFilesCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The resource group of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccount",
            nameof(ResourceGroupName))]
        public string AccountName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the ANF BackupVault")]
        [ValidateNotNullOrEmpty]
        [Alias("BackupVaultName")]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/backupVaults",
            nameof(ResourceGroupName),
            nameof(AccountName))]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable array which represents resource tags")]
        [ValidateNotNullOrEmpty]
        [Alias("Tags")]
        public Hashtable Tag { get; set; }

        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Account object for the new BackupVault")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesAccount AccountObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = AccountObject.ResourceGroupName;                
                var NameParts = AccountObject.Name.Split('/');
                AccountName = NameParts[0];
            }
            IDictionary<string, string> tagPairs = null;

            if (Tag != null)
            {
                tagPairs = new Dictionary<string, string>();

                foreach (string key in Tag.Keys)
                {
                    tagPairs.Add(key, Tag[key].ToString());
                }
            }

            Management.NetApp.Models.BackupVault existingBackupVault = null;
            try
            {
                existingBackupVault = AzureNetAppFilesManagementClient.BackupVaults.Get(ResourceGroupName, AccountName, Name);
            }
            catch
            {
                existingBackupVault = null;
            }
            if (existingBackupVault == null)
            {
                throw new AzPSResourceNotFoundCloudException($"A BackupVault with name '{this.Name}' in resource group '{this.ResourceGroupName}' does not exist. Please use New-AzNetAppFilesBackupVault to create a new BackupVault.");
            }

            var backupVaultBody = new Management.NetApp.Models.BackupVault()
            {
                Location = existingBackupVault.Location,                
                Tags = tagPairs
            };

            if (ShouldProcess(Name, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.CreateResourceMessage, ResourceGroupName)))
            {
                try
                {
                    var anfBackupVault = AzureNetAppFilesManagementClient.BackupVaults.CreateOrUpdate(ResourceGroupName, AccountName, backupVaultName: Name, body: backupVaultBody);
                    WriteObject(anfBackupVault.ConvertToPs());                
                }
                catch(ErrorResponseException ex)
                {
                    throw new CloudException(ex.Body.Error.Message, ex);
                }
            }
        }
    }
}

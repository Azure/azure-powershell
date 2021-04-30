
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
using System.Globalization;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using Microsoft.Azure.Management.Monitor.Version2018_09_01.Models;
using System.Collections.Generic;
using System;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.Common.Exceptions;

namespace Microsoft.Azure.Commands.NetAppFiles.BackupPolicy
{
    [Cmdlet(
        "Set",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesBackupPolicy",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesBackupPolicy))]
    [Alias("Set-AnfBackupPolicy")]
    public class SetAzureRmNetAppFilesBackupPolicy : AzureNetAppFilesCmdletBase
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
            HelpMessage = "The location of the resource")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.NetApp/netAppAccounts/backupPolicies")]
        public string Location { get; set; }

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
            HelpMessage = "The name of the ANF backup policy")]
        [ValidateNotNullOrEmpty]
        [Alias("BackupPolicyName")]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/backupPolicies",
            nameof(ResourceGroupName),
            nameof(AccountName))]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The property to decide policy is enabled or not")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Enabled { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Daily backups count to keep")]
        [ValidateNotNullOrEmpty]
        public int? DailyBackupsToKeep { get; set; }
        
        [Parameter(
            Mandatory = false,
            HelpMessage = "Weekly backups count to keep")]
        [ValidateNotNullOrEmpty]
        public int? WeeklyBackupsToKeep { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Monthly backups count to keep")]
        [ValidateNotNullOrEmpty]
        public int? MonthlyBackupsToKeep { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Yearly backups count to keep")]
        [ValidateNotNullOrEmpty]
        public int? YearlyBackupsToKeep { get; set; }

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
            HelpMessage = "The Account object for the new Backup Policy")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesAccount AccountObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the ANF account",
            ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ResourceIdParameterSet)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                var parentResources = resourceIdentifier.ParentResource.Split('/');
                AccountName = parentResources[1];
                Name = resourceIdentifier.ResourceName;
            }
            if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = AccountObject.ResourceGroupName;
                Location = AccountObject.Location;
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
            Management.NetApp.Models.BackupPolicy existingBackupPolicy = null;
            try
            {
                existingBackupPolicy = AzureNetAppFilesManagementClient.BackupPolicies.Get(ResourceGroupName, AccountName, Name);
            }
            catch
            {
                existingBackupPolicy = null;
            }
            if (existingBackupPolicy == null)
            {
                throw new AzPSResourceNotFoundCloudException($"A Backup Policy with name '{this.Name}' in resource group '{this.ResourceGroupName}' does not exist. Please use New-AzNetAppFilesBackupPolicy to create a new Backup Policy.");
            }

            var backupPolicyBody = new Management.NetApp.Models.BackupPolicy()
            {
                Location = Location,
                Enabled = Enabled,
                Tags = tagPairs,
                DailyBackupsToKeep = DailyBackupsToKeep,
                WeeklyBackupsToKeep = WeeklyBackupsToKeep,
                MonthlyBackupsToKeep = MonthlyBackupsToKeep,
                YearlyBackupsToKeep = YearlyBackupsToKeep
            };

            if (ShouldProcess(Name, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.UpdateResourceMessage, ResourceGroupName)))
            {
                var anfBackupPolicy = AzureNetAppFilesManagementClient.BackupPolicies.Create(ResourceGroupName, AccountName, backupPolicyName: Name, body: backupPolicyBody);
                WriteObject(anfBackupPolicy.ConvertToPs());
            }
        }
    }
}

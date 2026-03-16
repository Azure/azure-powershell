using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models
{
    public partial class DeletedBackupVaultResource
    {
        private string location;
        public string Location
        {
            get
            {
                // Extract location from Id
                // Format: /subscriptions/{subscriptionId}/providers/Microsoft.DataProtection/locations/{location}/deletedVaults/{vaultId}
                if (string.IsNullOrEmpty(this.location) && !string.IsNullOrEmpty(this.Id))
                {
                    var match = Regex.Match(this.Id, @"/locations/([^/]+)/", RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        this.location = match.Groups[1].Value;
                    }
                }
                return this.location;
            }
            set { location = value; }
        }

        private string originalBackupVaultResourceGroup;
        public string OriginalBackupVaultResourceGroup
        {
            get
            {
                // Extract resource group from OriginalBackupVaultResourcePath
                // Format: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.DataProtection/BackupVaults/{vaultName}
                if (string.IsNullOrEmpty(this.originalBackupVaultResourceGroup) && !string.IsNullOrEmpty(this.OriginalBackupVaultResourcePath))
                {
                    var match = Regex.Match(this.OriginalBackupVaultResourcePath, @"/resourcegroups/([^/]+)/", RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        this.originalBackupVaultResourceGroup = match.Groups[1].Value;
                    }
                }
                return this.originalBackupVaultResourceGroup;
            }
            set { originalBackupVaultResourceGroup = value; }
        }
    }
}

using Azure.Core.Diagnostics;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzurePrefix + CmdletNoun.KeyVault, SupportsShouldProcess = true, DefaultParameterSetName = InteractiveStorageName)]
    [OutputType(typeof(bool))]
    public class RestoreAzureManagedHsm : FullBackupRestoreCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Folder name of the backup, e.g. 'mhsm-*-2020101309020403'.\nIt can also be nested such as 'backups/mhsm-*-2020101309020403'.")]
        public string BackupFolder { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Key name to restore.")]
        public string KeyName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return true when the HSM is restored.")]
        public SwitchParameter PassThru { get; set; }

        public override void DoExecuteCmdlet()
        {
            ConfirmAction(
                    string.Format(Resources.DoFullRestore, StorageContainerUri),
                    HsmName, () =>
                    {
                        var errorMsg = string.Format(Resources.FullRestoreFailed, HsmName);
                        try
                        {
                            if(KeyName == null)
                            {
                                Track2DataClient.RestoreHsm(HsmName, StorageContainerUri, SasToken.ConvertToString(), BackupFolder);
                            }
                            else
                            {
                                Track2DataClient.SelectiveRestoreHsm(HsmName, KeyName,StorageContainerUri, SasToken.ConvertToString(), BackupFolder);
                                errorMsg = string.Format(Resources.SelectiveRestoreFailed, KeyName, HsmName);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(errorMsg, ex);                            
                        }
                        
                        if (PassThru)
                        {
                            WriteObject(true);
                        }
                    }
                );
        }
    }
}

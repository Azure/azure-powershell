using Azure.Core.Diagnostics;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    [Cmdlet("Backup", ResourceManager.Common.AzureRMConstants.AzurePrefix + CmdletNoun.ManagedHsm, SupportsShouldProcess = true, DefaultParameterSetName = InteractiveStorageName)]
    [OutputType(typeof(string))]
    public class BackupAzureManagedHsm : FullBackupRestoreCmdletBase
    {
        public override void DoExecuteCmdlet()
        {

            ConfirmAction(
                string.Format(Resources.DoFullBackup, StorageContainerUri),
                Name, () =>
            {
                try
                {
                    WriteObject(Track2DataClient.BackupHsm(Name, StorageContainerUri, SasToken.ConvertToString()).AbsoluteUri);
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format(Resources.FullBackupFailed, Name), ex);
                }
            });
        }
    }
}

using Azure.Core.Diagnostics;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    [Cmdlet("Backup", ResourceManager.Common.AzureRMConstants.AzurePrefix + CmdletNoun.KeyVault, SupportsShouldProcess = true, DefaultParameterSetName = InteractiveStorageName)]
    [OutputType(typeof(string))]
    public class BackupAzureManagedHsm : FullBackupRestoreCmdletBase
    {
        public override void DoExecuteCmdlet()
        {

            ConfirmAction(
                string.Format(Resources.DoFullBackup, StorageContainerUri),
                HsmName, () =>
            {
                try
                {
                    WriteObject(Track2DataClient.BackupHsm(HsmName, StorageContainerUri, SasToken.ConvertToString()).AbsoluteUri);
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format(Resources.FullBackupFailed, HsmName), ex);
                }
            });
        }
    }
}

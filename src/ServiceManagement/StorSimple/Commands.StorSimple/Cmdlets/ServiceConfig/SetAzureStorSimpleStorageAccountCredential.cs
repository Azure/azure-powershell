
using System;
using System.Management.Automation;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Commands.StorSimple.Encryption;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System.Collections.Generic;
using System.Net;
using System.Linq;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    using Properties;

    /// <summary>
    /// Edit the Storage Account Cred
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureStorSimpleStorageAccountCredential"), OutputType(typeof(TaskStatusInfo))]

    public class SetAzureStorSimpleStorageAccountCredential : StorSimpleCmdletBase
    {
        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageStorageAccountName)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Alias("Key")]
        [Parameter(Position = 1, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageStorageAccountKey)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountKey { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageUseSSL)]
        [ValidateNotNullOrEmpty]
        public bool? UseSSL { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageWaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {

                var allSACs = StorSimpleClient.GetAllStorageAccountCredentials();
                var existingSac = allSACs.Where(x => x.Name.Equals(StorageAccountName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                if (existingSac == null)
                {
                    WriteVerbose(String.Format(Resources.SACNotFoundWithName,StorageAccountName));
                    return;
                }

                String encryptedKey = null;
                StorSimpleCryptoManager storSimpleCryptoManager = new StorSimpleCryptoManager(StorSimpleClient);
                if (!String.IsNullOrEmpty(StorageAccountKey))
                {
                    //validate storage account credentials
                    string hostname = existingSac.Hostname;
                    string endpoint = hostname.Substring(hostname.IndexOf('.') + 1);
                    if (!ValidStorageAccountCred(StorageAccountName, StorageAccountKey, endpoint))
                    {
                        WriteVerbose(Resources.StorageCredentialVerificationFailureMessage);
                        return;
                    }
                    WriteVerbose(Resources.StorageCredentialVerificationSuccessMessage);
                    WriteVerbose(Resources.EncryptionInProgressMessage);
                    storSimpleCryptoManager.EncryptSecretWithRakPub(StorageAccountKey, out encryptedKey);
                }

                var serviceConfig = new ServiceConfiguration()
                {
                    AcrChangeList = new AcrChangeList(),
                    CredentialChangeList = new SacChangeList()
                    {
                        Added = new List<StorageAccountCredential>(),
                        Deleted = new List<string>(),
                        Updated = new[]
                        {
                            new StorageAccountCredential()
                            {
                                InstanceId = existingSac.InstanceId,
                                CloudType = existingSac.CloudType,
                                Hostname = existingSac.Hostname,
                                Login = existingSac.Login,
                                Password = encryptedKey ?? existingSac.Password,
                                UseSSL = UseSSL ?? existingSac.UseSSL,
                                VolumeCount = existingSac.VolumeCount,
                                Name = existingSac.Name,
                                IsDefault = existingSac.IsDefault,
                                PasswordEncryptionCertThumbprint = storSimpleCryptoManager.GetSecretsEncryptionThumbprint(),
                                Location = existingSac.Location
                            },
                        }
                    }
                };

                if (WaitForComplete.IsPresent)
                {
                    WriteVerbose("About to run a task to update your Storage Access credential!"); 
                    var taskStatus = StorSimpleClient.ConfigureService(serviceConfig);
                    HandleSyncTaskResponse(taskStatus, "update");
                    if (taskStatus.AsyncTaskAggregatedResult == AsyncTaskAggregatedResult.Succeeded)
                    {
                        var updatedSac = StorSimpleClient.GetAllStorageAccountCredentials()
                                            .Where(x => x.Name.Equals(StorageAccountName, StringComparison.InvariantCultureIgnoreCase));
                        WriteObject(updatedSac);
                    }
                }
                else
                {
                    WriteVerbose("About to create a task to update your Storage Access credential!");
                    var taskResponse = StorSimpleClient.ConfigureServiceAsync(serviceConfig);
                    HandleAsyncTaskResponse(taskResponse, "update");
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}


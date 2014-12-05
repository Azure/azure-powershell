
using System;
using System.Management.Automation;
using Microsoft.WindowsAzure;
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
    [Cmdlet(VerbsCommon.Set, "AzureStorSimpleStorageAccountCredential"), OutputType(typeof(JobStatusInfo))]

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
                    WriteVerbose(Resources.NotFoundMessageStorageAccount);
                    return;
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
                                CloudType = existingSac.CloudType,
                                Hostname = existingSac.Hostname,
                                Login = existingSac.Login,
                                Password = StorageAccountKey ?? existingSac.Password,
                                UseSSL = UseSSL ?? existingSac.UseSSL,
                                VolumeCount = existingSac.VolumeCount,
                                Name = existingSac.Name,
                                PasswordEncryptionCertThumbprint = existingSac.PasswordEncryptionCertThumbprint
                            },
                        }
                    }
                };

                if (WaitForComplete.IsPresent)
                {
                    var jobStatus = StorSimpleClient.ConfigureService(serviceConfig);
                    HandleSyncJobResponse(jobStatus, "update");
                    if (jobStatus.TaskResult == TaskResult.Succeeded)
                    {
                        var updatedSac = StorSimpleClient.GetAllStorageAccountCredentials()
                                            .Where(x => x.Name.Equals(StorageAccountName, StringComparison.InvariantCultureIgnoreCase));
                        WriteObject(updatedSac);
                    }
                }
                else
                {
                    var jobResponse = StorSimpleClient.ConfigureServiceAsync(serviceConfig);
                    HandleAsyncJobResponse(jobResponse, "update");
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}


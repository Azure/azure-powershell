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

using System;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.StorSimple.Encryption;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// Edit the Storage Account Cred
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureStorSimpleStorageAccountCredential"), OutputType(typeof(TaskStatusInfo))]

    public class SetAzureStorSimpleStorageAccountCredential : StorSimpleCmdletBase
    {
        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.StorageAccountName)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Alias("Key")]
        [Parameter(Position = 1, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.StorageAccountKey)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountKey { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.UseSSL)]
        [ValidateNotNullOrEmpty]
        public bool? UseSSL { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.WaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {

                var allSACs = StorSimpleClient.GetAllStorageAccountCredentials();
                var existingSac = allSACs.Where(x => x.Name.Equals(StorageAccountName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                if (existingSac == null)
                {
                    throw new ArgumentException(string.Format(Resources.SACNotFoundWithName, StorageAccountName));
                }

                string encryptedKey;
                string thumbprint;
                string endpoint = GetEndpointFromHostname(existingSac.Hostname);
                if (!ValidateAndEncryptStorageCred(StorageAccountName, StorageAccountKey, endpoint, out encryptedKey, out thumbprint))
                {
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
                                InstanceId = existingSac.InstanceId,
                                CloudType = existingSac.CloudType,
                                Hostname = existingSac.Hostname,
                                Login = existingSac.Login,
                                Password = encryptedKey ?? existingSac.Password,
                                UseSSL = UseSSL ?? existingSac.UseSSL,
                                VolumeCount = existingSac.VolumeCount,
                                Name = existingSac.Name,
                                IsDefault = existingSac.IsDefault,
                                PasswordEncryptionCertThumbprint = thumbprint,
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


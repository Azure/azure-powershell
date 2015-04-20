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
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.StorSimple.Encryption;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// Add Azure Storage account to the StorSimple Manager Service
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureStorSimpleStorageAccountCredential"), OutputType(typeof(TaskStatusInfo))]

    public class NewAzureStorSimpleStorageAccountCredential : StorSimpleCmdletBase
    {
        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.StorageAccountName)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Alias("Key")]
        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.StorageAccountKey)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountKey { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.UseSSL)]
        [ValidateNotNullOrEmpty]
        public bool UseSSL { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.Endpoint)]
        [ValidateNotNullOrEmpty]
        public string Endpoint { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.WaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                string endpoint = string.IsNullOrEmpty(Endpoint) ? StorSimpleConstants.DefaultStorageAccountEndpoint : Endpoint;
                
                //validate storage account credentials
                bool storageAccountPresent;
                string encryptedKey;
                string thumbprint;
                string location = GetStorageAccountLocation(StorageAccountName, out storageAccountPresent);
                if (!storageAccountPresent
                    || !ValidateAndEncryptStorageCred(StorageAccountName, StorageAccountKey, endpoint, out encryptedKey, out thumbprint))
                {
                    return;
                }

                var serviceConfig = new ServiceConfiguration()
                {
                    AcrChangeList = new AcrChangeList(),
                    CredentialChangeList = new SacChangeList()
                    {
                        Added = new[]
                        {
                            new StorageAccountCredential()
                            {
                                CloudType = CloudType.Azure,
                                Hostname = GetHostnameFromEndpoint(endpoint),
                                Login = StorageAccountName,
                                Password = encryptedKey,
                                PasswordEncryptionCertThumbprint = thumbprint,
                                UseSSL = UseSSL,
                                Name = StorageAccountName,
                                Location = location
                            },
                        },
                        Deleted = new List<string>(),
                        Updated = new List<StorageAccountCredential>()
                    }
                };

                if (WaitForComplete.IsPresent)
                {
                    var taskStatus = StorSimpleClient.ConfigureService(serviceConfig);
                    HandleSyncTaskResponse(taskStatus, "create");
                    if (taskStatus.AsyncTaskAggregatedResult == AsyncTaskAggregatedResult.Succeeded)
                    {
                        var createdSac = StorSimpleClient.GetAllStorageAccountCredentials()
                                            .Where(x => x.Name.Equals(StorageAccountName, StringComparison.InvariantCultureIgnoreCase));
                        WriteObject(createdSac);
                    }
                }
                else
                {
                    var taskResponse = StorSimpleClient.ConfigureServiceAsync(serviceConfig);
                    HandleAsyncTaskResponse(taskResponse, "create");
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}
        

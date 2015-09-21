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

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "AzureStorSimpleDeviceVolumeContainer"), OutputType(typeof(TaskStatusInfo))]
    public class NewAzureStorSimpleDeviceVolumeContainer : StorSimpleCmdletBase
    {

        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName)]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Alias("Name")]
        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.DataContainerName)]
        [ValidateNotNullOrEmpty]
        public string VolumeContainerName { get; set; }

        [Alias("StorageAccount")]
        [Parameter(Position = 2, Mandatory = true, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.SACObject)]
        [ValidateNotNullOrEmpty]
        public StorageAccountCredentialResponse PrimaryStorageAccountCredential { get; set; }

        [Alias("CloudBandwidthInMbps")]
        [Parameter(Position = 3, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.DataContainerBandwidth)]
        [ValidateNotNullOrEmpty]
        public int BandWidthRateInMbps { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.DataContainerEncryptionEnabled)]
        [ValidateNotNullOrEmpty]
        public bool? EncryptionEnabled { get; set; }

        [Parameter(Position = 5, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.DataContainerEncryptionkey)]
        [ValidateNotNullOrEmpty]
        public string EncryptionKey { get; set; }

        [Parameter(Position = 6, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.WaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }
        public override void ExecuteCmdlet()
        {
            try
            {
                string deviceid = StorSimpleClient.GetDeviceId(DeviceName);
                if (deviceid == null)
                {
                    throw new ArgumentException(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
                }

                if(EncryptionEnabled == true && (string.IsNullOrEmpty(EncryptionKey) || !IsValidAsciiString(EncryptionKey)))
                {
                    throw new ArgumentException(Resources.EncryptionKeyNotAcceptableMessage);
                }

                string encryptedKey = null;
                StorSimpleCryptoManager storSimpleCryptoManager = new StorSimpleCryptoManager(StorSimpleClient);
                if (EncryptionEnabled == true)
                {
                    WriteVerbose(Resources.EncryptionInProgressMessage);
                    storSimpleCryptoManager.EncryptSecretWithRakPub(EncryptionKey, out encryptedKey);
                }

                if (string.IsNullOrEmpty(PrimaryStorageAccountCredential.InstanceId))
                {
                    //The SAC needs to be created inline
                    WriteVerbose(Resources.InlineSacCreationMessage);

                    var sac = PrimaryStorageAccountCredential;

                    //validate storage account credentials
                    bool storageAccountPresent;
                    string encryptedPassword;
                    string thumbprint;
                    string endpoint = GetEndpointFromHostname(sac.Hostname);
                    string location = GetStorageAccountLocation(sac.Name, out storageAccountPresent);
                    if (!storageAccountPresent 
                        || !ValidateAndEncryptStorageCred(sac.Name, sac.Password, endpoint, out encryptedPassword, out thumbprint))
                    {
                        return;
                    }
                    
                    sac.Password = encryptedPassword;
                    sac.PasswordEncryptionCertThumbprint = thumbprint;
                    sac.Location = location;
                }

                var dc = new DataContainerRequest
                {
                    IsDefault = false,
                    Name = VolumeContainerName,
                    BandwidthRate = BandWidthRateInMbps,
                    IsEncryptionEnabled = EncryptionEnabled ?? false,
                    EncryptionKey = encryptedKey,
                    VolumeCount = 0,
                    PrimaryStorageAccountCredential = PrimaryStorageAccountCredential,
                    SecretsEncryptionThumbprint = storSimpleCryptoManager.GetSecretsEncryptionThumbprint()
                };

                if (WaitForComplete.IsPresent)
                {
                    var taskStatus = StorSimpleClient.CreateDataContainer(deviceid, dc);
                    HandleSyncTaskResponse(taskStatus, "create");
                    if (taskStatus.AsyncTaskAggregatedResult == AsyncTaskAggregatedResult.Succeeded)
                    {
                        var createdDataContainer = StorSimpleClient.GetDataContainer(deviceid, VolumeContainerName);
                        WriteObject(createdDataContainer.DataContainerInfo);
                    }
                }

                else
                {
                    var taskstatus = StorSimpleClient.CreateDataContainerAsync(deviceid, dc);
                    HandleAsyncTaskResponse(taskstatus, "create");                
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}
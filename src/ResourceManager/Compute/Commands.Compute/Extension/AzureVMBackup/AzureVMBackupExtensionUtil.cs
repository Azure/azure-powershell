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


using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Extension.AzureDiskEncryption;
using Microsoft.Azure.Commands.Compute.StorageServices;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.WindowsAzure.Commands.Sync.Download;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Extension.AzureVMBackup
{
    /// <summary>
    /// Used to create/remove snapshots of the disk page blobs of the specified virtual machines.
    /// </summary>
    public class AzureVMBackupExtensionUtil
    {
        public const string extensionPublisher = "Microsoft.Azure.Security";
        public const string extensionType = "VMBackupForLinuxExtension";
        public const string extensionDefaultVersion = "0.1";
        public const string backupExtensionName = "vmbackupextension";
        public const string backupExtensionMetadataName = "vmbackuptag";
        public const string backupExtensionIdentityMetadataName = "vmbackupidentity";
        public const string backupSnapshotCommand = "snapshot";
        public const string backupDefaultLocale = "en-us";

        private List<string> GetDiskBlobUris(VirtualMachine virtualMachineResponse)
        {
            List<string> blobUris = new List<string>();
            string osDiskUri = virtualMachineResponse.StorageProfile.OsDisk.Vhd.Uri;
            blobUris.Add(osDiskUri);
            var dataDisks = virtualMachineResponse.StorageProfile.DataDisks;
            for (int i = 0; i < dataDisks.Count; i++)
            {
                blobUris.Add(dataDisks[i].Vhd.Uri);
            }
            return blobUris;
        }

        private string GetBase64Encoding(object obj)
        {
            string plainText = JsonConvert.SerializeObject(obj);
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            string base64EncodedPrivateConfig = System.Convert.ToBase64String(plainTextBytes);
            return base64EncodedPrivateConfig;
        }

        /// <summary>
        /// find the snapshot with the tags
        /// </summary>
        /// <param name="blobUris"></param>
        /// <param name="snapshotTag"></param>
        /// <param name="taskId"></param>
        /// <param name="storageCredentialsFactory"></param>
        /// <returns></returns>
        public List<CloudPageBlob> FindSnapshot(List<string> blobUris, Dictionary<string, string> snapshotQuery, StorageCredentialsFactory storageCredentialsFactory)
        {
            List<CloudPageBlob> snapshots = new List<CloudPageBlob>();
            for (int i = 0; i < blobUris.Count; i++)
            {
                BlobUri blobUri = null;
                if (BlobUri.TryParseUri(new Uri(blobUris[i]), out blobUri))
                {
                    StorageCredentials sc = storageCredentialsFactory.Create(blobUri);
                    CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(sc, true);
                    CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
                    CloudBlobContainer blobContainer = blobClient.GetContainerReference(blobUri.BlobContainerName);
                    IEnumerable<IListBlobItem> blobs = blobContainer.ListBlobs(null, true, BlobListingDetails.All);
                    foreach (var blob in blobs)
                    {
                        if (blob is CloudPageBlob)
                        {
                            CloudPageBlob pageBlob = blob as CloudPageBlob;
                            if (pageBlob.IsSnapshot && pageBlob.Name == blobUri.BlobName)
                            {
                                bool allMatch = true;
                                foreach (string keyToQuey in snapshotQuery.Keys)
                                {
                                    if (!pageBlob.Metadata.Keys.Contains(keyToQuey))
                                    {
                                        allMatch = false;
                                    }
                                    else if (!string.Equals(pageBlob.Metadata[keyToQuey], snapshotQuery[keyToQuey]))
                                    {
                                        allMatch = false;
                                    }
                                }
                                if (allMatch)
                                {
                                    snapshots.Add(pageBlob);
                                }
                            }
                        }
                    }
                }
            }
            return snapshots;
        }


        public AzureVMBackupBlobSasUris GenerateBlobSasUris(List<string> blobUris, CloudPageBlobObjectFactory cloudPageBlobObjectFactory)
        {
            AzureVMBackupBlobSasUris blobSASUris = new AzureVMBackupBlobSasUris();

            for (int i = 0; i < blobUris.Count; i++)
            {
                string blobUri = blobUris[i];
                BlobUri osBlobUri = null;
                if (BlobUri.TryParseUri(new Uri(blobUri), out osBlobUri))
                {
                    CloudPageBlob pageBlob = cloudPageBlobObjectFactory.Create(osBlobUri);

                    SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
                    sasConstraints.SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(5);
                    sasConstraints.Permissions = SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.List;

                    string sasUri = osBlobUri.Uri + pageBlob.GetSharedAccessSignature(sasConstraints);
                    blobSASUris.blobSASUri.Add(sasUri);
                }
                else
                {
                    throw new AzureVMBackupException(AzureVMBackupErrorCodes.WrongBlobUriFormat, "the blob uri is not in correct format.");
                }
            }
            return blobSASUris;
        }

        /// <summary>
        /// remove the vmbackups with the metadata  key "vmbackuptag" and value snapshotTag, snapshotTag is the parameter passed in.
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="vmName"></param>
        /// <param name="virtualMachineExtensionType"></param>
        /// <param name="location"></param>
        /// <param name="virtualMachineResponse"></param>
        /// <param name="profile"></param>
        /// <param name="VirtualMachineExtensionClient"></param>
        /// <param name="snapshotTag"></param>
        public void RemoveSnapshot(AzureVMBackupConfig vmConfig, string snapshotTag, VirtualMachineExtensionBaseCmdlet virtualMachineExtensionBaseCmdlet)
        {
            var virtualMachineResponse = virtualMachineExtensionBaseCmdlet.ComputeClient.ComputeManagementClient.VirtualMachines.GetWithInstanceView(vmConfig.ResourceGroupName, vmConfig.VMName);
            StorageManagementClient storageClient = AzureSession.ClientFactory.CreateArmClient<StorageManagementClient>(virtualMachineExtensionBaseCmdlet.DefaultProfile.Context, AzureEnvironment.Endpoint.ResourceManager);

            StorageCredentialsFactory storageCredentialsFactory = new StorageCredentialsFactory(vmConfig.ResourceGroupName, storageClient, virtualMachineExtensionBaseCmdlet.DefaultProfile.Context.Subscription);

            List<string> blobUris = this.GetDiskBlobUris(virtualMachineResponse.Body);

            Dictionary<string, string> snapshotQuery = new Dictionary<string, string>();
            snapshotQuery.Add(backupExtensionMetadataName, snapshotTag);
            List <CloudPageBlob> snapshots = this.FindSnapshot(blobUris, snapshotQuery, storageCredentialsFactory);
            if (snapshots == null || snapshots.Count == 0)
            {
                throw new AzureVMBackupException(AzureVMBackupErrorCodes.NoSnapshotFound, "snapshot with the tag not found.");
            }
            else
            {
                foreach (CloudPageBlob snapshot in snapshots)
                {
                    snapshot.Delete();
                }
            }
        }


        /// <summary>
        /// we only support the Linux box now, if it's a windows, one AzureVMBackupException would be thrown.
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="vmName"></param>
        /// <param name="virtualMachineExtensionType"></param>
        /// <param name="location"></param>
        /// <param name="virtualMachineResponse"></param>
        /// <param name="snapshotTag"></param>
        /// <param name="virtualMachineExtensionBaseCmdlet"></param>
        public void CreateSnapshotForDisks(AzureVMBackupConfig vmConfig, string snapshotTag, VirtualMachineExtensionBaseCmdlet virtualMachineExtensionBaseCmdlet)
        {
            var virtualMachine = virtualMachineExtensionBaseCmdlet.ComputeClient.ComputeManagementClient.VirtualMachines.GetWithInstanceView(
                vmConfig.ResourceGroupName,
                vmConfig.VMName);
            StorageManagementClient storageClient = AzureSession.ClientFactory.CreateArmClient<StorageManagementClient>(virtualMachineExtensionBaseCmdlet.DefaultProfile.Context, AzureEnvironment.Endpoint.ResourceManager);

            StorageCredentialsFactory storageCredentialsFactory = new StorageCredentialsFactory(vmConfig.ResourceGroupName, storageClient, virtualMachineExtensionBaseCmdlet.DefaultProfile.Context.Subscription);

            CloudPageBlobObjectFactory cloudPageBlobObjectFactory = new CloudPageBlobObjectFactory(storageCredentialsFactory, TimeSpan.FromMinutes(1));

            List<string> vmPageBlobUris = this.GetDiskBlobUris(virtualMachine.Body);

            AzureVMBackupBlobSasUris blobSASUris = this.GenerateBlobSasUris(vmPageBlobUris, cloudPageBlobObjectFactory);

            string taskId = Guid.NewGuid().ToString();

            AzureVMBackupExtensionProtectedSettings privateConfig = new AzureVMBackupExtensionProtectedSettings();
            privateConfig.logsBlobUri = string.Empty;
            privateConfig.objectStr = this.GetBase64Encoding(blobSASUris);

            AzureVMBackupExtensionPublicSettings publicConfig = new AzureVMBackupExtensionPublicSettings();
            publicConfig.commandToExecute = backupSnapshotCommand;
            publicConfig.locale = backupDefaultLocale;
            publicConfig.commandStartTimeUTCTicks = DateTimeOffset.UtcNow.Ticks.ToString();
            publicConfig.taskId = taskId;
            AzureVMBackupMetadata backupMetadata = new AzureVMBackupMetadata();

            AzureVMBackupMetadataItem tagMetadataItem = new AzureVMBackupMetadataItem();
            tagMetadataItem.Key = backupExtensionMetadataName;
            tagMetadataItem.Value = snapshotTag;

            AzureVMBackupMetadataItem taskIdMetadataItem = new AzureVMBackupMetadataItem();
            taskIdMetadataItem.Key = backupExtensionIdentityMetadataName;
            taskIdMetadataItem.Value = taskId;

            backupMetadata.backupMetadata.Add(tagMetadataItem);
            backupMetadata.backupMetadata.Add(taskIdMetadataItem);

            publicConfig.objectStr = this.GetBase64Encoding(backupMetadata);

            VirtualMachineExtension vmExtensionParameters = new VirtualMachineExtension
            {
                Location = virtualMachine.Body.Location,
                Publisher = extensionPublisher,
                VirtualMachineExtensionType = extensionType,
                TypeHandlerVersion = extensionDefaultVersion,
                Settings = publicConfig,
                ProtectedSettings = privateConfig,
            };

            var vmBackupOperation = virtualMachineExtensionBaseCmdlet.VirtualMachineExtensionClient.CreateOrUpdate(
                vmConfig.ResourceGroupName,
                vmConfig.VMName,
                vmConfig.ExtensionName ?? backupExtensionName,
                vmExtensionParameters);

            // check the snapshots with the task id are all created.
            int timePeriod = 5000;
            int loopingTimes = ((int)TimeSpan.FromMinutes(10).TotalMilliseconds / timePeriod);

            Dictionary<string, string> snapshotQuery = new Dictionary<string, string>();
            snapshotQuery.Add(backupExtensionMetadataName, snapshotTag);
            snapshotQuery.Add(backupExtensionIdentityMetadataName, taskId);
            int i = 0;
            for (; i < loopingTimes; i++)
            {
                List<CloudPageBlob> snapshotsFound = this.FindSnapshot(vmPageBlobUris, snapshotQuery, storageCredentialsFactory);
                if (snapshotsFound.Count == vmPageBlobUris.Count)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(timePeriod);
                }
            }
            if (i == loopingTimes)
            {
                throw new AzureVMBackupException(AzureVMBackupErrorCodes.TimeOut, "snapshot not created, or not found in time.");
            }
        }
    }
}

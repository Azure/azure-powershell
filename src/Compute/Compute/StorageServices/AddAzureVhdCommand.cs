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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Storage.Version2017_10_01;
using Microsoft.WindowsAzure.Commands.Sync.Download;
using Microsoft.WindowsAzure.Commands.Tools.Vhd;
using Microsoft.WindowsAzure.Commands.Tools.Vhd.Model;
using System.Management;
using System;
using System.IO;
using System.Management.Automation;
using Rsrc = Microsoft.Azure.Commands.Compute.Properties.Resources;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Compute.Automation;
using Microsoft.Azure.Management.Compute;
using Microsoft.Samples.HyperV.Storage;
using Microsoft.Samples.HyperV.Common;
using System.Data.OleDb;

namespace Microsoft.Azure.Commands.Compute.StorageServices
{
    /// <summary>
    /// Uploads a vhd as fixed disk format vhd to a blob in Microsoft Azure Storage
    /// </summary>
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Vhd"), OutputType(typeof(VhdUploadContext))]
    public class AddAzureVhdCommand : ComputeClientBaseCmdlet
    {
        private const int DefaultNumberOfUploaderThreads = 8;
        private const string DefaultParameterSet = "DefaultParameterSet";
        private const string DirectUploadToManagedDiskSet = "DirectUploadToManagedDiskSet";

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = DirectUploadToManagedDiskSet,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Uri to blob")]
        [ValidateNotNullOrEmpty]
        [Alias("dst")]
        public Uri Destination
        {
            get;
            set;
        }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Local path of the vhd file")]
        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = DirectUploadToManagedDiskSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Local path of the vhd file")]
        [ValidateNotNullOrEmpty]
        [Alias("lf")]
        public FileInfo LocalFilePath
        {
            get;
            set;
        }

        [Parameter(
            Mandatory = true,
            ParameterSetName = DirectUploadToManagedDiskSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the new managed Disk")]
        [ValidateNotNullOrEmpty]
        public string DiskName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = DirectUploadToManagedDiskSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Location of new Managed Disk")]
        [LocationCompleter("Microsoft.Compute/disks")]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = DirectUploadToManagedDiskSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Sku for managed disk. Options: Standard_LRS, Premium_LRS, StandardSSD_LRS, UltraSSD_LRS")]
        [PSArgumentCompleter("Standard_LRS", "Premium_LRS", "StandardSSD_LRS", "UltraSSD_LRS")]
        public string DiskSku { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = DirectUploadToManagedDiskSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "OS Type for managed disk. Windows or Linux")]
        [PSArgumentCompleter("Windows", "Linux")]
        public OperatingSystemTypes? DiskOsType { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = DirectUploadToManagedDiskSet,
            ValueFromPipelineByPropertyName = true)]
        public int DiskSizeGB { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Number of uploader threads")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(1, 64)]
        [Alias("th")]
        public int? NumberOfUploaderThreads
        {
            get;
            set;
        }

        [Parameter(
            Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Uri to a base image in a blob storage account to apply the difference")]
        [ValidateNotNullOrEmpty]
        [Alias("bs")]
        public Uri BaseImageUriToPatch
        {
            get;
            set;
        }

        [Parameter(
            Position = 5,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "Vhd",
            HelpMessage = "Delete the blob if already exists")]
        [ValidateNotNullOrEmpty]
        [Alias("o")]
        public SwitchParameter OverWrite
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public UploadParameters ValidateParameters()
        {
            // validate destination
            BlobUri destinationUri;
            if (!BlobUri.TryParseUri(Destination, out destinationUri))
            {
                throw new ArgumentOutOfRangeException("Destination", this.Destination.ToString());
            }

            // validate baseImageUriToPatch
            BlobUri baseImageUri = null;
            if (this.BaseImageUriToPatch != null)
            {
                if (!BlobUri.TryParseUri(BaseImageUriToPatch, out baseImageUri))
                {
                    throw new ArgumentOutOfRangeException("BaseImageUriToPatch", this.BaseImageUriToPatch.ToString());
                }

                if (!String.IsNullOrEmpty(destinationUri.Uri.Query))
                {
                    var message = String.Format(Rsrc.AddAzureVhdCommandSASUriNotSupportedInPatchMode, destinationUri.Uri);
                    throw new ArgumentOutOfRangeException("Destination", message);
                }
            }

            var storageCredentialsFactory = CreateStorageCredentialsFactory();


            // checking for corrupted vhd
            PathIntrinsics currentPath = SessionState.Path;
            var filePath = new FileInfo(currentPath.GetUnresolvedProviderPathFromPSPath(LocalFilePath.ToString()));

            using (var vds = new VirtualDiskStream(filePath.FullName))
            {
                if (vds.DiskType == DiskType.Fixed)
                {
                    long divisor = Convert.ToInt64(Math.Pow(2, 9));
                    long rem = 0;
                    Math.DivRem(filePath.Length, divisor, out rem);
                    if (rem != 0)
                    {
                        throw new ArgumentOutOfRangeException("LocalFilePath", "Given vhd file is a corrupted fixed vhd");
                    }
                }
            }

            // sets objects, no create yet
            var parameters = new UploadParameters(
                destinationUri, baseImageUri, filePath, OverWrite.IsPresent,
                (NumberOfUploaderThreads) ?? DefaultNumberOfUploaderThreads)
            {
                Cmdlet = this,
                BlobObjectFactory = new CloudPageBlobObjectFactory(storageCredentialsFactory, TimeSpan.FromMinutes(1))
            };

            return parameters;
        }

        private StorageCredentialsFactory CreateStorageCredentialsFactory()
        {
            StorageCredentialsFactory storageCredentialsFactory;

            var storageClient = AzureSession.Instance.ClientFactory.CreateArmClient<StorageManagementClient>(
                        DefaultProfile.DefaultContext, AzureEnvironment.Endpoint.ResourceManager);

            if (StorageCredentialsFactory.IsChannelRequired(Destination))
            {
                storageCredentialsFactory = new StorageCredentialsFactory(this.ResourceGroupName, storageClient, DefaultContext.Subscription);
            }
            else
            {
                storageCredentialsFactory = new StorageCredentialsFactory();
            }

            return storageCredentialsFactory;
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() => 
            {
                bool backupCreated = false;
                // 1. convert vhdx to vhd if need
                // 1-1 check if vhdx file
                if (Path.GetExtension(this.LocalFilePath.Name) == ".vhdx")
                {
                    // create back up 
                    // createBackUp(this.LocalFilePath.FullName);
                    backupCreated = true;

                    // 1-2. convert file
                    FileInfo vhdFileInfo = new FileInfo(Path.ChangeExtension(this.LocalFilePath.FullName, ".vhd"));
                    ManagementScope scope = new ManagementScope(@"\root\virtualization\V2");
                    VirtualHardDiskSettingData settingData = new VirtualHardDiskSettingData(VirtualHardDiskType.FixedSize, VirtualHardDiskFormat.Vhd, vhdFileInfo.FullName, null, 0, 0, 0, 0);

                    WriteVerbose("Converting .vhdx file .vhd file.");
                    using (ManagementObject imageManagementService =
                        StorageUtilities.GetImageManagementService(scope))
                    {
                        using (ManagementBaseObject inParams =
                            imageManagementService.GetMethodParameters("ConvertVirtualHardDisk"))
                        {
                            inParams["SourcePath"] = this.LocalFilePath.FullName;
                            inParams["VirtualDiskSettingData"] =
                                settingData.GetVirtualHardDiskSettingDataEmbeddedInstance(null, imageManagementService.Path.Path);

                            using (ManagementBaseObject outParams = imageManagementService.InvokeMethod(
                                "ConvertVirtualHardDisk", inParams, null))
                            {
                                WmiUtilities.ValidateOutput(outParams, scope);
                            }
                        }
                    }
                    
                    // 1-3. update this.LocalFilePath property for resizing, if all good
                    this.LocalFilePath = vhdFileInfo;
                }
                
                // 2. resize vhd 
                // 2-2. check if resize is needed 
                if ((this.LocalFilePath.Length - 512) % 1048576 != 0) { // needs resizing
                    
                    // 2-2. make backupFile
                    if (!backupCreated)
                    {
                        createBackUp(this.LocalFilePath.FullName);
                    }

                    /*
                    // 2-3. resize
                    UInt64 FileSize = 1048576 * Convert.ToUInt64(Math.Ceiling((this.LocalFilePath.Length - 512) / 1048576.0));
                    WriteVerbose("Resizing Vhd file from " + this.LocalFilePath.Length + " to " + FileSize);
                    ManagementScope scope = new ManagementScope(@"\root\virtualization\V2");
                    using (ManagementObject imageManagementService =
                        StorageUtilities.GetImageManagementService(scope))
                    {
                        using (ManagementBaseObject inParams =
                            imageManagementService.GetMethodParameters("ResizeVirtualHardDisk"))
                        {
                            inParams["Path"] = this.LocalFilePath.FullName;
                            inParams["MaxInternalSize"] = FileSize;
                                             using (ManagementBaseObject outParams = imageManagementService.InvokeMethod(
                                "ResizeVirtualHardDisk", inParams, null))
                            {
                                WmiUtilities.ValidateOutput(outParams, scope);
                            }
                        }
                    }
                    */
                }
                else // does not need resizing
                { 
                    WriteVerbose("Vhd file already resized. Proceeding to uploading.");
                } 
                

                if (this.ParameterSetName == DirectUploadToManagedDiskSet)
                {
                    /*
                    // 3. DIRECT UPLOAD TO MANAGED DISK

                    
                    // 3-1. create disk config  
                    // TO-DO: need to set disksizeGB in this method still 
                    var diskConfig = CreateDiskConfig();

                    // 3-2: create disk 
                    NewAzureRmDisk newDisk = new NewAzureRmDisk
                    {
                        ResourceGroupName = this.ResourceGroupName,
                        DiskName = this.DiskName,
                        Disk = diskConfig
                    };
                    
                    newDisk.ExecuteCmdlet();
                    
                    // 3-3: generate SAS
                    GrantAzureRmDiskAccess sas = new GrantAzureRmDiskAccess();
                    var grantAccessData = new GrantAccessData();
                    grantAccessData.Access = "Write";
                    grantAccessData.DurationInSeconds = 86400;
                    var accessUri = sas.DisksClient.GrantAccess(this.ResourceGroupName, this.DiskName, grantAccessData);
                    Uri sasUri = new Uri(accessUri.AccessSAS);
                    this.Destination = sasUri;
                    //sas.ResourceGroupName = this.ResourceGroupName;
                    //sas.DiskName = this.DiskName;
                    //sas.DurationInSecond = 86400;
                    //sas.Access = "Write";
                    //sas.ExecuteCmdlet();
                    
                    // 3-4: upload 
                    var parameters = ValidateParameters();
                    var vhdUploadContext = VhdUploaderModel.Upload(parameters);
                    // AzCopy.exe copy "c:\somewhere\mydisk.vhd" $diskSas.AccessSAS --blob-type PageBlob
                    
                    // 3-5: revoke SAS
                    RevokeAzureRmDiskAccess revokeSas = new RevokeAzureRmDiskAccess();
                    revokeSas.ResourceGroupName = this.ResourceGroupName;
                    revokeSas.DiskName = this.DiskName;
                    revokeSas.ExecuteCmdlet();

                    WriteObject(vhdUploadContext);
                    */
                }
                else
                {
                    var parameters = ValidateParameters();
                    var vhdUploadContext = VhdUploaderModel.Upload(parameters);
                    WriteObject(vhdUploadContext);
                }
            });
            
            
        }

        private PSDisk CreateDiskConfig()
        {

            // Sku
            DiskSku vSku = null;

            // CreationData
            CreationData vCreationData = null;

            if (this.IsParameterBound(c => c.DiskSku))
            {
                if (vSku == null)
                {
                    vSku = new DiskSku();
                }
                vSku.Name = this.DiskSku;
            }

            vCreationData = new CreationData();
            vCreationData.CreateOption = "upload";
            // TO-DO: change back to first line when .length is always N * Mib + 512
            //vCreationData.UploadSizeBytes = this.LocalFilePath.Length;
            vCreationData.UploadSizeBytes = 32506368;

            var vDisk = new PSDisk
            {
                Zones = null,
                OsType = this.IsParameterBound(c => c.DiskOsType) ? this.DiskOsType : (OperatingSystemTypes?)null,
                HyperVGeneration = null,
                DiskSizeGB = this.IsParameterBound(c => c.DiskSizeGB) ? this.DiskSizeGB : (int?)null,
                DiskIOPSReadWrite = null,
                DiskMBpsReadWrite = null,
                DiskIOPSReadOnly = null,
                DiskMBpsReadOnly = null,
                MaxShares = null,
                Location = this.IsParameterBound(c => c.Location) ? this.Location : null,
                Tags = null,
                Sku = vSku,
                CreationData = vCreationData,
                EncryptionSettingsCollection = null,
                Encryption = null ,
                NetworkAccessPolicy = null,
                DiskAccessId = null
            };
            return vDisk;
        }

        private void createBackUp(string filePath)
        {
            string ext = Path.GetExtension(filePath);
            string backupPath = Path.GetDirectoryName(filePath) + @"\" + Path.GetFileNameWithoutExtension(filePath) + "_temp" + ext;
            int extNum = 0;
            while (File.Exists(backupPath))
            {
                backupPath = Path.GetDirectoryName(filePath) + @"\" + Path.GetFileNameWithoutExtension(filePath) + "_temp(" + extNum + ")" + ext;
                extNum += 1;
            }
            this.LocalFilePath.CopyTo(backupPath);
            Console.WriteLine("Back up copy made to: " + backupPath);
        }

    }
}

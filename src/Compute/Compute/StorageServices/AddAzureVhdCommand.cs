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
using System.CodeDom;

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
                /*
                // 1.              CONVERT VHDX TO VHD
                // 1-1             CHECK IF VHDX FILE
                if (Path.GetExtension(this.LocalFilePath.Name) == ".vhdx")
                {

                    // 1-2.          IF VHDX, CONVERT
                    string ConvertedPath = Path.GetDirectoryName(this.LocalFilePath.FullName) + @"\" + Path.GetFileNameWithoutExtension(this.LocalFilePath.FullName) + "_Converted.vhd";
                    FileInfo vhdFileInfo = new FileInfo(ConvertedPath);
                    ManagementScope scope = new ManagementScope(@"\root\virtualization\V2");
                    VirtualHardDiskSettingData settingData = new VirtualHardDiskSettingData(VirtualHardDiskType.FixedSize, VirtualHardDiskFormat.Vhd, vhdFileInfo.FullName, null, 0, 0, 0, 0);

                    try
                    {
                        using (ManagementObject imageManagementService =
                        StorageUtilities.GetImageManagementService(scope))
                        {
                            WriteVerbose("Converting .vhdx file to .vhd file. Converted file: " + ConvertedPath);
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
                    }
                    catch (System.Management.ManagementException e)
                    {
                            ThrowTerminatingError(new ErrorRecord(
                                e,
                                "Hyper-V is unavailable",
                                ErrorCategory.InvalidOperation,
                                null));
                    }
                    
                    
                    // 1-3.      UPDATE this.LocalFilePath PARAMETER TO USE THE NEW VHD FILE TO BE RESIZED IN THE NEXT PART
                    this.LocalFilePath = vhdFileInfo;
                }
                
                // 2.            RESIZE VHD
                // 2-1.          CHECK IF RESIZE NEEDED
                if ((this.LocalFilePath.Length - 512) % 1048576 != 0) { // needs resizing
                    

                    // 2-2.      CHECK IF FIXED SIZED, IF NOT COVERT TO FIXED SIZE
                    try
                    {
                        VirtualHardDiskSettingData virtualHardDiskSettingData;
                        ManagementScope scope = new ManagementScope(@"\root\virtualization\V2");

                        using (ManagementObject imageManagementService = StorageUtilities.GetImageManagementService(scope))
                        {
                            using (ManagementBaseObject inParams = imageManagementService.GetMethodParameters("GetVirtualHardDiskSettingData"))
                            {
                                inParams["Path"] = this.LocalFilePath.FullName;

                                using (ManagementBaseObject outParams = imageManagementService.InvokeMethod("GetVirtualHardDiskSettingData", inParams, null))
                                {
                                    WmiUtilities.ValidateOutput(outParams, scope);

                                    virtualHardDiskSettingData = VirtualHardDiskSettingData.Parse(outParams["SettingData"].ToString());
                                }
                            }
                        }

                        // NOT FIXED. CONVERT
                        if (virtualHardDiskSettingData.DiskType != VirtualHardDiskType.FixedSize)
                        {
                            string FixedSizePath = Path.GetDirectoryName(this.LocalFilePath.FullName) + @"\" + Path.GetFileNameWithoutExtension(this.LocalFilePath.FullName) + "_fixedSize.vhd";
                            FileInfo FixedFileInfo = new FileInfo(FixedSizePath);
                            VirtualHardDiskSettingData settingData = new VirtualHardDiskSettingData(VirtualHardDiskType.FixedSize, VirtualHardDiskFormat.Vhd, FixedFileInfo.FullName, null, 0, 0, 0, 0);
                            using (ManagementObject imageManagementService =
                                StorageUtilities.GetImageManagementService(scope))
                            {
                                WriteVerbose("Converting dynamically sized VHD to fixed size VHD. Fixed VHD file: " + FixedSizePath);
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
                                        this.LocalFilePath = FixedFileInfo;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // 2-3. BACK UP IF NOT CONVERTING 
                            createBackUp(this.LocalFilePath.FullName);
                        }

                        // 2-4.      RESIZE
                        UInt64 FileSize = 1048576 * Convert.ToUInt64(Math.Ceiling((this.LocalFilePath.Length - 512) / 1048576.0));
                        UInt64 FullFileSize = FileSize + 512;

                    
                        using (ManagementObject imageManagementService =
                            StorageUtilities.GetImageManagementService(scope))
                        {
                            WriteVerbose("Resizing Vhd file from " + this.LocalFilePath.Length + " to " + FullFileSize);
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
                    }
                    catch (System.Management.ManagementException e)
                    {
                        ThrowTerminatingError(new ErrorRecord(
                            e,
                            "Hyper-V is unavailable",
                            ErrorCategory.InvalidOperation,
                            null));
                    }
                }
                else // does not need resizing
                { 
                    WriteVerbose("Vhd file already resized. Proceeding to uploading.");
                } 
                */
                
                
                if (this.ParameterSetName == DirectUploadToManagedDiskSet)
                {
                    
                    // 3. DIRECT UPLOAD TO MANAGED DISK

                    // 3-1. create disk config  
                    // TO-DO: need to set disksizeGB in this method still 
                    var diskConfig = CreateDiskConfig();

                    // 3-2: create disk 
                    createManagedDisk(this.ResourceGroupName, this.DiskName, diskConfig);
                    

                    // 3-3: generate SAS
                    GrantAzureRmDiskAccess sas = new GrantAzureRmDiskAccess();
                    var grantAccessData = new GrantAccessData();
                    grantAccessData.Access = "Write";
                    grantAccessData.DurationInSeconds = 86400;
                    var accessUri = sas.DisksClient.GrantAccess(this.ResourceGroupName, this.DiskName, grantAccessData);
                    Uri sasUri = new Uri(accessUri.AccessSAS);
                    
                    //this.Destination = sasUri;

                    // 3-4: upload 
                    // var parameters = ValidateParameters();
                    // var vhdUploadContext = VhdUploaderModel.Upload(parameters);
                    // AzCopy.exe copy "c:\somewhere\mydisk.vhd" $diskSas.AccessSAS --blob-type PageBlob

                    // 3-5: revoke SAS
                    //RevokeAzureRmDiskAccess revokeSas = new RevokeAzureRmDiskAccess();
                    //var result = revokeSas.DisksClient.RevokeAccessWithHttpMessagesAsync(this.ResourceGroupName, this.DiskName).GetAwaiter().GetResult();
                    //PSOperationStatusResponse output = new PSOperationStatusResponse
                    //{
                    //    StartTime = this.StartTime,
                    //    EndTime = DateTime.Now
                    //};

                    //if (result != null && result.Request != null && result.Request.RequestUri != null)
                    //{
                    //    output.Name = GetOperationIdFromUrlString(result.Request.RequestUri.ToString());
                    //}

                    //WriteObject(output);

                    //RevokeAzureRmDiskAccess revokeSas = new RevokeAzureRmDiskAccess();
                    //revokeSas.ResourceGroupName = this.ResourceGroupName;
                    //revokeSas.DiskName = this.DiskName;
                    //revokeSas.ExecuteCmdlet();

                    // WriteObject(vhdUploadContext);

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
            vCreationData.UploadSizeBytes = this.LocalFilePath.Length;

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
            string backupPath = Path.GetDirectoryName(filePath) + @"\" + Path.GetFileNameWithoutExtension(filePath) + "_backup" + ext;
            int extNum = 0;
            while (File.Exists(backupPath))
            {
                backupPath = Path.GetDirectoryName(filePath) + @"\" + Path.GetFileNameWithoutExtension(filePath) + "_backup(" + extNum + ")" + ext;
                extNum += 1;
            }
            Console.WriteLine("Making a back up copy to: " + backupPath);
            this.LocalFilePath.CopyTo(backupPath);
        }

        private void createManagedDisk(string ResourceGroupName, string DiskName, PSDisk psDisk)
        {
            NewAzureRmDisk newDisk = new NewAzureRmDisk();
            string resourceGroupName = ResourceGroupName;
            string diskName = DiskName;
            Disk disk = new Disk();
            ComputeAutomationAutoMapperProfile.Mapper.Map<PSDisk, Disk>(psDisk, disk);

            var result = newDisk.DisksClient.CreateOrUpdate(resourceGroupName, diskName, disk);
            var psObject = new PSDisk();
            ComputeAutomationAutoMapperProfile.Mapper.Map<Disk, PSDisk>(result, psObject);
            WriteObject(psObject);
        }

    }
}

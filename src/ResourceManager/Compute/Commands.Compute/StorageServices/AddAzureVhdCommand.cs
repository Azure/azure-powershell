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
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.WindowsAzure.Commands.Sync.Download;
using Microsoft.WindowsAzure.Commands.Tools.Vhd;
using Microsoft.WindowsAzure.Commands.Tools.Vhd.Model;
using System;
using System.IO;
using System.Management.Automation;
using Rsrc = Microsoft.Azure.Commands.Compute.Properties.Resources;

namespace Microsoft.Azure.Commands.Compute.StorageServices
{
    /// <summary>
    /// Uploads a vhd as fixed disk format vhd to a blob in Microsoft Azure Storage
    /// </summary>
    [Cmdlet(VerbsCommon.Add, ProfileNouns.Vhd), OutputType(typeof(VhdUploadContext))]
    public class AddAzureVhdCommand : ComputeClientBaseCmdlet
    {
        private const int DefaultNumberOfUploaderThreads = 8;

        [Parameter(
            Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
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

        public UploadParameters ValidateParameters()
        {
            BlobUri destinationUri;
            if (!BlobUri.TryParseUri(Destination, out destinationUri))
            {
                throw new ArgumentOutOfRangeException("Destination", this.Destination.ToString());
            }

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

            var storageClient = AzureSession.ClientFactory.CreateArmClient<StorageManagementClient>(
                        DefaultProfile.Context, AzureEnvironment.Endpoint.ResourceManager);

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
            var parameters = ValidateParameters();
            var vhdUploadContext = VhdUploaderModel.Upload(parameters);
            WriteObject(vhdUploadContext);
        }
    }
}

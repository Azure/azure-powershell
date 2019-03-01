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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzurePrefix + "BatchResourceFile", DefaultParameterSetName = HttpUrlParameterSet), OutputType(typeof(PSResourceFile))]
    public class NewBatchResourceFileCommand : AzureRMCmdlet
    {
        internal const string HttpUrlParameterSet = "HttpUrl";
        internal const string StorageContainerUrlParameterSet = "StorageContainerUrl";
        internal const string AutoStorageContainerNameParameterSet = "AutoStorageContainerName";

        [Parameter(ParameterSetName = HttpUrlParameterSet, Mandatory = true, HelpMessage = "The URL of the file to download. If the URL is Azure Blob Storage, it must be readable using anonymous access; that is, the Batch service does not present any credentials when downloading the blob. There are two ways to get such a URL for a blob in Azure storage: include a Shared Access Signature (SAS) granting read permissions on the blob, or set the ACL for the blob or its container to allow public access.")]
        [ValidateNotNullOrEmpty]
        public string HttpUrl { get; set; }

        [Parameter(ParameterSetName = HttpUrlParameterSet, Mandatory = true, HelpMessage = "The location on the compute node to which to download the file(s), relative to the task's working directory. If the HttpUrl parameter is specified, the FilePath is required and describes the path which the file will be downloaded to, including the filename. Otherwise, if the AutoStorageContainerName or StorageContainerUrl parameters are specified, FilePath is optional and is the directory to download the files to. In the case where FilePath is used as a directory, any directory structure already associated with the input data will be retained in full and appended to the specified FilePath directory. The specified relative path cannot break out of the task's working directory (for example by using '..').")]
        [Parameter(ParameterSetName = StorageContainerUrlParameterSet)]
        [Parameter(ParameterSetName = AutoStorageContainerNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string FilePath { get; set; }

        [Parameter(HelpMessage = "Gets the file permission mode attribute in octal format. This property is applicable only if the resource file is downloaded to a Linux node. If this property is not specified for a Linux node, then the default value is 0770.")]
        [ValidateNotNullOrEmpty]
        public string FileMode { get; set; }

        [Parameter(ParameterSetName = AutoStorageContainerNameParameterSet, Mandatory = true, HelpMessage = "The storage container name in the auto storage account.")]
        [ValidateNotNullOrEmpty]
        public string AutoStorageContainerName { get; set; }

        [Parameter(
            ParameterSetName = StorageContainerUrlParameterSet, 
            HelpMessage = "Gets the blob prefix to use when downloading blobs from an Azure Storage container. Only the blobs whose names begin with the specified prefix will be downloaded. This prefix can be a partial filename or a subdirectory. If a prefix is not specified, all the files in the container will be downloaded.")]
        [Parameter(ParameterSetName = AutoStorageContainerNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string BlobPrefix { get; set; }

        [Parameter(ParameterSetName = StorageContainerUrlParameterSet, Mandatory = true, HelpMessage = "The URL of the blob container within Azure Blob Storage. This URL must be readable and listable using anonymous access; that is, the Batch service does not present any credentials when downloading blobs from the container. There are two ways to get such a URL for a container in Azure storage: include a Shared Access Signature (SAS) granting read permissions on the container, or set the ACL for the container to allow public access.")]
        [ValidateNotNullOrEmpty]
        public string StorageContainerUrl { get; set; }

        public override void ExecuteCmdlet()
        {
            ResourceFile resourceFile;
            if(!string.IsNullOrEmpty(HttpUrl))
            {
                resourceFile = ResourceFile.FromUrl(HttpUrl, FilePath, fileMode: FileMode);
            }
            else if(!string.IsNullOrEmpty(StorageContainerUrl))
            {
                resourceFile = ResourceFile.FromStorageContainerUrl(StorageContainerUrl, FilePath, blobPrefix: BlobPrefix, fileMode: FileMode);
            }
            else
            {
                resourceFile = ResourceFile.FromAutoStorageContainer(AutoStorageContainerName, FilePath, blobPrefix: BlobPrefix, fileMode: FileMode);
            }

            WriteObject(new PSResourceFile(resourceFile));
        }
    }
}

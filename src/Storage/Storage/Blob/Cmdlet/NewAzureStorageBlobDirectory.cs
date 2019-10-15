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

namespace Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet
{
    using Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.Azure.Storage.Blob;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading.Tasks;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// create a new azure container
    /// </summary>
    [Cmdlet("New", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageBlobDirectory", DefaultParameterSetName = ManualParameterSet, SupportsShouldProcess = true), OutputType(typeof(AzureStorageBlob))]
    public class NewAzureStorageBlobDirectoryCommand : StorageCloudBlobCmdletBase
    {
        /// <summary>
        /// manually set the name parameter
        /// </summary>
        private const string ManualParameterSet = "ReceiveManual";

        /// <summary>
        /// container pipeline
        /// </summary>
        private const string ContainerParameterSet = "ContainerPipeline";

        [Parameter(Mandatory = true, HelpMessage = "Azure Container Object",
            ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerParameterSet)]
        [ValidateNotNull]
        public CloudBlobContainer CloudBlobContainer { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Container name", ParameterSetName = ManualParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Container
        {
            get { return ContainerName; }
            set { ContainerName = value; }
        }
        private string ContainerName = String.Empty;

        [Parameter(Mandatory = true, HelpMessage = "Blob Directory path")]
        [ValidateNotNullOrEmpty]
        public string Path
        {
            get { return BlobDirectoryPath; }
            set { BlobDirectoryPath = value; }
        }
        private string BlobDirectoryPath = String.Empty;

        [Parameter(Mandatory = false, HelpMessage = "When creating blob directory and the parent folder does not have a default ACL, the umask restricts the permissions of the file or directory to be created. The resulting permission is given by p & ^u, where p is the permission and u is the umask. Symbolic (rwxrw-rw-) is supported. ")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("([r-][w-][x-]){3}")]
        public string Umask { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission. Symbolic (rwxrw-rw-) is supported. ")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("([r-][w-][x-]){3}")]
        public string Permission { get; set; }


        [Parameter(HelpMessage = "Blob Directory Properties", Mandatory = false)]
        public Hashtable Property
        {
            get
            {
                return BlobDirProperties;
            }

            set
            {
                BlobDirProperties = value;
            }
        }
        private Hashtable BlobDirProperties = null;

        [Parameter(HelpMessage = "Blob Directory Metadata", Mandatory = false)]
        public Hashtable Metadata
        {
            get
            {
                return BlobDirMetadata;
            }

            set
            {
                BlobDirMetadata = value;
            }
        }
        private Hashtable BlobDirMetadata = null;

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageBlobDirectoryCommand class.
        /// </summary>
        public NewAzureStorageBlobDirectoryCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageBlobDirectoryCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public NewAzureStorageBlobDirectoryCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }

        /// <summary>
        /// execute command
        /// </summary>
        public override void ExecuteCmdlet()
        {
            IStorageBlobManagement localChannel = Channel;

            BlobRequestOptions requestOptions = RequestOptions;
            CloudBlobContainer container;
            if (ParameterSetName == ManualParameterSet)
            {
                if (!NameUtil.IsValidContainerName(ContainerName))
                {
                    throw new ArgumentException(String.Format(Resources.InvalidContainerName, ContainerName));
                }
                container = localChannel.GetContainerReference(ContainerName);
            }
            else //ContainerParameterSet
            {
                container = CloudBlobContainer;
            }

            CloudBlobDirectory blobDir = container.GetDirectoryReference(BlobDirectoryPath);

            if (ShouldProcess(blobDir.Uri.ToString(), "Create Blob Directory: "))
            {

                if (blobDir.Exists())
                {
                    throw new ResourceAlreadyExistException(String.Format("Blob Directory '{0}' already exists.", blobDir.Uri));
                }

                if (this.Permission != null)
                {
                    blobDir.PathProperties.Permissions = PathPermissions.ParseSymbolic(this.Permission);
                }

                // Set Blob Properties
                if (this.BlobDirProperties != null)
                {
                    // Valid Blob Dir properties
                    foreach (DictionaryEntry entry in this.BlobDirProperties)
                    {
                        if (!validCloudBlobDirProperties.ContainsKey(entry.Key.ToString()))
                        {
                            throw new ArgumentException(String.Format(Resources.InvalidBlobProperties, entry.Key.ToString(), entry.Value.ToString()));
                        }
                    }

                    foreach (DictionaryEntry entry in BlobDirProperties)
                    {
                        string key = entry.Key.ToString();
                        string value = entry.Value.ToString();
                        Action<BlobProperties, string> action = validCloudBlobDirProperties[key];

                        if (action != null)
                        {
                            action(blobDir.Properties, value);
                        }
                    }
                }

                //Set Blob MetaData
                if (this.BlobDirMetadata != null)
                {
                    foreach (DictionaryEntry entry in this.BlobDirMetadata)
                    {
                        string key = entry.Key.ToString();
                        string value = entry.Value.ToString();

                        if (blobDir.Metadata.ContainsKey(key))
                        {
                            blobDir.Metadata[key] = value;
                        }
                        else
                        {
                            blobDir.Metadata.Add(key, value);
                        }
                    }
                }

                blobDir.Create(requestOptions,
                        this.Umask != null ? PathPermissions.ParseSymbolic(this.Umask) : null);

                blobDir.FetchAttributes();
                blobDir.FetchAccessControls();

                AzureStorageBlob azureBlob = new AzureStorageBlob(blobDir);
                azureBlob.Context = localChannel.StorageContext;
                WriteObject(azureBlob);
            }
        }

        //only support the common blob properties for Blob Dir
        private Dictionary<string, Action<BlobProperties, string>> validCloudBlobDirProperties =
            new Dictionary<string, Action<BlobProperties, string>>(StringComparer.OrdinalIgnoreCase)
            {
                {"CacheControl", (p, v) => p.CacheControl = v},
                {"ContentDisposition", (p, v) => p.ContentDisposition = v},
                {"ContentEncoding", (p, v) => p.ContentEncoding = v},
                {"ContentLanguage", (p, v) => p.ContentLanguage = v},
                //{"ContentMD5", (p, v) => p.ContentMD5 = v},
                //{"ContentType", (p, v) => p.ContentType = v},
            };
    }
}

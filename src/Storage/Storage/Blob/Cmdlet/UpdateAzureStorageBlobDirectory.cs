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
    using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;

    /// <summary>
    /// create a new azure container
    /// </summary>
    [Cmdlet("Update", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageBlobDirectory", DefaultParameterSetName = ManualParameterSet, SupportsShouldProcess = true), OutputType(typeof(AzureStorageBlob))]
    public class SetAzureStorageBlobDirectoryCommand : StorageCloudBlobCmdletBase
    {
        /// <summary>
        /// manually set the name parameter
        /// </summary>
        private const string ManualParameterSet = "ReceiveManual";

        /// <summary>
        /// container pipeline
        /// </summary>
        private const string ContainerParameterSet = "ContainerPipeline";

        /// <summary>
        /// BlobDirectory pipeline
        /// </summary>
        private const string BlobDirectoryParameterSet = "BlobDirectoryPipeline";

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

        [Parameter(Mandatory = true, HelpMessage = "Blob Directory path", ParameterSetName = ContainerParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "Blob Directory path", ParameterSetName = ManualParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Path
        {
            get { return BlobDirectoryPath; }
            set { BlobDirectoryPath = value; }
        }
        private string BlobDirectoryPath = String.Empty;

        [Parameter(Mandatory = true, HelpMessage = "Azure BlobDirectory Object",
            ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobDirectoryParameterSet)]
        [ValidateNotNull]
        public CloudBlobDirectory CloudBlobDirectory { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission. Symbolic (rwxrw-rw-) is supported. Invalid in conjunction with ACL.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("([r-][w-][x-]){3}")]
        public string Permission { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Sets the owner of the blob directory.")]
        [ValidateNotNullOrEmpty]
        public string Owner { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Sets the owning group of the blob directory.")]
        [ValidateNotNullOrEmpty]
        public string Group { get; set; }

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

        [Parameter(HelpMessage = "Sets POSIX access control rights on files and directories. Create this object with New-AzStorageBlobPathACL.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public PSPathAccessControlEntry[] ACL { get; set; }

        /// <summary>
        /// Initializes a new instance of the SetAzureStorageBlobDirectoryCommand class.
        /// </summary>
        public SetAzureStorageBlobDirectoryCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SetAzureStorageBlobDirectoryCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public SetAzureStorageBlobDirectoryCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }

        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            IStorageBlobManagement localChannel = Channel;
            BlobRequestOptions requestOptions = RequestOptions;

            CloudBlobDirectory blobDir = this.CloudBlobDirectory;
            switch (ParameterSetName)
            {
                case ManualParameterSet:
                    CloudBlobContainer blobContainer = localChannel.GetContainerReference(ContainerName);
                    blobDir = blobContainer.GetDirectoryReference(BlobDirectoryPath);
                    break;
                case ContainerParameterSet:
                    blobDir = this.CloudBlobContainer.GetDirectoryReference(BlobDirectoryPath);
                    break;
                default:
                    // BlobDirectoryParameterSet already has the BlobDirectory created.
                    break;
            }

            if (ShouldProcess(blobDir.Uri.ToString(), "Update Blob Directory: "))
            {
                blobDir.FetchAttributes();
                blobDir.FetchAccessControls();

                //Set ACL
                if (this.Permission != null || this.Owner != null || this.Group != null)
                {
                    if (this.Permission != null)
                    {
                        blobDir.PathProperties.Permissions = PathPermissions.ParseSymbolic(this.Permission);
                    }
                    if (this.Owner != null)
                    {
                        blobDir.PathProperties.Owner = this.Owner;
                    }
                    if (this.Group != null)
                    {
                        blobDir.PathProperties.Group = this.Group;
                    }
                    blobDir.SetPermissions();
                }

                //Set ACL            
                if (this.ACL != null)
                {
                    blobDir.PathProperties.ACL = PSPathAccessControlEntry.ParseAccessControls(this.ACL);
                    blobDir.SetAcl();
                }

                // Set Properties
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
                    blobDir.SetProperties();
                }

                //Set MetaData
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
                    blobDir.SetMetadata();
                }

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

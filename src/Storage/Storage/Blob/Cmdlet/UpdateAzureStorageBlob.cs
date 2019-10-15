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
    [Cmdlet("Update", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageBlob", DefaultParameterSetName = ManualParameterSet, SupportsShouldProcess = true),OutputType(typeof(AzureStorageBlob))]
    public class SetAzStorageBlobCommand : StorageCloudBlobCmdletBase
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
        private const string BlobParameterSet = "BlobPipeline";

        [Parameter(Mandatory = true, HelpMessage = "Azure Container Object",
            ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerParameterSet)]
        [ValidateNotNull]
        public CloudBlobContainer CloudBlobContainer { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Container name", ParameterSetName = ManualParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Container { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Blob path", ParameterSetName = ManualParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "Blob path", ParameterSetName = ContainerParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Alias("ICloudBlob")]
        [Parameter(Mandatory = true, HelpMessage = "Azure Blob Object",
            ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobParameterSet)]
        [ValidateNotNull]
        public CloudBlob CloudBlob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission. Symbolic (rwxrw-rw-) is supported. Invalid in conjunction with ACL.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("([r-][w-][x-]){3}")]
        public string Permission { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Sets the owner of the blob.")]
        [ValidateNotNullOrEmpty]
        public string Owner { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Sets the owning group of the blob.")]
        [ValidateNotNullOrEmpty]
        public string Group { get; set; }

        [Parameter(HelpMessage = "Blob Properties", Mandatory = false)]
        public Hashtable Property
        {
            get
            {
                return BlobProperties;
            }

            set
            {
                BlobProperties = value;
            }
        }
        private Hashtable BlobProperties = null;

        [Parameter(HelpMessage = "Blob Metadata", Mandatory = false)]
        public Hashtable Metadata
        {
            get
            {
                return BlobMetadata;
            }

            set
            {
                BlobMetadata = value;
            }
        }
        private Hashtable BlobMetadata = null;

        [Parameter(HelpMessage = "Sets POSIX access control rights on files and directories. Create this object with New-AzStorageBlobPathACL.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public PSPathAccessControlEntry[] ACL { get; set; }



        /// <summary>
        /// Initializes a new instance of the SetAzStorageBlobCommand class.
        /// </summary>
        public SetAzStorageBlobCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SetAzStorageBlobCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public SetAzStorageBlobCommand(IStorageBlobManagement channel)
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

            CloudBlockBlob blob = this.CloudBlob as CloudBlockBlob;
            switch (ParameterSetName)
            {
                case ManualParameterSet:
                    if (!NameUtil.IsValidContainerName(this.Container))
                    {
                        throw new ArgumentException(String.Format(Resources.InvalidContainerName, this.Container));
                    }
                    CloudBlobContainer blobContainer = localChannel.GetContainerReference(this.Container);
                    blob = blobContainer.GetBlockBlobReference(this.Path);
                    break;
                case ContainerParameterSet:
                    blob = this.CloudBlobContainer.GetBlockBlobReference(this.Path);
                    break;
                default:
                    // BlobParameterSet already has Blob created.
                    break;
            }

            if (ShouldProcess(blob.Uri.ToString(), "Update Blob: "))
            {
                blob.FetchAttributes();


                if (this.Permission != null || this.Owner != null || this.Group != null || this.ACL != null)
                {
                    blob.FetchAccessControls();
                }

                    //Set permission
                    if (this.Permission != null || this.Owner != null || this.Group != null)
                {
                    if (this.Permission != null)
                    {
                        blob.PathProperties.Permissions = PathPermissions.ParseSymbolic(this.Permission);
                    }
                    if (this.Owner != null)
                    {
                        blob.PathProperties.Owner = this.Owner;
                    }
                    if (this.Group != null)
                    {
                        blob.PathProperties.Group = this.Group;
                    }
                    blob.SetPermissions();
                }

                //Set ACL               
                if (this.ACL != null)
                {
                    blob.PathProperties.ACL = PSPathAccessControlEntry.ParseAccessControls(this.ACL);
                    blob.SetAcl();
                }              

                // Set Blob Properties
                if (this.BlobProperties != null)
                {
                    // Valid Blob Dir properties
                    foreach (DictionaryEntry entry in this.BlobProperties)
                    {
                        if (!validCloudBlobProperties.ContainsKey(entry.Key.ToString()))
                        {
                            throw new ArgumentException(String.Format(Resources.InvalidBlobProperties, entry.Key.ToString(), entry.Value.ToString()));
                        }
                    }

                    foreach (DictionaryEntry entry in BlobProperties)
                    {
                        string key = entry.Key.ToString();
                        string value = entry.Value.ToString();
                        Action<BlobProperties, string> action = validCloudBlobProperties[key];

                        if (action != null)
                        {
                            action(blob.Properties, value);
                        }
                    }
                    blob.SetProperties();
                }

                //Set Blob MetaData
                if (this.BlobMetadata != null)
                {
                    foreach (DictionaryEntry entry in this.BlobMetadata)
                    {
                        string key = entry.Key.ToString();
                        string value = entry.Value.ToString();

                        if (blob.Metadata.ContainsKey(key))
                        {
                            blob.Metadata[key] = value;
                        }
                        else
                        {
                            blob.Metadata.Add(key, value);
                        }
                    }
                    blob.SetMetadata();
                }
            }

            blob.FetchAttributes();
            if (this.Permission != null || this.Owner != null || this.Group != null || this.ACL != null)
            {
                blob.FetchAccessControls();
            }

            AzureStorageBlob azureBlob = new AzureStorageBlob(blob);
            azureBlob.Context = localChannel.StorageContext;
            WriteObject(azureBlob);
        }

        //only support the common blob properties for Blob Dir
        private Dictionary<string, Action<BlobProperties, string>> validCloudBlobProperties =
            new Dictionary<string, Action<BlobProperties, string>>(StringComparer.OrdinalIgnoreCase)
            {
                {"CacheControl", (p, v) => p.CacheControl = v},
                {"ContentDisposition", (p, v) => p.ContentDisposition = v},
                {"ContentEncoding", (p, v) => p.ContentEncoding = v},
                {"ContentLanguage", (p, v) => p.ContentLanguage = v},
                {"ContentMD5", (p, v) => p.ContentMD5 = v},
                {"ContentType", (p, v) => p.ContentType = v},
            };
    }
}

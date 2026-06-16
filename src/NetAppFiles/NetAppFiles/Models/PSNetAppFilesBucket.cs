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

using Microsoft.Azure.Management.NetApp.Models;

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    /// <summary>
    /// PowerShell representation of an Azure NetApp Files Bucket resource.
    /// </summary>
    public class PSNetAppFilesBucket
    {
        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the resource Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the resource name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the volume path mounted inside the bucket.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the file system user (NFS or CIFS) accessing the bucket data.
        /// </summary>
        public FileSystemUser FileSystemUser { get; set; }

        /// <summary>
        /// Gets the provisioning state of the bucket resource.
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets the bucket credentials status (NoCredentialsSet | CredentialsExpired | Active).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets properties of the server managing the lifecycle of volume buckets.
        /// </summary>
        public BucketServerProperties Server { get; set; }

        /// <summary>
        /// Gets or sets the access permissions for the bucket (ReadOnly | ReadWrite).
        /// </summary>
        public string Permissions { get; set; }

        /// <summary>
        /// Gets or sets the Azure Key Vault settings used for the bucket certificate and credentials.
        /// </summary>
        public AzureKeyVaultDetails AkvDetails { get; set; }

        /// <summary>
        /// Gets or sets the system data.
        /// </summary>
        public PSSystemData SystemData { get; set; }
    }
}

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

namespace Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel
{
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;

    /// <summary>
    /// azure storage container
    /// </summary>
    public class AzureStorageContainer : AzureStorageBase
    {
        /// <summary>
        /// CloudBlobContainer object
        /// </summary>
        public CloudBlobContainer CloudBlobContainer { get; private set; }

        /// <summary>
        /// the permission of CloudBlobContainer
        /// </summary>
        public BlobContainerPermissions Permission { get; private set; }

        /// <summary>
        /// the public access level of CloudBlobContainer
        /// </summary>
        public BlobContainerPublicAccessType? PublicAccess { get; private set; }

        /// <summary>
        /// last modified of CloudBlobContainer
        /// </summary>
        public DateTimeOffset? LastModified { get; private set; }

        /// <summary>
        /// Container continuation token
        /// </summary>
        public BlobContinuationToken ContinuationToken { get; set; }

        /// <summary>
        /// init azure storage container using CloudBlobContainer and BlobContainerPermissions
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="permissions">permissions of container</param>
        public AzureStorageContainer(CloudBlobContainer container, BlobContainerPermissions permissions)
        {
            CloudBlobContainer = container;
            Permission = permissions;
            Name = container.Name;

            if (permissions == null)
            {
                PublicAccess = null;
            }
            else
            {
                PublicAccess = permissions.PublicAccess;
            }

            LastModified = container.Properties.LastModified;
        }
    }
}

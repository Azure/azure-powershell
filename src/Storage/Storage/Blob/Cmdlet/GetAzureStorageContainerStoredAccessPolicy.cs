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
    using Common;
<<<<<<< HEAD
    using Microsoft.Azure.Storage.Blob;
    using Model.Contract;
    using System;
=======
    using global::Azure.Storage.Blobs;
    using global::Azure.Storage.Blobs.Models;
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using Model.Contract;
    using System;
    using System.Collections.Generic;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    using System.Globalization;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading.Tasks;

    /// <summary>
    /// create a new azure container
    /// </summary>
<<<<<<< HEAD
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageContainerStoredAccessPolicy"), OutputType(typeof(SharedAccessBlobPolicy))]
=======
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageContainerStoredAccessPolicy"), OutputType(typeof(PSObject))]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    public class GetAzureStorageContainerStoredAccessPolicyCommand : StorageCloudBlobCmdletBase
    {
        [Alias("N", "Name")]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Container name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Container { get; set; }

        [Parameter(Position = 1,
            HelpMessage = "Policy Identifier",
            ValueFromPipelineByPropertyName = true)]
        public string Policy { get; set; }

        /// <summary>
        /// Initializes a new instance of the GetAzureStorageContainerStoredAccessPolicyCommand class.
        /// </summary>
        public GetAzureStorageContainerStoredAccessPolicyCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the GetAzureStorageContainerStoredAccessPolicyCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public GetAzureStorageContainerStoredAccessPolicyCommand(IStorageBlobManagement channel)
            : base(channel)
        {
        }

        internal async Task GetAzureContainerStoredAccessPolicyAsync(long taskId, IStorageBlobManagement localChannel, string containerName, string policyName)
        {
<<<<<<< HEAD
            SharedAccessBlobPolicies shareAccessPolicies = await GetPoliciesAsync(localChannel, containerName, policyName).ConfigureAwait(false);

            if (!String.IsNullOrEmpty(policyName))
            {
                if (shareAccessPolicies.Keys.Contains(policyName))
                {
                    OutputStream.WriteObject(taskId, AccessPolicyHelper.ConstructPolicyOutputPSObject<SharedAccessBlobPolicy>(shareAccessPolicies, policyName));
                }
                else
                {
                    throw new ResourceNotFoundException(String.Format(CultureInfo.CurrentCulture, Resources.PolicyNotFound, policyName));
                }
            }
            else
            {
                foreach (string key in shareAccessPolicies.Keys)
                {
                    OutputStream.WriteObject(taskId, AccessPolicyHelper.ConstructPolicyOutputPSObject<SharedAccessBlobPolicy>(shareAccessPolicies, key));
=======
            //Get container instance, Get existing permissions
            CloudBlobContainer container_Track1 = Channel.GetContainerReference(containerName);
            BlobContainerClient container = AzureStorageContainer.GetTrack2BlobContainerClient(container_Track1, Channel.StorageContext, ClientOptions);
            BlobContainerAccessPolicy accessPolicy = (await container.GetAccessPolicyAsync(BlobRequestConditions, cancellationToken: CmdletCancellationToken).ConfigureAwait(false)).Value;
            IEnumerable<BlobSignedIdentifier> signedIdentifiers = accessPolicy.SignedIdentifiers;

            if (!String.IsNullOrEmpty(policyName))
            {
                BlobSignedIdentifier signedIdentifier = null;
                foreach (BlobSignedIdentifier identifier in signedIdentifiers)
                {
                    if (identifier.Id == policyName)
                    {
                        signedIdentifier = identifier;
                    }
                }
                if (signedIdentifier == null)
                {
                    throw new ResourceNotFoundException(String.Format(CultureInfo.CurrentCulture, Resources.PolicyNotFound, policyName));
                }
                else
                {
                    OutputStream.WriteObject(taskId, AccessPolicyHelper.ConstructPolicyOutputPSObject<BlobSignedIdentifier>(signedIdentifier));
                }
            }
            else
            {
                foreach (BlobSignedIdentifier identifier in signedIdentifiers)
                {
                    OutputStream.WriteObject(taskId, AccessPolicyHelper.ConstructPolicyOutputPSObject<BlobSignedIdentifier>(identifier));
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                }
            }
        }

<<<<<<< HEAD
        internal async Task<SharedAccessBlobPolicies> GetPoliciesAsync(IStorageBlobManagement localChannel, string containerName, string policyName)
        {
            CloudBlobContainer container = localChannel.GetContainerReference(containerName);
            BlobContainerPermissions blobContainerPermissions = await localChannel.GetContainerPermissionsAsync(container, null, null, null, CmdletCancellationToken).ConfigureAwait(false);
            return blobContainerPermissions.SharedAccessPolicies;
        }


=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (String.IsNullOrEmpty(Container)) return;
            Func<long, Task> taskGenerator = (taskId) => GetAzureContainerStoredAccessPolicyAsync(taskId, Channel, Container, Policy);
            RunTask(taskGenerator);
        }
    }
}

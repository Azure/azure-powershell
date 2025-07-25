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
    using global::Azure.Storage.Blobs;
    using global::Azure.Storage.Blobs.Models;
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using Model.Contract;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Management.Automation;
    using System.Security.Permissions;

    /// <summary>
    /// create a new azure container
    /// </summary>
    [Cmdlet("New", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageContainerStoredAccessPolicy"), OutputType(typeof(String))]
    public class NewAzureStorageContainerStoredAccessPolicyCommand : StorageCloudBlobCmdletBase
    {
        [Alias("N", "Name")]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Container name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Container { get; set; }

        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "Policy Identifier. Need to be unique in the Container")]
        [ValidateNotNullOrEmpty]
        public string Policy { get; set; }

        [Parameter(HelpMessage = "Permissions for a container. Permissions can be any subset of \"racwdxlt\", make the permission order also same as it")]
        public string Permission { get; set; }

        [Parameter(HelpMessage = "Start Time")]
        public DateTime? StartTime { get; set; }

        [Parameter(HelpMessage = "Expiry Time")]
        public DateTime? ExpiryTime { get; set; }
        
        // Overwrite the useless parameter
        public override string TagCondition { get; set; }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageContainerStoredAccessPolicyCommand class.
        /// </summary>
        public NewAzureStorageContainerStoredAccessPolicyCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageContainerStoredAccessPolicyCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public NewAzureStorageContainerStoredAccessPolicyCommand(IStorageBlobManagement channel) :
            base(channel)
        {
            EnableMultiThread = false;
        }

        internal string CreateAzureContainerStoredAccessPolicy(IStorageBlobManagement localChannel, string containerName, string policyName, DateTime? startTime, DateTime? expiryTime, string permission)
        {
            if (!NameUtil.IsValidStoredAccessPolicyName(policyName))
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.InvalidAccessPolicyName, policyName));
            }

            //Get container instance, Get existing permissions
            CloudBlobContainer container_Track1 = Channel.GetContainerReference(containerName);
            BlobContainerClient container = AzureStorageContainer.GetTrack2BlobContainerClient(container_Track1, Channel.StorageContext, ClientOptions);
            BlobContainerAccessPolicy accessPolicy = container.GetAccessPolicy(cancellationToken: CmdletCancellationToken).Value;
            IEnumerable<BlobSignedIdentifier> signedIdentifiers = accessPolicy.SignedIdentifiers;

            //Add new policy
            foreach (BlobSignedIdentifier identifier in signedIdentifiers)
            {
                if (identifier.Id == policyName)
                {
                    throw new ResourceAlreadyExistException(String.Format(CultureInfo.CurrentCulture, Resources.PolicyAlreadyExists, policyName));
                }
            }
            BlobSignedIdentifier signedIdentifier = new BlobSignedIdentifier();
            signedIdentifier.Id = policyName;
            signedIdentifier.AccessPolicy = new BlobAccessPolicy();
            if (StartTime != null)
            {
                signedIdentifier.AccessPolicy.PolicyStartsOn = StartTime.Value.ToUniversalTime();
            }
            if (ExpiryTime != null)
            {
                signedIdentifier.AccessPolicy.PolicyExpiresOn = ExpiryTime.Value.ToUniversalTime();
            }
            signedIdentifier.AccessPolicy.Permissions = AccessPolicyHelper.OrderBlobPermission(this.Permission);
            var newsignedIdentifiers = new List<BlobSignedIdentifier>(signedIdentifiers);
            newsignedIdentifiers.Add(signedIdentifier);

            //Set permissions back to container
            container.SetAccessPolicy(accessPolicy.BlobPublicAccess, newsignedIdentifiers, BlobRequestConditions, CmdletCancellationToken);
            return policyName;
        }

        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (String.IsNullOrEmpty(Container) || String.IsNullOrEmpty(Policy)) return;
            string resultPolicy = CreateAzureContainerStoredAccessPolicy(Channel, Container, Policy, StartTime, ExpiryTime, Permission);
            WriteObject(resultPolicy);
        }
    }
}

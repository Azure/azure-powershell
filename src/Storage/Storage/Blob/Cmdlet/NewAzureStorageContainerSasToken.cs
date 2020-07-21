﻿// ----------------------------------------------------------------------------------
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
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;
    using global::Azure.Storage.Blobs;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using Track2Models = global::Azure.Storage.Blobs.Models;
    using global::Azure.Storage.Sas;

    [Cmdlet("New", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageContainerSASToken", SupportsShouldProcess = true), OutputType(typeof(String))]
    public class NewAzureStorageContainerSasTokenCommand : StorageCloudBlobCmdletBase
    {
        /// <summary>
        /// Sas permission parameter set name
        /// </summary>
        private const string SasPermissionParameterSet = "SasPermission";

        /// <summary>
        /// Sas policy paremeter set name
        /// </summary>
        private const string SasPolicyParmeterSet = "SasPolicy";

        [Alias("N", "Container")]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Container Name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Policy Identifier",
            ParameterSetName = SasPolicyParmeterSet)]
        [ValidateNotNullOrEmpty]
        public string Policy
        {
            get { return accessPolicyIdentifier; }
            set { accessPolicyIdentifier = value; }
        }
        private string accessPolicyIdentifier;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Permissions for a container. Permissions can be any not-empty subset of \"rwdl\".",
            ParameterSetName = SasPermissionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Permission { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Protocol can be used in the request with this SAS token.")]
        [ValidateNotNull]
        public SharedAccessProtocol? Protocol { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "IP, or IP range ACL (access control list) that the request would be accepted by Azure Storage.")]
        [ValidateNotNullOrEmpty]
        public string IPAddressOrRange { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Start Time")]
        [ValidateNotNull]
        public DateTime? StartTime { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Expiry Time")]
        [ValidateNotNull]
        public DateTime? ExpiryTime { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Display full uri with sas token")]
        public SwitchParameter FullUri { get; set; }

        // Overwrite the useless parameter
        public override int? ServerTimeoutPerRequest { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ConcurrentTaskCount { get; set; }
        protected override bool UseTrack2Sdk()
        {
            if (SasTokenHelper.IsTrack2Permission(this.Permission))
            {
                return true;
            }
            return base.UseTrack2Sdk();
        }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageContainerSasCommand class.
        /// </summary>
        public NewAzureStorageContainerSasTokenCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageContainerSasCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public NewAzureStorageContainerSasTokenCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
            EnableMultiThread = false;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (String.IsNullOrEmpty(Name)) return;

            // When the input context is Oauth bases, can't generate normal SAS, but UserDelegationSas
            bool generateUserDelegationSas = false;
            if (Channel!=null && Channel.StorageContext!= null && Channel.StorageContext.StorageAccount.Credentials.IsToken)
            {
                if (ShouldProcess(Name, "Generate User Delegation SAS, since input Storage Context is OAuth based."))
                {
                    generateUserDelegationSas = true;
                    if (!string.IsNullOrEmpty(accessPolicyIdentifier))
                    {
                        throw new ArgumentException("When input Storage Context is OAuth based, Saved Policy is not supported.", "Policy");
                    }
                }
                else
                {
                    return;
                }
            }

            if (!UseTrack2Sdk()) // Track1
            {
                CloudBlobContainer container = Channel.GetContainerReference(Name);
                SharedAccessBlobPolicy accessPolicy = new SharedAccessBlobPolicy();
                bool shouldSetExpiryTime = SasTokenHelper.ValidateContainerAccessPolicy(Channel, container.Name, accessPolicy, accessPolicyIdentifier);
                SetupAccessPolicy(accessPolicy, shouldSetExpiryTime);
                string sasToken;

                if (generateUserDelegationSas)
                {
                    UserDelegationKey userDelegationKey = Channel.GetUserDelegationKey(accessPolicy.SharedAccessStartTime, accessPolicy.SharedAccessExpiryTime, null, null, OperationContext);
                    sasToken = container.GetUserDelegationSharedAccessSignature(userDelegationKey, accessPolicy, null, Protocol, Util.SetupIPAddressOrRangeForSAS(IPAddressOrRange));
                }
                else
                {
                    sasToken = container.GetSharedAccessSignature(accessPolicy, accessPolicyIdentifier, Protocol, Util.SetupIPAddressOrRangeForSAS(IPAddressOrRange));
                }

                if (FullUri)
                {
                    string fullUri = SasTokenHelper.GetFullUriWithSASToken(container.Uri.AbsoluteUri.ToString(), sasToken);
                    WriteObject(fullUri);
                }
                else
                {
                    WriteObject(sasToken);
                }
            }
            else //Track2
            {
                //Get container instance
                CloudBlobContainer container_Track1 = Channel.GetContainerReference(Name);
                BlobContainerClient container = AzureStorageContainer.GetTrack2BlobContainerClient(container_Track1, Channel.StorageContext, ClientOptions);

                // Get contaienr saved policy if any
                Track2Models.BlobSignedIdentifier identifier = null;
                if (ParameterSetName == SasPolicyParmeterSet)
                {
                    identifier = SasTokenHelper.GetBlobSignedIdentifier(container, this.Policy, CmdletCancellationToken);
                }

                //Create SAS builder
                BlobSasBuilder sasBuilder = SasTokenHelper.SetBlobSasBuilder_FromContainer(container, identifier, this.Permission, this.StartTime, this.ExpiryTime, this.IPAddressOrRange, this.Protocol);

                //Create SAS and output it
                string sasToken = SasTokenHelper.GetBlobSharedAccessSignature(Channel.StorageContext, sasBuilder, generateUserDelegationSas, ClientOptions, CmdletCancellationToken);
                if (sasToken[0] != '?')
                {
                    sasToken = "?" + sasToken;
                }

                if (FullUri)
                {
                    string fullUri = SasTokenHelper.GetFullUriWithSASToken(container.Uri.AbsoluteUri.ToString(), sasToken);
                    WriteObject(fullUri);
                }
                else
                {
                    WriteObject(sasToken);
                }
            }
        }

        /// <summary>
        /// Update the access policy
        /// </summary>
        /// <param name="policy">Access policy object</param>
        /// <param name="shouldSetExpiryTime">Should set the default expiry time</param>
        private void SetupAccessPolicy(SharedAccessBlobPolicy policy, bool shouldSetExpiryTime)
        {
            DateTimeOffset? accessStartTime;
            DateTimeOffset? accessEndTime;
            SasTokenHelper.SetupAccessPolicyLifeTime(StartTime, ExpiryTime,
                out accessStartTime, out accessEndTime, shouldSetExpiryTime);
            policy.SharedAccessStartTime = accessStartTime;
            policy.SharedAccessExpiryTime = accessEndTime;
            AccessPolicyHelper.SetupAccessPolicyPermission(policy, Permission);
        }
    }
}

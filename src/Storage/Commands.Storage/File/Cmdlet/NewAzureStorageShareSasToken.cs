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

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    using Microsoft.WindowsAzure.Commands.Common.Storage;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.File;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;

    [Cmdlet(VerbsCommon.New, StorageNouns.ShareSas), OutputType(typeof(String))]
    public class NewAzureStorageShareSasToken : AzureStorageFileCmdletBase
    {
        /// <summary>
        /// Sas permission parameter set name
        /// </summary>
        private const string SasPermissionParameterSet = "SasPermission";

        /// <summary>
        /// Sas policy paremeter set name
        /// </summary>
        private const string SasPolicyParmeterSet = "SasPolicy";

        [Alias("N", "Name")]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Share Name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Policy Identifier", ParameterSetName = SasPolicyParmeterSet)]
        [ValidateNotNullOrEmpty]
        public string Policy
        {
            get { return accessPolicyIdentifier; }
            set { accessPolicyIdentifier = value; }
        }
        private string accessPolicyIdentifier;

        [Parameter(Mandatory = false, HelpMessage = "Permissions for a share. Permissions can be any subset of \"rwdl\".",
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

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure Storage Context Object")]
        [ValidateNotNull]
        public override AzureStorageContext Context { get; set; }

        // Overwrite the useless parameter
        public override int? ServerTimeoutPerRequest { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ConcurrentTaskCount { get; set; }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (String.IsNullOrEmpty(ShareName)) return;
            CloudFileShare fileShare = Channel.GetShareReference(this.ShareName);
            SharedAccessFilePolicy accessPolicy = new SharedAccessFilePolicy();

            bool shouldSetExpiryTime = SasTokenHelper.ValidateShareAccessPolicy(
                Channel,
                this.ShareName,
                accessPolicyIdentifier,
                !string.IsNullOrEmpty(this.Permission),
                this.StartTime.HasValue,
                this.ExpiryTime.HasValue);

            SetupAccessPolicy(accessPolicy, shouldSetExpiryTime);
            string sasToken = fileShare.GetSharedAccessSignature(accessPolicy, accessPolicyIdentifier, Protocol, Util.SetupIPAddressOrRangeForSAS(IPAddressOrRange));

            if (FullUri)
            {
                string fullUri = SasTokenHelper.GetFullUriWithSASToken(fileShare.Uri.AbsoluteUri.ToString(), sasToken);

                WriteObject(fullUri);
            }
            else
            {
                WriteObject(sasToken);
            }
        }

        protected override IStorageFileManagement CreateChannel()
        {
            if (this.Channel == null || !this.ShareChannel)
            {
                this.Channel = new StorageFileManagement(this.GetCmdletStorageContext());
            }

            return this.Channel;
        }

        /// <summary>
        /// Update the access policy
        /// </summary>
        /// <param name="policy">Access policy object</param>
        /// <param name="shouldSetExpiryTime">Should set the default expiry time</param>
        private void SetupAccessPolicy(SharedAccessFilePolicy policy, bool shouldSetExpiryTime)
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

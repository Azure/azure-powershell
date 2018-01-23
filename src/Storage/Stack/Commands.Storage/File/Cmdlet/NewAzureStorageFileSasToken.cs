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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
using Microsoft.WindowsAzure.Storage.File;

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    [Cmdlet(VerbsCommon.New, StorageNouns.FileSas), OutputType(typeof(String))]
    public class NewAzureStorageFileSasToken : AzureStorageFileCmdletBase
    {
        /// <summary>
        /// Sas permission with share name and path parameter set name
        /// </summary>
        private const string NameSasPermissionParameterSet = "NameSasPermission";

        /// <summary>
        /// Sas policy with share name and pathparemeter set name
        /// </summary>
        private const string NameSasPolicyParmeterSet = "NameSasPolicy";

        /// <summary>
        /// Sas permission with CloudFile instance parameter set name
        /// </summary>
        private const string CloudFileSasPermissionParameterSet = "FileSasPermission";

        /// <summary>
        /// Sas policy with CloudFile instance parameter set name
        /// </summary>
        private const string CloudFileSasPolicyParmeterSet = "FileSasPolicy";

        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Share Name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = NameSasPermissionParameterSet)]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Share Name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = NameSasPolicyParmeterSet)]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "Path to the cloud file to generate sas token against.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = NameSasPermissionParameterSet)]
        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "Path to the cloud file to generate sas token against.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = NameSasPolicyParmeterSet)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "CloudFile instance to represent the file to get SAS token against.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CloudFileSasPermissionParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "CloudFile instance to represent the file to get SAS token against.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CloudFileSasPolicyParmeterSet)]
        [ValidateNotNull]
        public CloudFile File { get; set; }

        [Parameter(HelpMessage = "Policy Identifier", ParameterSetName = NameSasPolicyParmeterSet)]
        [Parameter(HelpMessage = "Policy Identifier", ParameterSetName = CloudFileSasPolicyParmeterSet)]
        public string Policy
        {
            get { return accessPolicyIdentifier; }
            set { accessPolicyIdentifier = value; }
        }
        private string accessPolicyIdentifier;

        [Parameter(HelpMessage = "Permissions for a file. Permissions can be any subset of \"rwd\".",
            ParameterSetName = NameSasPermissionParameterSet)]
        [Parameter(HelpMessage = "Permissions for a file. Permissions can be any subset of \"rwd\".",
            ParameterSetName = CloudFileSasPermissionParameterSet)]
        public string Permission { get; set; }

        [Parameter(HelpMessage = "Start Time")]
        public DateTime? StartTime { get; set; }

        [Parameter(HelpMessage = "Expiry Time")]
        public DateTime? ExpiryTime { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Display full uri with sas token")]
        public SwitchParameter FullUri { get; set; }

        [Parameter(
            ValueFromPipeline = true,
            HelpMessage = "Azure Storage Context Object",
            ParameterSetName = NameSasPermissionParameterSet)]
        [Parameter(
            ValueFromPipeline = true,
            HelpMessage = "Azure Storage Context Object",
            ParameterSetName = NameSasPolicyParmeterSet)]
        public override IStorageContext Context { get; set; }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (String.IsNullOrEmpty(ShareName)) return;

            CloudFileShare fileShare = null;
            CloudFile file = null;

            if (null != this.File)
            {
                file = this.File;
                fileShare = this.File.Share;
            }
            else
            {
                string[] path = NamingUtil.ValidatePath(this.Path, true); 
                fileShare = Channel.GetShareReference(this.ShareName);
                file = fileShare.GetRootDirectoryReference().GetFileReferenceByPath(path);
            }

            SharedAccessFilePolicy accessPolicy = new SharedAccessFilePolicy();

            bool shouldSetExpiryTime = SasTokenHelper.ValidateShareAccessPolicy(
                Channel,
                fileShare.Name,
                accessPolicyIdentifier,
                !string.IsNullOrEmpty(this.Permission),
                this.StartTime.HasValue,
                this.ExpiryTime.HasValue);

            SetupAccessPolicy(accessPolicy, shouldSetExpiryTime);

            string sasToken = file.GetSharedAccessSignature(accessPolicy, accessPolicyIdentifier);

            if (FullUri)
            {
                string fullUri = SasTokenHelper.GetFullUriWithSASToken(file.Uri.AbsoluteUri.ToString(), sasToken);

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
            SetupAccessPolicyPermission(policy, Permission);
        }

        /// <summary>
        /// Set up access policy permission
        /// </summary>
        /// <param name="policy">SharedAccessFilePolicy object</param>
        /// <param name="permission">Permission</param>
        internal void SetupAccessPolicyPermission(SharedAccessFilePolicy policy, string permission)
        {
            if (string.IsNullOrEmpty(permission)) return;
            permission = permission.ToLower(CultureInfo.CurrentCulture);
            policy.Permissions = SharedAccessFilePolicy.PermissionsFromString(permission);
        }
    }
}

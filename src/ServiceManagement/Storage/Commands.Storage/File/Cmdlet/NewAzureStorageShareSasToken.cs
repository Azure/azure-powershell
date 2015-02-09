using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;
    using Microsoft.WindowsAzure.Commands.Common.Storage;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.WindowsAzure.Storage.File;

    [Cmdlet(VerbsCommon.New, StorageNouns.ShareSas), OutputType(typeof(String))]
    public class NewAzureStorageShareSasToken : AzureStorageFileCmdletBase
    {
        [Parameter(
            ValueFromPipeline = true,
            HelpMessage = "Azure Storage Context Object")]
        public override AzureStorageContext Context { get; set; }

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

        [Parameter(HelpMessage = "Policy Identifier", ParameterSetName = SasPolicyParmeterSet)]
        public string Policy
        {
            get { return accessPolicyIdentifier; }
            set { accessPolicyIdentifier = value; }
        }
        private string accessPolicyIdentifier;

        [Parameter(HelpMessage = "Permissions for a container. Permissions can be any not-empty subset of \"rwdl\".",
            ParameterSetName = SasPermissionParameterSet)]
        public string Permission { get; set; }

        [Parameter(HelpMessage = "Start Time")]
        public DateTime? StartTime { get; set; }

        [Parameter(HelpMessage = "Expiry Time")]
        public DateTime? ExpiryTime { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Display full uri with sas token")]
        public SwitchParameter FullUri { get; set; }

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
            bool shouldSetExpiryTime = SasTokenHelper.ValidateShareAccessPolicy(Channel, this.ShareName, accessPolicy, accessPolicyIdentifier);
            SetupAccessPolicy(accessPolicy, shouldSetExpiryTime);
            string sasToken = fileShare.GetSharedAccessSignature(accessPolicy, accessPolicyIdentifier);

            if (FullUri)
            {
                string fullUri = fileShare.Uri.ToString() + sasToken;
                WriteObject(fullUri);
            }
            else
            {
                WriteObject(sasToken);
            }
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
            permission = permission.ToLower();
            policy.Permissions = SharedAccessFilePolicy.PermissionsFromString(permission);
        }
    }
}

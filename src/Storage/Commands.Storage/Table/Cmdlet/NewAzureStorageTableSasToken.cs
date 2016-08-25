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

namespace Microsoft.WindowsAzure.Commands.Storage.Table.Cmdlet
{
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;

    [Cmdlet(VerbsCommon.New, StorageNouns.TableSas), OutputType(typeof(String))]
    public class NewAzureStorageTableSasTokenCommand : StorageCloudTableCmdletBase
    {
        /// <summary>
        /// Sas permission parameter set name
        /// </summary>
        private const string SasPermissionParameterSet = "SasPermission";

        /// <summary>
        /// Sas policy paremeter set name
        /// </summary>
        private const string SasPolicyParmeterSet = "SasPolicy";

        [Alias("N", "Table")]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Table Name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Policy Identifier", ParameterSetName = SasPolicyParmeterSet)]
        [ValidateNotNullOrEmpty]
        public string Policy
        {
            get { return accessPolicyIdentifier; }
            set { accessPolicyIdentifier = value; }
        }

        private string accessPolicyIdentifier;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Permissions for a container. Permissions can be any not-empty subset of \"audq\".",
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

        [Alias("startpk")]
        [Parameter(HelpMessage = "Start Partition Key")]
        public string StartPartitionKey { get; set; }

        [Alias("startrk")]
        [Parameter(HelpMessage = "Start Row Key")]
        public string StartRowKey { get; set; }

        [Alias("endpk")]
        [Parameter(HelpMessage = "End Partition Key")]
        public string EndPartitionKey { get; set; }

        [Alias("endrk")]
        [Parameter(HelpMessage = "End Row Key")]
        public string EndRowKey { get; set; }

        // Override the useless parameters
        public override int? ServerTimeoutPerRequest { get; set; }

        public override int? ClientTimeoutPerRequest { get; set; }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageTableSasCommand class.
        /// </summary>
        public NewAzureStorageTableSasTokenCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageTableSasCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public NewAzureStorageTableSasTokenCommand(IStorageTableManagement channel)
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
            CloudTable table = Channel.GetTableReference(Name);
            SharedAccessTablePolicy policy = new SharedAccessTablePolicy();
            bool shouldSetExpiryTime = SasTokenHelper.ValidateTableAccessPolicy(Channel, table.Name, policy, accessPolicyIdentifier);
            SetupAccessPolicy(policy, shouldSetExpiryTime);
            ValidatePkAndRk(StartPartitionKey, StartRowKey, EndPartitionKey, EndRowKey);
            string sasToken = table.GetSharedAccessSignature(policy, accessPolicyIdentifier, StartPartitionKey,
                                StartRowKey, EndPartitionKey, EndRowKey, Protocol, Util.SetupIPAddressOrRangeForSAS(IPAddressOrRange));

            if (FullUri)
            {
                string fullUri = table.Uri.ToString() + sasToken;
                WriteObject(fullUri);
            }
            else
            {
                WriteObject(sasToken);
            }
        }

        /// <summary>
        /// Validate the combination of PartitionKey and RowKey
        /// </summary>
        /// <param name="startPartitionKey"></param>
        /// <param name="startRowKey"></param>
        /// <param name="endPartitionKey"></param>
        /// <param name="endRowKey"></param>
        private void ValidatePkAndRk(string startPartitionKey, string startRowKey, string endPartitionKey, string endRowKey)
        {
            if (!string.IsNullOrEmpty(startRowKey) && string.IsNullOrEmpty(startPartitionKey))
            {
                throw new ArgumentException(Resources.StartpkMustAccomanyStartrk);
            }

            if (!string.IsNullOrEmpty(endRowKey) && string.IsNullOrEmpty(endPartitionKey))
            {
                throw new ArgumentException(Resources.EndpkMustAccomanyEndrk);
            }
        }

        /// <summary>
        /// Update the access policy
        /// </summary>
        /// <param name="policy">Access policy object</param>
        /// <param name="shouldSetExpiryTime">Should set the default expiry time</param>
        private void SetupAccessPolicy(SharedAccessTablePolicy policy, bool shouldSetExpiryTime)
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

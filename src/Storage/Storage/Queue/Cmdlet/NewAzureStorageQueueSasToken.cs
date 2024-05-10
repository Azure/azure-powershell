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

namespace Microsoft.WindowsAzure.Commands.Storage.Queue.Cmdlet
{
    using global::Azure.Storage.Queues;
    using global::Azure.Storage.Queues.Models;
    using global::Azure.Storage.Sas;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

    [Cmdlet("New", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageQueueSASToken"), OutputType(typeof(String))]
    public class NewAzureStorageQueueSasTokenCommand : StorageQueueBaseCmdlet
    {
        /// <summary>
        /// Sas permission parameter set name
        /// </summary>
        private const string SasPermissionParameterSet = "SasPermission";

        /// <summary>
        /// Sas policy paremeter set name
        /// </summary>
        private const string SasPolicyParmeterSet = "SasPolicy";

        [Alias("N", "Queue")]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Queue Name",
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
            HelpMessage = "Permissions for a queue. Permissions can be any not-empty subset of \"raup\".",
            ParameterSetName = SasPermissionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Permission { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Protocol can be used in the request with this SAS token.")]
        [ValidateSet("HttpsOnly", "HttpsOrHttp", IgnoreCase = true),]
        public string Protocol { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "IP, or IP range ACL (access control list) that the request would be accepted from by Azure Storage.")]
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

        //Override the useless parameters
        public override int? ServerTimeoutPerRequest { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageQueueSasCommand class.
        /// </summary>
        public NewAzureStorageQueueSasTokenCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageQueueSasCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public NewAzureStorageQueueSasTokenCommand(IStorageQueueManagement channel)
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

            QueueClient queueClient = Util.GetTrack2QueueClient(this.Name, (AzureStorageContext)this.Context, this.ClientOptions);
            QueueSignedIdentifier identifier = null;
            if (!string.IsNullOrEmpty(this.Policy))
            {
                identifier = SasTokenHelper.GetQueueSignedIdentifier(queueClient, this.Policy, CmdletCancellationToken);
            }

            QueueSasBuilder sasBuilder = SasTokenHelper.SetQueueSasbuilder(queueClient, identifier, this.Permission, this.StartTime, this.ExpiryTime, this.IPAddressOrRange, this.Protocol);
            string sasToken = SasTokenHelper.GetQueueSharedAccessSignature((AzureStorageContext)this.Context, sasBuilder, CmdletCancellationToken);

            // remove prefix "?" of SAS if any
            sasToken = Util.GetSASStringWithoutQuestionMark(sasToken);

            if (FullUri)
            {
                string fullUri = SasTokenHelper.GetFullUriWithSASToken(queueClient.Uri.AbsoluteUri.ToString(), sasToken);
                WriteObject(fullUri);
            }
            else
            {
                WriteObject(sasToken);
            }
        }
    }
}

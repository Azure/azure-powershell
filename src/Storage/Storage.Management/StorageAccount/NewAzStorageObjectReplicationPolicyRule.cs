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

using Microsoft.Azure.Commands.Management.Storage.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageObjectReplicationPolicyRule"), OutputType(typeof(PSObjectReplicationPolicyRule))]
    public class NewAzureStorageAccountObjectReplicationPolicyRuleCommand : StorageAccountBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           HelpMessage = "The Source Container name to replicate from.")]
        [ValidateNotNullOrEmpty]
        public string SourceContainer { get; set; }

        [Parameter(
           Mandatory = true,
           HelpMessage = "The Destination Container name to replicate to.")]
        [ValidateNotNullOrEmpty]
        public string DestinationContainer { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Filters the results to replicate only blobs whose names begin with the specified prefix.")]
        [ValidateNotNullOrEmpty]
        public string[] PrefixMatch { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Blobs created after the time will be replicated to the destination..")]
        [ValidateNotNull]
        public DateTime MinCreationTime
        {
            get
            {
                return minCreationTime is null ? DateTime.MinValue : minCreationTime.Value;
            }
            set
            {
                minCreationTime = value;
            }
        }
        private DateTime? minCreationTime;

        [Parameter(Mandatory = false,
            HelpMessage = "Object Replication Rule Id.")]
        public string RuleId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            string[] blobType = new string[] { AzureBlobType.BlockBlob };
            PSObjectReplicationPolicyRule rule = new PSObjectReplicationPolicyRule()
            {
                RuleId = this.RuleId,
                SourceContainer = this.SourceContainer,
                DestinationContainer = this.DestinationContainer
            };

            if (this.PrefixMatch != null || minCreationTime != null)
            {
                rule.Filters = new PSObjectReplicationPolicyFilter()
                {
                    PrefixMatch = this.PrefixMatch,
                    MinCreationTime = this.minCreationTime,
                };
            }

            WriteObject(rule);
        }
    }
}

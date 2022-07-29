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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageAccountManagementPolicyFilter"), OutputType(typeof(PSManagementPolicyRuleFilter))]
    public class NewAzureStorageAccountManagementPolicyFilterCommand : StorageAccountBaseCmdlet
    {
        /// <summary>
        /// block blob type
        /// </summary>
        private const string BlockBlobType = "Block";

        /// <summary>
        /// append blob type
        /// </summary>
        private const string AppendBlobType = "Append";

        [Parameter(Mandatory = false,
            HelpMessage = "An array of strings for prefixes to be match. A prefix string must start with a container name.")]
        [ValidateNotNullOrEmpty]
        public string[] PrefixMatch { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "An array of strings for blobtypes to be match. Currently blockBlob supports all tiering and delete actions. Only delete actions are supported for appendBlob.")]
        [ValidateSet(AzureBlobType.BlockBlob, AzureBlobType.AppendBlob, IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string[] BlobType { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "An array of blob index tag based filters, there can be at most 10 tag filters.")]
        [ValidateNotNullOrEmpty]
        public PSTagFilter[] BlobIndexMatch { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            string[] blobType = new string[] { AzureBlobType.BlockBlob };

            if (this.BlobType != null)
            {
                blobType = new string[this.BlobType.Length];
                for (int i=0;i< this.BlobType.Length; i++)
                {

                    if (this.BlobType[i].ToLower() == AzureBlobType.AppendBlob.ToLower())
                    {
                        blobType[i] = AzureBlobType.AppendBlob;
                    }
                    else
                    {
                        blobType[i] = AzureBlobType.BlockBlob;
                    }
                }
            }

            PSManagementPolicyRuleFilter filter = new PSManagementPolicyRuleFilter()
            {
                BlobTypes = blobType,
                PrefixMatch = this.PrefixMatch,
                BlobIndexMatch = this.BlobIndexMatch,
            };

            WriteObject(filter);
        }
    }
}

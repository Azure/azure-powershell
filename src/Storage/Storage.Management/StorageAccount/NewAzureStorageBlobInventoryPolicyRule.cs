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
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Management.Automation;
using StorageModels = Microsoft.Azure.Management.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageBlobInventoryPolicyRule"), OutputType(typeof(PSBlobInventoryPolicyRule))]
    public class NewAzureStorageBlobInventoryPolicyRuleCommand : StorageAccountBaseCmdlet
    {
        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within a policy.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The rule is disabled if set it.")]
        public SwitchParameter Disabled { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Sets the blob types for the blob inventory policy rule. Valid values include blockBlob, appendBlob, pageBlob. Hns accounts does not support pageBlobs.")]
        [ValidateSet(AzureBlobType.BlockBlob,
            AzureBlobType.PageBlob,
            AzureBlobType.AppendBlob,
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string[] BlobType { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Sets an array of strings for blob prefixes to be matched..")]
        [ValidateNotNullOrEmpty]
        public string[] PrefixMatch { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The rule is disabled if set it.")]
        public SwitchParameter IncludeSnapshot { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The rule is disabled if set it.")]
        public SwitchParameter IncludeBlobVersion { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (this.BlobType != null)
            {
                for (int i = 0; i < this.BlobType.Length; i++)
                {
                    if(this.BlobType[i].ToLower() == AzureBlobType.BlockBlob.ToLower())
                    {
                        this.BlobType[i] = AzureBlobType.BlockBlob;
                    }
                    else if (this.BlobType[i].ToLower() == AzureBlobType.AppendBlob.ToLower())
                    {
                        this.BlobType[i] = AzureBlobType.AppendBlob;
                    }
                    else if (this.BlobType[i].ToLower() == AzureBlobType.PageBlob.ToLower())
                    {
                        this.BlobType[i] = AzureBlobType.PageBlob;
                    }
                }
            }

            PSBlobInventoryPolicyRule rule = new PSBlobInventoryPolicyRule()
            {
                Name = this.Name,
                Enabled = Disabled.IsPresent ? false : true,
                Definition = new PSBlobInventoryPolicyDefinition()
                {
                    Filters = new PSBlobInventoryPolicyFilter()
                    {
                        BlobTypes = this.BlobType,
                        PrefixMatch = this.PrefixMatch,
                        IncludeBlobVersions = this.IncludeBlobVersion.IsPresent,
                        IncludeSnapshots = this.IncludeSnapshot.IsPresent
                    }
                }
            };

            WriteObject(rule);
        }
    }
}

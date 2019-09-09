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
        [Parameter(Mandatory = false,
            HelpMessage = "An array of strings for prefixes to be match. A prefix string must start with a container name.")]
        [ValidateNotNullOrEmpty]
        public string[] PrefixMatch { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            string[] blobType = new string[] { AzureBlobType.BlockBlob };
            PSManagementPolicyRuleFilter filter = new PSManagementPolicyRuleFilter()
            {
                BlobTypes = blobType,
                PrefixMatch = this.PrefixMatch,
            };

            WriteObject(filter);
        }
    }
}

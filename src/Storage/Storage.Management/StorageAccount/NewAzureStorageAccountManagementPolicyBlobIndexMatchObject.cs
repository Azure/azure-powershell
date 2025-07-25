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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageAccountManagementPolicyBlobIndexMatchObject"), OutputType(typeof(PSTagFilter))]
    public class NewAzureStorageAccountManagementPolicyBlobIndexMatchObjectCommand : StorageAccountBaseCmdlet
    {

        [Parameter(Mandatory = false,
            HelpMessage = "Gets or sets this is the filter tag name, it can have 1 - 128 characters")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Gets or sets this is the filter tag value field used for tag based filtering, it can have 0 - 256 characters.")]
        [ValidateNotNullOrEmpty]
        public string Value { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            PSTagFilter tagFilter = new PSTagFilter()
            {
                Name = this.Name,
                Op = "==",
                Value = this.Value,
            };

            WriteObject(tagFilter);
        }
    }
}

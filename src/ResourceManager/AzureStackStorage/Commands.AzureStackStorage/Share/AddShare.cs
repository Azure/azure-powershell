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

using System.Linq;
using System.Management.Automation;
using Microsoft.AzureStack.AzureConsistentStorage;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{

    /// <summary>
    /// Add a share
    /// </summary>
    [Cmdlet(VerbsCommon.Add, Nouns.AdminShare)]
    public sealed class AddShare : AdminCmdlet
    {
        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Farm Identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string FarmName
        {
            get;
            set;
        }

        /// <summary>
        /// The share name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ShareName
        {
            get;
            set;
        }

        protected override void Execute()
        {
            var share = Client.Shares.Put(ResourceGroupName, FarmName, ShareName);

            WriteObject(new ShareResponse(share.Share));
        }
    }
}
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

using Microsoft.Azure.Commands.Batch.Properties;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Get, "AzureBatchAccountKeys"), OutputType(typeof(BatchAccountContext))]
    public class GetBatchAccountKeysCommand : BatchCmdletBase
    {
        internal const string ParameterSetContext = "Use Context";
        internal const string ParameterSetNames = "Use Names";

        [Parameter(ParameterSetName = ParameterSetNames, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the Batch service account to query keys for.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group of the account.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Get the keys associated with the specified account. If only the account name is passed in, then
        /// look up its resource group and construct a new BatchAccountContext to hold everything.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            BatchAccountContext context = BatchClient.ListKeys(this.ResourceGroupName, this.AccountName);
            WriteObject(context);
        }
    }
}

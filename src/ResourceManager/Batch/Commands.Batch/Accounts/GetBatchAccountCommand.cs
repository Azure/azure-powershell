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
using Microsoft.Azure.Management.Batch.Models;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Get, "AzureBatchAccount"), OutputType(typeof(BatchAccountContext))]
    public class GetBatchAccountCommand : BatchCmdletBase
    {
        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the Batch service account name to query.")]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group associated with the account being queried.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Filter list of accounts using the key and optional value of the specified tag.")]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(this.AccountName))
            {
                foreach (BatchAccountContext context in BatchClient.ListAccounts(this.ResourceGroupName, Tag))
                {
                    WriteObject(context);
                }
            }
            else
            {
                BatchAccountContext context = BatchClient.GetAccount(this.ResourceGroupName, this.AccountName);
                WriteObject(context);
            }
        }
    }
}

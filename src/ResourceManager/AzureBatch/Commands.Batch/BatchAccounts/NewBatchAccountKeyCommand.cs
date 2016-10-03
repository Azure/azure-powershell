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

using Microsoft.Azure.Management.Batch.Models;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.New, Constants.AzureRmBatchAccountKey), OutputType(typeof(BatchAccountContext))]
    public class RegenBatchAccountKeyCommand : BatchCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the Batch service account to regenerate the specified key for.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string ResourceGroupName { get; set; }

        private AccountKeyType keyType;
        [Parameter(Mandatory = true, ValueFromPipeline = false,
            HelpMessage = "The type of key (primary or secondary) to regenerate.")]
        [ValidateSet("Primary", "Secondary")]
        public string KeyType
        {
            get { return keyType.ToString(); }
            set
            {
                if (value == "Primary")
                {
                    keyType = AccountKeyType.Primary;
                }
                else if (value == "Secondary")
                {
                    keyType = AccountKeyType.Secondary;
                }
            }
        }

        public override void ExecuteCmdlet()
        {
            BatchAccountContext context = BatchClient.RegenerateKeys(this.ResourceGroupName, this.AccountName, this.keyType);
            WriteObject(context);
        }
    }
}

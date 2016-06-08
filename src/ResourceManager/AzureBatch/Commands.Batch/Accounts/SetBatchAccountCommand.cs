﻿// ----------------------------------------------------------------------------------
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

using System.Collections;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Set, Constants.AzureRmBatchAccount), OutputType(typeof(BatchAccountContext))]
    public class SetBatchAccountCommand : BatchCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the Batch service account to update.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Alias("Tags")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
            HelpMessage = "An array of hashtables which represents the tags to set on the account.")]
        public Hashtable[] Tag { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string AutoStorageAccountId { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteWarning("WARNING: The usage of the Tag parameter in this cmdlet will be modified in a future release. This will impact creating, updating and appending tags " +
                "for Azure resources. For more details about the change, please visit https://github.com/Azure/azure-powershell/issues/726#issuecomment-213545494 ");

            BatchAccountContext context = BatchClient.UpdateAccount(this.ResourceGroupName, this.AccountName, this.Tag, this.AutoStorageAccountId);
            WriteObject(context);
        }
    }
}

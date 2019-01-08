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

using Microsoft.Azure.Commands.Batch.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BatchAccount", SupportsShouldProcess = true), OutputType(typeof(void))]
    public class RemoveBatchAccountCommand : BatchCmdletBase
    {
        private static string mamlCall = "RemoveAccount";

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the Batch service account to remove.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemoveAccountConfirm, this.AccountName),
                Resources.RemoveBatchAccount,
                this.AccountName,
                () => DeleteAction(this.ResourceGroupName, this.AccountName));
        }

        private void DeleteAction(string resGroupName, string accountName)
        {
            WriteVerboseWithTimestamp(Resources.BeginMAMLCall, mamlCall);
            BatchClient.DeleteAccount(resGroupName, accountName);
            WriteVerboseWithTimestamp(Resources.EndMAMLCall, mamlCall);
        }
    }
}

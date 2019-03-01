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

using System;
using System.Management.Automation;

using Microsoft.Azure.Commands.Batch.Models;

using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BatchApplication")]
    [OutputType(typeof(PSApplication))]
    public class NewBatchApplicationCommand : BatchCmdletBase
    {
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, Mandatory = true,
            HelpMessage = "Specifies the name of the Batch account.")]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Specifies the name of the resource group that contains the Batch account.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Specifies the name of the application.")]
        [ValidateNotNullOrEmpty]
        [Alias("ApplicationId")]
        public string ApplicationName { get; set; }

        [Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public bool? AllowUpdates { get; set; }

        [Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        protected override void ExecuteCmdletImpl()
        {
            PSApplication response = BatchClient.AddApplication(this.ResourceGroupName, this.AccountName, this.ApplicationName, this.AllowUpdates, this.DisplayName);
            WriteObject(response);
        }
    }
}

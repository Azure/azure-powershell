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

using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Anf.Common;
using Microsoft.Azure.Commands.Anf.Models;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Azure.Commands.Anf.Helpers;

namespace Microsoft.Azure.Commands.Anf.Account
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AnfAccount"), OutputType(typeof(PSAnfAccount))]
    public class NewAzureRmAnfAccount : AzureAnfCmdletBase
    {
        [Parameter(
            Mandatory = true
            , HelpMessage = "The resource group of the ANF account")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The location of the resource")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Tags for the resource")]
        [ValidateNotNullOrEmpty]
        public string Tags { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the ANF account")]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        public override void ExecuteCmdlet()
        {
            var netAppAccountBody = new NetAppAccount()
            {
                Location = Location,
                Tags = Tags
            };

            var anfAccount = AzureNetAppFilesManagementClient.Accounts.CreateOrUpdate(netAppAccountBody, ResourceGroupName, AccountName);
            WriteObject(anfAccount.ToPsAnfAccount());
        }
    }
}

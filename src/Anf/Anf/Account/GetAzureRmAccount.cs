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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Anf.Common;
using Microsoft.Azure.Commands.Anf.Helpers;
using Microsoft.Azure.Commands.Anf.Models;
using Microsoft.Azure.Management.NetApp;
using System.Linq;

namespace Microsoft.Azure.Commands.Anf.Account
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AnfAccount"), OutputType(typeof(PSAnfAccount))]
    public class GetAzureRmAnfAccount : AzureAnfCmdletBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group of the ANF account",
            ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the ANF account",
            ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource id of the ANF account",
            ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ResourceIdParameterSet)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                AccountName = resourceIdentifier.ResourceName;
            }

            if (AccountName != null)
            {
                var anfAccount = AzureNetAppFilesManagementClient.Accounts.Get(ResourceGroupName, AccountName);
                WriteObject(anfAccount.ToPsAnfAccount());
            }
            else
            {
                var anfAccount = AzureNetAppFilesManagementClient.Accounts.List(ResourceGroupName).Select(e => e.ToPsAnfAccount());
                WriteObject(anfAccount, true);
            }
        }
    }
}

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

using Microsoft.Azure.Commands.Management.CognitiveServices.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    /// <summary>
    /// Get Cognitive Services Account by name, all accounts under resource group or all accounts under the subscription
    /// </summary>
    [Cmdlet(VerbsCommon.Get, CognitiveServicesAccountNounStr), OutputType(typeof(PSCognitiveServicesAccount))]
    public class GetAzureCognitiveServicesAccountCommand : CognitiveServicesAccountBaseCmdlet
    {
        protected const string ResourceGroupParameterSet = "ResourceGroupParameterSet";
        protected const string AccountNameParameterSet = "AccountNameParameterSet";

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = ResourceGroupParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = AccountNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AccountNameParameterSet,
            HelpMessage = "Cognitive Services Account Name.")]
        [Alias(CognitiveServicesAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                if (string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    var cognitiveServicesAccounts = GetWithPaging(this.CognitiveServicesClient.Accounts.List(), false);

                    WriteCognitiveServicesAccountList(cognitiveServicesAccounts);
                }
                else if (string.IsNullOrEmpty(this.Name))
                {
                    var cognitiveServicesAccounts = GetWithPaging(this.CognitiveServicesClient.Accounts.ListByResourceGroup(this.ResourceGroupName), true);
                    if (cognitiveServicesAccounts == null)
                    {
                        WriteWarningWithTimestamp("Received empty accounts list");
                    }
                    WriteCognitiveServicesAccountList(cognitiveServicesAccounts);
                }
                else
                {
                    var cognitiveServicesAccount = this.CognitiveServicesClient.Accounts.GetProperties(
                        this.ResourceGroupName,
                        this.Name);

                    WriteCognitiveServicesAccount(cognitiveServicesAccount);
                }
            });
        }

        private IEnumerable<CognitiveServicesAccount> GetWithPaging(IPage<CognitiveServicesAccount> firstPage, bool isResourceGroup)
        {
            var cognitiveServicesAccounts = new List<CognitiveServicesAccount>(firstPage);
            IPage<CognitiveServicesAccount> nextPage = null;
            for (var nextLink = firstPage.NextPageLink; !string.IsNullOrEmpty(nextLink); nextLink = nextPage.NextPageLink)
            {
                if (isResourceGroup)
                {
                    nextPage = this.CognitiveServicesClient.Accounts.ListByResourceGroupNext(nextLink);
                }
                else
                {
                    nextPage = this.CognitiveServicesClient.Accounts.ListNext(nextLink);
                }

                cognitiveServicesAccounts.AddRange(nextPage);
            }

            return cognitiveServicesAccounts;
        }
    }
}

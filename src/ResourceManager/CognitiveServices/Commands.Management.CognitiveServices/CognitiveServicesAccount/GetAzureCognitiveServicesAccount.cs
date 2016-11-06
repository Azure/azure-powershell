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
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using System.Globalization;
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
                    var cognitiveServicesAccounts = this.CognitiveServicesClient.CognitiveServicesAccounts.List();

                    WriteCognitiveServicesAccountList(cognitiveServicesAccounts);
                }
                else if (string.IsNullOrEmpty(this.Name))
                {
                    var cognitiveServicesAccounts = this.CognitiveServicesClient.CognitiveServicesAccounts.ListByResourceGroup(this.ResourceGroupName);
                    if (cognitiveServicesAccounts == null)
                    {
                        WriteWarningWithTimestamp("Received empty accounts list");
                    }
                    WriteCognitiveServicesAccountList(cognitiveServicesAccounts);
                }
                else
                {
                    var cognitiveServicesAccount = this.CognitiveServicesClient.CognitiveServicesAccounts.GetProperties(
                        this.ResourceGroupName,
                        this.Name);

                    WriteCognitiveServicesAccount(cognitiveServicesAccount);
                }
            });
        }
    }
}

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

using Microsoft.Azure.Commands.Management.CognitiveServices.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CognitiveServices;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    /// <summary>
    /// Delete a Cognitive Services.
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CognitiveServicesAccount", DefaultParameterSetName = AccountParameterSet, SupportsShouldProcess = true), OutputType(typeof(void))]
    public class RemoveAzureCognitiveServicesAccountCommand : CognitiveServicesAccountBaseCmdlet
    {
        protected const string AccountParameterSet = "AccountParameterSet";
        protected const string DeletedAccountParameterSet = "DeletedAccountParameterSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = AccountParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = DeletedAccountParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = AccountParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Name.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = DeletedAccountParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Name.")]
        [Alias(CognitiveServicesAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = DeletedAccountParameterSet,
            HelpMessage = "Specifies whether to only show the deleted accounts in the output.")]
        public SwitchParameter InRemovedState { get; set; }

        [Parameter(
            Position = 2,
            ParameterSetName = DeletedAccountParameterSet,
            Mandatory = true,
            HelpMessage = "Cognitive Services Account Location.")]
        [LocationCompleter("Microsoft.CognitiveServices/accounts")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(
                this.Name, string.Format(CultureInfo.CurrentCulture, Resources.RemoveAccount_ProcessMessage, this.Name))
                ||
                Force.IsPresent)
            {
                RunCmdLet(() =>
                {
                    switch (ParameterSetName)
                    {
                        case DeletedAccountParameterSet:
                            this.CognitiveServicesClient.DeletedAccounts.Purge(this.Location, this.ResourceGroupName, this.Name);
                            break;
                        default:
                            this.CognitiveServicesClient.Accounts.Delete(this.ResourceGroupName, this.Name);
                            break;
                    }
                });
            }
        }
    }
}

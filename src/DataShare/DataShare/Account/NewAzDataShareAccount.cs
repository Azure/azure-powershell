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

namespace Microsoft.Azure.Commands.DataShare.Account
{
    using System.Collections;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.DataShare.Common;
    using Microsoft.Azure.Commands.DataShare.Helpers;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Management.DataShare.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models;

    /// <summary>
    /// Defines the New-DataShareAccount cmdlet.
    /// </summary>
    [Cmdlet(
         "New",
         ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShareAccount",
         DefaultParameterSetName = ParameterSetNames.FieldsParameterSet,
         SupportsShouldProcess = true), OutputType(typeof(PSAccount))]
    public class NewAzDataShareAccount : AzureDataShareCmdletBase
    {
        /// <summary>
        /// The resource group name of the azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name of the azure data share account will be created in.")]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Azure data share account name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Azure data share account name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// The location in which to create the azure data share account.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The location in which to create the data share account.")]
        [LocationCompleter("Microsoft.DataShare/accounts")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// The tags to associate with the azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "The tags to associate with the azure data share account.")]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            this.ConfirmAction(
                this.MyInvocation.InvocationName,
                this.Name,
                this.NewAccount);
        }

        private void NewAccount()
        {
            if (this.ShouldProcess(this.Name, VerbsCommon.New))
            {
                Account dataShareAccount = this.DataShareManagementClient.Accounts.Create(
                    this.ResourceGroupName,
                    this.Name,
                    new Account()
                    {
                        Location = this.Location, Tags = this.Tag?.ToDictionaryTags(),
                        Identity = new Identity
                        {
                            Type = "SystemAssigned"
                        }
                    });

                this.WriteObject(dataShareAccount.ToPsObject());
            }
        }
    }
}
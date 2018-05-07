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

using Microsoft.Azure.Management.LocationBasedServices;
using Microsoft.Azure.Management.LocationBasedServices.Models;
using Microsoft.Azure.Commands.LocationBasedServices.Properties;
using System.Collections;
using System.Globalization;
using System.Management.Automation;
using LocationBasedServicesModels = Microsoft.Azure.Commands.LocationBasedServices.Models;

namespace Microsoft.Azure.Commands.LocationBasedServices
{
    /// <summary>
    /// Create a new Location Based Services Account, specify it's type (resource kind)
    /// </summary>
    [Cmdlet(VerbsCommon.New, LocationBasedServicesAccountNounStr, SupportsShouldProcess = true), OutputType(typeof(LocationBasedServicesModels.PSLocationBasedServicesAccount))]
    public class NewAzureLocationBasedServicesAccountCommand : LocationBasedServicesAccountBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Location Based Services Account Name.")]
        [Alias(LocationBasedServicesAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("^[a-zA-Z0-9][a-zA-Z0-9_.-]*$")]
        [ValidateLength(2, 64)]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Location Based Services Account Sku Name.")]
        [ValidateSet("S0")]
        public string SkuName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Location Based Services Account Tags.")]
        [Alias(TagsAlias)]
        [ValidateNotNull]
        [AllowEmptyCollection]
        public Hashtable[] Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                LocationBasedServicesAccountCreateParameters createParameters = new LocationBasedServicesAccountCreateParameters()
                {
                    Sku = new Sku(this.SkuName),
                    Tags = TagsConversionHelper.CreateTagDictionary(Tag),
                    Location = "global"
                };

                if (ShouldProcess(
                    this.Name, string.Format(CultureInfo.CurrentCulture, Resources.NewAccount_ProcessMessage, this.Name, this.SkuName)))
                {
                    if (Force.IsPresent)
                    {
                        WriteWarning(Resources.NewAccount_Notice);
                    }
                    else
                    {
                        bool yesToAll = false, noToAll = false;
                        if (!ShouldContinue(Resources.NewAccount_Notice, "Notice", true, ref yesToAll, ref noToAll))
                        {
                            return;
                        }
                    }

                    var createAccountResponse = this.LocationBasedServicesClient.Accounts.CreateOrUpdate(
                                    this.ResourceGroupName,
                                    this.Name,
                                    createParameters);

                    var locationBasedServicesAccount = this.LocationBasedServicesClient.Accounts.Get(this.ResourceGroupName, this.Name);

                    this.WriteLocationBasedServicesAccount(locationBasedServicesAccount);
                }
            });
        }
    }
}

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

using System.Collections;
using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Commands.Maps.Properties;
using Microsoft.Azure.Management.Maps;
using Microsoft.Azure.Management.Maps.Models;
using Microsoft.Azure.Commands.Maps.Models;

namespace Microsoft.Azure.Commands.Maps.MapsAccount
{
    /// <summary>
    /// Create a new Maps Account, specify it's type (resource kind)
    /// </summary>
    [Cmdlet(VerbsCommon.New, MapsAccountNounStr, SupportsShouldProcess = true), OutputType(typeof(PSMapsAccount))]
    public class NewAzureMapsAccount : MapsAccountBaseCmdlet
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
            HelpMessage = "Maps Account Name.")]
        [Alias(MapsAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("^[a-zA-Z0-9][a-zA-Z0-9_.-]*$")]
        [ValidateLength(2, 64)]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Maps Account Sku Name.")]
        [ValidateSet("S0")]
        public string SkuName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Maps Account Tags.")]
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
                MapsAccountCreateParameters createParameters = new MapsAccountCreateParameters()
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

                    var createAccountResponse = this.MapsClient.Accounts.CreateOrUpdate(
                                    this.ResourceGroupName,
                                    this.Name,
                                    createParameters);

                    var mapsAccount = this.MapsClient.Accounts.Get(this.ResourceGroupName, this.Name);

                    this.WriteMapsAccount(mapsAccount);
                }
            });
        }
    }
}

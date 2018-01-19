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
using Microsoft.Azure.Management.CognitiveServices.Models;
using System.Collections;
using System.Globalization;
using System.Management.Automation;
using CognitiveServicesModels = Microsoft.Azure.Commands.Management.CognitiveServices.Models;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    /// <summary>
    /// Create a new Cognitive Services Account, specify it's type (resource kind)
    /// </summary>
    [Cmdlet(VerbsCommon.New, CognitiveServicesAccountNounStr, SupportsShouldProcess = true), OutputType(typeof(CognitiveServicesModels.PSCognitiveServicesAccount))]
    public class NewAzureCognitiveServicesAccountCommand : CognitiveServicesAccountBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Name.")]
        [Alias(CognitiveServicesAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("^[a-zA-Z0-9][a-zA-Z0-9_.-]*$")]
        [ValidateLength(2, 64)]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Type.")]
        [Alias(CognitiveServicesAccountTypeAlias, AccountTypeAlias, KindAlias)]
        public string Type { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Sku Name.")]
        public string SkuName { get; set; }

        [Parameter(
            Position = 4,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Location.")]
        [LocationCompleter("Microsoft.CognitiveServices/accounts")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Cognitive Services Account Tags.")]
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
                CognitiveServicesAccountCreateParameters createParameters = new CognitiveServicesAccountCreateParameters()
                {
                    Location = this.Location,
                    Kind = this.Type, // must have value, mandatory parameter
                    Sku = new Sku(this.SkuName),
                    Tags = TagsConversionHelper.CreateTagDictionary(Tag),
                    Properties = new object(), // Must not be null according to Azure RM spec. Also there is no actual properties to pass, so not exposing it through cmdlet
                };

                if (ShouldProcess(
                    this.Name, string.Format(CultureInfo.CurrentCulture, Resources.NewAccount_ProcessMessage, this.Name, this.Type, this.SkuName, this.Location)))
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

                    var createAccountResponse = this.CognitiveServicesClient.Accounts.Create(
                                    this.ResourceGroupName,
                                    this.Name,
                                    createParameters);

                    var cognitiveServicesAccount = this.CognitiveServicesClient.Accounts.GetProperties(this.ResourceGroupName, this.Name);

                    this.WriteCognitiveServicesAccount(cognitiveServicesAccount);
                }
            });
        }
    }
}

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

using Microsoft.Azure.Commands.Management.CognitiveServices.ArgumentCompleters;
using Microsoft.Azure.Commands.Management.CognitiveServices.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Globalization;
using System.Management.Automation;
using CognitiveServicesModels = Microsoft.Azure.Commands.Management.CognitiveServices.Models;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    /// <summary>
    /// Create a new Cognitive Services Account, specify it's type (resource kind)
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CognitiveServicesAccount", SupportsShouldProcess = true), OutputType(typeof(CognitiveServicesModels.PSCognitiveServicesAccount))]
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
        [AccountTypeCompleter()]
        public string Type { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Sku Name.")]
        [AccountSkuCompleter()]
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

        [Parameter(
            Mandatory = false,
            HelpMessage = "Cognitive Services Account Subdomain Name.")]
        [ValidateNotNull]
        [AllowEmptyCollection]
        public string CustomSubdomainName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                CognitiveServicesAccountCreateParameters createParameters = new CognitiveServicesAccountCreateParameters()
                {
                    Location = Location,
                    Kind = Type, // must have value, mandatory parameter
                    Sku = new Sku(SkuName),
                    Tags = TagsConversionHelper.CreateTagDictionary(Tag),
                    Properties = string.IsNullOrWhiteSpace(CustomSubdomainName) ?
                        new object():
                        JToken.Parse(string.Format(
                            CultureInfo.InvariantCulture,
                            "{{\"customSubDomainName\":\"{0}\"}}",
                            CustomSubdomainName))
                };

                if (ShouldProcess(
                    Name, string.Format(CultureInfo.CurrentCulture, Resources.NewAccount_ProcessMessage, Name, Type, SkuName, Location)))
                {
                    if (Type.StartsWith("Bing.", StringComparison.InvariantCultureIgnoreCase))
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
                    }
                    try
                    {
                        CognitiveServicesAccount createAccountResponse = CognitiveServicesClient.Accounts.Create(
                                        ResourceGroupName,
                                        Name,
                                        createParameters);
                    }
                    catch (Exception ex)
                    {
                        // Give users a specific message says `Failed to create Cognitive Services account.`
                        // Details should able be found in the exception.
                        throw new Exception("Failed to create Cognitive Services account.", ex);
                    }

                    CognitiveServicesAccount cognitiveServicesAccount = CognitiveServicesClient.Accounts.GetProperties(ResourceGroupName, Name);
                    WriteCognitiveServicesAccount(cognitiveServicesAccount);
                }
            });
        }
    }
}

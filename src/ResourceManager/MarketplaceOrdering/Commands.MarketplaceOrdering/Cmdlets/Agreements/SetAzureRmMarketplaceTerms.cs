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
using Microsoft.Azure.Commands.MarketplaceOrdering.Common;
using Microsoft.Azure.Commands.MarketplaceOrdering.Models;
using Microsoft.Azure.Management.MarketplaceOrdering;

namespace Microsoft.Azure.Commands.MarketplaceOrdering.Cmdlets.Agreements
{
    [Cmdlet(VerbsCommon.Set, "AzureRmMarketplaceTerms", DefaultParameterSetName = Constants.ParameterSetNames.AgreementAcceptParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSAgreementTerms))]
    public class SetAzureRmMarketplaceTerms : AzureMarketplaceOrderingCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Publisher identifier string of image being deployed.", ParameterSetName = Constants.ParameterSetNames.AgreementAcceptParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "Publisher identifier string of image being deployed.", ParameterSetName = Constants.ParameterSetNames.AgreementRejectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Publisher { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Offer identifier string of image being deployed.", ParameterSetName = Constants.ParameterSetNames.AgreementAcceptParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "Offer identifier string of image being deployed.", ParameterSetName = Constants.ParameterSetNames.AgreementRejectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Product { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Plan identifier string of image being deployed.", ParameterSetName = Constants.ParameterSetNames.AgreementAcceptParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "Plan identifier string of image being deployed.", ParameterSetName = Constants.ParameterSetNames.AgreementRejectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Pass this to accept the legal terms.", ParameterSetName = Constants.ParameterSetNames.AgreementAcceptParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "Pass this to accept the legal terms.", ParameterSetName = Constants.ParameterSetNames.InputObjectAcceptParametrSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Accept { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Pass this to reject the legal terms.", ParameterSetName = Constants.ParameterSetNames.AgreementRejectParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "Pass this to reject the legal terms.", ParameterSetName = Constants.ParameterSetNames.InputObjectRejectParametrSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Reject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Terms object returned in Get-AzureRmMarketplaceTerms cmdlet. This is a mandatory parameter if you accept the legal terms.", ParameterSetName = Constants.ParameterSetNames.AgreementAcceptParameterSet)]
        [Parameter(Mandatory = false, HelpMessage = "Terms object returned in Get-AzureRmMarketplaceTerms cmdlet. This is a mandatory parameter if you accept the legal terms.", ParameterSetName = Constants.ParameterSetNames.AgreementRejectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAgreementTerms Terms { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0, HelpMessage = "Terms object returned in Get-AzureRmMarketplaceTerms cmdlet. This is a mandatory parameter if Accept paramter is true.", ParameterSetName = Constants.ParameterSetNames.InputObjectAcceptParametrSet)]
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0, HelpMessage = "Terms object returned in Get-AzureRmMarketplaceTerms cmdlet. This is a mandatory parameter if Accept paramter is true.", ParameterSetName = Constants.ParameterSetNames.InputObjectRejectParametrSet)]
        [ValidateNotNullOrEmpty]
        public PSAgreementTerms InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess("AzureRmMarketplaceTerms", "Set Legal Terms"))
            {
                switch (ParameterSetName)
                {
                    case Constants.ParameterSetNames.AgreementAcceptParameterSet:
                    {
                        if (Terms != null)
                        {
                            Terms.Accepted = true;
                            var agreementTerms = new PSAgreementTerms(MarketplaceOrderingAgreementsClient.MarketplaceAgreements.Create(
                                            Publisher, Product, Name, Terms.ToAgreementTerms()));
                            WriteObject(agreementTerms);
                        }
                        else
                        {//Accept but there is no terms object
                            WriteWarning("Terms parameter is mandatory to accept the legal terms.");
                        }
                    }
                        break;
                    case Constants.ParameterSetNames.AgreementRejectParameterSet:
                    {
                        Terms = new PSAgreementTerms
                        {
                            Accepted = false
                        };
                        var agreementTerms = new PSAgreementTerms(MarketplaceOrderingAgreementsClient.MarketplaceAgreements.Create(
                                            Publisher, Product, Name, Terms.ToAgreementTerms()));
                        WriteObject(agreementTerms);
                    }
                        break;
                    case Constants.ParameterSetNames.InputObjectAcceptParametrSet:
                        if (InputObject != null)
                        {
                            InputObject.Accepted = true;
                            var agreementTerms = new PSAgreementTerms(MarketplaceOrderingAgreementsClient.MarketplaceAgreements.Create(
                                                    InputObject.Publisher, InputObject.Product, InputObject.Plan, InputObject.ToAgreementTerms()));
                            WriteObject(agreementTerms);
                        }
                        else
                        {
                            WriteWarning("Terms parameter is mandatory when passing it as pipeline.");
                        }
                        break;
                    case Constants.ParameterSetNames.InputObjectRejectParametrSet:
                        if (InputObject != null)
                        {
                            InputObject.Accepted = false;
                            var agreementTerms = new PSAgreementTerms(MarketplaceOrderingAgreementsClient.MarketplaceAgreements.Create(
                                                    InputObject.Publisher, InputObject.Product, InputObject.Plan, InputObject.ToAgreementTerms()));
                            WriteObject(agreementTerms);
                        }
                        else
                        {
                            WriteWarning("Terms parameter is mandatory when passing it as pipeline.");
                        }
                        break;
                }
            }
        }
    }
}

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

namespace Microsoft.Azure.Commands.LogicApp.Cmdlets
{
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.LogicApp.Utilities;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Updates the integration account agreement.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmIntegrationAccountAgreement", SupportsShouldProcess = true),
     OutputType(typeof (object))]
    public class UpdateAzureIntegrationAccountAgreementCommand : LogicAppBaseCmdlet
    {

        #region Input Paramters

        [Parameter(Mandatory = true, HelpMessage = "The integration account resource group name.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account name.",
            ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account agreement name.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string AgreementName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account agreement type.",
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("X12", "AS2", "Edifact", IgnoreCase = false)]
        public string AgreementType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account agreement guest partner.",
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string GuestPartner { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account agreement host partner.",
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string HostPartner { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account agreement guest identity qualifier.",
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string GuestIdentityQualifier { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account agreement host identity qualifier.",
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string HostIdentityQualifier { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account agreement content.",
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string AgreementContent { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account agreement content.",
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string AgreementContentFilePath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account agreement metadata.",
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public object Metadata { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the integration account agreement update command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var integrationAccountAgreement =
                IntegrationAccountClient.GetIntegrationAccountAgreement(this.ResourceGroupName,
                    this.Name, this.AgreementName);

            if (this.Metadata != null)
            {
                integrationAccountAgreement.Metadata = CmdletHelper.ConvertToMetadataJObject(this.Metadata);
            }

            var hostPartner = IntegrationAccountClient.GetIntegrationAccountPartner(this.ResourceGroupName, this.Name,
                string.IsNullOrEmpty(this.HostPartner)
                    ? integrationAccountAgreement.HostPartner
                    : this.HostPartner);
            integrationAccountAgreement.HostPartner = hostPartner.Name;

            var guestPartner = IntegrationAccountClient.GetIntegrationAccountPartner(this.ResourceGroupName, this.Name,
                string.IsNullOrEmpty(this.GuestPartner)
                    ? integrationAccountAgreement.GuestPartner
                    : this.GuestPartner);
            integrationAccountAgreement.GuestPartner = guestPartner.Name;

            if (!string.IsNullOrEmpty(this.HostIdentityQualifier))
            {
                var hostIdentity =
                    hostPartner.Content.B2b.BusinessIdentities.FirstOrDefault(
                        s => s.Qualifier == this.HostIdentityQualifier);

                if (hostIdentity == null)
                {
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture,
                        Properties.Resource.InvalidQualifierSpecified, this.HostIdentityQualifier, hostPartner.Name));
                }

                integrationAccountAgreement.HostIdentity = hostIdentity;
            }

            if (!string.IsNullOrEmpty(this.GuestIdentityQualifier))
            {
                var guestIdentity =
                    guestPartner.Content.B2b.BusinessIdentities.FirstOrDefault(
                        s => s.Qualifier == this.GuestIdentityQualifier);

                if (guestIdentity == null)
                {
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture,
                        Properties.Resource.InvalidQualifierSpecified, this.GuestIdentityQualifier, guestPartner.Name));
                }

                integrationAccountAgreement.GuestIdentity = guestIdentity;
            }

            if (!string.IsNullOrEmpty(this.AgreementType))
            {
                integrationAccountAgreement.AgreementType =
                    (AgreementType) Enum.Parse(typeof (AgreementType), this.AgreementType);
            }

            if (!string.IsNullOrEmpty(this.AgreementContentFilePath))
            {
                this.AgreementContent =
                    CmdletHelper.GetContentFromFile(this.TryResolvePath(this.AgreementContentFilePath));
            }

            if (!string.IsNullOrEmpty(this.AgreementContent))
            {
                integrationAccountAgreement.Content = CmdletHelper.ConvertToAgreementContent(this.AgreementContent);
            }

            ConfirmAction(Force.IsPresent,
                string.Format(CultureInfo.InvariantCulture, Properties.Resource.UpdateResourceWarning,
                    "Microsoft.Logic/integrationAccounts/agreements", this.Name),
                string.Format(CultureInfo.InvariantCulture, Properties.Resource.UpdateResourceMessage,
                    "Microsoft.Logic/integrationAccounts/agreements", this.Name),
                Name,
                () =>
                {
                    this.WriteObject(
                        IntegrationAccountClient.UpdateIntegrationAccountAgreement(this.ResourceGroupName, this.Name,
                            this.AgreementName,
                            integrationAccountAgreement), true);

                },
                null);
        }
    }
}
﻿// ----------------------------------------------------------------------------------
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
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.LogicApp.Utilities;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using ResourceManager.Common.ArgumentCompleters;

    /// <summary>
    /// Creates a new integration account agreement.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IntegrationAccountAgreement", SupportsShouldProcess = true)]
    [OutputType(typeof(IntegrationAccountAgreement))]
    public class NewAzureIntegrationAccountAgreementCommand : LogicAppBaseCmdlet
    {

        #region Input Parameters

        [Parameter(Mandatory = true, HelpMessage = "The integration account resource group name.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account name.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("IntegrationAccountName", "ResourceName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account agreement name.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string AgreementName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account agreement type.",
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("X12", "AS2", "Edifact", IgnoreCase = false)]
        public string AgreementType { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account agreement guest partner.",
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string GuestPartner { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account agreement host partner.",
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string HostPartner { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account agreement guest identity qualifier.",
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string GuestIdentityQualifier { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account agreement guest identity qualifier value.",
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string GuestIdentityQualifierValue { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account agreement host identity qualifier.",
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string HostIdentityQualifier { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account agreement host identity qualifier value.",
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string HostIdentityQualifierValue { get; set; }

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

        #endregion Input Parameters

        /// <summary>
        /// Executes the integration account agreement create command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.Metadata != null)
            {
                this.Metadata = CmdletHelper.ConvertToMetadataJObject(this.Metadata);
            }

            var integrationAccount = IntegrationAccountClient.GetIntegrationAccount(this.ResourceGroupName, this.Name);

            var hostPartner = IntegrationAccountClient.GetIntegrationAccountPartner(this.ResourceGroupName, this.Name,
                this.HostPartner);
            var guestPartner = IntegrationAccountClient.GetIntegrationAccountPartner(this.ResourceGroupName, this.Name,
                this.GuestPartner);

            var hostIdentity =
                hostPartner.Content.B2b.BusinessIdentities.FirstOrDefault(
                    s => s.Qualifier == this.HostIdentityQualifier && s.Value == this.HostIdentityQualifierValue);

            if (hostIdentity == null)
            {
                throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture,
                    Properties.Resource.InvalidQualifierSpecified, this.HostIdentityQualifier, this.HostPartner));
            }

            var guestIdentity =
                guestPartner.Content.B2b.BusinessIdentities.FirstOrDefault(
                    s => s.Qualifier == this.GuestIdentityQualifier && s.Value == this.GuestIdentityQualifierValue);

            if (guestIdentity == null)
            {
                throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture,
                    Properties.Resource.InvalidQualifierSpecified, this.GuestIdentityQualifier, this.GuestPartner));
            }

            if (string.IsNullOrEmpty(this.AgreementContent))
            {
                this.AgreementContent =
                    CmdletHelper.GetContentFromFile(this.TryResolvePath(this.AgreementContentFilePath));
            }

            this.WriteObject(
                IntegrationAccountClient.CreateIntegrationAccountAgreement(this.ResourceGroupName, integrationAccount.Name,
                    this.AgreementName,
                    new IntegrationAccountAgreement
                    {
                        AgreementType = (AgreementType) Enum.Parse(typeof(AgreementType), this.AgreementType),
                        HostIdentity = hostIdentity,
                        GuestIdentity = guestIdentity,
                        GuestPartner = this.GuestPartner,
                        HostPartner = this.HostPartner,
                        Content = CmdletHelper.ConvertToAgreementContent(this.AgreementContent),
                        Metadata = this.Metadata
                    }), true);
        }
    }
}

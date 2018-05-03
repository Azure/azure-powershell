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
    using System.Globalization;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.LogicApp.Utilities;
    using ResourceManager.Common.ArgumentCompleters;

    /// <summary>
    /// Updates the integration account generated interchange control number.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmIntegrationAccountGeneratedIcn", SupportsShouldProcess = true)]
    [OutputType(typeof(IntegrationAccountControlNumber))]
    public class UpdateAzureIntegrationAccountGeneratedIcnCommand : LogicAppBaseCmdlet
    {
        #region Input Paramters

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The integration account resource group name.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the integration account name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The integration account name.")]
        [Alias("ResourceName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the agreement name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The integration account agreement name.")]
        [ValidateNotNullOrEmpty]
        public string AgreementName { get; set; }

        /// <summary>
        /// Gets or sets the control number.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The generated control number new value.")]
        [ValidateNotNullOrEmpty]
        public string ControlNumber { get; set; }

        /// <summary>
        /// Gets or sets the agreement type.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The integration account agreement type.")]
        [Alias("MessageType")]
        [ValidateSet("X12", "Edifact", IgnoreCase = true)]
        public string AgreementType { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the integration account generated control number update command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (string.IsNullOrEmpty(AgreementType))
            {
                this.WriteWarning(Constants.NoAgreementTypeParameterWarningMessage);
                AgreementType = "X12";
            }

            var integrationAccountGeneratedIcn = this.IntegrationAccountClient.GetIntegrationAccountGeneratedIcn(
                resourceGroupName: this.ResourceGroupName,
                integrationAccountName: this.Name,
                integrationAccountAgreementName: this.AgreementName);

            integrationAccountGeneratedIcn.MessageType = (MessageType)Enum.Parse(enumType: typeof(MessageType), value: AgreementType, ignoreCase: true);
            integrationAccountGeneratedIcn.ControlNumber = this.ControlNumber;
            integrationAccountGeneratedIcn.ControlNumberChangedTime = DateTime.UtcNow > integrationAccountGeneratedIcn.ControlNumberChangedTime ?
                DateTime.UtcNow :
                integrationAccountGeneratedIcn.ControlNumberChangedTime.AddTicks(1);

            this.ConfirmAction(
                processMessage: string.Format(CultureInfo.InvariantCulture, Properties.Resource.UpdateGeneratedControlNumberMessage, "Microsoft.Logic/integrationAccounts/agreements", this.Name),
                target: this.Name,
                action: () =>
                {
                    this.WriteObject(
                        sendToPipeline: this.IntegrationAccountClient.UpdateIntegrationAccountGeneratedIcn(
                            resourceGroupName: this.ResourceGroupName,
                            integrationAccountName: this.Name,
                            integrationAccountAgreementName: this.AgreementName,
                            integrationAccountControlNumber: integrationAccountGeneratedIcn),
                        enumerateCollection: true);
                });
        }
    }
}
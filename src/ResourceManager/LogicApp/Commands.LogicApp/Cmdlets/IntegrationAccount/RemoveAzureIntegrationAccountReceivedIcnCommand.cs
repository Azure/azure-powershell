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
    using Microsoft.Azure.Management.Logic.Models;
    using ResourceManager.Common.ArgumentCompleters;

    /// <summary>
    /// Removes the integration account received interchange control number.
    /// </summary>
    /// <remarks>As the underlying resource provider does not return the deleted entity, there is no output to this cmdlet and no PassThru parameter either.</remarks>
    [Cmdlet(VerbsCommon.Remove, "AzureRmIntegrationAccountReceivedIcn", SupportsShouldProcess = true)]
    public class RemoveAzureIntegrationAccountReceivedIcnCommand : LogicAppBaseCmdlet
    {
        #region Input Paramters

        [Parameter(
            Mandatory = true,
            HelpMessage = "The integration account resource group name.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account name.")]
        [ValidateNotNullOrEmpty]
        [Alias("IntegrationAccountName", "ResourceName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account agreement name.")]
        [ValidateNotNullOrEmpty]
        public string AgreementName { get; set; }

        /// <summary>
        /// Gets or sets the control number value.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The integration account control number value.")]
        [ValidateNotNullOrEmpty]
        public string ControlNumberValue { get; set; }

        /// <summary>
        /// Gets or sets the agreement type.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The integration account agreement type.")]
        [Alias("MessageType")]
        [ValidateSet("X12", "Edifact", IgnoreCase = true)]
        public string AgreementType { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the command to remove integration account agreement
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (string.IsNullOrEmpty(AgreementType))
            {
                this.WriteWarning(Constants.NoAgreementTypeParameterWarningMessage);
                AgreementType = "X12";
            }

            this.ConfirmAction(
                processMessage: string.Format(CultureInfo.InvariantCulture, Properties.Resource.RemoveResourceMessage, "received control number", this.Name),
                target: Name,
                action : () => {
                    IntegrationAccountClient.RemoveIntegrationAccountReceivedControlNumber(
                        resourceGroupName: this.ResourceGroupName,
                        integrationAccountName: this.Name,
                        integrationAccountAgreementName: this.AgreementName,
                        agreementType: (AgreementType)Enum.Parse(enumType: typeof(AgreementType), value: AgreementType, ignoreCase: true),
                        controlNumber: this.ControlNumberValue);
                });
        }
    }
}
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

namespace Microsoft.Azure.Commands.LogicApp.Utilities
{
    using System.Globalization;
    using System.Management.Automation;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;

    /// <summary>
    /// LogicApp client partial class for integration account control number operations.
    /// </summary>
    public partial class IntegrationAccountClient
    {
        /// <summary>
        /// Updates an integration account received interchange control number for a given agreement.
        /// </summary>
        /// <param name="resourceGroupName">The integration account agreement resource group.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountAgreementName">The integration account agreement name.</param>
        /// <param name="agreementType">The agreement type.</param>
        /// <param name="integrationAccountControlNumber">The integration account control number object.</param>
        /// <returns>Updated integration account control number</returns>
        public IntegrationAccountControlNumber UpdateIntegrationAccountReceivedIcn(string resourceGroupName, string integrationAccountName, string integrationAccountAgreementName, AgreementType agreementType, IntegrationAccountControlNumber integrationAccountControlNumber)
        {
            if (!this.DoesIntegrationAccountAgreementExist(resourceGroupName, integrationAccountName, integrationAccountAgreementName))
            {
                throw new PSArgumentException(message: string.Format(
                    CultureInfo.InvariantCulture,
                    Properties.Resource.ResourceNotFound,
                    integrationAccountAgreementName,
                    resourceGroupName));
            }

            return SessionContentToIntegrationAccountControlNumber(
                sessionContent: this.LogicManagementClient.IntegrationAccountSessions
                    .CreateOrUpdate(
                        resourceGroupName: resourceGroupName,
                        integrationAccountName: integrationAccountName,
                        sessionName: SessionNameForReceivedControlNumber(
                            integrationAccountAgreementName: integrationAccountAgreementName,
                            agreementType: agreementType,
                            controlNumberValue: integrationAccountControlNumber.ControlNumber),
                        session: new IntegrationAccountSession
                        {
                            Content = integrationAccountControlNumber
                        })
                    .Content,
                integrationAccountAgreementName: integrationAccountAgreementName);
        }

        /// <summary>
        /// Gets the integration account received interchange control number by agreement name and control number value.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountAgreementName">The integration account agreement name.</param>
        /// <param name="agreementType">The agreement type.</param>
        /// <param name="controlNumber">The control number specific value</param>
        /// <returns>Integration account control number object.</returns>
        public IntegrationAccountControlNumber GetIntegrationAccountReceivedControlNumber(string resourceGroupName, string integrationAccountName, string integrationAccountAgreementName, AgreementType agreementType, string controlNumber)
        {
            return SessionContentToIntegrationAccountControlNumber(
                sessionContent: this.LogicManagementClient.IntegrationAccountSessions
                    .Get(
                        resourceGroupName: resourceGroupName,
                        integrationAccountName: integrationAccountName,
                        sessionName: SessionNameForReceivedControlNumber(
                            integrationAccountAgreementName: integrationAccountAgreementName,
                            agreementType: agreementType,
                            controlNumberValue: controlNumber))
                     .Content,
                integrationAccountAgreementName: integrationAccountAgreementName,
                controlNumber: controlNumber);
        }

        /// <summary>
        /// Removes the specified integration account received control number.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountAgreementName">The integration account agreement name.</param>
        /// <param name="agreementType">The agreement type.</param>
        /// <param name="controlNumber">The control number specific value</param>
        public void RemoveIntegrationAccountReceivedControlNumber(string resourceGroupName, string integrationAccountName, string integrationAccountAgreementName, AgreementType agreementType, string controlNumber)
        {
            this.LogicManagementClient.IntegrationAccountSessions
                .Delete(
                    resourceGroupName: resourceGroupName,
                    integrationAccountName: integrationAccountName,
                    sessionName: SessionNameForReceivedControlNumber(
                        integrationAccountAgreementName: integrationAccountAgreementName,
                        agreementType: agreementType,
                        controlNumberValue: controlNumber));
        }

        /// <summary>
        /// Gets the integration account session name (prefix) for received control number for a given integration account agreement name and optionally control number value.
        /// </summary>
        /// <param name="integrationAccountAgreementName">The integration account agreement name.</param>
        /// <param name="agreementType">The agreement type.</param>
        /// <param name="controlNumberValue">The control number specific value</param>
        /// <returns>The integration account session (prefix)name for received interchange control number(s).</returns>
        private static string SessionNameForReceivedControlNumber(string integrationAccountAgreementName, AgreementType agreementType, string controlNumberValue = null)
        {
            // NOTE(daviburg): The session name is formed using the B2B connectors format for all received control numbers.
            // At the moment we only care for X12 type.
            return string.Format(
                Constants.ReceivedControlNumberSessionIdFormat,
                agreementType,
                integrationAccountAgreementName,
                controlNumberValue ?? string.Empty);
        }
    }
}
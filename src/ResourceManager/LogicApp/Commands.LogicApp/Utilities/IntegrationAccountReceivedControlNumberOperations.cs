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
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;

    /// <summary>
    /// LogicApp client partial class for integration account control number operations.
    /// </summary>
    public partial class IntegrationAccountClient
    {
        /// <summary>
        /// Gets the integration account generated interchange control number by agreement name.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountAgreementName">The integration account agreement name.</param>
        /// <param name="controlNumberValue">The control number specific value</param>
        /// <returns>Integration account control number object.</returns>
        public IntegrationAccountControlNumber GetIntegrationAccountReceivedControlNumber(string resourceGroupName, string integrationAccountName, string integrationAccountAgreementName, string controlNumber)
        {
            return IntegrationAccountClient.SessionContentToIntegrationAccountControlNumber(
                sessionContent: this.LogicManagementClient.Sessions
                    .GetOrThrow(
                        resourceGroupName: resourceGroupName,
                        integrationAccountName: integrationAccountName,
                        sessionName: IntegrationAccountClient.SessionNameForReceivedControlNumber(
                            integrationAccountAgreementName: integrationAccountAgreementName,
                            controlNumberValue: controlNumber))
                     .Content,
                integrationAccountAgreementName: integrationAccountAgreementName,
                controlNumber: controlNumber);
        }

        /// <summary>
        /// Removes the specified integration account recevied control number.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountAgreementName">The integration account agreement name.</param>
        /// <param name="controlNumberValue">The control number specific value</param>
        public void RemoveIntegrationAccountReceivedControlNumber(string resourceGroupName, string integrationAccountName, string integrationAccountAgreementName, string controlNumber)
        {
            this.LogicManagementClient.Sessions
                .Delete(
                    resourceGroupName: resourceGroupName,
                    integrationAccountName: integrationAccountName,
                    sessionName: IntegrationAccountClient.SessionNameForReceivedControlNumber(
                        integrationAccountAgreementName: integrationAccountAgreementName,
                        controlNumberValue: controlNumber));
        }

        /// <summary>
        /// Gets the integration account session name (prefix) for received control number for a given integration account agreement name and optionally control number value.
        /// </summary>
        /// <param name="integrationAccountAgreementName">The integration account agreement name.</param>
        /// <param name="controlNumberValue">The control number specific value</param>
        /// <returns>The integration account session (prefix)name for received interchange control number(s).</returns>
        private static string SessionNameForReceivedControlNumber(string integrationAccountAgreementName, string controlNumberValue = null)
        {
            // NOTE(daviburg): The session name is formed using the B2B connectors format for all received control numbers.
            // At the moment we only care for X12 type.
            return string.Format(
                Constants.ReceivedControlNumberSessionIdFormat,
                AgreementType.X12,
                integrationAccountAgreementName,
                controlNumberValue ?? string.Empty);
        }
    }
}
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
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// LogicApp client partial class for integration account control number operations.
    /// </summary>
    public partial class IntegrationAccountClient
    {
        /// <summary>
        /// Updates the integration account generated interchange control number for a given agreement.
        /// </summary>
        /// <param name="resourceGroupName">The integration account agreement resource group.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountAgreementName">The integration account agreement name.</param>
        /// <param name="integrationAccountControlNumber">The integration account control number object.</param>
        /// <returns>Updated integration account control number</returns>
        public IntegrationAccountControlNumber UpdateIntegrationAccountGeneratedIcn(string resourceGroupName, string integrationAccountName, string integrationAccountAgreementName, IntegrationAccountControlNumber integrationAccountControlNumber)
        {
            if (!this.DoesIntegrationAccountAgreementExist(resourceGroupName, integrationAccountName, integrationAccountAgreementName))
            {
                throw new PSArgumentException(message: string.Format(
                    CultureInfo.InvariantCulture,
                    Properties.Resource.ResourceNotFound,
                    integrationAccountAgreementName,
                    resourceGroupName));
            }

            return IntegrationAccountClient.SessionContentToIntegrationAccountControlNumber(
                sessionContent: this.LogicManagementClient.Sessions
                    .CreateOrUpdate(
                        resourceGroupName: resourceGroupName,
                        integrationAccountName: integrationAccountName,
                        sessionName: IntegrationAccountClient.SessionNameForGeneratedIcn(integrationAccountAgreementName),
                        session: new IntegrationAccountSession
                        {
                            Content = integrationAccountControlNumber
                        })
                    .Content,
                integrationAccountAgreementName: integrationAccountAgreementName);
        }

        /// <summary>
        /// Gets the integration account generated interchange control number by agreement name.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountAgreementName">The integration account agreement name.</param>
        /// <returns>Integration account control number object.</returns>
        public IntegrationAccountControlNumber GetIntegrationAccountGeneratedIcn(string resourceGroupName, string integrationAccountName, string integrationAccountAgreementName)
        {
            return IntegrationAccountClient.SessionContentToIntegrationAccountControlNumber(
                sessionContent: this.LogicManagementClient.Sessions
                    .GetOrThrow(
                        resourceGroupName: resourceGroupName,
                        integrationAccountName: integrationAccountName,
                        sessionName: IntegrationAccountClient.SessionNameForGeneratedIcn(integrationAccountAgreementName))
                     .Content,
                integrationAccountAgreementName: integrationAccountAgreementName);
        }

        /// <summary>
        /// Tries to get the integration account generated interchange control number by agreement name.
        /// Returns a placeholder if the underlying session is not found.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountAgreementName">The integration account agreement name.</param>
        /// <returns>Integration account control number object.</returns>
        public IntegrationAccountControlNumber TryGetIntegrationAccountGeneratedIcn(string resourceGroupName, string integrationAccountName, string integrationAccountAgreementName)
        {
            try
            {
                return IntegrationAccountClient.SessionContentToIntegrationAccountControlNumber(
                    sessionContent: this.LogicManagementClient.Sessions
                        .GetOrThrow(
                            resourceGroupName: resourceGroupName,
                            integrationAccountName: integrationAccountName,
                            sessionName: IntegrationAccountClient.SessionNameForGeneratedIcn(integrationAccountAgreementName))
                         .Content,
                    integrationAccountAgreementName: integrationAccountAgreementName);
            }
            catch (CloudException ex)
            {
                if (ex.Body.Code == "SessionNotFound")
                {
                    return new IntegrationAccountControlNumber { ControlNumber = Properties.Resource.GeneratedControlNumberNotFound, ControlNumberChangedTime = DateTime.MinValue };
                }

                throw;
            }
        }

        /// <summary>
        /// Gets the integration account generated interchange control numbers by resource group name.
        /// </summary>
        /// <param name="resourceGroupName">The integration account agreement resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <returns>List of integration account agreements.</returns>
        public IList<QualifiedIntegrationAccountControlNumber> ListIntegrationAccountGeneratedIcns(string resourceGroupName, string integrationAccountName)
        {
            return this
                .ListIntegrationAccountAgreements(
                    resourceGroupName: resourceGroupName,
                    integrationAccountName: integrationAccountName)
                .Where(agreement => agreement.AgreementType == AgreementType.X12)
                .Select(agreement => new QualifiedIntegrationAccountControlNumber(
                    icn: this.TryGetIntegrationAccountGeneratedIcn(
                        resourceGroupName: resourceGroupName,
                        integrationAccountName: integrationAccountName,
                        integrationAccountAgreementName: agreement.Name),
                    agreementName: agreement.Name))
                .ToList();
        }

        /// <summary>
        /// Gets the integration account session name for generated interchange control number for a given integration account agreement name.
        /// </summary>
        /// <param name="integrationAccountAgreementName">The integration account agreement name.</param>
        /// <returns>The integration account session name for generated interchange control number.</returns>
        private static string SessionNameForGeneratedIcn(string integrationAccountAgreementName)
        {
            // NOTE(daviburg): The session name is formed using the B2B connectors format for all generated control numbers.
            // At the moment we only care for ICN type which never has the acknowledgement suffix.
            return string.Format(
                Constants.GeneratedControlNumberSessionIdFormat,
                integrationAccountAgreementName,
                ControlNumberType.Icn,
                string.Empty);
        }
   }
}
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

using System;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.ManagementPartner;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.ManagementPartner.Models;

namespace Microsoft.Azure.Commands.ManagementPartner
{
    public abstract class AzureManagementPartnerCmdletsBase:AzureRMCmdlet
    {
        private IACEProvisioningManagementPartnerAPIClient aceProvisioningManagementPartnerApiClient;

        public IACEProvisioningManagementPartnerAPIClient AceProvisioningManagementPartnerApiClient
        {
            get
            {
                return aceProvisioningManagementPartnerApiClient ?? (aceProvisioningManagementPartnerApiClient =
                           AzureSession.Instance.ClientFactory.CreateArmClient<ACEProvisioningManagementPartnerAPIClient>(
                               DefaultProfile.DefaultContext, AzureEnvironment.Endpoint.ResourceManager));
            }

            set { aceProvisioningManagementPartnerApiClient = value; }
        }

        protected void LogException(Exception ex)
        {
            if (ex is ErrorException)
            {
                ErrorException errorEx = ex as ErrorException;
                throw new ErrorException(
                    $"Operation failed with message '{errorEx.Body.ErrorProperty.Message}'");
            }

            throw ex;
        }
    }
}

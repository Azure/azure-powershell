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

using Commands.Security;
using Microsoft.Azure.Commands.Security.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SecurityCenter.Cmdlets.SqlInformationProtectionPolicy
{
    public class SqlInformationProtectionPolicyCmdlet : SecurityCenterCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        protected Management.Security.Models.InformationProtectionPolicy RetrieveSqlInformationProtectionPolicy()
        {
            var azureOperationResponse = SecurityCenterClient.InformationProtectionPolicies.GetWithHttpMessagesAsync(Scope, SqlInformationProtectionPolicyName).Result;
            if (!azureOperationResponse.Response.IsSuccessStatusCode)
            {
                throw new Exception($"{Resources.SqlInformationProtectionPolicyNotRetrievedError} Status Code: {azureOperationResponse.Response.StatusCode}");
            }

            var policy = azureOperationResponse.Body;
            if (policy == null)
            {
                throw new Exception(Resources.SqlInformationProtectionPolicyNotRetrievedError);
            }

            return policy;
        }

        protected void SetInformationProtectionPolicy(Management.Security.Models.InformationProtectionPolicy policy)
        {
            var response = SecurityCenterClient.InformationProtectionPolicies.CreateOrUpdateWithHttpMessagesAsync(Scope, SqlInformationProtectionPolicyName).Result.Response;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(string.Format(Resources.SqlInformationProtectionPolicyUpdateError, response.StatusCode));
            }
        }

        protected const string SqlInformationProtectionPolicyCmdletSuffix = "SqlInformationProtectionPolicy";
        protected const string SqlInformationProtectionPolicyParameterSet = "SQL Information Protection Policy";

        private string Scope => $"providers/Microsoft.Management/managementGroups/{DefaultContext.Tenant.Id}";
        private const string SqlInformationProtectionPolicyName = "effective";
    }
}

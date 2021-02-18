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

using Microsoft.Azure.Commands.SecurityCenter.Models.SqlInformationProtectionPolicy;
using Microsoft.Azure.Management.Security.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SecurityCenter.Cmdlets.SqlInformationProtectionPolicy
{
    [Cmdlet(VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SqlInformationProtectionPolicyCmdletSuffix,
        DefaultParameterSetName = SqlInformationProtectionPolicyParameterSet),
        OutputType(typeof(PSSqlInformationProtectionPolicy))]
    public class GetSqlInformationProtectionPolicy : SqlInformationProtectionPolicyCmdlet
    {
        public override void ExecuteCmdlet()
        {
            WriteObject(RetrieveSqlInformationProtectionPolicy());
        }

        protected PSSqlInformationProtectionPolicy RetrieveSqlInformationProtectionPolicy()
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

            return policy.ConverToPSType();
        }

        private const string SqlInformationProtectionPolicyName = "effective";
    }
}

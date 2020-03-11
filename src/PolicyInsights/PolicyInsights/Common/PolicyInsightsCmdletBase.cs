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

namespace Microsoft.Azure.Commands.PolicyInsights.Common
{
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Management.PolicyInsights;
    using Microsoft.Azure.Management.PolicyInsights.Models;
    using Microsoft.Rest;

    /// <summary>
    /// Base class for Azure Policy Insights cmdlets
    /// </summary>
    public abstract class PolicyInsightsCmdletBase : AzureRMCmdlet
    {
        /// <summary>
        /// Policy insights client
        /// </summary>
        private IPolicyInsightsClient _policyInsightsClient;

        /// <summary>
        /// Gets or sets the policy insights client
        /// </summary>
        public IPolicyInsightsClient PolicyInsightsClient
        {
            get
            {
                return _policyInsightsClient ?? 
                    (_policyInsightsClient = AzureSession.Instance.ClientFactory.CreateArmClient<PolicyInsightsClient>(DefaultContext, AzureEnvironment.Endpoint.ResourceManager));
            }
            set
            {
                _policyInsightsClient = value;
            }
        }

        /// <summary>
        /// Executes the cmdlet logic.
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// The cmdlet execution wrapper
        /// </summary>
        public sealed override void ExecuteCmdlet()
        {
            try
            {
                this.Execute();
            }
            catch (QueryFailureException ex)
            {
                WriteExceptionError(ex.Body?.Error != null
                    ? new RestException($"{ex.Message} ({ex.Body.Error.Code}: {ex.Body.Error.Message})")
                    : ex);
            }
            catch (ErrorResponseException ex)
            {
                WriteExceptionError(ex.Body?.Error != null
                    ? new RestException($"{ex.Message} ({ex.Body.Error.Code}: {ex.Body.Error.Message})")
                    : ex);
            }
        }
    }
}

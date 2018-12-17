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

namespace Microsoft.Azure.Commands.Advisor.Utilities
{
    using Management.Advisor;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.ResourceManager.Common;

    public class ResourceAdvisorBaseCmdlet : AzureRMCmdlet
    {
        /// <summary>
        /// The resource advisor client
        /// </summary>
        private IAdvisorManagementClient _resourceAdvisorClient;

        /// <summary>
        /// Gets the resource advisor client.
        /// </summary>
        public IAdvisorManagementClient ResourceAdvisorClient
        {
            get
            {
                if (this._resourceAdvisorClient == null)
                {
                    this._resourceAdvisorClient =
                        AzureSession.Instance.ClientFactory.CreateArmClient<AdvisorManagementClient>(
                            this.DefaultContext, AzureEnvironment.Endpoint.ResourceManager);
                }
                
                return this._resourceAdvisorClient;
            }
        }
    }
}

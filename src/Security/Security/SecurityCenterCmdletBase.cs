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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Security;

namespace Commands.Security
{
    public abstract class SecurityCenterCmdletBase : AzureRMCmdlet
    {
        /// <summary>
        /// Security Center client
        /// </summary>
        private ISecurityCenterClient _securityCenterClient;

        /// <summary>
        /// Gets or sets the policy insights client
        /// </summary>
        public ISecurityCenterClient SecurityCenterClient
        {
            get
            {
                return _securityCenterClient ??
                    (_securityCenterClient = AzureSession.Instance.ClientFactory.CreateArmClient<SecurityCenterClient>(DefaultContext, AzureEnvironment.Endpoint.ResourceManager));
            }
            set
            {
                _securityCenterClient = value;
            }
        }
    }
}

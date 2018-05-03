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
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Insights
{
    /// <summary>
    /// Base class for the Azure Insights SDK Cmdlets based on the MonitorManagementClient
    /// </summary>
    public abstract class ManagementCmdletBase : MonitorCmdletBase
    {
        #region General declarations

        private IMonitorManagementClient monitorManagementClient;

        /// <summary>
        /// Gets the monitorManagementClient to use in the Cmdlet
        /// </summary>
        public IMonitorManagementClient MonitorManagementClient
        {
            // The premise is that a command to establish a context (like Connect-AzureRmAccount) has
            //   been called before this command in order to have a correct CurrentContext
            get
            {
                if (this.monitorManagementClient == null)
                {
                    this.monitorManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<MonitorManagementClient>(DefaultProfile.DefaultContext, AzureEnvironment.Endpoint.ResourceManager);
                }

                return this.monitorManagementClient;
            }
            set { this.monitorManagementClient = value; }
        }
        #endregion
    }
}

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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.Insights;

namespace Microsoft.Azure.Commands.Insights
{
    /// <summary>
    /// Base class for the Azure Insights SDK Cmdlets based on the InsightsManagementClient
    /// </summary>
    public abstract class ManagementCmdletBase : InsightsCmdletBase
    {
        #region General declarations

        private IInsightsManagementClient insightsManagementClient;

        private bool disposed;

        /// <summary>
        /// Gets the insightsManagementClient to use in the Cmdlet
        /// </summary>
        public IInsightsManagementClient InsightsManagementClient
        {
            // The premise is that a command to establish a context (like Add-AzureRmAccount) has
            //   been called before this command in order to have a correct CurrentContext
            get
            {
                if (this.insightsManagementClient == null)
                {
                    this.insightsManagementClient = AzureSession.ClientFactory.CreateClient<InsightsManagementClient>(DefaultProfile.Context, AzureEnvironment.Endpoint.ResourceManager);
                }

                return this.insightsManagementClient;
            }
            set { this.insightsManagementClient = value; }
        }

        /// <summary>
        /// Dispose the resources
        /// </summary>
        /// <param name="disposing">Indicates whether the managed resources should be disposed or not</param>
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (this.insightsManagementClient != null)
                {
                    this.insightsManagementClient.Dispose();
                    this.insightsManagementClient = null;
                }

                this.disposed = true;
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}

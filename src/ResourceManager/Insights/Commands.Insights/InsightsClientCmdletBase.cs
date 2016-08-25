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
using Microsoft.Azure.Insights;
using System;

namespace Microsoft.Azure.Commands.Insights
{
    /// <summary>
    /// Base class for the Azure Insights SDK Cmdlets based on the InsightsClient
    /// </summary>
    public abstract class InsightsClientCmdletBase : InsightsCmdletBase, IDisposable
    {
        #region General declarations

        private IInsightsClient insightsClient;

        private bool disposed;

        /// <summary>
        /// Gets the InsightsClient to use in the Cmdlet
        /// </summary>
        public IInsightsClient InsightsClient
        {
            get
            {
                if (this.insightsClient == null)
                {
                    // The premise is that a command to establish a context (like Add-AzureRmAccount) has been called before this command in order to have a correct CurrentContext
                    this.insightsClient = AzureSession.ClientFactory.CreateClient<InsightsClient>(DefaultProfile.Context, AzureEnvironment.Endpoint.ResourceManager);
                }

                return this.insightsClient;
            }
            set { this.insightsClient = value; }
        }

        /// <summary>
        /// Dispose the resources
        /// </summary>
        /// <param name="disposing">Indicates whether the managed resources should be disposed or not</param>
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (this.insightsClient != null)
                {
                    this.insightsClient.Dispose();
                    this.insightsClient = null;
                }

                this.disposed = true;
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}

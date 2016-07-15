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
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Models;
    using Microsoft.Azure.Management.WebSites;
    using Microsoft.Azure.Management.WebSites.Models;

    /// <summary>
    /// Website client to perform operation on AppServicePlan
    /// </summary>
    public class WebsitesClient
    {
        /// <summary>
        /// Verbose Logger
        /// </summary>
        public Action<string> VerboseLogger { get; set; }

        /// <summary>
        /// Error Logger
        /// </summary>
        public Action<string> ErrorLogger { get; set; }

        /// <summary>
        /// Warning Logger
        /// </summary>
        public Action<string> WarningLogger { get; set; }

        /// <summary>
        /// Initializes the client instance
        /// </summary>
        /// <param name="context"></param>
        public WebsitesClient(AzureContext context)
        {
            this.WrappedWebsitesClient = AzureSession.ClientFactory.CreateArmClient<WebSiteManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }

        /// <summary>
        /// Public property exposing the client instance
        /// </summary>
        public WebSiteManagementClient WrappedWebsitesClient
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the app service plan from the specified resource group
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="appServicePlanName">Name of the App Service Plan name</param>
        /// <returns>Object represents the AppServicePlan</returns>
        public ServerFarmWithRichSku GetAppServicePlan(string resourceGroupName, string appServicePlanName)
        {
            return WrappedWebsitesClient.ServerFarms.GetServerFarm(resourceGroupName, appServicePlanName);
        }

        /// <summary>
        /// Writes verbose
        /// </summary>
        /// <param name="verboseFormat">Verbose format</param>
        /// <param name="args">Arguments to write verbose</param>
        private void WriteVerbose(string verboseFormat, params object[] args)
        {
            if (VerboseLogger != null)
            {
                VerboseLogger(string.Format(verboseFormat, args));
            }
        }

        /// <summary>
        /// Write warning
        /// </summary>
        /// <param name="warningFormat">Warning format</param>
        /// <param name="args">Arguments to write warning</param>
        private void WriteWarning(string warningFormat, params object[] args)
        {
            if (WarningLogger != null)
            {
                WarningLogger(string.Format(warningFormat, args));
            }
        }

        /// <summary>
        /// Write error
        /// </summary>
        /// <param name="errorFormat">Error format</param>
        /// <param name="args">Arguments to write error</param>

        private void WriteError(string errorFormat, params object[] args)
        {
            if (ErrorLogger != null)
            {
                ErrorLogger(string.Format(errorFormat, args));
            }
        }
    }
}
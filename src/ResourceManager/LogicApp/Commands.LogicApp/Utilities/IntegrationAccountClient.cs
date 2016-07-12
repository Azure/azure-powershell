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
    using System.Management.Automation;
    using System.Globalization;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Models;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;

    /// <summary>
    /// Integration Account client class
    /// </summary>
    public partial class IntegrationAccountClient
    {
        /// <summary>
        /// Gets or sets the Verbose Logger
        /// </summary>
        public Action<string> VerboseLogger { get; set; }

        /// <summary>
        /// Gets or sets the Error Logger
        /// </summary>
        public Action<string> ErrorLogger { get; set; }

        /// <summary>
        /// Creates new LogicManagement client instance.
        /// </summary>
        /// <param name="context">The Azure context instance</param>        
        public IntegrationAccountClient(AzureContext context)
        {
            this.LogicManagementClient = AzureSession.ClientFactory.CreateArmClient<LogicManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);            
            this.LogicManagementClient.SubscriptionId = context.Subscription.Id.ToString();            
        }

        /// <summary>
        /// Creates new LogicManagement client instance.
        /// </summary>
        public IntegrationAccountClient()
        {
        }

        /// <summary>
        /// Creates new LogicManagement client instance.
        /// </summary>
        /// <param name="client">client reference</param>
        public IntegrationAccountClient(ILogicManagementClient client)
        {
            this.LogicManagementClient = client;
        }

        /// <summary>
        /// Gets or sets the Logic client instance
        /// </summary>
        public ILogicManagementClient LogicManagementClient { get; set; }

    }
}
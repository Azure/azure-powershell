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

using Microsoft.Azure.Commands.Automation.Common;
using AutomationManagement = Microsoft.Azure.Management.Automation;

namespace Microsoft.Azure.Commands.Automation.Model
{
    /// <summary>
    /// The Agent Registration.
    /// </summary>
    public class AgentRegistration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AgentRegistration"/> class.
        /// </summary>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="automationAccountName">
        /// The automation account.
        /// </param>
        /// <param name="agentRegistration">
        /// The automation account agent registration
        /// </param>/// 
        public AgentRegistration(string resourceGroupName, string automationAccountName, AutomationManagement.Models.AgentRegistration agentRegistration)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();

            this.ResourceGroupName = resourceGroupName;
            this.AutomationAccountName = automationAccountName;
            if (agentRegistration.Keys != null)
            {
                this.PrimaryKey = agentRegistration.Keys.Primary;
                this.SecondaryKey = agentRegistration.Keys.Secondary;
            }

            this.Endpoint = agentRegistration.Endpoint;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AgentRegistration"/> class.
        /// </summary>
        public AgentRegistration()
        {
        }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the automation account name.
        /// </summary>
        public string AutomationAccountName { get; set; }

        /// <summary>
        /// Gets or sets the agent registration information primary key
        /// </summary>
        public string PrimaryKey { get; set; }

        /// <summary>
        /// Gets or sets the agent registration information secondary key
        /// </summary>
        public string SecondaryKey { get; set; }

        /// <summary>
        /// Gets or sets the pull server end point
        /// </summary>
        public string Endpoint { get; set; }
    }
}

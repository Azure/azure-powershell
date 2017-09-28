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

namespace Microsoft.Azure.Commands.Automation.Model
{
    using System;
    using Common;

    public class NodeConfigurationDeploymentSchedule
    {

        /// <summary>
        ///     Initializes a new instance of the <see cref="NodeConfigurationDeploymentSchedule" /> class.
        /// </summary>
        /// <param name="resourceGroupName">
        ///     The resource group name.
        /// </param>
        /// <param name="accountName">
        ///     The account name.
        /// </param>
        /// <param name="automationJobSchedule">
        ///     The Job Schedule. (optional)
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public NodeConfigurationDeploymentSchedule(string resourceGroupName, string accountName,
            Management.Automation.Models.JobSchedule automationJobSchedule = null)
        {
            Requires.Argument("accountName", accountName).NotNull();
            Requires.Argument("resourceGroupName", resourceGroupName).NotNull();

            RunbookName = "Deploy-NodeConfigurationToAutomationDscNodesV1";
            ResourceGroupName = resourceGroupName;
            AutomationAccountName = accountName;

            if (automationJobSchedule != null && automationJobSchedule.Properties == null) return;
            if (automationJobSchedule == null) return;

            JobScheduleId = automationJobSchedule.Properties.Id;
            JobSchedule = new JobSchedule(resourceGroupName, accountName, automationJobSchedule);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NodeConfigurationDeploymentSchedule" /> class.
        /// </summary>
        public NodeConfigurationDeploymentSchedule()
        {
            RunbookName = "Deploy-NodeConfigurationToAutomationDscNodesV1";
        }

        /// <summary>
        ///     Gets or sets the resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        ///     Gets or sets the automaiton account name.
        /// </summary>
        public string AutomationAccountName { get; set; }

        /// <summary>
        ///     Gets or sets the job id.
        /// </summary>
        public Guid JobScheduleId { get; set; }

        /// <summary>
        ///     Gets or sets the job id.
        /// </summary>
        public JobSchedule JobSchedule { get; set; }

        /// <summary>
        ///     Gets or sets the job id.
        /// </summary>
        public string RunbookName { get; }
    }
}
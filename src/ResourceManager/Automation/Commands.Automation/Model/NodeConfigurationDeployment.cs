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
    using AutomationManagement = Management.Automation;
    using System;
    using Common;
    using System.Collections.Generic;

    public class NodeConfigurationDeployment
    {
        private const string Scheduled = "Scheduled";

        /// <summary>
        ///     Initializes a new instance of the <see cref="NodeConfigurationDeployment" /> class.
        /// </summary>
        /// <param name="resourceGroupName">
        ///     The resource group name.
        /// </param>
        /// <param name="accountName">
        ///     The account name.
        /// </param>
        /// <param name="nodeConfiguraionName">
        ///     The node configuration name.
        /// </param>
        /// <param name="automationJob">
        ///     The Job.
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public NodeConfigurationDeployment(string resourceGroupName, string accountName,
            string nodeConfiguraionName, Management.Automation.Models.Job automationJob = null)
        {
            Requires.Argument("accountName", accountName).NotNull();
            Requires.Argument("resourceGroupName", resourceGroupName).NotNull();

            ResourceGroupName = resourceGroupName;
            AutomationAccountName = accountName;

            if (automationJob != null && automationJob.Properties == null) return;

            if (automationJob != null)
            {
                JobId = automationJob.Properties.JobId;
                JobStatus = automationJob.Properties.Status;
                Job = new Job(resourceGroupName, accountName, automationJob);
            }

            NodeConfigurationName = nodeConfiguraionName;
        }


        /// <summary>
        ///     Initializes a new instance of the <see cref="NodeConfigurationDeployment" /> class.
        /// </summary>
        /// <param name="resourceGroupName">
        ///     The resource group name.
        /// </param>
        /// <param name="accountName">
        ///     The account name.
        /// </param>
        /// <param name="nodeConfiguraionName">
        ///     The node configuration name.
        /// </param>
        /// <param name="automationJob">
        ///     The Job.
        /// </param>
        /// <param name="automationJobSchedule">
        ///     The Job Schedule. (optional)
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public NodeConfigurationDeployment(string resourceGroupName, string accountName, string nodeConfiguraionName,
            Management.Automation.Models.Job automationJob = null, Management.Automation.Models.JobSchedule automationJobSchedule = null)
        {
            Requires.Argument("accountName", accountName).NotNull();
            Requires.Argument("resourceGroupName", resourceGroupName).NotNull();

            ResourceGroupName = resourceGroupName;
            AutomationAccountName = accountName;
            NodeConfigurationName = nodeConfiguraionName;
            
            if (automationJob == null && automationJobSchedule == null) return;
            else
            {
                if (automationJob != null)
                {
                    JobId = automationJob.Properties.JobId;
                    JobStatus = automationJob.Properties.Status;
                    Job = new Job(resourceGroupName, accountName, automationJob);
                }
                else
                {
                    JobScheduleId = automationJobSchedule.Properties.Id;
                    JobStatus = Scheduled;
                    JobSchedule = new JobSchedule(resourceGroupName, accountName, automationJobSchedule);
                }
            }

            NodeConfigurationName = nodeConfiguraionName;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NodeConfigurationDeployment" /> class.
        /// </summary>
        /// <param name="resourceGroupName">
        ///     The resource group name.
        /// </param>
        /// <param name="accountName">
        ///     The account name.
        /// </param>
        /// <param name="nodeConfiguraionName"> 
        ///     The Node Configuration Name 
        /// </param>
        /// <param name="nodeGroups">
        ///     The list of Node Groups with status.
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public NodeConfigurationDeployment(string resourceGroupName, string accountName, string nodeConfiguraionName, 
            IList<IDictionary<string, string>> nodeGroups = null)
        {
            Requires.Argument("accountName", accountName).NotNull();
            Requires.Argument("resourceGroupName", resourceGroupName).NotNull();

            ResourceGroupName = resourceGroupName;
            AutomationAccountName = accountName;
            NodeConfigurationName = nodeConfiguraionName;

            if (nodeGroups != null)
            {
                NodeStatus = nodeGroups;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NodeConfigurationDeployment" /> class.
        /// </summary>
        /// <param name="resourceGroupName">
        ///     The resource group name.
        /// </param>
        /// <param name="accountName">
        ///     The account name.
        /// </param>
        /// <param name="automationJob">
        ///     The Job. (optional)
        /// </param>
        /// <param name="nodeConfiguraionName"> 
        ///     The Node Configuration Name 
        /// </param>
        /// <param name="nodeGroups">
        ///     The list of Node Groups with status. (optional)
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public NodeConfigurationDeployment(string resourceGroupName, string accountName, string nodeConfiguraionName,
            Management.Automation.Models.Job automationJob = null, IList<IDictionary<string, string>> nodeGroups = null)
        {
            Requires.Argument("accountName", accountName).NotNull();
            Requires.Argument("resourceGroupName", resourceGroupName).NotNull();

            ResourceGroupName = resourceGroupName;
            AutomationAccountName = accountName;
            NodeConfigurationName = nodeConfiguraionName;

            if (automationJob != null && automationJob.Properties == null) return;

            if (automationJob != null)
            {
                JobId = automationJob.Properties.JobId;
                JobStatus = automationJob.Properties.Status;
                Job = new Job(resourceGroupName, accountName, automationJob);
            }

            if (nodeGroups != null)
            {
                NodeStatus = nodeGroups;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NodeConfigurationDeployment" /> class.
        /// </summary>
        /// <param name="resourceGroupName">
        ///     The resource group name.
        /// </param>
        /// <param name="accountName">
        ///     The account name.
        /// </param>
        /// <param name="automationJob">
        ///     The Job. (optional)
        /// </param>
        /// <param name="automationJobSchedule">
        ///     The Job Schedule. (optional)
        /// </param>
        /// <param name="nodeConfiguraionName"> 
        ///     The Node Configuration Name 
        /// </param>
        /// <param name="nodeGroups">
        ///     The list of Node Groups with status. (optional)
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public NodeConfigurationDeployment(string resourceGroupName, string accountName, string nodeConfiguraionName,
            Management.Automation.Models.Job automationJob = null, Management.Automation.Models.JobSchedule automationJobSchedule = null,
            IList<IDictionary<string, string>> nodeGroups = null)
        {
            Requires.Argument("accountName", accountName).NotNull();
            Requires.Argument("resourceGroupName", resourceGroupName).NotNull();

            ResourceGroupName = resourceGroupName;
            AutomationAccountName = accountName;
            NodeConfigurationName = nodeConfiguraionName;

            if (automationJob == null && automationJobSchedule == null) return;
            else
            {
                if (automationJob != null)
                {
                    JobId = automationJob.Properties.JobId;
                    JobStatus = automationJob.Properties.Status;
                    Job = new Job(resourceGroupName, accountName, automationJob);
                }
                else
                {
                    JobScheduleId = automationJobSchedule.Properties.Id;
                    JobSchedule = new JobSchedule(resourceGroupName, accountName, automationJobSchedule);
                }
            }

            if (nodeGroups != null)
            {
                NodeStatus = nodeGroups;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NodeConfigurationDeployment" /> class.
        /// </summary>
        public NodeConfigurationDeployment()
        {
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
        public Guid JobId { get; set; }

        /// <summary>
        ///     Gets or sets the job id.
        /// </summary>
        public Job Job { get; set; }

        /// <summary>
        ///     Gets or sets the job status.
        /// </summary>
        public string JobStatus { get; set; }

        /// <summary>
        ///     Gets or sets list of node groups with their status.
        /// </summary>
        public IList<IDictionary<string, string>> NodeStatus { get; set; }

        /// <summary>
        ///     Gets or sets Node Configuration name.
        /// </summary>
        public string NodeConfigurationName { get; set; }

        /// <summary>
        ///     Gets or sets Job Schedule.
        /// </summary>
        public JobSchedule JobSchedule { get; set; }

        /// <summary>
        ///     Gets or sets Job Schedule Id.
        /// </summary>
        public Guid JobScheduleId { get; set; }
    }
}
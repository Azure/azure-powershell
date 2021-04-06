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

namespace Microsoft.Azure.Commands.Automation.Model.UpdateManagement
{
    using System;
    using System.Xml;
    using Management.Automation.Models;

    public class SoftwareUpdateRun : BaseProperties
    {
        internal SoftwareUpdateRun(string resourceGroupName, string automationAccountName, SoftwareUpdateConfigurationRun sucr)
        {
            this.ResourceGroupName = resourceGroupName;
            this.AutomationAccountName = automationAccountName;
            this.ComputerCount = sucr.ComputerCount.HasValue ? sucr.ComputerCount.Value : 0;    // TODO: why do we have this nullable still?
            this.ConfiguredDuration = XmlConvert.ToTimeSpan(sucr.ConfiguredDuration);
            this.CreationTime = sucr.CreationTime;
            this.EndTime = sucr.EndTime;
            this.FailedCount = sucr.FailedCount.HasValue ? sucr.FailedCount.Value : 0;
            this.LastModifiedTime = sucr.LastModifiedTime;
            this.Name = sucr.Name;
            this.OperatingSystem = (OperatingSystemType)Enum.Parse(typeof(OperatingSystemType), sucr.OsType, true);
            this.RunId = Guid.Parse(sucr.Name);
            this.SoftwareUpdateConfigurationName = sucr.SoftwareUpdateConfiguration.Name;
            this.StartTime = sucr.StartTime;
            this.Status = (SoftwareUpdateRunStatus)Enum.Parse(typeof(SoftwareUpdateRunStatus), sucr.Status, true);
            this.Tasks = TaskConverter(sucr.Tasks);
        }

        public Guid RunId { get; set; }

        public string SoftwareUpdateConfigurationName { get; set; }

        public TimeSpan ConfiguredDuration { get; set; }

        public OperatingSystemType OperatingSystem { get; set; }

        public DateTimeOffset StartTime { get; set; }

        public DateTimeOffset? EndTime { get; set; }

        public int ComputerCount { get; set; }

        public int FailedCount { get; set; }

        public SoftwareUpdateRunStatus Status { get; set; }

        public SoftareUpdateConfigurationRunTasks Tasks { get; set; }

        /// <summary>
        /// Software update configuration run tasks model. 
        /// Added temporarily to avoid breaking change
        /// </summary>
        public partial class SoftareUpdateConfigurationRunTasks
        {
            /// <summary>
            /// Initializes a new instance of the
            /// SoftwareUpdateConfigurationRunTasks class.
            /// </summary>
            public SoftareUpdateConfigurationRunTasks()
            {
                CustomInit();
            }

            /// <summary>
            /// Initializes a new instance of the
            /// SoftwareUpdateConfigurationRunTasks class.
            /// </summary>
            /// <param name="preTask">Pre task properties.</param>
            /// <param name="postTask">Post task properties.</param>
            public SoftareUpdateConfigurationRunTasks(SoftwareUpdateConfigurationRunTaskProperties preTask = default(SoftwareUpdateConfigurationRunTaskProperties), SoftwareUpdateConfigurationRunTaskProperties postTask = default(SoftwareUpdateConfigurationRunTaskProperties))
            {
                PreTask = preTask;
                PostTask = postTask;
                CustomInit();
            }

            /// <summary>
            /// An initialization method that performs custom operations like setting defaults
            /// </summary>
            partial void CustomInit();

            /// <summary>
            /// Gets or sets pre task properties.
            /// </summary>
            public SoftwareUpdateConfigurationRunTaskProperties PreTask { get; set; }

            /// <summary>
            /// Gets or sets post task properties.
            /// </summary>
            public SoftwareUpdateConfigurationRunTaskProperties PostTask { get; set; }

        }

        // SoftwareUpdateConfigurationRunTasks to SoftareUpdateConfigurationRunTasks
        // Added temporarily to avoid breaking change
        public SoftareUpdateConfigurationRunTasks TaskConverter(SoftwareUpdateConfigurationRunTasks tasks1)
        {
            SoftareUpdateConfigurationRunTasks tasks2 = new SoftareUpdateConfigurationRunTasks(tasks1.PreTask, tasks1.PostTask);
            return tasks2;
        }
    }
}

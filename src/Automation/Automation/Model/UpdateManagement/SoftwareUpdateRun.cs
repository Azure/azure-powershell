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
            this.Tasks = sucr.Tasks;
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
    }
}

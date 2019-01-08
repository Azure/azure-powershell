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
    using Management.Automation.Models;

    public class SoftwareUpdateMachineRun : BaseProperties
    {
        internal SoftwareUpdateMachineRun(string resourceGroupName, string automationAccountName, SoftwareUpdateConfigurationMachineRun sucmr)
        {
            this.ResourceGroupName = resourceGroupName;
            this.AutomationAccountName = automationAccountName;
            this.CreationTime = sucmr.CreationTime;
            this.LastModifiedTime = sucmr.LastModifiedTime;
            this.MachineRunId = Guid.Parse(sucmr.Name);
            this.Name = sucmr.Name;
            this.OperatingSystem = (OperatingSystemType)Enum.Parse(typeof(OperatingSystemType), sucmr.OsType, true);
            this.SoftwareUpdateRunId = sucmr.CorrelationId.Value;
            this.TargetComputerType = (ComputerType)Enum.Parse(typeof(ComputerType), sucmr.TargetComputerType, true);
            this.TargetComputer = sucmr.TargetComputer;
            this.Status = (SoftwareUpdateMachineRunStatus)Enum.Parse(typeof(SoftwareUpdateMachineRunStatus), sucmr.Status, true);
        }

        public Guid MachineRunId { get; set; }

        public string TargetComputer { get; set; }

        public ComputerType TargetComputerType { get; set; }

        public Guid SoftwareUpdateRunId { get; set; }

        public OperatingSystemType OperatingSystem { get; set; }

        public SoftwareUpdateMachineRunStatus Status { get; set; }
    }
}

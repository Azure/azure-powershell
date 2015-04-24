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

using System;
using System.Collections;
using Microsoft.Azure.Commands.Automation.Common;
using AutomationManagement = Microsoft.Azure.Management.Automation;

namespace Microsoft.Azure.Commands.Automation.Model
{
    /// <summary>
    /// The Dsc Node Report.
    /// </summary>
    public class DscNodeReport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DscNodeReport"/> class.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="automationAccountName">The automation account.</param>
        /// <param name="dscNodeReport">The dsc node report.</param>
        public DscNodeReport(string resourceGroupName, string automationAccountName, AutomationManagement.Models.DscNodeReport dscNodeReport)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
            Requires.Argument("dscNodeReport", dscNodeReport).NotNull();

            this.ResourceGroupName = resourceGroupName;
            this.AutomationAccountName = automationAccountName;
            this.StartTime = dscNodeReport.StartTime;
            this.EndTime = dscNodeReport.EndTime;
            this.LastModifiedTime = dscNodeReport.LastModifiedTime;
            this.ReportType = dscNodeReport.Type;
            this.Id = dscNodeReport.Id;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DscNodeReport"/> class.
        /// </summary>
        public DscNodeReport()
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
        /// Gets or sets the start time.
        /// </summary>
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// Gets or sets the last modified time.
        /// </summary>
        public DateTimeOffset LastModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        public DateTimeOffset EndTime { get; set; }

        /// <summary>
        /// Gets or sets the report type.
        /// </summary>
        public string ReportType { get; set; }

        /// <summary>
        /// Gets or sets the id of the node report.
        /// </summary>
        public string Id { get; set; }
    }
}

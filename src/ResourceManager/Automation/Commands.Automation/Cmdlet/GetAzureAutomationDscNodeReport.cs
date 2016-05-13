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
using Microsoft.Azure.Commands.Automation.Model;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Gets azure automation dsc node report.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmAutomationDscNodeReport", DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(DscNode))]
    public class GetAzureAutomationDscNodeReport : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// True to get latest the dsc report; false otherwise.
        /// </summary>        
        private bool latestReport;

        /// <summary> 
        /// Gets or sets the node id. 
        /// </summary> 
        [Parameter(Mandatory = true, ParameterSetName = AutomationCmdletParameterSets.ByLatest, ValueFromPipelineByPropertyName = true, HelpMessage = "The dsc node id.")]
        [Parameter(Mandatory = true, ParameterSetName = AutomationCmdletParameterSets.ByAll, ValueFromPipelineByPropertyName = true, HelpMessage = "The dsc node id.")]
        [Parameter(Mandatory = true, ParameterSetName = AutomationCmdletParameterSets.ById, ValueFromPipelineByPropertyName = true, HelpMessage = "The dsc node id.")]
        public Guid NodeId { get; set; }

        /// <summary>
        /// Gets or sets the switch parameter to get latest dsc report
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AutomationCmdletParameterSets.ByLatest, HelpMessage = "Get Latest Dsc report.")]
        public SwitchParameter Latest
        {
            get { return this.latestReport; }
            set { this.latestReport = value; }
        }

        /// <summary> 
        /// Gets or sets the node report id. 
        /// </summary> 
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ById, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The dsc node report id.")]
        [Alias("ReportId")]
        public Guid Id { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = AutomationCmdletParameterSets.ByAll, ValueFromPipelineByPropertyName = true, HelpMessage = "Retrieves all reports created after this time")]
        public DateTimeOffset? StartTime { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = AutomationCmdletParameterSets.ByAll, ValueFromPipelineByPropertyName = true, HelpMessage = "Retrieves all reports received before this time")]
        public DateTimeOffset? EndTime { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            IEnumerable<DscNodeReport> ret = null;

            if (this.ParameterSetName == AutomationCmdletParameterSets.ByLatest)
            {
                ret = new List<DscNodeReport>
                {
                   this.AutomationClient.GetLatestDscNodeReport(this.ResourceGroupName, this.AutomationAccountName, this.NodeId)
                };
            }
            else if (this.ParameterSetName == AutomationCmdletParameterSets.ById)
            {
                ret = new List<DscNodeReport>
                {
                    this.AutomationClient.GetDscNodeReportByReportId(this.ResourceGroupName, this.AutomationAccountName, this.NodeId, this.Id)
                };
            }
            else
            {
                ret = this.AutomationClient.ListDscNodeReports(
                    this.ResourceGroupName,
                    this.AutomationAccountName,
                    this.NodeId,
                    this.StartTime,
                    this.EndTime);
            }

            this.GenerateCmdletOutput(ret);
        }
    }
}

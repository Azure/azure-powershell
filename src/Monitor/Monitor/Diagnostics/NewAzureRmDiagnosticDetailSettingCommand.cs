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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Insights.Diagnostics
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DiagnosticDetailSetting", DefaultParameterSetName = MetricSettingParameterSet), OutputType(typeof(PSDiagnosticDetailSettings))]
    public class NewAzureRmDiagnosticDetailSettingCommand : ManagementCmdletBase
    {
        public const string LogSettingParameterSet = "LogSettingParameterSet";
        public const string MetricSettingParameterSet = "MetricSettingParameterSet";

        #region Parameters declarations

        [Parameter(ParameterSetName = LogSettingParameterSet, Mandatory = true, HelpMessage = "To create log setting")]
        public SwitchParameter Log { get; set; }

        [Parameter(ParameterSetName = MetricSettingParameterSet, Mandatory = true, HelpMessage = "To create metric setting")]
        public SwitchParameter Metric { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Retention days for retention policy")]
        public int RetentionInDays { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enable Retention policy")]
        public SwitchParameter RetentionEnabled { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Category of setting")]
        public string Category { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enable the setting")]
        public SwitchParameter Enabled { get; set; }

        [Parameter(ParameterSetName = MetricSettingParameterSet, Mandatory = false, HelpMessage = "TimeGrain for metric setting")]
        public System.TimeSpan? TimeGrain { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            
            
            PSRetentionPolicy policy;
            if (!this.IsParameterBound(c => c.RetentionInDays) && !this.IsParameterBound(c => c.RetentionEnabled))
            {
                policy = null;
            }
            else
            {
                policy = new PSRetentionPolicy()
                {
                    Days = this.IsParameterBound(c => c.RetentionInDays) ? this.RetentionInDays : 0,
                    Enabled = this.IsParameterBound(c => RetentionEnabled) ? true : false
                };
            }

            PSDiagnosticDetailSettings setting;

            if (this.ParameterSetName.Equals(LogSettingParameterSet))
            {
                setting = new PSLogSettings()
                {
                    RetentionPolicy = policy,
                    Category = this.Category,
                    Enabled = this.IsParameterBound(c => c.Enabled) ? true : false,
                    CategoryType = PSDiagnosticSettingCategoryType.Logs
                };
            }
            else
            {
                setting = new PSMetricSettings()
                {
                    RetentionPolicy = policy,
                    Category = this.Category,
                    Enabled = this.IsParameterBound(c => c.Enabled) ? true : false,
                    TimeGrain = this.TimeGrain ?? default(System.TimeSpan),
                    CategoryType = PSDiagnosticSettingCategoryType.Metrics
                };
            }

            WriteObject(setting);
        }
    }
}

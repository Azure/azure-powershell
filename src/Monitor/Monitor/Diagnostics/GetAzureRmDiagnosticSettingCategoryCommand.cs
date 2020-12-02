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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Insights.Diagnostics
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DiagnosticSettingCategory"), OutputType(typeof(PSDiagnosticSettingCategory))]
    public class GetAzureRmDiagnosticSettingCategoryCommand : ManagementCmdletBase
    {
        #region Parameters declarations

        [Parameter(Mandatory = true, HelpMessage = "Target resource Id")]
        [ValidateNotNullOrEmpty]
        public string TargetResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of diagnostic setting category")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            if (this.IsParameterBound(c => c.Name))
            {
                WriteObject(new PSDiagnosticSettingCategory(this.MonitorManagementClient
                                                                .DiagnosticSettingsCategory
                                                                .Get(TargetResourceId, Name)));
            }
            else
            {
                WriteObject(this.MonitorManagementClient
                                .DiagnosticSettingsCategory
                                .List(TargetResourceId)
                                .Value
                                .Select(x => new PSDiagnosticSettingCategory(x)).ToList(), true);
            }
        }
    }
}

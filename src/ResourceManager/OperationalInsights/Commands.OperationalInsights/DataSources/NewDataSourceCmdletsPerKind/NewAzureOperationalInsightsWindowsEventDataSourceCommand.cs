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

using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.OperationalInsights.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    [Cmdlet(VerbsCommon.New, "AzureRmOperationalInsightsWindowsEventDataSource", SupportsShouldProcess = true, 
        DefaultParameterSetName = ByWorkspaceName), OutputType(typeof(PSDataSource))]
    public class NewAzureOperationalInsightsWindowsEventDataSourceCommand : NewAzureOperationalInsightsDataSourceBaseCmdlet
    {
        [Parameter(Position = 4, Mandatory = true, ValueFromPipelineByPropertyName = true,
        HelpMessage = "The name of Windows EventLog.")]
        [ValidateNotNullOrEmpty]
        public string EventLogName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Collect error events.")]
        public SwitchParameter CollectErrors { get; set; }
        [Parameter(Mandatory = false, HelpMessage = "Collect warning events.")]
        public SwitchParameter CollectWarnings { get; set; }
        [Parameter(Mandatory = false, HelpMessage = "Collect information events.")]
        public SwitchParameter CollectInformation { get; set; }

        public override void ExecuteCmdlet()
        {
            List<WindowsEventTypeIdentifier> eventTypeInstances = new List<WindowsEventTypeIdentifier>();
            if (CollectErrors.IsPresent) {
                eventTypeInstances.Add(new WindowsEventTypeIdentifier { eventType = WindowsEventType.Error });
            }
            if (CollectWarnings.IsPresent)
            {
                eventTypeInstances.Add(new WindowsEventTypeIdentifier { eventType = WindowsEventType.Warning });
            }
            if (CollectInformation.IsPresent)
            {
                eventTypeInstances.Add(new WindowsEventTypeIdentifier { eventType = WindowsEventType.Information });
            }

            if (eventTypeInstances.Count == 0)
            {
                throw new ArgumentException(Resources.DataSourceWindowsEventNoEventTypeSelected);
            }

            var auditLogProperties = new PSWindowsEventDataSourceProperties
            {
                EventLogName = this.EventLogName,
                EventTypes = eventTypeInstances
            };


            CreatePSDataSourceWithProperties(auditLogProperties);
        }
    }
}
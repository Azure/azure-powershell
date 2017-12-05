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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    [Cmdlet(VerbsCommon.New, "AzureRmOperationalInsightsLinuxPerformanceObjectDataSource", SupportsShouldProcess = true, 
        DefaultParameterSetName = ByWorkspaceName), OutputType(typeof(PSDataSource))]
    public class NewAzureOperationalInsightsLinuxPerformanceObjectDataSourceCommand : NewAzureOperationalInsightsDataSourceBaseCmdlet
    {
        [Parameter(Position = 0, ParameterSetName = ByWorkspaceObject, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = "The workspace that will contain the data source.")]
        [ValidateNotNull]
        public override PSWorkspace Workspace { get; set; }

        [Parameter(Position = 1, ParameterSetName = ByWorkspaceName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(Position = 2, ParameterSetName = ByWorkspaceName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the workspace that will contain the data source.")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data source name.")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(Position = 4, Mandatory = true, ValueFromPipelineByPropertyName = true,
        HelpMessage = "The name of object name of Linux Performance Counter.")]
        [ValidateNotNullOrEmpty]
        public string ObjectName { get; set; }

        [Parameter(Position = 5, Mandatory = true, ValueFromPipelineByPropertyName = true,
        HelpMessage = "The array of countername for Linux Performance Counter.")]
        [ValidateNotNullOrEmpty]
        public string[] CounterNames { get; set; }

        private string _InstanceName = "*";
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
        HelpMessage = "The name of instance name of Linux Performance Counter.")]
        [ValidateNotNullOrEmpty]
        public string InstanceName
        {
            get { return _InstanceName; }
            set { _InstanceName = value; }
        }

        private int _InternalSeconds = 15;
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
        HelpMessage = "The interval to collect performance counter.")]
        [ValidateNotNullOrEmpty]
        public int IntervalSeconds
        {
            get { return _InternalSeconds; }
            set { _InternalSeconds = value; }
        }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public override SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            List<PerformanceCounterIdentifier> counterNameSubscription = this.CounterNames.Select(counterName => new PerformanceCounterIdentifier { CounterName = counterName }).ToList();
            
            var dsProperties = new PSLinuxPerformanceObjectDataSourceProperties
            {
                ObjectName = this.ObjectName,
                InstanceName = this.InstanceName,
                IntervalSeconds = this.IntervalSeconds,
                PerformanceCounters = counterNameSubscription
            };
            
            CreatePSDataSourceWithProperties(dsProperties);
        }
    }
}
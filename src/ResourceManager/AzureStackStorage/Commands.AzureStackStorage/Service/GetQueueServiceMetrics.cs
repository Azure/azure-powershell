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

using Microsoft.AzureStack.AzureConsistentStorage.Commands;
using Microsoft.AzureStack.AzureConsistentStorage;
using Microsoft.AzureStack.AzureConsistentStorage.Models;
using System;
using System.Management.Automation;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    /// <summary>
    ///     SYNTAX
    ///          Get-QueueServiceMetric [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///             [-SkipCertificateValidation] [-FarmName] {string}
    ///             [[-StartTime] {DateTime}] [[-EndTime] {DateTime}] [[-TimeGrain] {TimeGrain}] [[-MetricNames] {string[]}] [ {CommonParameters}]
    /// 
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminQueueServiceMetric)]
    public sealed class GetQueueServiceMetrics : AdminCmdlet
    {
        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string ResourceGroupName { get; set; }

        /// <summary>
        ///     Farm Identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 4)]
        [ValidateNotNull]
        public string FarmName { get; set; }

        /// <summary>
        ///     start time
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public DateTime StartTime { get; set; }

        /// <summary>
        ///     end time
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public DateTime EndTime { get; set; }

        /// <summary>
        ///     time grain
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public TimeGrain TimeGrain { get; set; }

        /// <summary>
        /// Array of metric names
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string[] MetricNames
        {
            get;
            set;
        }

        protected override void Execute()
        {
            string filter = Tools.GenerateFilter(MetricNames, StartTime, EndTime, TimeGrain);
            WriteVerbose("filter: " + filter);

            MetricsResult node = Client.QueueService.GetMetrics(ResourceGroupName, FarmName, filter);
            WriteObject(node);
        }
    }
}
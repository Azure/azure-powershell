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

using Microsoft.Azure.Commands.StreamAnalytics.Models;
using Microsoft.Azure.Commands.StreamAnalytics.Properties;
using Microsoft.Azure.Management.StreamAnalytics.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using System.Globalization;
using System.Management.Automation;
using System.Net;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.StreamAnalytics
{
    [GenericBreakingChange("The parameters of Start-AzStreamAnalyticsJob will be updated in an upcoming breaking change release.", "2.0.0")]
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StreamAnalyticsJob"), OutputType(typeof(bool))]
    public class StartAzureStreamAnalyticsJobCommand : StreamAnalyticsResourceProviderBaseCmdlet
    {
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The azure stream analytics job name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The desired output start mode for the azure stream analytics job.")]
        [ValidateNotNullOrEmpty]
        public string OutputStartMode { get; set; }

        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The desired output start time for the azure stream analytics job.")]
        [ValidateNotNullOrEmpty]
        public DateTime? OutputStartTime { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            if (ResourceGroupName != null && string.IsNullOrWhiteSpace(ResourceGroupName))
            {
                throw new PSArgumentNullException("ResourceGroupName");
            }

            StartPSJobParameter parameter = new StartPSJobParameter()
            {
                ResourceGroupName = ResourceGroupName,
                JobName = Name,
                StartParameters = new StartStreamingJobParameters()
                {
                    OutputStartMode = OutputStartMode,
                    OutputStartTime = OutputStartTime
                }
            };

            try
            {
                StreamAnalyticsClient.StartPSJob(parameter);
                WriteObject(true);
            }
            catch
            {
                WriteObject(false);
            }
        }
    }
}

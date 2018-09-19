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
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services;

namespace Microsoft.WindowsAzure.Commands.Websites
{
    /// <summary>
    /// Gets an azure website.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureWebsiteLog"), OutputType(typeof(string))]
    public class GetAzureWebsiteLogCommand : DeploymentBaseCmdlet
    {
        private const string TailParameterSet = "Tail";

        private const string ListPathParameterSet = "ListPath";

        public Predicate<string> StopCondition;

        public const int WaitInterval = 10000;

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, 
            ParameterSetName = TailParameterSet, HelpMessage = "The log path.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, 
            ParameterSetName = TailParameterSet, HelpMessage = "The search subsrting.")]
        [ValidateNotNullOrEmpty]
        public string Message { get; set; }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = TailParameterSet, HelpMessage = "The log streaming switch.")]
        public SwitchParameter Tail { get; set; }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = ListPathParameterSet, HelpMessage = "List the available paths")]
        public SwitchParameter ListPath { get; set; }

        /// <summary>
        /// Initializes a new instance of the GetAzureWebsiteLogCommand class.
        /// </summary>
        public GetAzureWebsiteLogCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the GetAzureWebsiteLogCommand class.
        /// </summary>
        /// <param name="deploymentChannel">
        /// Channel used for communication with the git repository.
        /// </param>
        public GetAzureWebsiteLogCommand(
            IDeploymentServiceManagement deploymentChannel)
        {
            DeploymentChannel = deploymentChannel;
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (Tail.IsPresent)
            {
                foreach (string logLine in WebsitesClient.StartLogStreaming(
                    Name,
                    Slot,
                    Path,
                    Message,
                    StopCondition,
                    WaitInterval))
                {
                    WriteObject(logLine);
                }
            }
            else if (ListPath.IsPresent)
            {
                WriteObject(WebsitesClient.ListLogPaths(Name, Slot).Select(i => i.Name), true);
            }
        }
    }
}

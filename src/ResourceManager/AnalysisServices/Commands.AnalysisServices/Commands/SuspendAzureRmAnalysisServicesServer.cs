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

using Microsoft.Azure.Commands.AnalysisServices.Models;
using Microsoft.Azure.Management.Analysis;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.AnalysisServices.Properties;
using Microsoft.Azure.Management.Analysis.Models;

namespace Microsoft.Azure.Commands.AnalysisServices
{
    [Cmdlet(VerbsLifecycle.Suspend, "AzureRmAnalysisServicesServer",
        DefaultParameterSetName = BaseParameterSetName,
        SupportsShouldProcess = true),
     OutputType(typeof(List<AnalysisServicesServer>))]
    [Alias("Suspend-AzureAs")]
    public class SuspendAzureAnalysisServicesServer : AnalysisServicesCmdletBase
    {
        internal const string BaseParameterSetName = "All In Subscription";
        internal const string ResourceGroupParameterSetName = "All In Resource Group";
        internal const string ServerParameterSetName = "Specific Server";

        [Parameter(ParameterSetName = ServerParameterSetName, Position = 1, ValueFromPipelineByPropertyName = true,
            Mandatory = false, HelpMessage = "Name of resource group under which to retrieve the server.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ServerParameterSetName, Position = 0, ValueFromPipelineByPropertyName = true,
            Mandatory = true, HelpMessage = "Name of a specific server.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                // Get for single server
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Resources.SuspendAnalysisServicesServer, Name),
                    string.Format(Resources.SuspendingAnalysisServicesServer, Name),
                    Name,
                    () => AnalysisServicesClient.SuspendServer(ResourceGroupName, Name));
            }
            else
            {
                WriteExceptionError(new PSArgumentNullException("Name", "Name of server not specified"));
            }
        }
    }
}
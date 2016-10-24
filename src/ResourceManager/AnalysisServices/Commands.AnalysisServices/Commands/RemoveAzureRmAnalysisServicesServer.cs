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
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.AnalysisServices.Models;
using Microsoft.Azure.Commands.AnalysisServices.Properties;
using Microsoft.Azure.Management.Analysis.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.AnalysisServices
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmAnalysisServicesServer", SupportsShouldProcess = true), 
        OutputType(typeof(bool))]
    [Alias("Remove-AzureAs")]
    public class RemoveAnalysisServicesServer : AnalysisServicesCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Name of server to be removed.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = false,
            HelpMessage = "Name of resource group under which the server exists.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Position = 3, Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            AnalysisServicesServer server = null;
            if (!AnalysisServicesClient.TestServer(ResourceGroupName, Name, out server))
            {
                throw new InvalidOperationException(string.Format(Properties.Resources.ServerDoesNotExist, Name));
            }

            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemoveAnalysisServicesServer, Name),
                string.Format(Resources.RemovingAnalysisServicesServer, Name),
                Name,
                () => AnalysisServicesClient.DeleteServer(ResourceGroupName, Name));

            if (PassThru)
            {
                WriteObject(server);
            }
        }
    }
}
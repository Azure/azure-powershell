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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.AnalysisServices
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmAnalysisServicesServer", SupportsShouldProcess = true), 
        OutputType(typeof(AzureAnalysisServicesServer))]
    [Alias("Remove-AzureAs")]
    public class RemoveAnalysisServicesServer : AnalysisServicesCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Name of server to be removed.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = false,
            HelpMessage = "Name of resource group under which the server exists.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(Name))
            {
                WriteExceptionError(new PSArgumentNullException("Name", "Name of server not specified"));
            }

            if (ShouldProcess(Name, Resources.RemovingAnalysisServicesServer))
            {
                AnalysisServicesServer server = null;
                if (!AnalysisServicesClient.TestServer(ResourceGroupName, Name, out server))
                {
                    throw new InvalidOperationException(string.Format(Properties.Resources.ServerDoesNotExist, Name));
                }

                AnalysisServicesClient.DeleteServer(ResourceGroupName, Name);

                if (PassThru.IsPresent)
                {
                    WriteObject(AzureAnalysisServicesServer.FromAnalysisServicesServer(server));
                }
            }
        }
    }
}
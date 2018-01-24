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
using Microsoft.Azure.Commands.AnalysisServices.Models;
using Microsoft.Azure.Commands.AnalysisServices.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Analysis.Models;

namespace Microsoft.Azure.Commands.AnalysisServices
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmAnalysisServicesServerGateway", SupportsShouldProcess = true),
       OutputType(typeof(AzureAnalysisServicesServer))]
    [Alias("Remove-AzureAsGateway")]
    public class RemoveAzureRmAnalysisServicesServerGateway : AnalysisServicesCmdletBase
    {
        [Parameter(Position = 0,
            ValueFromPipelineByPropertyName = true, Mandatory = true,
            HelpMessage = "Name of resource group under which the user want to retrieve the server.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true,
            Mandatory = true, HelpMessage = "Name of a specific server.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(Name))
            {
                WriteExceptionError(new PSArgumentNullException("Name", "Name of server not specified"));
            }

            if (ShouldProcess(Name, Resources.UpdatingAnalysisServicesServer))
            {
                AnalysisServicesServer server = null;
                if (!AnalysisServicesClient.TestServer(ResourceGroupName, Name, out server))
                {
                    throw new InvalidOperationException(string.Format(Properties.Resources.ServerDoesNotExist, Name));
                }

                if (server.GatewayDetails != null)
                {
                    server = AnalysisServicesClient.DissociateGateway(ResourceGroupName, Name);
                }

                if (PassThru.IsPresent)
                {
                    WriteObject(AzureAnalysisServicesServer.FromAnalysisServicesServer(server));
                }
            }
        }
    }
}

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

using System.Management.Automation;
using Microsoft.Azure.Commands.AnalysisServices.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Analysis.Models;

namespace Microsoft.Azure.Commands.AnalysisServices
{
    [Cmdlet(VerbsCommon.Get, "AzureRmAnalysisServicesServerGatewayStatus"),
        OutputType(typeof(string))]
    [Alias("Get-AzureAsGateway")]
    public class GetAzureAnalysisServicesServerGatewayStatus: AnalysisServicesCmdletBase
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

        public override void ExecuteCmdlet()
        {
            try
            {
                var gatewayStatus = AnalysisServicesClient.GetGatewayStatus(ResourceGroupName, Name);
                WriteObject(gatewayStatus.Status.Value);
            }
            catch(GatewayListStatusErrorException ex)
            {
                var errorMessage = ex.Body.Error.Message.ToString();
                WriteObject(errorMessage);
            }
        }
    }
}

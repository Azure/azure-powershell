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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Analysis.Models;

namespace Microsoft.Azure.Commands.AnalysisServices
{
    [Cmdlet(VerbsCommon.Get, "AzureRmAnalysisServicesGateway"),
        OutputType(typeof(GatewayInfo))]
    [Alias("Get-AzureAsGateway")]
    public class GetAzureAnalysisServicesServerGateway: AnalysisServicesCmdletBase
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
			AnalysisServicesServer currentServer = null;
			if (!AnalysisServicesClient.TestServer(ResourceGroupName, Name, out currentServer))
			{
				throw new InvalidOperationException(string.Format(Properties.Resources.ServerDoesNotExist, Name));
			}

			GatewayInfo gatewayInfo = new GatewayInfo();

			if (currentServer.GatewayDetails == null || currentServer.GatewayDetails.GatewayResourceId == null)
			{
				gatewayInfo.status = string.Format("Current Ananlysis Server {0} is not associated with any gateway.", Name);
				WriteObject(gatewayInfo);
			}
			else {
				try
				{
					gatewayInfo = AnalysisServicesClient.GetGatewayInfo(currentServer.GatewayDetails.GatewayResourceId);
					gatewayInfo.status = AnalysisServicesClient.GetGatewayStatus(ResourceGroupName, Name).Status.ToString();
					WriteObject(gatewayInfo);
				}
				catch (GatewayListStatusErrorException ex)
				{
					gatewayInfo.status = ex.Body.Error.Message.ToString();
					WriteObject(gatewayInfo);
				}
			}
        }
    }
}

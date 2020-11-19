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
// ------------------------------------

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.SecurityInsights;
using Microsoft.Azure.Commands.SecurityInsights.Common;
using Microsoft.Azure.Commands.SecurityInsights.Models.DataConnectors;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Linq;
using Microsoft.Azure.Management.SecurityInsights;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.DataConnectors
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelDataConnector", DefaultParameterSetName = ParameterSetNames.WorkspaceScope), OutputType(typeof(PSSentinelDataConnector))]
    public class GetDataConnectors : SecurityInsightsCmdletBase
    {
        private const int MaxDataConnectorsToFetch = 1500;

        [Parameter(ParameterSetName = ParameterSetNames.WorkspaceScope, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = ParameterSetNames.DataConnectorId, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.WorkspaceScope, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = ParameterSetNames.DataConnectorId, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.DataConnectorId, Mandatory = true, HelpMessage = ParameterHelpMessages.DataConnectorId)]
        [ValidateNotNullOrEmpty]
        public string DataConnectorId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            int numberOfFetchedDataConnectors = 0;
            string nextLink = null;
            switch (ParameterSetName)
            {
                case ParameterSetNames.WorkspaceScope:
                    var dataconnectors = SecurityInsightsClient.DataConnectors.List(ResourceGroupName, WorkspaceName);
                    int dataconnectorscount = dataconnectors.Count();
                    WriteObject(dataconnectors.ConvertToPSType(), enumerateCollection: true);
                    numberOfFetchedDataConnectors += dataconnectorscount;
                    nextLink = dataconnectors?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink) && numberOfFetchedDataConnectors < MaxDataConnectorsToFetch)
                    {
                        dataconnectors = SecurityInsightsClient.DataConnectors.ListNext(dataconnectors.NextPageLink);
                        dataconnectorscount = dataconnectors.Count();
                        WriteObject(dataconnectors.ConvertToPSType(), enumerateCollection: true);
                        numberOfFetchedDataConnectors += dataconnectorscount;
                        nextLink = dataconnectors?.NextPageLink;
                    }
                    break;
                case ParameterSetNames.DataConnectorId:
                    var dataconnector = SecurityInsightsClient.DataConnectors.Get(ResourceGroupName, WorkspaceName, DataConnectorId);
                    WriteObject(dataconnector.ConvertToPSType(), enumerateCollection: false);
                    break;
                case ParameterSetNames.ResourceId:
                    dataconnector = SecurityInsightsClient.DataConnectors.Get(ResourceGroupName, WorkspaceName, AzureIdUtilities.GetResourceName(ResourceId));
                    WriteObject(dataconnector.ConvertToPSType(), enumerateCollection: false);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}

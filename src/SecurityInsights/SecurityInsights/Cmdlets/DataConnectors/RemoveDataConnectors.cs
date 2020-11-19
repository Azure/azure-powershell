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

using System.Management.Automation;
using Microsoft.Azure.Commands.SecurityInsights;
using Microsoft.Azure.Commands.SecurityInsights.Common;
using Microsoft.Azure.Commands.SecurityInsights.Models.DataConnectors;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.SecurityInsights;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.DataConnectors
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelDataConnector", DefaultParameterSetName = ParameterSetNames.DataConnectorId, SupportsShouldProcess = true), OutputType(typeof(PSSentinelDataConnector))]
    public class RemoveDataConnectors : SecurityInsightsCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.DataConnectorId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AlertRuleId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AlertRuleId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DataConnectorId)]
        [ValidateNotNullOrEmpty]
        public string DataConnectorId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.InputObject)]
        [ValidateNotNullOrEmpty]
        public PSSentinelDataConnector InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            var name = DataConnectorId;

            switch (ParameterSetName)
            {
                case ParameterSetNames.DataConnectorId:
                    break;
                case ParameterSetNames.InputObject:
                    name = InputObject.Name;
                    break;
                default:
                    throw new PSInvalidOperationException();
            }

            if (ShouldProcess(name, VerbsCommon.Remove))
            {
                SecurityInsightsClient.DataConnectors.Delete(ResourceGroupName, WorkspaceName, name);
            }

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}

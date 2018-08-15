﻿// ----------------------------------------------------------------------------------
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

using System.Globalization;
using System.Management.Automation;
using System.Net;
using System.Security.Permissions;
using Microsoft.Azure.Commands.DataFactoryV2.Properties;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataFactoryV2IntegrationRuntimeNode",DefaultParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,SupportsShouldProcess = true), OutputType(typeof(void))]
    public class RemoveAzureDataFactoryIntegrationRuntimeNodeCommand : IntegrationRuntimeContextBaseCmdlet
    {
        [Parameter(Mandatory = true,
            HelpMessage = Constants.HelpIntegrationRuntimeNodeName)]
        [ValidateNotNullOrEmpty]
        public string NodeName { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = Constants.HelpDontAskConfirmation)]
        public SwitchParameter Force { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            this.ByResourceId();
            this.ByIntegrationRuntimeObject();

            // ValidationNotNullOrEmpty doesn't handle whitespaces well
            if (string.IsNullOrWhiteSpace(NodeName))
            {
                throw new PSArgumentNullException("NodeName");
            }

            ConfirmAction(
                Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IntegrationRuntimeNodeConfirmationMessage,
                    NodeName,
                    IntegrationRuntimeName),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IntegrationRuntimeNodeRemoving,
                    NodeName,
                    IntegrationRuntimeName),
                IntegrationRuntimeName,
                ExecuteRemoveNode);
        }

        private void ExecuteRemoveNode()
        {
            var response = DataFactoryClient.RemoveIntegrationRuntimeNodeAsync(
                ResourceGroupName,
                DataFactoryName,
                IntegrationRuntimeName,
                NodeName).ConfigureAwait(true).GetAwaiter().GetResult();

            if (response == HttpStatusCode.NoContent)
            {
                WriteWarning(string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IntegrationRuntimeNodeNotFound,
                    NodeName,
                    IntegrationRuntimeName));
            }
        }
    }
}

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
using System.Globalization;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Commands.DataFactoryV2.Properties;
using Microsoft.Azure.Management.DataFactory.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet(
        VerbsData.Update,
        Constants.IntegrationRuntimeNode,
        DefaultParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
        SupportsShouldProcess = true),
     OutputType(typeof(PSSelfHostedIntegrationRuntimeNode))]
    public class UpdateAzureDataFactoryIntegrationRuntimeNodeCommand : IntegrationRuntimeContextBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpIntegrationRuntimeNodeName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpIntegrationRuntimeJobsLimit)]
        public int ConcurrentJobsLimit { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            this.ByResourceId();
            this.ByIntegrationRuntimeObject();

            Action updateIntegrationRuntimeNode = () =>
            {
                var node = this.DataFactoryClient.UpdateIntegrationRuntimeNodesAsync(
                    ResourceGroupName,
                    DataFactoryName,
                    IntegrationRuntimeName,
                    Name,
                    new UpdateIntegrationRuntimeNodeRequest()
                    {
                        ConcurrentJobsLimit = ConcurrentJobsLimit
                    }).ConfigureAwait(false).GetAwaiter().GetResult();

                WriteObject(new PSSelfHostedIntegrationRuntimeNode(
                    ResourceGroupName,
                    DataFactoryName,
                    IntegrationRuntimeName,
                    Name,
                    node,
                    null));
            };

            ConfirmAction(
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IntegrationRuntimeNodeUpdating,
                    Name),
                Name,
                updateIntegrationRuntimeNode);
        }
    }
}

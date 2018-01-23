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

using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.DataFactoryV2.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet(VerbsCommon.Get,
        Constants.IntegrationRuntime,
        DefaultParameterSetName = ParameterSetNames.ByIntegrationRuntimeName),
        OutputType(typeof(List<PSIntegrationRuntime>), typeof(PSManagedIntegrationRuntime), typeof(PSSelfHostedIntegrationRuntime))]
    public class GetAzureDataFactoryIntegrationRuntimeCommand : IntegrationRuntimeCmdlet
    {
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpIntegrationRuntimeName)]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.IntegrationRuntimeName)]
        public new string Name { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeStatus)]
        public SwitchParameter Status { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            this.ByResourceId();
            this.ByIntegrationRuntimeObject();

            if (Name == null)
            {
                var integrationRuntimes = DataFactoryClient.ListIntegrationRuntimesAsync(
                    new AdfEntityFilterOptions
                    {
                        ResourceGroupName = ResourceGroupName,
                        DataFactoryName = DataFactoryName
                    }).ConfigureAwait(true).GetAwaiter().GetResult();

                WriteObject(integrationRuntimes, true);
            }
            else
            {
                if (Status.IsPresent)
                {
                    var integrationRuntime = DataFactoryClient.GetIntegrationRuntimeStatusAsync(
                        ResourceGroupName,
                        DataFactoryName,
                        Name).ConfigureAwait(true).GetAwaiter().GetResult();

                    WriteObject(integrationRuntime);
                }
                else
                {
                    var integrationRuntime = DataFactoryClient.GetIntegrationRuntimeAsync(
                        ResourceGroupName,
                        DataFactoryName,
                        Name).ConfigureAwait(true).GetAwaiter().GetResult();

                    WriteObject(integrationRuntime);
                }
            }
        }
    }
}
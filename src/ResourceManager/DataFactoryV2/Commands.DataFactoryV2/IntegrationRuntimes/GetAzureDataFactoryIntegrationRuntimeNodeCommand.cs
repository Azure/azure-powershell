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
using System.Linq;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.DataFactoryV2.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet(
        VerbsCommon.Get,
        Constants.IntegrationRuntimeNode,
        DefaultParameterSetName = ParameterSetNames.ByIntegrationRuntimeName),
        OutputType(typeof(PSManagedIntegrationRuntimeNode), typeof(PSSelfHostedIntegrationRuntimeNode))]
    public class GetAzureDataFactoryIntegrationRuntimeNodeCommand : IntegrationRuntimeContextBaseCmdlet
    {
        [Parameter(Mandatory = true,
            HelpMessage = Constants.HelpIntegrationRuntimeNodeName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeNodeIpAddress)]
        public SwitchParameter IpAddress { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            this.ByResourceId();
            this.ByIntegrationRuntimeObject();

            var status = DataFactoryClient.GetIntegrationRuntimeStatusAsync(ResourceGroupName, DataFactoryName,
                IntegrationRuntimeName).ConfigureAwait(false).GetAwaiter().GetResult();

            var managedStatus = status as PSManagedIntegrationRuntimeStatus;
            if (managedStatus != null)
            {
                if (IpAddress.IsPresent)
                {
                    ThrowTerminatingError
                        (new ErrorRecord(
                            new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                                "The SSIS-Azure integration runtime does not support getting IP address of node.")),
                            string.Empty,
                            ErrorCategory.ObjectNotFound,
                            null));
                }

                var node = managedStatus.Nodes.FirstOrDefault(n => n.NodeId == Name);
                if (node == null)
                {
                    ThrowTerminatingError
                        (new ErrorRecord(
                            new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                                "The node with node ID {0} in integration runtime {1} was not found.", Name, IntegrationRuntimeName)),
                            string.Empty,
                            ErrorCategory.ObjectNotFound,
                            null));
                }

                WriteObject(new PSManagedIntegrationRuntimeNode(ResourceGroupName, DataFactoryName, IntegrationRuntimeName, Name, node));                
            }

            var selfHostedStatus = status as PSSelfHostedIntegrationRuntimeStatus;
            if (selfHostedStatus != null)
            {
                var node = selfHostedStatus.Nodes.FirstOrDefault(n => n.NodeName == Name);
                if (node == null)
                {
                    ThrowTerminatingError
                        (new ErrorRecord(
                            new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                                "The node with node name {0} in integration runtime {1} was not found.", Name, IntegrationRuntimeName)),
                            string.Empty,
                            ErrorCategory.ObjectNotFound,
                            null));
                }

                string ipAddress = null;
                if (IpAddress.IsPresent)
                {
                    var ip = DataFactoryClient.GetIntegrationRuntimeNodeIpAsync(
                        ResourceGroupName,
                        DataFactoryName,
                        IntegrationRuntimeName,
                        Name).ConfigureAwait(false).GetAwaiter().GetResult();
                    ipAddress = ip.IpAddress;
                }

                WriteObject(new PSSelfHostedIntegrationRuntimeNode(ResourceGroupName, DataFactoryName, IntegrationRuntimeName, Name, node, ipAddress));
            }
        }
    }
}

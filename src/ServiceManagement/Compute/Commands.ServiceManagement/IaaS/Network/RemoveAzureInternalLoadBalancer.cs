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
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.Azure;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsCommon.Remove, "AzureInternalLoadBalancer"), OutputType(typeof(ManagementOperationContext))]
    public class RemoveAzureInternalLoadBalancer : ServiceManagementBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Service Name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            ExecuteClientActionNewSM(null,
                CommandRuntime.ToString(),
                () =>
                {
                    AzureOperationResponse op = null;
                    var deployment = this.ComputeClient.Deployments.GetBySlot(this.ServiceName, DeploymentSlot.Production);
                    if (deployment.LoadBalancers != null && deployment.LoadBalancers.Any())
                    {
                        foreach (var b in deployment.LoadBalancers)
                        {
                            if (string.Equals(GetLoadBalancerType(b), FrontendIPConfigurationType.Private, StringComparison.OrdinalIgnoreCase))
                            {
                                op = this.ComputeClient.LoadBalancers.Delete(this.ServiceName, deployment.Name, b.Name);
                            }
                        }
                    }

                    return op;
                });
        }

        protected string GetLoadBalancerType(LoadBalancer b)
        {
            if (b != null && b.FrontendIPConfiguration != null)
            {
                return b.FrontendIPConfiguration.Type;
            }

            return null;
        }
    }
}

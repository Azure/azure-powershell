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
using Microsoft.Azure.Management.DataFactory.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2.Models
{
    public class PSSelfHostedIntegrationRuntime : PSIntegrationRuntime
    {
        public PSSelfHostedIntegrationRuntime(
            IntegrationRuntimeResource integrationRuntime,
            string resourceGroupName,
            string factoryName)
            : base(integrationRuntime, resourceGroupName, factoryName)
        {
            if (IntegrationRuntime.Properties == null)
            {
                IntegrationRuntime.Properties = new SelfHostedIntegrationRuntime();
            }

            if (SelfHostedIntegrationRuntime == null)
            {
                throw new PSArgumentException("The resource is not a valid self-hosted integration runtime.");
            }
        }

        public bool? SelfContainedInteractiveAuthoringEnabled => SelfHostedIntegrationRuntime.SelfContainedInteractiveAuthoringEnabled;

        protected SelfHostedIntegrationRuntime SelfHostedIntegrationRuntime => IntegrationRuntime.Properties as SelfHostedIntegrationRuntime;
    }
}

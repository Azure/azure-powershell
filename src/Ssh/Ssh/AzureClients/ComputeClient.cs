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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.PowerShell.Ssh.Helpers.Compute;

namespace Microsoft.Azure.PowerShell.Cmdlets.Ssh.AzureClients
{
    internal class ComputeClient
    {
        public IComputeManagementClient ComputeManagementClient { get; private set; }

        public ComputeClient(IAzureContext context)
            : this(AzureSession.Instance.ClientFactory.CreateArmClient<ComputeManagementClient>(
                context, AzureEnvironment.Endpoint.ResourceManager))
        {
        }

        public ComputeClient(IComputeManagementClient computeManagementClient)
        {
            this.ComputeManagementClient = computeManagementClient;
        }
    }
}

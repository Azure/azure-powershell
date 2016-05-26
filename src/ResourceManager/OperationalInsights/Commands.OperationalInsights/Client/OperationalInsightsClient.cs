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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.OperationalInsights;

namespace Microsoft.Azure.Commands.OperationalInsights.Client
{
    public partial class OperationalInsightsClient
    {
        public IOperationalInsightsManagementClient OperationalInsightsManagementClient { get; private set; }

        public OperationalInsightsClient(AzureContext context)
        {
            OperationalInsightsManagementClient = AzureSession.ClientFactory.CreateClient<OperationalInsightsManagementClient>(
                context,
                AzureEnvironment.Endpoint.ResourceManager);
        }

        /// <summary>
        /// Parameterless constructor for Mocking.
        /// </summary>
        public OperationalInsightsClient()
        {
        }
    }
}

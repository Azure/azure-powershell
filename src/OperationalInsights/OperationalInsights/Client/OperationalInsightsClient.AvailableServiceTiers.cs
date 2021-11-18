// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Commands.OperationalInsights.Properties;
using Microsoft.Azure.Management.OperationalInsights.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights.Client
{
    public partial class OperationalInsightsClient
    {
        public IList<PSAvailableServiceTier> ListPSAvailableServiceTier(string resourceGroupName, string workspaceName)
        {
            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                throw new PSArgumentException(Resources.ResourceGroupNameCannotBeEmpty);
            }

            if (string.IsNullOrWhiteSpace(workspaceName))
            {
                throw new PSArgumentException(Resources.WorkspaceDetailsCannotBeEmpty);
            }

            IList<AvailableServiceTier> availableServiceTiers =  this.OperationalInsightsManagementClient.AvailableServiceTiers.ListByWorkspace(resourceGroupName, workspaceName);
            return availableServiceTiers.Select(item => new PSAvailableServiceTier(item)).ToList();
        }
    }
}

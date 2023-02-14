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

using System.Management.Automation;
using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Rest;

namespace Microsoft.Azure.Commands.OperationalInsights.Client
{
    public partial class OperationalInsightsClient
    {
        public virtual PSWorkspacePurgeResponse PurgeWorkspace(string resourceGroupName, string workspaceName, PSWorkspacePurgeBody purgeBody)
        {
            try
            {
                PSWorkspacePurgeResponse response = new PSWorkspacePurgeResponse(OperationalInsightsManagementClient.WorkspacePurge.Purge(resourceGroupName, workspaceName, purgeBody.GetWorkspacePurgeBody()));
                return response;
            }
            catch (RestException e)
            {
                throw new PSInvalidOperationException($"Failed to purge workspace: '{workspaceName}', with error: '{e}'.");
            }
        }

        public virtual PSWorkspacePurgeStatusResponse GetPurgeWorkspaceStatus(string resourceGroupName, string workspaceName, string purgeId)
        {
            try
            {
                var response = new PSWorkspacePurgeStatusResponse(OperationalInsightsManagementClient.WorkspacePurge.GetPurgeStatus(resourceGroupName, workspaceName, purgeId));
                return response;
            }
            catch (RestException)
            {
                throw new PSInvalidOperationException($"Failed to find purge status for workspace: '{workspaceName}' with ID: '{purgeId}'.");
            }
        }
    }
}

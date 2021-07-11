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

using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSWorkspaceAadAdminInfo
    {
        public PSWorkspaceAadAdminInfo(WorkspaceAadAdminInfo info, string resourceGroupName, string workspaceName)
        {
            this.ResourceGroupName = resourceGroupName;
            this.WorkspaceName = workspaceName;
            this.DisplayName = info.Login;
            this.ObjectId = info.Sid;
        }

        public string ResourceGroupName { get; set; }

        public string WorkspaceName { get; set; }

        public string DisplayName { get; set; }

        public string ObjectId { get; set; }
    }
}

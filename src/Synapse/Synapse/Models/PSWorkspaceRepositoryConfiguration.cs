using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSWorkspaceRepositoryConfiguration
    {
        private WorkspaceRepositoryConfiguration workspaceRepositoryConfiguration;

        public PSWorkspaceRepositoryConfiguration(WorkspaceRepositoryConfiguration workspaceRepositoryConfiguration)
        {
            this.workspaceRepositoryConfiguration = workspaceRepositoryConfiguration;
        }
    }
}
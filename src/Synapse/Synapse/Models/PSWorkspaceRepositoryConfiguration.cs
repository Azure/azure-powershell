using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSWorkspaceRepositoryConfiguration
    {
        private WorkspaceRepositoryConfiguration workspaceRepositoryConfiguration;

        public PSWorkspaceRepositoryConfiguration(WorkspaceRepositoryConfiguration workspaceRepositoryConfiguration)
        {
            this.workspaceRepositoryConfiguration = workspaceRepositoryConfiguration;
            this.Type = workspaceRepositoryConfiguration.Type;
            this.HostName = workspaceRepositoryConfiguration.HostName;
            this.AccountName = workspaceRepositoryConfiguration.AccountName;
            this.ProjectName = workspaceRepositoryConfiguration.ProjectName;
            this.RepositoryName = workspaceRepositoryConfiguration.RepositoryName;
            this.CollaborationBranch = workspaceRepositoryConfiguration.CollaborationBranch;
            this.RootFolder = workspaceRepositoryConfiguration.RootFolder;
            this.LastCommitId = workspaceRepositoryConfiguration.LastCommitId;
            this.TenantId = workspaceRepositoryConfiguration.TenantId;
        }

        /// <summary>
        /// Gets or sets type of workspace repositoryID configuration. Example
        /// WorkspaceVSTSConfiguration, WorkspaceGitHubConfiguration
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets gitHub Enterprise host name. For example:
        /// https://github.mydomain.com
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets account name
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets VSTS project name
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Gets or sets repository name
        /// </summary>
        public string RepositoryName { get; set; }

        /// <summary>
        /// Gets or sets collaboration branch
        /// </summary>
        public string CollaborationBranch { get; set; }

        /// <summary>
        /// Gets or sets root folder to use in the repository
        /// </summary>
        public string RootFolder { get; set; }

        /// <summary>
        /// Gets or sets the last commit ID
        /// </summary>
        public string LastCommitId { get; set; }

        /// <summary>
        /// Gets or sets the VSTS tenant ID
        /// </summary>
        public System.Guid? TenantId { get; set; }
    }
}
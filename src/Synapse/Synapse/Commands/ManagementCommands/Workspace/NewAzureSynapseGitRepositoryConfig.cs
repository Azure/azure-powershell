using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse.Commands
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.GitRepositoryConfig)]
    [OutputType(typeof(PSWorkspaceRepositoryConfiguration))]
    public class NewAzureSynapseGitRepositoryConfig : SynapseManagementCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = HelpMessages.RepositoryType)]
        [ValidateSet(SynapseConstants.RepositoryType.GitHub, SynapseConstants.RepositoryType.AzureDevOpsGit, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string RepositoryType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.HostName)]
        [ValidateNotNullOrEmpty]
        public string HostName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessages.AccountName)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.ProjectName)]
        [ValidateNotNullOrEmpty]
        public string ProjectName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessages.RepositoryName)]
        [ValidateNotNullOrEmpty]
        public string RepositoryName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessages.CollaborationBranch)]
        [ValidateNotNullOrEmpty]
        public string CollaborationBranch { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.RootFolder)]
        [ValidateNotNullOrEmpty]
        public string RootFolder { get; set; } = "/";

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.TenantId)]
        [ValidateNotNullOrEmpty]
        public Guid TenantId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.RepositoryType == SynapseConstants.RepositoryType.AzureDevOpsGit && this.ProjectName == null)
            {
                throw new PSArgumentException(string.Format(Resources.WorkspaceGitRepoParameterException, "ProjectName"), "ProjectName");
            }

            if (this.RepositoryType == SynapseConstants.RepositoryType.AzureDevOpsGit)
            {
                if (!this.IsParameterBound(c => c.TenantId))
                {
                    this.TenantId = SynapseAnalyticsClient.GetTenantId();
                }
            }

            var settings = new WorkspaceRepositoryConfiguration
            {
                Type = this.RepositoryType == SynapseConstants.RepositoryType.AzureDevOpsGit ? SynapseConstants.RepositoryType.WorkspaceVSTSConfiguration : SynapseConstants.RepositoryType.WorkspaceGitHubConfiguration,
                HostName = this.RepositoryType == SynapseConstants.RepositoryType.GitHub ? this.HostName : null,
                AccountName = this.AccountName,
                ProjectName = this.RepositoryType == SynapseConstants.RepositoryType.AzureDevOpsGit ? this.ProjectName : null,
                RepositoryName = this.RepositoryName,
                CollaborationBranch = this.CollaborationBranch,
                TenantId = this.TenantId,
                RootFolder = this.RootFolder
            };

            WriteObject(new PSWorkspaceRepositoryConfiguration(settings));
        }
    }
}

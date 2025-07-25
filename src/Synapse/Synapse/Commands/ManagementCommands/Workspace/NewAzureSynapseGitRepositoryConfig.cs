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

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.LastCommitId)]
        [ValidateNotNullOrEmpty]
        public string LastCommitId { get; set; }

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
                LastCommitId = this.LastCommitId,
                RootFolder = this.RootFolder
            };

            WriteObject(new PSWorkspaceRepositoryConfiguration(settings));
        }
    }
}

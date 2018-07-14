using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet(VerbsCommon.Set, Constants.ConfigureRepository, DefaultParameterSetName = ParameterSetNames.ByGitHub,
        SupportsShouldProcess = true), OutputType(typeof(PSDataset))]
    public class SetAzureDataFactoryRepoConfiguration : DataFactoryBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByVSTS, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryResourceId)]
        [Parameter(ParameterSetName = ParameterSetNames.ByGitHub, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryResourceId)]
        [ValidateNotNullOrEmpty]
        public string FactoryResourceId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByVSTS, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryLocation)]
        [Parameter(ParameterSetName = ParameterSetNames.ByGitHub, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryLocation)]
        [LocationCompleter("Microsoft.DataFactory/factories")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.HelpDontAskConfirmation)]
        public SwitchParameter Force { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByVSTS, Mandatory = true, HelpMessage = Constants.HelpRepositoryAccountName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByGitHub, Mandatory = true, HelpMessage = Constants.HelpRepositoryAccountName)]
        public string RepositoryAccountName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByVSTS, Mandatory = true, HelpMessage = Constants.HelpRepositoryName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByGitHub, Mandatory = true, HelpMessage = Constants.HelpRepositoryName)]
        public string RepositoryName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByVSTS, Mandatory = true, HelpMessage = Constants.HelpRepositoryCollaborationBranch)]
        [Parameter(ParameterSetName = ParameterSetNames.ByGitHub, Mandatory = true, HelpMessage = Constants.HelpRepositoryCollaborationBranch)]
        public string RepositoryCollaborationBranch { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByVSTS, Mandatory = true, HelpMessage = Constants.HelpRepositoryRootFolder)]
        [Parameter(ParameterSetName = ParameterSetNames.ByGitHub, Mandatory = true, HelpMessage = Constants.HelpRepositoryRootFolder)]
        public string RepositoryRootFolder { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByVSTS, Mandatory = false, HelpMessage = Constants.HelpRepositoryLastCommitId)]
        [Parameter(ParameterSetName = ParameterSetNames.ByGitHub, Mandatory = false, HelpMessage = Constants.HelpRepositoryLastCommitId)]
        public string RepositoryLastCommitId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByGitHub, Mandatory = true, HelpMessage = Constants.HelpGithubConfig)]
        public SwitchParameter GitHubConfig { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByGitHub, Mandatory = false, HelpMessage = Constants.HelpGithubHostName)]
        public string GitHubHostName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByVSTS, Mandatory = true, HelpMessage = Constants.HelpVSTSProjectName)]
        public string VSTSProjectName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByVSTS, Mandatory = false, HelpMessage = Constants.HelpVSTSTenantId)]
        public string VSTSTenantId { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            FactoryRepoConfiguration repo = null;
            if (ParameterSetName.Equals(ParameterSetNames.ByVSTS, StringComparison.OrdinalIgnoreCase))
            {
                repo = new FactoryVSTSConfiguration(
                    this.RepositoryAccountName,
                    this.RepositoryName,
                    this.RepositoryCollaborationBranch,
                    this.RepositoryRootFolder,
                    this.VSTSProjectName,
                    this.RepositoryLastCommitId,
                    this.VSTSTenantId);
            }
            else if (ParameterSetName.Equals(ParameterSetNames.ByGitHub, StringComparison.OrdinalIgnoreCase))
            {
                repo = new FactoryGitHubConfiguration(
                    this.RepositoryAccountName,
                    this.RepositoryName,
                    this.RepositoryCollaborationBranch,
                    this.RepositoryRootFolder,
                    this.RepositoryLastCommitId,
                    this.GitHubHostName
                    );
            }
            var parsedResourceId = new ResourceIdentifier(FactoryResourceId);
            var parameters = new ConfigurePSDataFactoryParameters()
            {
                ResourceGroupName = parsedResourceId.ResourceGroupName,
                DataFactoryName = parsedResourceId.ResourceName,
                FactoryResourceId = FactoryResourceId,
                LocationId = Location,
                Force = Force.IsPresent,
                ConfirmAction = ConfirmAction,
                Repo = repo
            };
            WriteObject(DataFactoryClient.ConfigurePSDDataFactory(parameters));
        }
    }
}

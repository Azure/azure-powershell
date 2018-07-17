using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet(VerbsCommon.Set, Constants.ConfigureRepository, DefaultParameterSetName = ParameterSetNames.ByFactoryNameByGitHub,
        SupportsShouldProcess = true), OutputType(typeof(PSDataset))]
    public class SetAzureDataFactoryRepoConfiguration : DataFactoryBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByVSTS, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceGroup)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByGitHub, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceGroup)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByVSTS, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByGitHub, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryName)]
        [ValidateNotNullOrEmpty]
        public string DataFactoryName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByResourceIdByVSTS, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryLocation)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByVSTS, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryLocation)]
        [Parameter(ParameterSetName = ParameterSetNames.ByResourceIdByGitHub, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryLocation)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByGitHub, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryLocation)]
        [LocationCompleter(Constants.DataFactoryQualifiedType)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByResourceIdByVSTS, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryLocation)]
        [Parameter(ParameterSetName = ParameterSetNames.ByResourceIdByGitHub, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObjectByVSTS, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryObject)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObjectByGitHub, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryObject)]
        [ValidateNotNullOrEmpty]
        public PSDataFactory InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.HelpDontAskConfirmation)]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.HelpRepositoryAccountName)]
        [ValidateNotNullOrEmpty]
        public string RepositoryAccountName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.HelpRepositoryName)]
        [ValidateNotNullOrEmpty]
        public string RepositoryName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.HelpRepositoryCollaborationBranch)]
        [ValidateNotNullOrEmpty]
        public string RepositoryCollaborationBranch { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.HelpRepositoryRootFolder)]
        [ValidateNotNullOrEmpty]
        public string RepositoryRootFolder { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.HelpRepositoryLastCommitId)]
        [ValidateNotNullOrEmpty]
        public string RepositoryLastCommitId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByGitHub, Mandatory = false, HelpMessage = Constants.HelpGithubHostName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByResourceIdByGitHub, Mandatory = false, HelpMessage = Constants.HelpGithubHostName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObjectByGitHub, Mandatory = false, HelpMessage = Constants.HelpGithubHostName)]
        [ValidateNotNullOrEmpty]
        public string GitHubHostName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByVSTS, Mandatory = true, HelpMessage = Constants.HelpVSTSProjectName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByResourceIdByVSTS, Mandatory = true, HelpMessage = Constants.HelpVSTSProjectName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObjectByVSTS, Mandatory = true, HelpMessage = Constants.HelpVSTSProjectName)]
        [ValidateNotNullOrEmpty]
        public string VSTSProjectName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByVSTS, Mandatory = false, HelpMessage = Constants.HelpVSTSTenantId)]
        [Parameter(ParameterSetName = ParameterSetNames.ByResourceIdByVSTS, Mandatory = false, HelpMessage = Constants.HelpVSTSTenantId)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObjectByVSTS, Mandatory = false, HelpMessage = Constants.HelpVSTSTenantId)]
        [ValidateNotNullOrEmpty]
        public string VSTSTenantId { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            ResourceIdentifier parsedResourceId = null;
            if (ParameterSetName.Equals(ParameterSetNames.ByResourceIdByVSTS, StringComparison.OrdinalIgnoreCase) ||
                ParameterSetName.Equals(ParameterSetNames.ByResourceIdByGitHub, StringComparison.OrdinalIgnoreCase))
            {
                parsedResourceId = new ResourceIdentifier(ResourceId);
            }
            else if (ParameterSetName.Equals(ParameterSetNames.ByFactoryObjectByVSTS, StringComparison.OrdinalIgnoreCase) ||
                ParameterSetName.Equals(ParameterSetNames.ByFactoryObjectByGitHub, StringComparison.OrdinalIgnoreCase))
            {
                ResourceId = InputObject.DataFactoryId;
                parsedResourceId = new ResourceIdentifier(ResourceId);
                Location = InputObject.Location;
            }
            else if (ParameterSetName.Equals(ParameterSetNames.ByFactoryNameByVSTS, StringComparison.OrdinalIgnoreCase) ||
                ParameterSetName.Equals(ParameterSetNames.ByFactoryNameByGitHub, StringComparison.OrdinalIgnoreCase))
            {
                parsedResourceId = new ResourceIdentifier
                {
                    ResourceGroupName = ResourceGroupName,
                    ResourceName = DataFactoryName,
                    ResourceType = Constants.DataFactoryQualifiedType,
                    Subscription = DefaultContext.Subscription.Id
                };
                ResourceId = parsedResourceId.ToString();
            }

            FactoryRepoConfiguration repo = null;
            if (ParameterSetName.Equals(ParameterSetNames.ByFactoryNameByVSTS, StringComparison.OrdinalIgnoreCase) ||
                ParameterSetName.Equals(ParameterSetNames.ByResourceIdByVSTS, StringComparison.OrdinalIgnoreCase) ||
                ParameterSetName.Equals(ParameterSetNames.ByFactoryObjectByVSTS, StringComparison.OrdinalIgnoreCase))
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
            else
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
            var parameters = new ConfigurePSDataFactoryParameters()
            {
                ResourceGroupName = parsedResourceId.ResourceGroupName,
                DataFactoryName = parsedResourceId.ResourceName,
                FactoryResourceId = ResourceId,
                LocationId = Location,
                Force = Force.IsPresent,
                Repo = repo
            };
            WriteObject(DataFactoryClient.ConfigurePSDDataFactory(parameters));
        }
    }
}

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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataFactoryV2", DefaultParameterSetName = ParameterSetNames.ByFactoryName, SupportsShouldProcess = true), OutputType(typeof(PSDataFactory))]
    [Alias("New-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataFactoryV2")]
    public class SetAzureDataFactoryCommand : DataFactoryBaseCmdlet
    {
        #region Attributes
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpDataFactoryV2ResourceId)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceIdFactoryRepoVstsConfig,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpDataFactoryV2ResourceId)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceIdFactoryRepoGitConfig,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpDataFactoryV2ResourceId)]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.Id, Constants.DataFactoryId)]
        [ResourceIdCompleter("Microsoft.DataFactory/factories")]
        #endregion // Attributes
        public string ResourceId { get; set; }

        #region Attributes
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryName,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceGroup)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryNameFactoryRepoGitConfig,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceGroup)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryNameFactoryRepoVstsConfig,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceGroup)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        #endregion // Attributes
        public string ResourceGroupName { get; set; }

        #region Attributes
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryName,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryNameFactoryRepoGitConfig,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryNameFactoryRepoVstsConfig,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryName)]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.DataFactoryName)]
        #endregion // Attributes
        public string Name { get; set; }

        #region Attributes
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = Constants.HelpFactoryObject)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObjectFactoryRepoVstsConfig,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = Constants.HelpFactoryObject)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObjectFactoryRepoGitConfig,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = Constants.HelpFactoryObject)]
        [ValidateNotNull]
        #endregion // Attributes
        public PSDataFactory InputObject { get; set; }

        #region Attributes
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryName,
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryLocation)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObject,
            Mandatory = false,
            HelpMessage = Constants.HelpFactoryLocation)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObjectFactoryRepoVstsConfig,
            Mandatory = false,
            HelpMessage = Constants.HelpFactoryLocation)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObjectFactoryRepoGitConfig,
            Mandatory = false,
            HelpMessage = Constants.HelpFactoryLocation)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryNameFactoryRepoGitConfig,
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryLocation)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryNameFactoryRepoVstsConfig,
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryLocation)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryLocation)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceIdFactoryRepoVstsConfig,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryLocation)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceIdFactoryRepoGitConfig,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryLocation)]
        [ValidateNotNullOrEmpty]
        [LocationCompleter(Constants.DataFactoryQualifiedType)]
        #endregion // Attributes
        public string Location { get; set; }

        #region Attributes
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryName,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = Constants.HelpTagsForFactory)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObject,
            Mandatory = false,
            HelpMessage = Constants.HelpTagsForFactory)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObjectFactoryRepoVstsConfig,
            Mandatory = false,
            HelpMessage = Constants.HelpTagsForFactory)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObjectFactoryRepoGitConfig,
            Mandatory = false,
            HelpMessage = Constants.HelpTagsForFactory)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryNameFactoryRepoGitConfig,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = Constants.HelpTagsForFactory)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryNameFactoryRepoVstsConfig,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = Constants.HelpTagsForFactory)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = Constants.HelpTagsForFactory)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceIdFactoryRepoVstsConfig,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = Constants.HelpTagsForFactory)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceIdFactoryRepoGitConfig,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = Constants.HelpTagsForFactory)]
        #endregion // Attributes
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.HelpDontAskConfirmation)]
        public SwitchParameter Force { get; set; }

        #region Attributes
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObjectFactoryRepoGitConfig,
            Mandatory = false,
            HelpMessage = Constants.HelpRepoConfigurationAccountName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObjectFactoryRepoVstsConfig,
            Mandatory = false,
            HelpMessage = Constants.HelpRepoConfigurationAccountName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryNameFactoryRepoGitConfig,
            Mandatory = true,
            HelpMessage = Constants.HelpRepoConfigurationAccountName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryNameFactoryRepoVstsConfig,
            Mandatory = true,
            HelpMessage = Constants.HelpRepoConfigurationAccountName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceIdFactoryRepoVstsConfig,
            Mandatory = true,
            HelpMessage = Constants.HelpRepoConfigurationAccountName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceIdFactoryRepoGitConfig,
            Mandatory = true,
            HelpMessage = Constants.HelpRepoConfigurationAccountName)]
        [ValidateNotNullOrEmpty]
        #endregion // Attributes
        public string AccountName { get; set; }

        #region Attributes
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObjectFactoryRepoGitConfig,
            Mandatory = false,
            HelpMessage = Constants.HelpRepoConfigurationRepositoryName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObjectFactoryRepoVstsConfig,
            Mandatory = false,
            HelpMessage = Constants.HelpRepoConfigurationRepositoryName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryNameFactoryRepoGitConfig,
            Mandatory = true,
            HelpMessage = Constants.HelpRepoConfigurationRepositoryName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryNameFactoryRepoVstsConfig,
            Mandatory = true,
            HelpMessage = Constants.HelpRepoConfigurationRepositoryName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceIdFactoryRepoVstsConfig,
            Mandatory = true,
            HelpMessage = Constants.HelpRepoConfigurationRepositoryName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceIdFactoryRepoGitConfig,
            Mandatory = true,
            HelpMessage = Constants.HelpRepoConfigurationRepositoryName)]
        [ValidateNotNullOrEmpty]
        #endregion // Attributes
        public string RepositoryName { get; set; }

        #region Attributes
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObjectFactoryRepoGitConfig,
            Mandatory = false,
            HelpMessage = Constants.HelpRepoConfigurationCollaborationBranch)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObjectFactoryRepoVstsConfig,
            Mandatory = false,
            HelpMessage = Constants.HelpRepoConfigurationCollaborationBranch)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryNameFactoryRepoGitConfig,
            Mandatory = true,
            HelpMessage = Constants.HelpRepoConfigurationCollaborationBranch)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryNameFactoryRepoVstsConfig,
            Mandatory = true,
            HelpMessage = Constants.HelpRepoConfigurationCollaborationBranch)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceIdFactoryRepoVstsConfig,
            Mandatory = true,
            HelpMessage = Constants.HelpRepoConfigurationCollaborationBranch)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceIdFactoryRepoGitConfig,
            Mandatory = true,
            HelpMessage = Constants.HelpRepoConfigurationCollaborationBranch)]
        [ValidateNotNullOrEmpty]
        #endregion // Attributes
        public string CollaborationBranch { get; set; }

        #region Attributes
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObjectFactoryRepoGitConfig,
            Mandatory = false,
            HelpMessage = Constants.HelpRepoConfigurationRootFolder)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObjectFactoryRepoVstsConfig,
            Mandatory = false,
            HelpMessage = Constants.HelpRepoConfigurationRootFolder)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryNameFactoryRepoGitConfig,
            Mandatory = true,
            HelpMessage = Constants.HelpRepoConfigurationRootFolder)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryNameFactoryRepoVstsConfig,
            Mandatory = true,
            HelpMessage = Constants.HelpRepoConfigurationRootFolder)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceIdFactoryRepoVstsConfig,
            Mandatory = true,
            HelpMessage = Constants.HelpRepoConfigurationRootFolder)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceIdFactoryRepoGitConfig,
            Mandatory = true,
            HelpMessage = Constants.HelpRepoConfigurationRootFolder)]
        [ValidateNotNullOrEmpty]
        #endregion // Attributes
        public string RootFolder { get; set; }

        #region Attributes
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObjectFactoryRepoVstsConfig,
            Mandatory = false,
            HelpMessage = Constants.HelpRepoConfigurationLastCommitId)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObjectFactoryRepoGitConfig,
            Mandatory = false,
            HelpMessage = Constants.HelpRepoConfigurationLastCommitId)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryNameFactoryRepoGitConfig,
            Mandatory = false,
            HelpMessage = Constants.HelpRepoConfigurationLastCommitId)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryNameFactoryRepoVstsConfig,
            Mandatory = false,
            HelpMessage = Constants.HelpRepoConfigurationLastCommitId)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceIdFactoryRepoVstsConfig,
            Mandatory = false,
            HelpMessage = Constants.HelpRepoConfigurationLastCommitId)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceIdFactoryRepoGitConfig,
            Mandatory = false,
            HelpMessage = Constants.HelpRepoConfigurationLastCommitId)]
        [ValidateNotNullOrEmpty]
        #endregion // Attributes
        public string LastCommitId { get; set; }

        #region Attributes
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObjectFactoryRepoVstsConfig,
            Mandatory = true,
            HelpMessage = Constants.HelpRepoConfigurationProjectName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryNameFactoryRepoVstsConfig,
            Mandatory = true,
            HelpMessage = Constants.HelpRepoConfigurationProjectName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceIdFactoryRepoVstsConfig,
            Mandatory = true,
            HelpMessage = Constants.HelpRepoConfigurationProjectName)]
        [ValidateNotNullOrEmpty]
        #endregion // Attributes
        public string ProjectName { get; set; }

        #region Attributes
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObjectFactoryRepoVstsConfig,
            Mandatory = false,
            HelpMessage = Constants.HelpRepoConfigurationTenantId)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryNameFactoryRepoVstsConfig,
            Mandatory = false,
            HelpMessage = Constants.HelpRepoConfigurationTenantId)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceIdFactoryRepoVstsConfig,
            Mandatory = false,
            HelpMessage = Constants.HelpRepoConfigurationTenantId)]
        [ValidateNotNullOrEmpty]
        #endregion // Attributes
        public string TenantId { get; set; }

        #region Attributes
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObjectFactoryRepoGitConfig,
            Mandatory = true,
            HelpMessage = Constants.HelpRepoConfigurationHostName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryNameFactoryRepoGitConfig,
            Mandatory = true,
            HelpMessage = Constants.HelpRepoConfigurationHostName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceIdFactoryRepoGitConfig,
            Mandatory = true,
            HelpMessage = Constants.HelpRepoConfigurationHostName)]
        [ValidateNotNullOrEmpty]
        #endregion // Attributes
        public string HostName { get; set; }

        public override void ExecuteCmdlet()
        {
            this.ValidateParameters();

            FactoryRepoConfiguration repoConfiguration = null;
            if (!string.IsNullOrWhiteSpace(this.ProjectName) || !string.IsNullOrWhiteSpace(this.TenantId))
            {
                var factoryVSTSConfiguration = new FactoryVSTSConfiguration();
                factoryVSTSConfiguration.ProjectName = this.ProjectName;
                factoryVSTSConfiguration.TenantId = this.TenantId;

                repoConfiguration = factoryVSTSConfiguration;
            }
            else if (!string.IsNullOrWhiteSpace(this.HostName))
            {
                var factoryGitHubConfiguration = new FactoryGitHubConfiguration();
                factoryGitHubConfiguration.HostName = this.HostName;

                repoConfiguration = factoryGitHubConfiguration;
            }

            if (repoConfiguration != null)
            {
                repoConfiguration.CollaborationBranch = this.CollaborationBranch;
                repoConfiguration.AccountName = this.AccountName;
                repoConfiguration.LastCommitId = this.LastCommitId;
                repoConfiguration.RootFolder = this.RootFolder;
                repoConfiguration.RepositoryName = this.RepositoryName;
            }

            var parameters = new CreatePSDataFactoryParameters()
            {
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = Name,
                Location = Location,
                Tags = Tag,
                Force = Force.IsPresent,
                RepoConfiguration = repoConfiguration,
                ConfirmAction = ConfirmAction
            };

            WriteObject(DataFactoryClient.CreatePSDataFactory(parameters));
        }

        private void ValidateParameters()
        {
            if (InputObject != null)
            {
                this.ResourceGroupName = InputObject.ResourceGroupName;
                this.Name = InputObject.DataFactoryName;
                this.Location = this.Location ?? InputObject.Location;
                this.Tag = this.Tag ?? new Hashtable((IDictionary)InputObject.Tags);
                if (InputObject.RepoConfiguration != null)
                {
                    this.AccountName = this.AccountName ?? InputObject.RepoConfiguration.AccountName;
                    this.CollaborationBranch = this.CollaborationBranch ?? InputObject.RepoConfiguration.CollaborationBranch;
                    this.LastCommitId = this.LastCommitId ?? InputObject.RepoConfiguration.LastCommitId;
                    this.RepositoryName = this.RepositoryName ?? InputObject.RepoConfiguration.RepositoryName;
                    this.RootFolder = this.RootFolder ?? InputObject.RepoConfiguration.RootFolder;

                    var factoryVSTSConfiguration = InputObject.RepoConfiguration as FactoryVSTSConfiguration;
                    if (factoryVSTSConfiguration != null)
                    {
                        this.ProjectName = this.ProjectName ?? factoryVSTSConfiguration.ProjectName;
                        this.TenantId = this.TenantId ?? factoryVSTSConfiguration.TenantId;
                    }
                    else
                    {
                        var factoryGitHubConfiguration = InputObject.RepoConfiguration as FactoryGitHubConfiguration;
                        if (factoryGitHubConfiguration != null)
                        {
                            this.HostName = this.HostName ?? factoryGitHubConfiguration.HostName;
                        }
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(ResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.Name = parsedResourceId.ResourceName;
            }
        }
    }
}

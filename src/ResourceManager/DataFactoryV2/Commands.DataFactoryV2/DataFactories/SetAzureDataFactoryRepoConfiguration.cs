using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Management.Automation;

using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataFactory.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2.DataFactories
{
    class SetAzureDataFactoryRepoConfiguration:DataFactoryBaseCmdlet
    {
        public string FactoryResourceId { get; set; }
        public string ResourceGroupName { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public Hashtable Tag { get; set; }
        public SwitchParameter Force { get; set; }
        public string RepositoryType { get; set; }
        public string RepositoryAccountName { get; set; }
        public string RepositoryName { get; set; }
        public string RepositoryCollaborationBranch { get; set; }
        public string RepositoryRootFolder { get; set; }
        public string RepositoryLastCommitId { get; set; }
        public string GitHubHostName { get; set; }
        public string VSTSProjectName { get; set; }
        public string VSTSTenantId { get; set; }

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
            var parameters = new ConfigurePSDataFactoryParameters()
            {
                FactoryResourceId = FactoryResourceId,
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = Name,
                LocationId = Location,
                Tags = Tag,
                Force = Force.IsPresent,
                ConfirmAction = ConfirmAction,
                Repo = repo
            };
            WriteObject(DataFactoryClient.ConfigurePSDDataFactory(parameters));
        }
    }
}

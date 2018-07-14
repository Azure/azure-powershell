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
using System.Security.Permissions;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.IO;
using System;
using Microsoft.Azure.Management.DataFactory.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet(VerbsCommon.Set, Constants.DataFactory, SupportsShouldProcess = true), OutputType(typeof(PSDataFactory))]
    [Alias(VerbsCommon.New + "-" + Constants.DataFactory)]
    public class SetAzureDataFactoryCommand : DataFactoryBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceGroup)]
        [Parameter(ParameterSetName = ParameterSetNames.ByVSTS, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceGroup)]
        [Parameter(ParameterSetName = ParameterSetNames.ByGitHub, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceGroup)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByVSTS, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByGitHub, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryName)]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.DataFactoryName)]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, 
            HelpMessage = Constants.HelpFactoryLocation)]
        [Parameter(ParameterSetName = ParameterSetNames.ByVSTS, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryLocation)]
        [Parameter(ParameterSetName = ParameterSetNames.ByGitHub, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryLocation)]
        [LocationCompleter("Microsoft.DataFactory/factories")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpTagsForFactory)]
        [Parameter(ParameterSetName = ParameterSetNames.ByVSTS, Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpTagsForFactory)]
        [Parameter(ParameterSetName = ParameterSetNames.ByGitHub, Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpTagsForFactory)]
        public Hashtable Tag { get; set; }

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
            else if(ParameterSetName.Equals(ParameterSetNames.ByGitHub, StringComparison.OrdinalIgnoreCase))
            {
                repo = new FactoryGitHubConfiguration(
                                    this.RepositoryAccountName,
                                    this.RepositoryName,
                                    this.RepositoryCollaborationBranch,
                                    this.RepositoryRootFolder,
                                    this.RepositoryLastCommitId,
                                    this.GitHubHostName);
            }
            var parameters = new CreatePSDataFactoryParameters()
            {
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = Name,
                Location = Location,
                Tags = Tag,
                Force = Force.IsPresent,
                ConfirmAction = ConfirmAction,
                repo = repo
            };
            WriteObject(DataFactoryClient.CreatePSDataFactory(parameters));
        }
    }
}
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

using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections;
using System.Management.Automation;
using Sku = Microsoft.Azure.Management.Synapse.Models.Sku;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SqlPool, DefaultParameterSetName = CreateByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSynapseSqlPool))]
    public class NewAzureSynapseSqlPool : SynapseManagementCmdletBase
    {
        private const string CreateByNameParameterSet = "CreateByNameParameterSet";
        private const string CreateByParentObjectParameterSet = "CreateByParentObjectParameterSet";

        [Parameter(ParameterSetName = CreateByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = CreateByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = CreateByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessages.SqlPoolName)]
        [Alias(nameof(SynapseConstants.SqlPoolName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.SqlPoolVersion)]
        [ValidateNotNullOrEmpty]
        [ValidateRange(2, 3)]
        public int Version { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.Tag)]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter(ParameterSetName = CreateByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.PerformanceLevel)]
        [Parameter(ParameterSetName = CreateByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.PerformanceLevel)]
        [ValidateNotNullOrEmpty]
        public string PerformanceLevel { get; set; }

        [Parameter(ParameterSetName = CreateByNameParameterSet, Mandatory = false, HelpMessage = HelpMessages.Collation)]
        [Parameter(ParameterSetName = CreateByParentObjectParameterSet, Mandatory = false, HelpMessage = HelpMessages.Collation)]
        [ValidateNotNullOrEmpty]
        public string Collation { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.StorageAccountType)]
        [ValidateSet(Management.Synapse.Models.StorageAccountType.GRS, Management.Synapse.Models.StorageAccountType.LRS, IgnoreCase = true)]
        [ValidateNotNull]
        public string StorageAccountType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.ResourceGroupName = new ResourceIdentifier(this.WorkspaceObject.Id).ResourceGroupName;
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (string.IsNullOrEmpty(this.ResourceGroupName))
            {
                this.ResourceGroupName = this.SynapseAnalyticsClient.GetResourceGroupByWorkspaceName(this.WorkspaceName);
            }

            var existingWorkspace = this.SynapseAnalyticsClient.GetWorkspaceOrDefault(this.ResourceGroupName, this.WorkspaceName);
            if (existingWorkspace == null)
            {
                throw new AzPSResourceNotFoundCloudException(string.Format(Resources.WorkspaceDoesNotExist, this.WorkspaceName));
            }

            if (this.Version == 3)
            {

                var existingSqlPool = this.SynapseAnalyticsClient.GetSqlPoolV3OrDefault(this.ResourceGroupName, this.WorkspaceName, this.Name);
                if (existingSqlPool != null)
                {
                    throw new AzPSInvalidOperationException(string.Format(Resources.SynapseSqlPoolExists, this.Name, this.ResourceGroupName, this.WorkspaceName));
                }

                var createParams = new SqlPoolV3
                {
                    Location = existingWorkspace.Location,
                    Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true)
                };

                switch (this.ParameterSetName)
                {
                    case CreateByNameParameterSet:
                    case CreateByParentObjectParameterSet:
                        createParams.Sku = new SkuV3
                        {
                            Name = this.PerformanceLevel
                        };
                        break;
                    default: throw new AzPSInvalidOperationException(string.Format(Resources.InvalidParameterSet, this.ParameterSetName));
                }

                if (this.ShouldProcess(this.Name, string.Format(Resources.CreatingSynapseSqlPool, this.ResourceGroupName, this.WorkspaceName, this.Name)))
                {
                    var result = new PSSynapseSqlPoolV3(this.SynapseAnalyticsClient.CreateSqlPoolV3(this.ResourceGroupName, this.WorkspaceName, this.Name, createParams));
                    WriteObject(result);
                }
            }
            else
            {
                var existingSqlPool = this.SynapseAnalyticsClient.GetSqlPoolOrDefault(this.ResourceGroupName, this.WorkspaceName, this.Name);
                if (existingSqlPool != null)
                {
                    throw new AzPSInvalidOperationException(string.Format(Resources.SynapseSqlPoolExists, this.Name, this.ResourceGroupName, this.WorkspaceName));
                }

                var createParams = new SqlPool
                {
                    Location = existingWorkspace.Location,
                    Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true),
                    StorageAccountType = this.StorageAccountType
                };

                createParams.CreateMode = SynapseSqlPoolCreateMode.Default;
                createParams.Collation = this.IsParameterBound(c => c.Collation) ? this.Collation : SynapseConstants.DefaultCollation;
                createParams.Sku = new Sku
                {
                    Name = this.PerformanceLevel
                };

                if (this.ShouldProcess(this.Name, string.Format(Resources.CreatingSynapseSqlPool, this.ResourceGroupName, this.WorkspaceName, this.Name)))
                {
                    var result = new PSSynapseSqlPool(this.ResourceGroupName, this.WorkspaceName, this.SynapseAnalyticsClient.CreateSqlPool(this.ResourceGroupName, this.WorkspaceName, this.Name, createParams));
                    WriteObject(result);
                }
            }
        }
    }
}

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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SparkSession, DefaultParameterSetName = GetByNameParameterSet)]
    [OutputType(typeof(PSSynapseSparkSession))]
    public class GetAzureSynapseSparkSession : SynapseSparkCmdletBase
    {
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByParentObjectParameterSet = "GetByParentObjectParameterSet";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolName)]
        [ResourceNameCompleter(
            ResourceTypes.SparkPool,
            "ResourceGroupName",
            nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public override string SparkPoolName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolObject)]
        [ValidateNotNull]
        public PSSynapseSparkPool SparkPoolObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.SessionId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByParentObjectParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.SessionId)]
        [Alias("Id")]
        [ValidateNotNullOrEmpty]
        public int LivyId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.SparkPoolName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByParentObjectParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.SessionName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ApplicationId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByParentObjectParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ApplicationId)]
        [ValidateNotNullOrEmpty]
        public string ApplicationId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.SparkPoolObject))
            {
                var resourceIdentifier = new ResourceIdentifier(this.SparkPoolObject.Id);
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.SparkPoolName = resourceIdentifier.ResourceName;
            }

            if (this.IsParameterBound(c => c.LivyId))
            {
                var result = new PSSynapseSparkSession(this.SynapseAnalyticsClient.GetSparkSession(this.LivyId));
                WriteObject(result);
            }
            else
            {
                var result = this.SynapseAnalyticsClient.ListSparkSessions().Select(r => new PSSynapseSparkSession(r));
                if (!string.IsNullOrEmpty(this.Name))
                {
                    result = result.Where(r => this.Name.Equals(r.Name, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrEmpty(this.ApplicationId))
                {
                    result = result.Where(b => this.ApplicationId.Equals(b.AppId, StringComparison.OrdinalIgnoreCase));
                }

                WriteObject(result, true);
            }
        }
    }
}

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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SparkStatement, DefaultParameterSetName = GetSparkStatementsByIdParameterSetName)]
    [OutputType(typeof(PSSynapseSparkStatement))]
    public class GetAzureSynapseSparkStatement : SynapseSparkCmdletBase
    {
        private const string GetSparkStatementsByIdParameterSetName = "GetSparkStatementsByIdParameterSet";
        private const string GetSparkStatementsByIdFromParentObjectParameterSetName = "GetSparkStatementsByParentObjectParameterSet";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetSparkStatementsByIdParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetSparkStatementsByIdParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolName)]
        [ResourceNameCompleter(
            ResourceTypes.SparkPool,
            "ResourceGroupName",
            nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public override string SparkPoolName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = GetSparkStatementsByIdFromParentObjectParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolObject)]
        [ValidateNotNull]
        public PSSynapseSparkSession SessionObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetSparkStatementsByIdParameterSetName,
            Mandatory = false, HelpMessage = HelpMessages.SparkStatementId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetSparkStatementsByIdFromParentObjectParameterSetName,
            Mandatory = false, HelpMessage = HelpMessages.SparkStatementId)]
        [Alias("Id")]
        [ValidateRange(0, int.MaxValue)]
        public int LivyId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetSparkStatementsByIdParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.SessionId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetSparkStatementsByIdFromParentObjectParameterSetName,
            Mandatory = false, HelpMessage = HelpMessages.SessionId)]
        [ValidateRange(0, int.MaxValue)]
        public int SessionId { get; set; } = SynapseConstants.UnknownId;

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.SessionObject))
            {
                this.WorkspaceName = this.SessionObject.WorkspaceName;
                this.SparkPoolName = this.SessionObject.SparkPoolName;
                this.SessionId = this.SessionObject.Id.Value;
            }

            if (this.IsParameterBound(c => c.LivyId))
            {
                // Get for single Spark session statement
                WriteObject(new PSSynapseSparkStatement(SynapseAnalyticsClient.GetSparkSessionStatement(this.SessionId, this.LivyId)));
            }
            else
            {
                // List all Spark session statements in given Spark session
                var sessionStatements = SynapseAnalyticsClient.ListSparkSessionStatements(this.SessionId).Select(element => new PSSynapseSparkStatement(element));
                WriteObject(sessionStatements, true);
            }
        }
    }
}

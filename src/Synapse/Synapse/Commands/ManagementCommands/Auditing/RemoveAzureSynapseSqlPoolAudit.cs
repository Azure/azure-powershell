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

using System.Management.Automation;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Models.Auditing;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(
        VerbsCommon.Reset,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + DefinitionsCommon.SqlPoolAuditCmdletsSuffix,
        DefaultParameterSetName = DefinitionsCommon.SqlPoolParameterSetName,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    [Alias("Remove-AzSynapseSqlPoolAudit")]
    public class RemoveAzureSynapseSqlPoolAudit : SynapseSqlPoolAuditCmdlet
    {
        protected override SqlPoolAuditModel PersistChanges(SqlPoolAuditModel entity)
        {
            ModelAdapter.RemoveAuditingSettings(entity);
            return null;
        }
    }
}

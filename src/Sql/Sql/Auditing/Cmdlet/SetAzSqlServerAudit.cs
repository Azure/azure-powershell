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

using Microsoft.Azure.Commands.Sql.Auditing.Model;
using Microsoft.Azure.Commands.Sql.Auditing.Services;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Management.Sql.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Auditing.Cmdlet
{
    [Cmdlet(
        VerbsCommon.Set,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + DefinitionsCommon.ServerAuditCmdletsSuffix,
        DefaultParameterSetName = DefinitionsCommon.ServerParameterSetName,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class SetAzSqlServerAudit : SetSqlServerAuditCmdlet<ExtendedServerBlobAuditingPolicy, ServerAuditModel, SqlServerAuditAdapter>
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = AuditingHelpMessages.AuditActionGroupsHelpMessage)]
        public AuditActionGroups[] AuditActionGroup { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = AuditingHelpMessages.PredicateExpressionHelpMessage)]
        [ValidateNotNull]
        public string PredicateExpression { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = AuditingHelpMessages.StorageKeyTypeHelpMessage)]
        [ValidateSet(
            SecurityConstants.Primary,
            SecurityConstants.Secondary,
            IgnoreCase = false)]
        public string StorageKeyType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = AuditingHelpMessages.RetentionInDaysHelpMessage)]
        [ValidateNotNullOrEmpty]
        public uint? RetentionInDays { get; set; }

        protected override ServerAuditModel ApplyUserInputToModel(ServerAuditModel model)
        {
            base.ApplyUserInputToModel(model);

            if (AuditActionGroup != null)
            {
                model.AuditActionGroup = AuditActionGroup;
            }

            if (PredicateExpression != null)
            {
                model.PredicateExpression = PredicateExpression;
            }

            if (MyInvocation.BoundParameters.ContainsKey(SecurityConstants.StorageKeyType))
            {
                model.StorageKeyType = (StorageKeyType == SecurityConstants.Primary) ? StorageKeyKind.Primary : StorageKeyKind.Secondary;
            }

            if (RetentionInDays != null)
            {
                model.RetentionInDays = RetentionInDays;
            }

            return model;
        }

        protected override SqlServerAuditAdapter InitModelAdapter()
        {
            return new SqlServerAuditAdapter(DefaultProfile.DefaultContext, RoleAssignmentId);
        }
    }
}

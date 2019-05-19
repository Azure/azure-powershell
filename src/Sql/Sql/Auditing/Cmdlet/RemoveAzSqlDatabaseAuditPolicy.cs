using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.Auditing.Model;

namespace Microsoft.Azure.Commands.Sql.Auditing.Cmdlet
{
    [Cmdlet(
        VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + DefinitionsCommon.DatabaseAuditPolicyCmdletsSuffix,
        DefaultParameterSetName = DefinitionsCommon.DatabaseParameterSetName),
        OutputType(typeof(bool))]
    public class RemoveAzSqlDatabaseAuditPolicy : SqlDatabaseAuditPolicyCmdlet
    {
        protected override DatabaseAuditPolicyModel PersistChanges(DatabaseAuditPolicyModel entity)
        {
            entity.BlobStorageTargetState = AuditStateType.Disabled;
            entity.EventHubTargetState = AuditStateType.Disabled;
            entity.LogAnalyticsTargetState = AuditStateType.Disabled;
            ModelAdapter.PersistAuditPolicyChanges(entity);
            return null;
        }
    }
}

using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.Auditing.Model;

namespace Microsoft.Azure.Commands.Sql.Auditing.Cmdlet
{
    [Cmdlet(
        VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + DefinitionsCommon.ServerAuditPolicyCmdletsSuffix,
        DefaultParameterSetName = DefinitionsCommon.ServerParameterSetName,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class RemoveAzSqlServerAuditPolicy : SqlServerAuditPolicyCmdlet
    {
        protected override ServerAuditPolicyModel PersistChanges(ServerAuditPolicyModel entity)
        {
            entity.BlobStorageTargetState = AuditStateType.Disabled;
            entity.EventHubTargetState = AuditStateType.Disabled;
            entity.LogAnalyticsTargetState = AuditStateType.Disabled;
            ModelAdapter.PersistAuditPolicyChanges(entity);
            return null;
        }
    }
}

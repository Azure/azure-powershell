using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Auditing.Cmdlet
{
    [Cmdlet(
        VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + DefinitionsCommon.DatabaseAuditPolicyCmdletsSuffix,
        DefaultParameterSetName = DefinitionsCommon.DatabaseParameterSetName),
        OutputType(typeof(bool))]
    public class RemoveAzSqlDatabaseAuditPolicy : SqlDatabaseAuditPolicyCmdlet
    {
    }
}

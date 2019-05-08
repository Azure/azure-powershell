using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Auditing.Cmdlet
{
    [Cmdlet(
        VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + DefinitionsCommon.ServerAuditPolicyCmdletsSuffix,
        DefaultParameterSetName = DefinitionsCommon.ServerParameterSetName),
        OutputType(typeof(bool))]
    public class RemoveAzSqlServerAuditPolicy : SqlServerAuditPolicyCmdlet
    {
    }
}

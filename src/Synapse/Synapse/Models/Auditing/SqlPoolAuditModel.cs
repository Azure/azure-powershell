
namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SqlPoolAuditModel : WorkspaceAuditModel
    {
        public string SqlPoolName { get; set; }

        public string[] AuditAction { get; set; }
    }
}

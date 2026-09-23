using System;

namespace Microsoft.Azure.Commands.StorageSync.Interop.ManagedIdentity
{
    /// <summary>
    /// ServerApplicationIdentity represents the server's application identity with application ID and tenant ID.
    /// </summary>
    public class ServerApplicationIdentity
    {
        public Guid ApplicationId { get; set; }
        public Guid TenantId { get; set; }

        public ServerApplicationIdentity(Guid applicationId, Guid tenantId)
        {
            ApplicationId = applicationId;
            TenantId = tenantId;
        }
    }
}

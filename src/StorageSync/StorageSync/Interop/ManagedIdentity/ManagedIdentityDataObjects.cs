namespace Microsoft.Azure.Commands.StorageSync.Interop.ManagedIdentity
{

    using Microsoft.Azure.Commands.StorageSync.Interop.Enums;
    using Newtonsoft.Json;


    public class ManagedIdentityConfigurationInfo
    {
        public LocalServerType ServerType { get; private set; }

        public RegisteredServerAuthType ServerAuthType { get; private set; }

        public ManagedIdentityConfigurationInfo(LocalServerType serverType, RegisteredServerAuthType serverAuthtype)
        {
            this.ServerType = serverType;
            this.ServerAuthType = serverAuthtype;
        }
    }

    /// <summary>
    /// The JSON response to deserialize when querying the Arc IMDS endpoint
    /// There are many properties, but we only need to extract out the resource id for our purposes.
    /// </summary>
    public sealed class Compute
    {
        [JsonProperty("resourceId")]
        public string ResourceId { get; set; }
    }

    /// <summary>
    /// The JSON response to deserialize when querying the Get (Az) Virtual Machine API or Get (Hybrid) Machine API
    /// We are only extracting out the Identity property.
    /// </summary>
    public sealed class Resource
    {
        [JsonProperty("identity")]
        public Identity Identity { get; set; }
    }

    // This will need to be updated to add userAssignedIdentities once it is supported by Arc.
    public sealed class Identity
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("principalId")]
        public string PrincipalId { get; set; }

        [JsonProperty("tenantId")]
        public string TenantId { get; set; }
    }
}


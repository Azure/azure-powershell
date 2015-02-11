namespace Microsoft.Azure.Commands.Network.ApplicationGateway.Model
{
    using System.Runtime.Serialization;


    /// <summary>
    /// Represents the provisioning state of a Gateway Tenant
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public enum ApplicationGatewayState
    {
        [EnumMember]
        Unknown,

        [EnumMember]
        Creating,

        [EnumMember]
        Stopped,

        [EnumMember]
        Starting,

        [EnumMember]
        Running,
        
        [EnumMember]
        Stopping,

        [EnumMember]
        Deleting,

        [EnumMember]
        Deleted

    }

    /// <summary>
    /// Represents the provisioning state of a Gateway Tenant
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public enum ApplicationGatewaySubState
    {
        [EnumMember]
        Unknown,

        [EnumMember]
        Updating
    }
}

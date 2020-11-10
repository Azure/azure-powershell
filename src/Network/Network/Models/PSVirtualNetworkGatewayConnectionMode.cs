namespace Microsoft.Azure.Commands.Network.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public enum VirtualNetworkGatewayConnectionMode
    {
        // Default behaviour to both initiate and respond to a connection request
        [EnumMember]
        Default,

        // Will only respond to connection request and never dial a connection
        [EnumMember]
        ResponderOnly,

        // Will only initiate a connection and never respond to an inital connection request
        [EnumMember]
        InitiatorOnly
    }
}

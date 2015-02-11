namespace Microsoft.Azure.Commands.Network.ApplicationGateway.Model
{
    using System.Runtime.Serialization;

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public enum Protocol
    {
        [EnumMember]
        Http,

        [EnumMember]
        Https
    }
}

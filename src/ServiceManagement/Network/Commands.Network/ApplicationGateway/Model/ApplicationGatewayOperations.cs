namespace Microsoft.Azure.Commands.Network.ApplicationGateway.Model
{
    using System.Runtime.Serialization;

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class ApplicationGatewayOperation
    {
        [DataMember(IsRequired = true)]
        public string OperationType;
    }
}

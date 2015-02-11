namespace Microsoft.Azure.Commands.Network.ApplicationGateway.Model
{
    using System.Runtime.Serialization;

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public abstract class ConfigValidation
    {
        public abstract void Validate();
    }

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public abstract class ConfigurationElement : ConfigValidation
    {
    }

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public abstract class NamedConfigurationElement : ConfigValidation
    {
        [DataMember(Order = 1, IsRequired = true)]
        public string Name { get; set; }
    }
}

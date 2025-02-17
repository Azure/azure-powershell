namespace Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401
{
    using Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models;
    public partial class Kubernetes
    {
        public System.Security.SecureString ServiceBusConnectionStringSecure { get => (this.ServiceBusConnectionString.ToSecureString()); set => this.ServiceBusConnectionString = value.ConvertToString(); }
    }
}
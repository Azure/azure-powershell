namespace Microsoft.Azure.PowerShell.Cmdlets.App.Models
{
    public partial class ManagedEnvironmentStorage
    {
        public System.Security.SecureString AzureFileAccountKeySecure { get => (this.AzureFileAccountKey.ToSecureString()); }
    }
}
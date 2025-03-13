namespace Microsoft.Azure.PowerShell.Cmdlets.App.Models
{
    public partial class ConnectedEnvironmentStorage
    {
        public System.Security.SecureString AzureFileAccountKeySecure { get => (this.AzureFileAccountKey.ToSecureString()); }
    }
}
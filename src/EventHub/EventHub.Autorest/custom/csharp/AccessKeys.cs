
namespace Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models
{
    public partial class AccessKeys
    {
        public System.Security.SecureString PrimaryKeySecure { get => (this.PrimaryKey.ToSecureString()); }
    }
}
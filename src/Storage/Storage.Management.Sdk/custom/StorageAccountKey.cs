namespace Microsoft.Azure.Management.Storage.Models
{
    using Microsoft.WindowsAzure.Commands.Common;

    /// <summary>
    /// An access key for the storage account.
    /// </summary>
    public partial class StorageAccountKey
    { 
        public System.Security.SecureString ValueSecure { get => (this.Value.ConvertToSecureString()); } 
    }
}

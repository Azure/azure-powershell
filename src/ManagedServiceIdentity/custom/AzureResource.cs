namespace Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models
{
    /// <summary>Customizations of AzureResource</summary>
    public partial class AzureResource
    {
        /// <summary>Property revealing 'Type' in response table.</summary>
        public string ResourceType { get => this.Type; }
    }
}
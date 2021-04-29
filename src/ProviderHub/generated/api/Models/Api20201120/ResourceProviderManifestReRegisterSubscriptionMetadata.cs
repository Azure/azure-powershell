namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceProviderManifestReRegisterSubscriptionMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestReRegisterSubscriptionMetadata,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestReRegisterSubscriptionMetadataInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IReRegisterSubscriptionMetadata"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IReRegisterSubscriptionMetadata __reRegisterSubscriptionMetadata = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ReRegisterSubscriptionMetadata();

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public int? ConcurrencyLimit { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IReRegisterSubscriptionMetadataInternal)__reRegisterSubscriptionMetadata).ConcurrencyLimit; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IReRegisterSubscriptionMetadataInternal)__reRegisterSubscriptionMetadata).ConcurrencyLimit = value ?? default(int); }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public bool Enabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IReRegisterSubscriptionMetadataInternal)__reRegisterSubscriptionMetadata).Enabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IReRegisterSubscriptionMetadataInternal)__reRegisterSubscriptionMetadata).Enabled = value ; }

        /// <summary>
        /// Creates an new <see cref="ResourceProviderManifestReRegisterSubscriptionMetadata" /> instance.
        /// </summary>
        public ResourceProviderManifestReRegisterSubscriptionMetadata()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__reRegisterSubscriptionMetadata), __reRegisterSubscriptionMetadata);
            await eventListener.AssertObjectIsValid(nameof(__reRegisterSubscriptionMetadata), __reRegisterSubscriptionMetadata);
        }
    }
    public partial interface IResourceProviderManifestReRegisterSubscriptionMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IReRegisterSubscriptionMetadata
    {

    }
    internal partial interface IResourceProviderManifestReRegisterSubscriptionMetadataInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IReRegisterSubscriptionMetadataInternal
    {

    }
}
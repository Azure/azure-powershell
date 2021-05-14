namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class SkuResource :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuResource,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.Resource();

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal)__resource).Id; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal)__resource).Type = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeSku Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceTypeSku()); set { {_property = value;} } }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeSku _property;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeSku Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceTypeSku()); set => this._property = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSetting[] SkuSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeSkuInternal)Property).SkuSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeSkuInternal)Property).SkuSetting = value ?? null /* arrayOf */; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="SkuResource" /> instance.</summary>
        public SkuResource()
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
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    public partial interface ISkuResource :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResource
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"skuSettings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSetting) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSetting[] SkuSetting { get; set; }

    }
    internal partial interface ISkuResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal
    {
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeSku Property { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSetting[] SkuSetting { get; set; }

    }
}
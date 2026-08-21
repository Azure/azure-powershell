// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Extensions;

    /// <summary>An offer.</summary>
    public partial class Offer :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOffer,
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferInternal,
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IExtensionResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IExtensionResource __extensionResource = new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ExtensionResource();

        /// <summary>The offer content</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContent Content { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPropertiesInternal)Property).OfferContent; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPropertiesInternal)Property).OfferContent = value ?? null /* model class */; }

        /// <summary>The content url</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inlined)]
        public string ContentUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPropertiesInternal)Property).ContentUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPropertiesInternal)Property).ContentUrl = value ?? null; }

        /// <summary>The content version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inlined)]
        public string ContentVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPropertiesInternal)Property).ContentVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPropertiesInternal)Property).ContentVersion = value ?? null; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).Id; }

        /// <summary>The marketplace skus</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSku> MarketplaceSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPropertiesInternal)Property).MarketplaceSku; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPropertiesInternal)Property).MarketplaceSku = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferProperties Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.OfferProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPropertiesInternal)Property).ProvisioningState = value ?? null; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).Id = value ?? null; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).Name = value ?? null; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ISystemData Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).SystemData = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SystemDataCreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal.SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataCreatedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal.SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).SystemDataCreatedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataCreatedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal.SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).SystemDataCreatedByType = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal.SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataLastModifiedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal.SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal.SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedByType = value ?? null; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).Type = value ?? null; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferProperties _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.OfferProperties()); set => this._property = value; }

        /// <summary>The resource provisioning state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPropertiesInternal)Property).ProvisioningState; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).SystemData = value ?? null /* model class */; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).SystemDataCreatedAt; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inherited)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).SystemDataCreatedBy; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inherited)]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).SystemDataCreatedByType; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedAt; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedBy; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedByType; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).Type; }

        /// <summary>Creates an new <see cref="Offer" /> instance.</summary>
        public Offer()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__extensionResource), __extensionResource);
            await eventListener.AssertObjectIsValid(nameof(__extensionResource), __extensionResource);
        }
    }
    /// An offer.
    public partial interface IOffer :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IExtensionResource
    {
        /// <summary>The offer content</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The offer content",
        SerializedName = @"offerContent",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContent) })]
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContent Content { get; set; }
        /// <summary>The content url</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The content url",
        SerializedName = @"contentUrl",
        PossibleTypes = new [] { typeof(string) })]
        string ContentUrl { get; set; }
        /// <summary>The content version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The content version",
        SerializedName = @"contentVersion",
        PossibleTypes = new [] { typeof(string) })]
        string ContentVersion { get; set; }
        /// <summary>The marketplace skus</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The marketplace skus",
        SerializedName = @"marketplaceSkus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSku) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSku> MarketplaceSku { get; set; }
        /// <summary>The resource provisioning state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The resource provisioning state",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled")]
        string ProvisioningState { get;  }

    }
    /// An offer.
    internal partial interface IOfferInternal :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IExtensionResourceInternal
    {
        /// <summary>The offer content</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContent Content { get; set; }
        /// <summary>The content url</summary>
        string ContentUrl { get; set; }
        /// <summary>The content version</summary>
        string ContentVersion { get; set; }
        /// <summary>The marketplace skus</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSku> MarketplaceSku { get; set; }
        /// <summary>The resource-specific properties for this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferProperties Property { get; set; }
        /// <summary>The resource provisioning state</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled")]
        string ProvisioningState { get; set; }

    }
}
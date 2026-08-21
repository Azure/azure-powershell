// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Extensions;

    /// <summary>A publisher who provides offers.</summary>
    public partial class Publisher :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IPublisher,
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IPublisherInternal,
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IExtensionResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IExtensionResource __extensionResource = new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ExtensionResource();

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IResourceInternal)__extensionResource).Id; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IPublisherProperties Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IPublisherInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.PublisherProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IPublisherInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IPublisherPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IPublisherPropertiesInternal)Property).ProvisioningState = value ?? null; }

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
        private Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IPublisherProperties _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IPublisherProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.PublisherProperties()); set => this._property = value; }

        /// <summary>The resource provisioning state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IPublisherPropertiesInternal)Property).ProvisioningState; }

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

        /// <summary>Creates an new <see cref="Publisher" /> instance.</summary>
        public Publisher()
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
    /// A publisher who provides offers.
    public partial interface IPublisher :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IExtensionResource
    {
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
    /// A publisher who provides offers.
    internal partial interface IPublisherInternal :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IExtensionResourceInternal
    {
        /// <summary>The resource-specific properties for this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IPublisherProperties Property { get; set; }
        /// <summary>The resource provisioning state</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled")]
        string ProvisioningState { get; set; }

    }
}
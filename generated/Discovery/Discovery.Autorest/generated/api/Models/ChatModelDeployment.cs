// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>
    /// Represents a deployment that ties a specific model family to a user defined deployment name used when invoking the chat
    /// model.
    /// </summary>
    public partial class ChatModelDeployment :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeployment,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.TrackedResource();

        /// <summary>Provisioned SKU capacity units for this chat model deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public int? Capacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentPropertiesInternal)Property).Capacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentPropertiesInternal)Property).Capacity = value ?? default(int); }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Id; }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)__trackedResource).Location = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentProperties Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ChatModelDeploymentProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentPropertiesInternal)Property).ProvisioningState = value ?? null; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Id = value ?? null; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Name = value ?? null; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemData Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemData = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SystemDataCreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataCreatedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataCreatedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataLastModifiedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType = value ?? null; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Type = value ?? null; }

        /// <summary>
        /// Model format as published by the provider. Verify supported formats per region using the Model Catalog API.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ModelFormat { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentPropertiesInternal)Property).ModelFormat; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentPropertiesInternal)Property).ModelFormat = value ?? null; }

        /// <summary>
        /// Canonical provider model name available in the selected region. Verify supported values per region using the Model Catalog
        /// API.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ModelName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentPropertiesInternal)Property).ModelName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentPropertiesInternal)Property).ModelName = value ?? null; }

        /// <summary>Provider-published version of the selected model.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ModelVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentPropertiesInternal)Property).ModelVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentPropertiesInternal)Property).ModelVersion = value ?? null; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentProperties _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ChatModelDeploymentProperties()); set => this._property = value; }

        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentPropertiesInternal)Property).ProvisioningState; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>SKU tier used by this chat model deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentPropertiesInternal)Property).SkuName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentPropertiesInternal)Property).SkuName = value ?? null; }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemData = value ?? null /* model class */; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)__trackedResource).Tag = value ?? null /* model class */; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Type; }

        /// <summary>Creates an new <see cref="ChatModelDeployment" /> instance.</summary>
        public ChatModelDeployment()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// Represents a deployment that ties a specific model family to a user defined deployment name used when invoking the chat
    /// model.
    public partial interface IChatModelDeployment :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResource
    {
        /// <summary>Provisioned SKU capacity units for this chat model deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Provisioned SKU capacity units for this chat model deployment.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? Capacity { get; set; }
        /// <summary>
        /// Model format as published by the provider. Verify supported formats per region using the Model Catalog API.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Model format as published by the provider. Verify supported formats per region using the Model Catalog API.",
        SerializedName = @"modelFormat",
        PossibleTypes = new [] { typeof(string) })]
        string ModelFormat { get; set; }
        /// <summary>
        /// Canonical provider model name available in the selected region. Verify supported values per region using the Model Catalog
        /// API.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Canonical provider model name available in the selected region. Verify supported values per region using the Model Catalog API.",
        SerializedName = @"modelName",
        PossibleTypes = new [] { typeof(string) })]
        string ModelName { get; set; }
        /// <summary>Provider-published version of the selected model.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Provider-published version of the selected model.",
        SerializedName = @"modelVersion",
        PossibleTypes = new [] { typeof(string) })]
        string ModelVersion { get; set; }
        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The status of the last operation.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Accepted", "Provisioning", "Updating", "Deleting")]
        string ProvisioningState { get;  }
        /// <summary>SKU tier used by this chat model deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"SKU tier used by this chat model deployment.",
        SerializedName = @"skuName",
        PossibleTypes = new [] { typeof(string) })]
        string SkuName { get; set; }

    }
    /// Represents a deployment that ties a specific model family to a user defined deployment name used when invoking the chat
    /// model.
    internal partial interface IChatModelDeploymentInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal
    {
        /// <summary>Provisioned SKU capacity units for this chat model deployment.</summary>
        int? Capacity { get; set; }
        /// <summary>
        /// Model format as published by the provider. Verify supported formats per region using the Model Catalog API.
        /// </summary>
        string ModelFormat { get; set; }
        /// <summary>
        /// Canonical provider model name available in the selected region. Verify supported values per region using the Model Catalog
        /// API.
        /// </summary>
        string ModelName { get; set; }
        /// <summary>Provider-published version of the selected model.</summary>
        string ModelVersion { get; set; }
        /// <summary>The resource-specific properties for this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentProperties Property { get; set; }
        /// <summary>The status of the last operation.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Accepted", "Provisioning", "Updating", "Deleting")]
        string ProvisioningState { get; set; }
        /// <summary>SKU tier used by this chat model deployment.</summary>
        string SkuName { get; set; }

    }
}
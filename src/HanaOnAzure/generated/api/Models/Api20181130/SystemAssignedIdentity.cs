namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>Describes a system assigned identity resource.</summary>
    public partial class SystemAssignedIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentity,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityInternal,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.Resource();

        /// <summary>
        /// The id of the app associated with the identity. This is a random generated UUID by MSI.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public string ClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityPropertiesInternal)Property).ClientId; }

        /// <summary>
        /// The ManagedServiceIdentity DataPlane URL that can be queried to obtain the identity credentials.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public string ClientSecretUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityPropertiesInternal)Property).ClientSecretUrl; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__resource).Id; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__resource).Type = value; }

        /// <summary>Internal Acessors for ClientId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityInternal.ClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityPropertiesInternal)Property).ClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityPropertiesInternal)Property).ClientId = value; }

        /// <summary>Internal Acessors for ClientSecretUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityInternal.ClientSecretUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityPropertiesInternal)Property).ClientSecretUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityPropertiesInternal)Property).ClientSecretUrl = value; }

        /// <summary>Internal Acessors for PrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityInternal.PrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityPropertiesInternal)Property).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityPropertiesInternal)Property).PrincipalId = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityProperties Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.SystemAssignedIdentityProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for TenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityInternal.TenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityPropertiesInternal)Property).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityPropertiesInternal)Property).TenantId = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__resource).Name; }

        /// <summary>The id of the service principal object associated with the created identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public string PrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityPropertiesInternal)Property).PrincipalId; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityProperties _property;

        /// <summary>The properties associated with the identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.SystemAssignedIdentityProperties()); }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityTags _tag;

        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.SystemAssignedIdentityTags()); set => this._tag = value; }

        /// <summary>The id of the tenant which the identity belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public string TenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityPropertiesInternal)Property).TenantId; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="SystemAssignedIdentity" /> instance.</summary>
        public SystemAssignedIdentity()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Describes a system assigned identity resource.
    public partial interface ISystemAssignedIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResource
    {
        /// <summary>
        /// The id of the app associated with the identity. This is a random generated UUID by MSI.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The id of the app associated with the identity. This is a random generated UUID by MSI.",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string ClientId { get;  }
        /// <summary>
        /// The ManagedServiceIdentity DataPlane URL that can be queried to obtain the identity credentials.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @" The ManagedServiceIdentity DataPlane URL that can be queried to obtain the identity credentials.",
        SerializedName = @"clientSecretUrl",
        PossibleTypes = new [] { typeof(string) })]
        string ClientSecretUrl { get;  }
        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The geo-location where the resource lives",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>The id of the service principal object associated with the created identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The id of the service principal object associated with the created identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalId { get;  }
        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityTags Tag { get; set; }
        /// <summary>The id of the tenant which the identity belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The id of the tenant which the identity belongs to.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get;  }

    }
    /// Describes a system assigned identity resource.
    internal partial interface ISystemAssignedIdentityInternal :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal
    {
        /// <summary>
        /// The id of the app associated with the identity. This is a random generated UUID by MSI.
        /// </summary>
        string ClientId { get; set; }
        /// <summary>
        /// The ManagedServiceIdentity DataPlane URL that can be queried to obtain the identity credentials.
        /// </summary>
        string ClientSecretUrl { get; set; }
        /// <summary>The geo-location where the resource lives</summary>
        string Location { get; set; }
        /// <summary>The id of the service principal object associated with the created identity.</summary>
        string PrincipalId { get; set; }
        /// <summary>The properties associated with the identity.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityProperties Property { get; set; }
        /// <summary>Resource tags</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityTags Tag { get; set; }
        /// <summary>The id of the tenant which the identity belongs to.</summary>
        string TenantId { get; set; }

    }
}
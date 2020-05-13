namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Describes an identity resource.</summary>
    public partial class IdentityUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IIdentityUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IIdentityUpdateInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.Resource();

        /// <summary>
        /// The id of the app associated with the identity. This is a random generated UUID by MSI.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IUserAssignedIdentityPropertiesInternal)Property).ClientId; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Id; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Type = value; }

        /// <summary>Internal Acessors for ClientId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IIdentityUpdateInternal.ClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IUserAssignedIdentityPropertiesInternal)Property).ClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IUserAssignedIdentityPropertiesInternal)Property).ClientId = value; }

        /// <summary>Internal Acessors for PrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IIdentityUpdateInternal.PrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IUserAssignedIdentityPropertiesInternal)Property).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IUserAssignedIdentityPropertiesInternal)Property).PrincipalId = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IUserAssignedIdentityProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IIdentityUpdateInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.UserAssignedIdentityProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for TenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IIdentityUpdateInternal.TenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IUserAssignedIdentityPropertiesInternal)Property).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IUserAssignedIdentityPropertiesInternal)Property).TenantId = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Name; }

        /// <summary>The id of the service principal object associated with the created identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IUserAssignedIdentityPropertiesInternal)Property).PrincipalId; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IUserAssignedIdentityProperties _property;

        /// <summary>The properties associated with the identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IUserAssignedIdentityProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.UserAssignedIdentityProperties()); }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IIdentityUpdateTags _tag;

        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IIdentityUpdateTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IdentityUpdateTags()); set => this._tag = value; }

        /// <summary>The id of the tenant which the identity belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string TenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IUserAssignedIdentityPropertiesInternal)Property).TenantId; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="IdentityUpdate" /> instance.</summary>
        public IdentityUpdate()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Describes an identity resource.
    public partial interface IIdentityUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResource
    {
        /// <summary>
        /// The id of the app associated with the identity. This is a random generated UUID by MSI.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The id of the app associated with the identity. This is a random generated UUID by MSI.",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string ClientId { get;  }
        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The geo-location where the resource lives",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>The id of the service principal object associated with the created identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The id of the service principal object associated with the created identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalId { get;  }
        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IIdentityUpdateTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IIdentityUpdateTags Tag { get; set; }
        /// <summary>The id of the tenant which the identity belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The id of the tenant which the identity belongs to.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get;  }

    }
    /// Describes an identity resource.
    internal partial interface IIdentityUpdateInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal
    {
        /// <summary>
        /// The id of the app associated with the identity. This is a random generated UUID by MSI.
        /// </summary>
        string ClientId { get; set; }
        /// <summary>The geo-location where the resource lives</summary>
        string Location { get; set; }
        /// <summary>The id of the service principal object associated with the created identity.</summary>
        string PrincipalId { get; set; }
        /// <summary>The properties associated with the identity.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IUserAssignedIdentityProperties Property { get; set; }
        /// <summary>Resource tags</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IIdentityUpdateTags Tag { get; set; }
        /// <summary>The id of the tenant which the identity belongs to.</summary>
        string TenantId { get; set; }

    }
}
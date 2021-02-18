namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>Represents a and external administrator to be created.</summary>
    public partial class ServerAdministratorResource :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorResource,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.Resource();

        /// <summary>The type of administrator.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public string AdministratorType { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorPropertiesInternal)Property).AdministratorType; }

        /// <summary>
        /// Fully qualified resource Id for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal)__resource).Id; }

        /// <summary>The server administrator login account name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public string Login { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorPropertiesInternal)Property).Login; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorPropertiesInternal)Property).Login = value ?? null; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal)__resource).Type = value; }

        /// <summary>Internal Acessors for AdministratorType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorResourceInternal.AdministratorType { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorPropertiesInternal)Property).AdministratorType; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorPropertiesInternal)Property).AdministratorType = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorProperties Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerAdministratorProperties()); set { {_property = value;} } }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorProperties _property;

        /// <summary>Properties of the server AAD administrator.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerAdministratorProperties()); set => this._property = value; }

        /// <summary>The server administrator Sid (Secure ID).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public string Sid { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorPropertiesInternal)Property).Sid; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorPropertiesInternal)Property).Sid = value ?? null; }

        /// <summary>The server Active Directory Administrator tenant id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public string TenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorPropertiesInternal)Property).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorPropertiesInternal)Property).TenantId = value ?? null; }

        /// <summary>
        /// The type of the resource. Ex- Microsoft.Compute/virtualMachines or Microsoft.Storage/storageAccounts.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="ServerAdministratorResource" /> instance.</summary>
        public ServerAdministratorResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Represents a and external administrator to be created.
    public partial interface IServerAdministratorResource :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResource
    {
        /// <summary>The type of administrator.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of administrator.",
        SerializedName = @"administratorType",
        PossibleTypes = new [] { typeof(string) })]
        string AdministratorType { get;  }
        /// <summary>The server administrator login account name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The server administrator login account name.",
        SerializedName = @"login",
        PossibleTypes = new [] { typeof(string) })]
        string Login { get; set; }
        /// <summary>The server administrator Sid (Secure ID).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The server administrator Sid (Secure ID).",
        SerializedName = @"sid",
        PossibleTypes = new [] { typeof(string) })]
        string Sid { get; set; }
        /// <summary>The server Active Directory Administrator tenant id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The server Active Directory Administrator tenant id.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get; set; }

    }
    /// Represents a and external administrator to be created.
    internal partial interface IServerAdministratorResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal
    {
        /// <summary>The type of administrator.</summary>
        string AdministratorType { get; set; }
        /// <summary>The server administrator login account name.</summary>
        string Login { get; set; }
        /// <summary>Properties of the server AAD administrator.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorProperties Property { get; set; }
        /// <summary>The server administrator Sid (Secure ID).</summary>
        string Sid { get; set; }
        /// <summary>The server Active Directory Administrator tenant id.</summary>
        string TenantId { get; set; }

    }
}
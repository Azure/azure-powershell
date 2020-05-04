namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>Azure Active Directory identity configuration for a resource.</summary>
    public partial class ResourceIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IResourceIdentity,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IResourceIdentityInternal
    {

        /// <summary>Internal Acessors for PrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IResourceIdentityInternal.PrincipalId { get => this._principalId; set { {_principalId = value;} } }

        /// <summary>Internal Acessors for TenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IResourceIdentityInternal.TenantId { get => this._tenantId; set { {_tenantId = value;} } }

        /// <summary>Backing field for <see cref="PrincipalId" /> property.</summary>
        private string _principalId;

        /// <summary>The Azure Active Directory principal id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string PrincipalId { get => this._principalId; }

        /// <summary>Backing field for <see cref="TenantId" /> property.</summary>
        private string _tenantId;

        /// <summary>The Azure Active Directory tenant id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string TenantId { get => this._tenantId; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.IdentityType? _type;

        /// <summary>
        /// The identity type. Set this to 'SystemAssigned' in order to automatically create and assign an Azure Active Directory
        /// principal for the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.IdentityType? Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="ResourceIdentity" /> instance.</summary>
        public ResourceIdentity()
        {

        }
    }
    /// Azure Active Directory identity configuration for a resource.
    public partial interface IResourceIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable
    {
        /// <summary>The Azure Active Directory principal id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Azure Active Directory principal id.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalId { get;  }
        /// <summary>The Azure Active Directory tenant id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Azure Active Directory tenant id.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get;  }
        /// <summary>
        /// The identity type. Set this to 'SystemAssigned' in order to automatically create and assign an Azure Active Directory
        /// principal for the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identity type. Set this to 'SystemAssigned' in order to automatically create and assign an Azure Active Directory principal for the resource.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.IdentityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.IdentityType? Type { get; set; }

    }
    /// Azure Active Directory identity configuration for a resource.
    internal partial interface IResourceIdentityInternal

    {
        /// <summary>The Azure Active Directory principal id.</summary>
        string PrincipalId { get; set; }
        /// <summary>The Azure Active Directory tenant id.</summary>
        string TenantId { get; set; }
        /// <summary>
        /// The identity type. Set this to 'SystemAssigned' in order to automatically create and assign an Azure Active Directory
        /// principal for the resource.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.IdentityType? Type { get; set; }

    }
}
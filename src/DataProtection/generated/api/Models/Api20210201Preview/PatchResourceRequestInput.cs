namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Patch Request content for Microsoft.DataProtection resources</summary>
    public partial class PatchResourceRequestInput :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IPatchResourceRequestInput,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IPatchResourceRequestInputInternal
    {

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDppIdentityDetails _identity;

        /// <summary>Input Managed Identity Details</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDppIdentityDetails Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.DppIdentityDetails()); set => this._identity = value; }

        /// <summary>
        /// The object ID of the service principal object for the managed identity that is used to grant role-based access to an Azure
        /// resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDppIdentityDetailsInternal)Identity).PrincipalId; }

        /// <summary>
        /// A Globally Unique Identifier (GUID) that represents the Azure AD tenant where the resource is now a member.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDppIdentityDetailsInternal)Identity).TenantId; }

        /// <summary>The identityType which can be either SystemAssigned or None</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDppIdentityDetailsInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDppIdentityDetailsInternal)Identity).Type = value ?? null; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDppIdentityDetails Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IPatchResourceRequestInputInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.DppIdentityDetails()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IPatchResourceRequestInputInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDppIdentityDetailsInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDppIdentityDetailsInternal)Identity).PrincipalId = value; }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IPatchResourceRequestInputInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDppIdentityDetailsInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDppIdentityDetailsInternal)Identity).TenantId = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IPatchResourceRequestInputTags _tag;

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IPatchResourceRequestInputTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.PatchResourceRequestInputTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="PatchResourceRequestInput" /> instance.</summary>
        public PatchResourceRequestInput()
        {

        }
    }
    /// Patch Request content for Microsoft.DataProtection resources
    public partial interface IPatchResourceRequestInput :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The object ID of the service principal object for the managed identity that is used to grant role-based access to an Azure
        /// resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The object ID of the service principal object for the managed identity that is used to grant role-based access to an Azure resource.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityPrincipalId { get;  }
        /// <summary>
        /// A Globally Unique Identifier (GUID) that represents the Azure AD tenant where the resource is now a member.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A Globally Unique Identifier (GUID) that represents the Azure AD tenant where the resource is now a member.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityTenantId { get;  }
        /// <summary>The identityType which can be either SystemAssigned or None</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identityType which can be either SystemAssigned or None",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityType { get; set; }
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IPatchResourceRequestInputTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IPatchResourceRequestInputTags Tag { get; set; }

    }
    /// Patch Request content for Microsoft.DataProtection resources
    internal partial interface IPatchResourceRequestInputInternal

    {
        /// <summary>Input Managed Identity Details</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDppIdentityDetails Identity { get; set; }
        /// <summary>
        /// The object ID of the service principal object for the managed identity that is used to grant role-based access to an Azure
        /// resource.
        /// </summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>
        /// A Globally Unique Identifier (GUID) that represents the Azure AD tenant where the resource is now a member.
        /// </summary>
        string IdentityTenantId { get; set; }
        /// <summary>The identityType which can be either SystemAssigned or None</summary>
        string IdentityType { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IPatchResourceRequestInputTags Tag { get; set; }

    }
}
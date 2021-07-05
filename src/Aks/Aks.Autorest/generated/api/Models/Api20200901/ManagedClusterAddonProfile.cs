namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>A Kubernetes add-on profile for a managed cluster.</summary>
    public partial class ManagedClusterAddonProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfile,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal
    {

        /// <summary>Backing field for <see cref="Config" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileConfig _config;

        /// <summary>Key-value pairs for configuring an add-on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileConfig Config { get => (this._config = this._config ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterAddonProfileConfig()); set => this._config = value; }

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private bool _enabled;

        /// <summary>Whether the add-on is enabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public bool Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentity _identity;

        /// <summary>Information of user assigned identity used by this add-on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentity Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.UserAssignedIdentity()); }

        /// <summary>The client id of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string IdentityClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentityInternal)Identity).ClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentityInternal)Identity).ClientId = value ?? null; }

        /// <summary>The object id of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string IdentityObjectId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentityInternal)Identity).ObjectId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentityInternal)Identity).ObjectId = value ?? null; }

        /// <summary>The resource id of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string IdentityResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentityInternal)Identity).ResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentityInternal)Identity).ResourceId = value ?? null; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentity Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.UserAssignedIdentity()); set { {_identity = value;} } }

        /// <summary>Creates an new <see cref="ManagedClusterAddonProfile" /> instance.</summary>
        public ManagedClusterAddonProfile()
        {

        }
    }
    /// A Kubernetes add-on profile for a managed cluster.
    public partial interface IManagedClusterAddonProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>Key-value pairs for configuring an add-on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Key-value pairs for configuring an add-on.",
        SerializedName = @"config",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileConfig) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileConfig Config { get; set; }
        /// <summary>Whether the add-on is enabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Whether the add-on is enabled or not.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool Enabled { get; set; }
        /// <summary>The client id of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The client id of the user assigned identity.",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityClientId { get; set; }
        /// <summary>The object id of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The object id of the user assigned identity.",
        SerializedName = @"objectId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityObjectId { get; set; }
        /// <summary>The resource id of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource id of the user assigned identity.",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityResourceId { get; set; }

    }
    /// A Kubernetes add-on profile for a managed cluster.
    internal partial interface IManagedClusterAddonProfileInternal

    {
        /// <summary>Key-value pairs for configuring an add-on.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileConfig Config { get; set; }
        /// <summary>Whether the add-on is enabled or not.</summary>
        bool Enabled { get; set; }
        /// <summary>Information of user assigned identity used by this add-on.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentity Identity { get; set; }
        /// <summary>The client id of the user assigned identity.</summary>
        string IdentityClientId { get; set; }
        /// <summary>The object id of the user assigned identity.</summary>
        string IdentityObjectId { get; set; }
        /// <summary>The resource id of the user assigned identity.</summary>
        string IdentityResourceId { get; set; }

    }
}
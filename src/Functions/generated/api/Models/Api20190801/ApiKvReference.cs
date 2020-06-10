namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Description of site key vault references.</summary>
    public partial class ApiKvReference :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApiKvReference,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApiKvReferenceInternal
    {

        /// <summary>Backing field for <see cref="Detail" /> property.</summary>
        private string _detail;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Detail { get => this._detail; set => this._detail = value; }

        /// <summary>Backing field for <see cref="IdentityType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType? _identityType;

        /// <summary>Type of managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType? IdentityType { get => this._identityType; set => this._identityType = value; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ConfigReferenceLocation? _location;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ConfigReferenceLocation? Location { get => this._location; set => this._location = value; }

        /// <summary>Backing field for <see cref="Reference" /> property.</summary>
        private string _reference;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Reference { get => this._reference; set => this._reference = value; }

        /// <summary>Backing field for <see cref="SecretName" /> property.</summary>
        private string _secretName;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SecretName { get => this._secretName; set => this._secretName = value; }

        /// <summary>Backing field for <see cref="SecretVersion" /> property.</summary>
        private string _secretVersion;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SecretVersion { get => this._secretVersion; set => this._secretVersion = value; }

        /// <summary>Backing field for <see cref="Source" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ConfigReferenceSource? _source;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ConfigReferenceSource? Source { get => this._source; set => this._source = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ResolveStatus? _status;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ResolveStatus? Status { get => this._status; set => this._status = value; }

        /// <summary>Backing field for <see cref="VaultName" /> property.</summary>
        private string _vaultName;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string VaultName { get => this._vaultName; set => this._vaultName = value; }

        /// <summary>Creates an new <see cref="ApiKvReference" /> instance.</summary>
        public ApiKvReference()
        {

        }
    }
    /// Description of site key vault references.
    public partial interface IApiKvReference :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(string) })]
        string Detail { get; set; }
        /// <summary>Type of managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of managed service identity.",
        SerializedName = @"identityType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType? IdentityType { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ConfigReferenceLocation) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ConfigReferenceLocation? Location { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"reference",
        PossibleTypes = new [] { typeof(string) })]
        string Reference { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"secretName",
        PossibleTypes = new [] { typeof(string) })]
        string SecretName { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"secretVersion",
        PossibleTypes = new [] { typeof(string) })]
        string SecretVersion { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"source",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ConfigReferenceSource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ConfigReferenceSource? Source { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ResolveStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ResolveStatus? Status { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"vaultName",
        PossibleTypes = new [] { typeof(string) })]
        string VaultName { get; set; }

    }
    /// Description of site key vault references.
    internal partial interface IApiKvReferenceInternal

    {
        string Detail { get; set; }
        /// <summary>Type of managed service identity.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType? IdentityType { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ConfigReferenceLocation? Location { get; set; }

        string Reference { get; set; }

        string SecretName { get; set; }

        string SecretVersion { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ConfigReferenceSource? Source { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ResolveStatus? Status { get; set; }

        string VaultName { get; set; }

    }
}
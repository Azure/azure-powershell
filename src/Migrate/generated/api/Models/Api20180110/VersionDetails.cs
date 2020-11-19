namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Version related details.</summary>
    public partial class VersionDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetailsInternal
    {

        /// <summary>Backing field for <see cref="ExpiryDate" /> property.</summary>
        private global::System.DateTime? _expiryDate;

        /// <summary>Version expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? ExpiryDate { get => this._expiryDate; set => this._expiryDate = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus? _status;

        /// <summary>A value indicating whether security update required.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus? Status { get => this._status; set => this._status = value; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>The agent version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Version { get => this._version; set => this._version = value; }

        /// <summary>Creates an new <see cref="VersionDetails" /> instance.</summary>
        public VersionDetails()
        {

        }
    }
    /// Version related details.
    public partial interface IVersionDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Version expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Version expiry date.",
        SerializedName = @"expiryDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ExpiryDate { get; set; }
        /// <summary>A value indicating whether security update required.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether security update required.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus? Status { get; set; }
        /// <summary>The agent version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The agent version.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get; set; }

    }
    /// Version related details.
    internal partial interface IVersionDetailsInternal

    {
        /// <summary>Version expiry date.</summary>
        global::System.DateTime? ExpiryDate { get; set; }
        /// <summary>A value indicating whether security update required.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus? Status { get; set; }
        /// <summary>The agent version.</summary>
        string Version { get; set; }

    }
}
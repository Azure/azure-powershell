namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class for host properties.</summary>
    public partial class HyperVHostProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostPropertiesInternal
    {

        /// <summary>Backing field for <see cref="CreatedTimestamp" /> property.</summary>
        private string _createdTimestamp;

        /// <summary>Timestamp marking Hyper-V host creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string CreatedTimestamp { get => this._createdTimestamp; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] _error;

        /// <summary>Errors for Hyper-V hosts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Error { get => this._error; }

        /// <summary>Backing field for <see cref="Fqdn" /> property.</summary>
        private string _fqdn;

        /// <summary>FQDN/IPAddress of the Hyper-V host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Fqdn { get => this._fqdn; set => this._fqdn = value; }

        /// <summary>Internal Acessors for CreatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostPropertiesInternal.CreatedTimestamp { get => this._createdTimestamp; set { {_createdTimestamp = value;} } }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostPropertiesInternal.Error { get => this._error; set { {_error = value;} } }

        /// <summary>Internal Acessors for UpdatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostPropertiesInternal.UpdatedTimestamp { get => this._updatedTimestamp; set { {_updatedTimestamp = value;} } }

        /// <summary>Internal Acessors for Version</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostPropertiesInternal.Version { get => this._version; set { {_version = value;} } }

        /// <summary>Backing field for <see cref="RunAsAccountId" /> property.</summary>
        private string _runAsAccountId;

        /// <summary>Run as account ID of the Hyper-V host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RunAsAccountId { get => this._runAsAccountId; set => this._runAsAccountId = value; }

        /// <summary>Backing field for <see cref="UpdatedTimestamp" /> property.</summary>
        private string _updatedTimestamp;

        /// <summary>Timestamp marking last updated on the Hyper-V host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string UpdatedTimestamp { get => this._updatedTimestamp; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>Version of the Hyper-V host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Version { get => this._version; }

        /// <summary>Creates an new <see cref="HyperVHostProperties" /> instance.</summary>
        public HyperVHostProperties()
        {

        }
    }
    /// Class for host properties.
    public partial interface IHyperVHostProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Timestamp marking Hyper-V host creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Timestamp marking Hyper-V host creation.",
        SerializedName = @"createdTimestamp",
        PossibleTypes = new [] { typeof(string) })]
        string CreatedTimestamp { get;  }
        /// <summary>Errors for Hyper-V hosts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Errors for Hyper-V hosts.",
        SerializedName = @"errors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Error { get;  }
        /// <summary>FQDN/IPAddress of the Hyper-V host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"FQDN/IPAddress of the Hyper-V host.",
        SerializedName = @"fqdn",
        PossibleTypes = new [] { typeof(string) })]
        string Fqdn { get; set; }
        /// <summary>Run as account ID of the Hyper-V host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Run as account ID of the Hyper-V host.",
        SerializedName = @"runAsAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string RunAsAccountId { get; set; }
        /// <summary>Timestamp marking last updated on the Hyper-V host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Timestamp marking last updated on the Hyper-V host.",
        SerializedName = @"updatedTimestamp",
        PossibleTypes = new [] { typeof(string) })]
        string UpdatedTimestamp { get;  }
        /// <summary>Version of the Hyper-V host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Version of the Hyper-V host.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get;  }

    }
    /// Class for host properties.
    internal partial interface IHyperVHostPropertiesInternal

    {
        /// <summary>Timestamp marking Hyper-V host creation.</summary>
        string CreatedTimestamp { get; set; }
        /// <summary>Errors for Hyper-V hosts.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Error { get; set; }
        /// <summary>FQDN/IPAddress of the Hyper-V host.</summary>
        string Fqdn { get; set; }
        /// <summary>Run as account ID of the Hyper-V host.</summary>
        string RunAsAccountId { get; set; }
        /// <summary>Timestamp marking last updated on the Hyper-V host.</summary>
        string UpdatedTimestamp { get; set; }
        /// <summary>Version of the Hyper-V host.</summary>
        string Version { get; set; }

    }
}
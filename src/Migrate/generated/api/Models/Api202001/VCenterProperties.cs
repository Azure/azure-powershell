namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class for vCenter properties.</summary>
    public partial class VCenterProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal
    {

        /// <summary>Backing field for <see cref="CreatedTimestamp" /> property.</summary>
        private string _createdTimestamp;

        /// <summary>Timestamp marking vCenter creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string CreatedTimestamp { get => this._createdTimestamp; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] _error;

        /// <summary>Error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Error { get => this._error; }

        /// <summary>Backing field for <see cref="Fqdn" /> property.</summary>
        private string _fqdn;

        /// <summary>FQDN/IPAddress of the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Fqdn { get => this._fqdn; set => this._fqdn = value; }

        /// <summary>Backing field for <see cref="InstanceUuid" /> property.</summary>
        private string _instanceUuid;

        /// <summary>Instance UUID of the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceUuid { get => this._instanceUuid; }

        /// <summary>Internal Acessors for CreatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal.CreatedTimestamp { get => this._createdTimestamp; set { {_createdTimestamp = value;} } }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal.Error { get => this._error; set { {_error = value;} } }

        /// <summary>Internal Acessors for InstanceUuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal.InstanceUuid { get => this._instanceUuid; set { {_instanceUuid = value;} } }

        /// <summary>Internal Acessors for PerfStatisticsLevel</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal.PerfStatisticsLevel { get => this._perfStatisticsLevel; set { {_perfStatisticsLevel = value;} } }

        /// <summary>Internal Acessors for UpdatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal.UpdatedTimestamp { get => this._updatedTimestamp; set { {_updatedTimestamp = value;} } }

        /// <summary>Internal Acessors for Version</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal.Version { get => this._version; set { {_version = value;} } }

        /// <summary>Backing field for <see cref="PerfStatisticsLevel" /> property.</summary>
        private string _perfStatisticsLevel;

        /// <summary>Performance statistics enabled on the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PerfStatisticsLevel { get => this._perfStatisticsLevel; }

        /// <summary>Backing field for <see cref="Port" /> property.</summary>
        private string _port;

        /// <summary>Port of the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Port { get => this._port; set => this._port = value; }

        /// <summary>Backing field for <see cref="RunAsAccountId" /> property.</summary>
        private string _runAsAccountId;

        /// <summary>Run as account ID of the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RunAsAccountId { get => this._runAsAccountId; set => this._runAsAccountId = value; }

        /// <summary>Backing field for <see cref="UpdatedTimestamp" /> property.</summary>
        private string _updatedTimestamp;

        /// <summary>Timestamp marking last updated on the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string UpdatedTimestamp { get => this._updatedTimestamp; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>Version of the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Version { get => this._version; }

        /// <summary>Creates an new <see cref="VCenterProperties" /> instance.</summary>
        public VCenterProperties()
        {

        }
    }
    /// Class for vCenter properties.
    public partial interface IVCenterProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Timestamp marking vCenter creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Timestamp marking vCenter creation.",
        SerializedName = @"createdTimestamp",
        PossibleTypes = new [] { typeof(string) })]
        string CreatedTimestamp { get;  }
        /// <summary>Error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error details.",
        SerializedName = @"errors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Error { get;  }
        /// <summary>FQDN/IPAddress of the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"FQDN/IPAddress of the vCenter.",
        SerializedName = @"fqdn",
        PossibleTypes = new [] { typeof(string) })]
        string Fqdn { get; set; }
        /// <summary>Instance UUID of the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Instance UUID of the vCenter.",
        SerializedName = @"instanceUuid",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceUuid { get;  }
        /// <summary>Performance statistics enabled on the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Performance statistics enabled on the vCenter.",
        SerializedName = @"perfStatisticsLevel",
        PossibleTypes = new [] { typeof(string) })]
        string PerfStatisticsLevel { get;  }
        /// <summary>Port of the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Port of the vCenter.",
        SerializedName = @"port",
        PossibleTypes = new [] { typeof(string) })]
        string Port { get; set; }
        /// <summary>Run as account ID of the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Run as account ID of the vCenter.",
        SerializedName = @"runAsAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string RunAsAccountId { get; set; }
        /// <summary>Timestamp marking last updated on the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Timestamp marking last updated on the vCenter.",
        SerializedName = @"updatedTimestamp",
        PossibleTypes = new [] { typeof(string) })]
        string UpdatedTimestamp { get;  }
        /// <summary>Version of the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Version of the vCenter.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get;  }

    }
    /// Class for vCenter properties.
    internal partial interface IVCenterPropertiesInternal

    {
        /// <summary>Timestamp marking vCenter creation.</summary>
        string CreatedTimestamp { get; set; }
        /// <summary>Error details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Error { get; set; }
        /// <summary>FQDN/IPAddress of the vCenter.</summary>
        string Fqdn { get; set; }
        /// <summary>Instance UUID of the vCenter.</summary>
        string InstanceUuid { get; set; }
        /// <summary>Performance statistics enabled on the vCenter.</summary>
        string PerfStatisticsLevel { get; set; }
        /// <summary>Port of the vCenter.</summary>
        string Port { get; set; }
        /// <summary>Run as account ID of the vCenter.</summary>
        string RunAsAccountId { get; set; }
        /// <summary>Timestamp marking last updated on the vCenter.</summary>
        string UpdatedTimestamp { get; set; }
        /// <summary>Version of the vCenter.</summary>
        string Version { get; set; }

    }
}
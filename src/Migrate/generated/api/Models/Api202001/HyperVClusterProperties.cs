namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class for cluster properties.</summary>
    public partial class HyperVClusterProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal
    {

        /// <summary>Backing field for <see cref="CreatedTimestamp" /> property.</summary>
        private string _createdTimestamp;

        /// <summary>Timestamp marking Hyper-V cluster creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string CreatedTimestamp { get => this._createdTimestamp; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] _error;

        /// <summary>Errors for Hyper-V clusters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Error { get => this._error; }

        /// <summary>Backing field for <see cref="Fqdn" /> property.</summary>
        private string _fqdn;

        /// <summary>FQDN/IPAddress of the Hyper-V cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Fqdn { get => this._fqdn; set => this._fqdn = value; }

        /// <summary>Backing field for <see cref="FunctionalLevel" /> property.</summary>
        private int? _functionalLevel;

        /// <summary>Functional level of the Hyper-V cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? FunctionalLevel { get => this._functionalLevel; }

        /// <summary>Backing field for <see cref="HostFqdnList" /> property.</summary>
        private string[] _hostFqdnList;

        /// <summary>List of hosts (FQDN) currently being tracked by the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] HostFqdnList { get => this._hostFqdnList; set => this._hostFqdnList = value; }

        /// <summary>Internal Acessors for CreatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal.CreatedTimestamp { get => this._createdTimestamp; set { {_createdTimestamp = value;} } }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal.Error { get => this._error; set { {_error = value;} } }

        /// <summary>Internal Acessors for FunctionalLevel</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal.FunctionalLevel { get => this._functionalLevel; set { {_functionalLevel = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Internal Acessors for UpdatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal.UpdatedTimestamp { get => this._updatedTimestamp; set { {_updatedTimestamp = value;} } }

        /// <summary>Backing field for <see cref="RunAsAccountId" /> property.</summary>
        private string _runAsAccountId;

        /// <summary>Run as account ID of the Hyper-V cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RunAsAccountId { get => this._runAsAccountId; set => this._runAsAccountId = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>Status of the Hyper-V cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Status { get => this._status; }

        /// <summary>Backing field for <see cref="UpdatedTimestamp" /> property.</summary>
        private string _updatedTimestamp;

        /// <summary>Timestamp marking last updated on the Hyper-V cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string UpdatedTimestamp { get => this._updatedTimestamp; }

        /// <summary>Creates an new <see cref="HyperVClusterProperties" /> instance.</summary>
        public HyperVClusterProperties()
        {

        }
    }
    /// Class for cluster properties.
    public partial interface IHyperVClusterProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Timestamp marking Hyper-V cluster creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Timestamp marking Hyper-V cluster creation.",
        SerializedName = @"createdTimestamp",
        PossibleTypes = new [] { typeof(string) })]
        string CreatedTimestamp { get;  }
        /// <summary>Errors for Hyper-V clusters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Errors for Hyper-V clusters.",
        SerializedName = @"errors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Error { get;  }
        /// <summary>FQDN/IPAddress of the Hyper-V cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"FQDN/IPAddress of the Hyper-V cluster.",
        SerializedName = @"fqdn",
        PossibleTypes = new [] { typeof(string) })]
        string Fqdn { get; set; }
        /// <summary>Functional level of the Hyper-V cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Functional level of the Hyper-V cluster.",
        SerializedName = @"functionalLevel",
        PossibleTypes = new [] { typeof(int) })]
        int? FunctionalLevel { get;  }
        /// <summary>List of hosts (FQDN) currently being tracked by the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of hosts (FQDN) currently being tracked by the cluster.",
        SerializedName = @"hostFqdnList",
        PossibleTypes = new [] { typeof(string) })]
        string[] HostFqdnList { get; set; }
        /// <summary>Run as account ID of the Hyper-V cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Run as account ID of the Hyper-V cluster.",
        SerializedName = @"runAsAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string RunAsAccountId { get; set; }
        /// <summary>Status of the Hyper-V cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Status of the Hyper-V cluster.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string Status { get;  }
        /// <summary>Timestamp marking last updated on the Hyper-V cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Timestamp marking last updated on the Hyper-V cluster.",
        SerializedName = @"updatedTimestamp",
        PossibleTypes = new [] { typeof(string) })]
        string UpdatedTimestamp { get;  }

    }
    /// Class for cluster properties.
    internal partial interface IHyperVClusterPropertiesInternal

    {
        /// <summary>Timestamp marking Hyper-V cluster creation.</summary>
        string CreatedTimestamp { get; set; }
        /// <summary>Errors for Hyper-V clusters.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Error { get; set; }
        /// <summary>FQDN/IPAddress of the Hyper-V cluster.</summary>
        string Fqdn { get; set; }
        /// <summary>Functional level of the Hyper-V cluster.</summary>
        int? FunctionalLevel { get; set; }
        /// <summary>List of hosts (FQDN) currently being tracked by the cluster.</summary>
        string[] HostFqdnList { get; set; }
        /// <summary>Run as account ID of the Hyper-V cluster.</summary>
        string RunAsAccountId { get; set; }
        /// <summary>Status of the Hyper-V cluster.</summary>
        string Status { get; set; }
        /// <summary>Timestamp marking last updated on the Hyper-V cluster.</summary>
        string UpdatedTimestamp { get; set; }

    }
}
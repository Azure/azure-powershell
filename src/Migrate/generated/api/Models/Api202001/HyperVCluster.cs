namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Cluster REST Resource.</summary>
    public partial class HyperVCluster :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVCluster,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal
    {

        /// <summary>Timestamp marking Hyper-V cluster creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CreatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal)Property).CreatedTimestamp; }

        /// <summary>Errors for Hyper-V clusters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Error { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal)Property).Error; }

        /// <summary>FQDN/IPAddress of the Hyper-V cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Fqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal)Property).Fqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal)Property).Fqdn = value ?? null; }

        /// <summary>Functional level of the Hyper-V cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public int? FunctionalLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal)Property).FunctionalLevel; }

        /// <summary>List of hosts (FQDN) currently being tracked by the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string[] HostFqdnList { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal)Property).HostFqdnList; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal)Property).HostFqdnList = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Internal Acessors for CreatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal.CreatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal)Property).CreatedTimestamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal)Property).CreatedTimestamp = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal.Error { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal)Property).Error; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal)Property).Error = value; }

        /// <summary>Internal Acessors for FunctionalLevel</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal.FunctionalLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal)Property).FunctionalLevel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal)Property).FunctionalLevel = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVClusterProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal.Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal)Property).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal)Property).Status = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Internal Acessors for UpdatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal.UpdatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal)Property).UpdatedTimestamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal)Property).UpdatedTimestamp = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterProperties _property;

        /// <summary>Nested properties of the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVClusterProperties()); set => this._property = value; }

        /// <summary>Run as account ID of the Hyper-V cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RunAsAccountId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal)Property).RunAsAccountId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal)Property).RunAsAccountId = value ?? null; }

        /// <summary>Status of the Hyper-V cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal)Property).Status; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of resource. Type = Microsoft.OffAzure/hyperVSites/clusters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Timestamp marking last updated on the Hyper-V cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string UpdatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterPropertiesInternal)Property).UpdatedTimestamp; }

        /// <summary>Creates an new <see cref="HyperVCluster" /> instance.</summary>
        public HyperVCluster()
        {

        }
    }
    /// Cluster REST Resource.
    public partial interface IHyperVCluster :
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
        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Name of the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the cluster.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
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
        /// <summary>Type of resource. Type = Microsoft.OffAzure/hyperVSites/clusters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Type of resource. Type = Microsoft.OffAzure/hyperVSites/clusters.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }
        /// <summary>Timestamp marking last updated on the Hyper-V cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Timestamp marking last updated on the Hyper-V cluster.",
        SerializedName = @"updatedTimestamp",
        PossibleTypes = new [] { typeof(string) })]
        string UpdatedTimestamp { get;  }

    }
    /// Cluster REST Resource.
    internal partial interface IHyperVClusterInternal

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
        /// <summary>Resource Id.</summary>
        string Id { get; set; }
        /// <summary>Name of the cluster.</summary>
        string Name { get; set; }
        /// <summary>Nested properties of the cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterProperties Property { get; set; }
        /// <summary>Run as account ID of the Hyper-V cluster.</summary>
        string RunAsAccountId { get; set; }
        /// <summary>Status of the Hyper-V cluster.</summary>
        string Status { get; set; }
        /// <summary>Type of resource. Type = Microsoft.OffAzure/hyperVSites/clusters.</summary>
        string Type { get; set; }
        /// <summary>Timestamp marking last updated on the Hyper-V cluster.</summary>
        string UpdatedTimestamp { get; set; }

    }
}
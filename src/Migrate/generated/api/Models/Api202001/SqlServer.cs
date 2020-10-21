namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>SQLServer in the guest virtual machine.</summary>
    public partial class SqlServer :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServerInternal
    {

        /// <summary>Backing field for <see cref="ClusterName" /> property.</summary>
        private string _clusterName;

        /// <summary>ClusterName of the SQLServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ClusterName { get => this._clusterName; }

        /// <summary>Backing field for <see cref="Clustered" /> property.</summary>
        private string _clustered;

        /// <summary>Clustered of the SQLServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Clustered { get => this._clustered; }

        /// <summary>Backing field for <see cref="Edition" /> property.</summary>
        private string _edition;

        /// <summary>Edition of the SQLServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Edition { get => this._edition; }

        /// <summary>Internal Acessors for ClusterName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServerInternal.ClusterName { get => this._clusterName; set { {_clusterName = value;} } }

        /// <summary>Internal Acessors for Clustered</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServerInternal.Clustered { get => this._clustered; set { {_clustered = value;} } }

        /// <summary>Internal Acessors for Edition</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServerInternal.Edition { get => this._edition; set { {_edition = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServerInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for ServicePack</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServerInternal.ServicePack { get => this._servicePack; set { {_servicePack = value;} } }

        /// <summary>Internal Acessors for Version</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServerInternal.Version { get => this._version; set { {_version = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the SQLServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="ServicePack" /> property.</summary>
        private string _servicePack;

        /// <summary>ServicePack of the SQLServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ServicePack { get => this._servicePack; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>Version of the SQLServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Version { get => this._version; }

        /// <summary>Creates an new <see cref="SqlServer" /> instance.</summary>
        public SqlServer()
        {

        }
    }
    /// SQLServer in the guest virtual machine.
    public partial interface ISqlServer :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>ClusterName of the SQLServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ClusterName of the SQLServer.",
        SerializedName = @"clusterName",
        PossibleTypes = new [] { typeof(string) })]
        string ClusterName { get;  }
        /// <summary>Clustered of the SQLServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Clustered of the SQLServer.",
        SerializedName = @"clustered",
        PossibleTypes = new [] { typeof(string) })]
        string Clustered { get;  }
        /// <summary>Edition of the SQLServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Edition of the SQLServer.",
        SerializedName = @"edition",
        PossibleTypes = new [] { typeof(string) })]
        string Edition { get;  }
        /// <summary>Name of the SQLServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the SQLServer.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>ServicePack of the SQLServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ServicePack of the SQLServer.",
        SerializedName = @"servicePack",
        PossibleTypes = new [] { typeof(string) })]
        string ServicePack { get;  }
        /// <summary>Version of the SQLServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Version of the SQLServer.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get;  }

    }
    /// SQLServer in the guest virtual machine.
    internal partial interface ISqlServerInternal

    {
        /// <summary>ClusterName of the SQLServer.</summary>
        string ClusterName { get; set; }
        /// <summary>Clustered of the SQLServer.</summary>
        string Clustered { get; set; }
        /// <summary>Edition of the SQLServer.</summary>
        string Edition { get; set; }
        /// <summary>Name of the SQLServer.</summary>
        string Name { get; set; }
        /// <summary>ServicePack of the SQLServer.</summary>
        string ServicePack { get; set; }
        /// <summary>Version of the SQLServer.</summary>
        string Version { get; set; }

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Feature in the guest virtual machine.</summary>
    public partial class Feature :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeatureInternal
    {

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeatureInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Parent</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeatureInternal.Parent { get => this._parent; set { {_parent = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeatureInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeatureInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the Feature.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Parent" /> property.</summary>
        private string _parent;

        /// <summary>Parent of the Feature.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Parent { get => this._parent; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>Status of the Feature.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Status { get => this._status; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>FeatureType of the Feature.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="Feature" /> instance.</summary>
        public Feature()
        {

        }
    }
    /// Feature in the guest virtual machine.
    public partial interface IFeature :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Name of the Feature.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the Feature.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>Parent of the Feature.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Parent of the Feature.",
        SerializedName = @"parent",
        PossibleTypes = new [] { typeof(string) })]
        string Parent { get;  }
        /// <summary>Status of the Feature.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Status of the Feature.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string Status { get;  }
        /// <summary>FeatureType of the Feature.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"FeatureType of the Feature.",
        SerializedName = @"featureType",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// Feature in the guest virtual machine.
    internal partial interface IFeatureInternal

    {
        /// <summary>Name of the Feature.</summary>
        string Name { get; set; }
        /// <summary>Parent of the Feature.</summary>
        string Parent { get; set; }
        /// <summary>Status of the Feature.</summary>
        string Status { get; set; }
        /// <summary>FeatureType of the Feature.</summary>
        string Type { get; set; }

    }
}
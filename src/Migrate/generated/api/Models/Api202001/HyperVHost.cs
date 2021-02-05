namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Host REST Resource.</summary>
    public partial class HyperVHost :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHost,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal
    {

        /// <summary>Timestamp marking Hyper-V host creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CreatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostPropertiesInternal)Property).CreatedTimestamp; }

        /// <summary>Errors for Hyper-V hosts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Error { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostPropertiesInternal)Property).Error; }

        /// <summary>FQDN/IPAddress of the Hyper-V host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Fqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostPropertiesInternal)Property).Fqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostPropertiesInternal)Property).Fqdn = value ?? null; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Internal Acessors for CreatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal.CreatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostPropertiesInternal)Property).CreatedTimestamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostPropertiesInternal)Property).CreatedTimestamp = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal.Error { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostPropertiesInternal)Property).Error; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostPropertiesInternal)Property).Error = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVHostProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Internal Acessors for UpdatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal.UpdatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostPropertiesInternal)Property).UpdatedTimestamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostPropertiesInternal)Property).UpdatedTimestamp = value; }

        /// <summary>Internal Acessors for Version</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal.Version { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostPropertiesInternal)Property).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostPropertiesInternal)Property).Version = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostProperties _property;

        /// <summary>Nested properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVHostProperties()); set => this._property = value; }

        /// <summary>Run as account ID of the Hyper-V host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RunAsAccountId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostPropertiesInternal)Property).RunAsAccountId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostPropertiesInternal)Property).RunAsAccountId = value ?? null; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of resource. Type = Microsoft.OffAzure/hyperVSites/hosts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Timestamp marking last updated on the Hyper-V host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string UpdatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostPropertiesInternal)Property).UpdatedTimestamp; }

        /// <summary>Version of the Hyper-V host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Version { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostPropertiesInternal)Property).Version; }

        /// <summary>Creates an new <see cref="HyperVHost" /> instance.</summary>
        public HyperVHost()
        {

        }
    }
    /// Host REST Resource.
    public partial interface IHyperVHost :
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
        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Name of the host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the host.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Run as account ID of the Hyper-V host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Run as account ID of the Hyper-V host.",
        SerializedName = @"runAsAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string RunAsAccountId { get; set; }
        /// <summary>Type of resource. Type = Microsoft.OffAzure/hyperVSites/hosts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Type of resource. Type = Microsoft.OffAzure/hyperVSites/hosts.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }
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
    /// Host REST Resource.
    internal partial interface IHyperVHostInternal

    {
        /// <summary>Timestamp marking Hyper-V host creation.</summary>
        string CreatedTimestamp { get; set; }
        /// <summary>Errors for Hyper-V hosts.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Error { get; set; }
        /// <summary>FQDN/IPAddress of the Hyper-V host.</summary>
        string Fqdn { get; set; }
        /// <summary>Resource Id.</summary>
        string Id { get; set; }
        /// <summary>Name of the host.</summary>
        string Name { get; set; }
        /// <summary>Nested properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostProperties Property { get; set; }
        /// <summary>Run as account ID of the Hyper-V host.</summary>
        string RunAsAccountId { get; set; }
        /// <summary>Type of resource. Type = Microsoft.OffAzure/hyperVSites/hosts.</summary>
        string Type { get; set; }
        /// <summary>Timestamp marking last updated on the Hyper-V host.</summary>
        string UpdatedTimestamp { get; set; }
        /// <summary>Version of the Hyper-V host.</summary>
        string Version { get; set; }

    }
}
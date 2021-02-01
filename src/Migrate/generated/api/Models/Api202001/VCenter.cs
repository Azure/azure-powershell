namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>VCenter REST Resource.</summary>
    public partial class VCenter :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenter,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal
    {

        /// <summary>Timestamp marking vCenter creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CreatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).CreatedTimestamp; }

        /// <summary>Error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Error { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).Error; }

        /// <summary>FQDN/IPAddress of the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Fqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).Fqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).Fqdn = value ?? null; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Instance UUID of the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string InstanceUuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).InstanceUuid; }

        /// <summary>Internal Acessors for CreatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal.CreatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).CreatedTimestamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).CreatedTimestamp = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal.Error { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).Error; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).Error = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for InstanceUuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal.InstanceUuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).InstanceUuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).InstanceUuid = value; }

        /// <summary>Internal Acessors for PerfStatisticsLevel</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal.PerfStatisticsLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).PerfStatisticsLevel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).PerfStatisticsLevel = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VCenterProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Internal Acessors for UpdatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal.UpdatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).UpdatedTimestamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).UpdatedTimestamp = value; }

        /// <summary>Internal Acessors for Version</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal.Version { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).Version = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Performance statistics enabled on the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PerfStatisticsLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).PerfStatisticsLevel; }

        /// <summary>Port of the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Port { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).Port; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).Port = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterProperties _property;

        /// <summary>vCenter nested properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VCenterProperties()); set => this._property = value; }

        /// <summary>Run as account ID of the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RunAsAccountId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).RunAsAccountId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).RunAsAccountId = value ?? null; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of resource. Type = Microsoft.OffAzure/VMWareSites/VCenters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Timestamp marking last updated on the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string UpdatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).UpdatedTimestamp; }

        /// <summary>Version of the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Version { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterPropertiesInternal)Property).Version; }

        /// <summary>Creates an new <see cref="VCenter" /> instance.</summary>
        public VCenter()
        {

        }
    }
    /// VCenter REST Resource.
    public partial interface IVCenter :
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
        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Instance UUID of the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Instance UUID of the vCenter.",
        SerializedName = @"instanceUuid",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceUuid { get;  }
        /// <summary>Name of the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the vCenter.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
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
        /// <summary>Type of resource. Type = Microsoft.OffAzure/VMWareSites/VCenters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Type of resource. Type = Microsoft.OffAzure/VMWareSites/VCenters.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }
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
    /// VCenter REST Resource.
    internal partial interface IVCenterInternal

    {
        /// <summary>Timestamp marking vCenter creation.</summary>
        string CreatedTimestamp { get; set; }
        /// <summary>Error details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Error { get; set; }
        /// <summary>FQDN/IPAddress of the vCenter.</summary>
        string Fqdn { get; set; }
        /// <summary>Resource Id.</summary>
        string Id { get; set; }
        /// <summary>Instance UUID of the vCenter.</summary>
        string InstanceUuid { get; set; }
        /// <summary>Name of the vCenter.</summary>
        string Name { get; set; }
        /// <summary>Performance statistics enabled on the vCenter.</summary>
        string PerfStatisticsLevel { get; set; }
        /// <summary>Port of the vCenter.</summary>
        string Port { get; set; }
        /// <summary>vCenter nested properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterProperties Property { get; set; }
        /// <summary>Run as account ID of the vCenter.</summary>
        string RunAsAccountId { get; set; }
        /// <summary>Type of resource. Type = Microsoft.OffAzure/VMWareSites/VCenters.</summary>
        string Type { get; set; }
        /// <summary>Timestamp marking last updated on the vCenter.</summary>
        string UpdatedTimestamp { get; set; }
        /// <summary>Version of the vCenter.</summary>
        string Version { get; set; }

    }
}
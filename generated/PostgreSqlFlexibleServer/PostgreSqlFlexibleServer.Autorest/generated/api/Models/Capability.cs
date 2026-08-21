// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Capability for the Azure Database for PostgreSQL flexible server.</summary>
    public partial class Capability :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapability,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityInternal,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBase"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBase __capabilityBase = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.CapabilityBase();

        /// <summary>Backing field for <see cref="FastProvisioningSupported" /> property.</summary>
        private string _fastProvisioningSupported;

        /// <summary>
        /// Indicates if fast provisioning is supported. 'Enabled' means fast provisioning is supported. 'Disabled' stands for fast
        /// provisioning is not supported. Will be deprecated in the future. Look to Supported Features for 'FastProvisioning'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string FastProvisioningSupported { get => this._fastProvisioningSupported; }

        /// <summary>Backing field for <see cref="GeoBackupSupported" /> property.</summary>
        private string _geoBackupSupported;

        /// <summary>
        /// Indicates if geographically redundant backups are supported in this location. 'Enabled' means geographically redundant
        /// backups are supported. 'Disabled' stands for geographically redundant backup is not supported. Will be deprecated in the
        /// future. Look to Supported Features for 'GeoBackup'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 5, Width = 20)]
        public string GeoBackupSupported { get => this._geoBackupSupported; }

        /// <summary>Internal Acessors for Reason</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal.Reason { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Reason; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Reason = value ?? null; }

        /// <summary>Internal Acessors for Status</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal.Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Status = value ?? null; }

        /// <summary>Internal Acessors for FastProvisioningSupported</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityInternal.FastProvisioningSupported { get => this._fastProvisioningSupported; set { {_fastProvisioningSupported = value;} } }

        /// <summary>Internal Acessors for GeoBackupSupported</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityInternal.GeoBackupSupported { get => this._geoBackupSupported; set { {_geoBackupSupported = value;} } }

        /// <summary>Internal Acessors for OnlineResizeSupported</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityInternal.OnlineResizeSupported { get => this._onlineResizeSupported; set { {_onlineResizeSupported = value;} } }

        /// <summary>Internal Acessors for Restricted</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityInternal.Restricted { get => this._restricted; set { {_restricted = value;} } }

        /// <summary>Internal Acessors for StorageAutoGrowthSupported</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityInternal.StorageAutoGrowthSupported { get => this._storageAutoGrowthSupported; set { {_storageAutoGrowthSupported = value;} } }

        /// <summary>Internal Acessors for SupportedFastProvisioningEdition</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IFastProvisioningEditionCapability> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityInternal.SupportedFastProvisioningEdition { get => this._supportedFastProvisioningEdition; set { {_supportedFastProvisioningEdition = value;} } }

        /// <summary>Internal Acessors for SupportedFeature</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISupportedFeature> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityInternal.SupportedFeature { get => this._supportedFeature; set { {_supportedFeature = value;} } }

        /// <summary>Internal Acessors for SupportedServerEdition</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapability> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityInternal.SupportedServerEdition { get => this._supportedServerEdition; set { {_supportedServerEdition = value;} } }

        /// <summary>Internal Acessors for SupportedServerVersion</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerVersionCapability> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityInternal.SupportedServerVersion { get => this._supportedServerVersion; set { {_supportedServerVersion = value;} } }

        /// <summary>Internal Acessors for ZoneRedundantHaAndGeoBackupSupported</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityInternal.ZoneRedundantHaAndGeoBackupSupported { get => this._zoneRedundantHaAndGeoBackupSupported; set { {_zoneRedundantHaAndGeoBackupSupported = value;} } }

        /// <summary>Internal Acessors for ZoneRedundantHaSupported</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityInternal.ZoneRedundantHaSupported { get => this._zoneRedundantHaSupported; set { {_zoneRedundantHaSupported = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of flexible servers capabilities.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 0, Width = 27)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="OnlineResizeSupported" /> property.</summary>
        private string _onlineResizeSupported;

        /// <summary>
        /// Indicates if resizing the storage, without interrupting the operation of the database engine, is supported in this location
        /// for the given subscription. 'Enabled' means resizing the storage without interrupting the operation of the database engine
        /// is supported. 'Disabled' means resizing the storage without interrupting the operation of the database engine is not supported.
        /// Will be deprecated in the future. Look to Supported Features for 'OnlineResize'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 4, Width = 23)]
        public string OnlineResizeSupported { get => this._onlineResizeSupported; }

        /// <summary>Reason for the capability not being available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string Reason { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Reason; }

        /// <summary>Backing field for <see cref="Restricted" /> property.</summary>
        private string _restricted;

        /// <summary>
        /// Indicates if this location is restricted. 'Enabled' means location is restricted. 'Disabled' stands for location is not
        /// restricted. Will be deprecated in the future. Look to Supported Features for 'Restricted'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string Restricted { get => this._restricted; }

        /// <summary>Status of the capability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Status; }

        /// <summary>Backing field for <see cref="StorageAutoGrowthSupported" /> property.</summary>
        private string _storageAutoGrowthSupported;

        /// <summary>
        /// Indicates if storage autogrow is supported in this location. 'Enabled' means storage autogrow is supported. 'Disabled'
        /// stands for storage autogrow is not supported. Will be deprecated in the future. Look to Supported Features for 'StorageAutoGrowth'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 3, Width = 27)]
        public string StorageAutoGrowthSupported { get => this._storageAutoGrowthSupported; }

        /// <summary>Backing field for <see cref="SupportedFastProvisioningEdition" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IFastProvisioningEditionCapability> _supportedFastProvisioningEdition;

        /// <summary>List of compute tiers supporting fast provisioning.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IFastProvisioningEditionCapability> SupportedFastProvisioningEdition { get => this._supportedFastProvisioningEdition; }

        /// <summary>Backing field for <see cref="SupportedFeature" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISupportedFeature> _supportedFeature;

        /// <summary>Features supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISupportedFeature> SupportedFeature { get => this._supportedFeature; }

        /// <summary>Backing field for <see cref="SupportedServerEdition" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapability> _supportedServerEdition;

        /// <summary>List of supported compute tiers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapability> SupportedServerEdition { get => this._supportedServerEdition; }

        /// <summary>Backing field for <see cref="SupportedServerVersion" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerVersionCapability> _supportedServerVersion;

        /// <summary>List of supported major versions of PostgreSQL database engine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerVersionCapability> SupportedServerVersion { get => this._supportedServerVersion; }

        /// <summary>Backing field for <see cref="ZoneRedundantHaAndGeoBackupSupported" /> property.</summary>
        private string _zoneRedundantHaAndGeoBackupSupported;

        /// <summary>
        /// Indicates if high availability with zone redundancy is supported in conjunction with geographically redundant backups
        /// in this location. 'Enabled' means high availability with zone redundancy is supported in conjunction with geographically
        /// redundant backups is supported. 'Disabled' stands for high availability with zone redundancy is supported in conjunction
        /// with geographically redundant backups is not supported. Will be deprecated in the future. Look to Supported Features for
        /// 'ZoneRedundantHaAndGeoBackup'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 2, Width = 37)]
        public string ZoneRedundantHaAndGeoBackupSupported { get => this._zoneRedundantHaAndGeoBackupSupported; }

        /// <summary>Backing field for <see cref="ZoneRedundantHaSupported" /> property.</summary>
        private string _zoneRedundantHaSupported;

        /// <summary>
        /// Indicates if high availability with zone redundancy is supported in this location. 'Enabled' means high availability with
        /// zone redundancy is supported. 'Disabled' stands for high availability with zone redundancy is not supported. Will be deprecated
        /// in the future. Look to Supported Features for 'ZoneRedundantHa'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 1, Width = 25)]
        public string ZoneRedundantHaSupported { get => this._zoneRedundantHaSupported; }

        /// <summary>Creates an new <see cref="Capability" /> instance.</summary>
        public Capability()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__capabilityBase), __capabilityBase);
            await eventListener.AssertObjectIsValid(nameof(__capabilityBase), __capabilityBase);
        }
    }
    /// Capability for the Azure Database for PostgreSQL flexible server.
    public partial interface ICapability :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBase
    {
        /// <summary>
        /// Indicates if fast provisioning is supported. 'Enabled' means fast provisioning is supported. 'Disabled' stands for fast
        /// provisioning is not supported. Will be deprecated in the future. Look to Supported Features for 'FastProvisioning'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Indicates if fast provisioning is supported. 'Enabled' means fast provisioning is supported. 'Disabled' stands for fast provisioning is not supported. Will be deprecated in the future. Look to Supported Features for 'FastProvisioning'.",
        SerializedName = @"fastProvisioningSupported",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string FastProvisioningSupported { get;  }
        /// <summary>
        /// Indicates if geographically redundant backups are supported in this location. 'Enabled' means geographically redundant
        /// backups are supported. 'Disabled' stands for geographically redundant backup is not supported. Will be deprecated in the
        /// future. Look to Supported Features for 'GeoBackup'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Indicates if geographically redundant backups are supported in this location. 'Enabled' means geographically redundant backups are supported. 'Disabled' stands for geographically redundant backup is not supported. Will be deprecated in the future. Look to Supported Features for 'GeoBackup'.",
        SerializedName = @"geoBackupSupported",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string GeoBackupSupported { get;  }
        /// <summary>Name of flexible servers capabilities.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name of flexible servers capabilities.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// Indicates if resizing the storage, without interrupting the operation of the database engine, is supported in this location
        /// for the given subscription. 'Enabled' means resizing the storage without interrupting the operation of the database engine
        /// is supported. 'Disabled' means resizing the storage without interrupting the operation of the database engine is not supported.
        /// Will be deprecated in the future. Look to Supported Features for 'OnlineResize'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Indicates if resizing the storage, without interrupting the operation of the database engine, is supported in this location for the given subscription. 'Enabled' means resizing the storage without interrupting the operation of the database engine is supported. 'Disabled' means resizing the storage without interrupting the operation of the database engine is not supported. Will be deprecated in the future. Look to Supported Features for 'OnlineResize'.",
        SerializedName = @"onlineResizeSupported",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string OnlineResizeSupported { get;  }
        /// <summary>
        /// Indicates if this location is restricted. 'Enabled' means location is restricted. 'Disabled' stands for location is not
        /// restricted. Will be deprecated in the future. Look to Supported Features for 'Restricted'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Indicates if this location is restricted. 'Enabled' means location is restricted. 'Disabled' stands for location is not restricted. Will be deprecated in the future. Look to Supported Features for 'Restricted'.",
        SerializedName = @"restricted",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string Restricted { get;  }
        /// <summary>
        /// Indicates if storage autogrow is supported in this location. 'Enabled' means storage autogrow is supported. 'Disabled'
        /// stands for storage autogrow is not supported. Will be deprecated in the future. Look to Supported Features for 'StorageAutoGrowth'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Indicates if storage autogrow is supported in this location. 'Enabled' means storage autogrow is supported. 'Disabled' stands for storage autogrow is not supported. Will be deprecated in the future. Look to Supported Features for 'StorageAutoGrowth'.",
        SerializedName = @"storageAutoGrowthSupported",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string StorageAutoGrowthSupported { get;  }
        /// <summary>List of compute tiers supporting fast provisioning.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"List of compute tiers supporting fast provisioning.",
        SerializedName = @"supportedFastProvisioningEditions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IFastProvisioningEditionCapability) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IFastProvisioningEditionCapability> SupportedFastProvisioningEdition { get;  }
        /// <summary>Features supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Features supported.",
        SerializedName = @"supportedFeatures",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISupportedFeature) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISupportedFeature> SupportedFeature { get;  }
        /// <summary>List of supported compute tiers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"List of supported compute tiers.",
        SerializedName = @"supportedServerEditions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapability) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapability> SupportedServerEdition { get;  }
        /// <summary>List of supported major versions of PostgreSQL database engine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"List of supported major versions of PostgreSQL database engine.",
        SerializedName = @"supportedServerVersions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerVersionCapability) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerVersionCapability> SupportedServerVersion { get;  }
        /// <summary>
        /// Indicates if high availability with zone redundancy is supported in conjunction with geographically redundant backups
        /// in this location. 'Enabled' means high availability with zone redundancy is supported in conjunction with geographically
        /// redundant backups is supported. 'Disabled' stands for high availability with zone redundancy is supported in conjunction
        /// with geographically redundant backups is not supported. Will be deprecated in the future. Look to Supported Features for
        /// 'ZoneRedundantHaAndGeoBackup'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Indicates if high availability with zone redundancy is supported in conjunction with geographically redundant backups in this location. 'Enabled' means high availability with zone redundancy is supported in conjunction with geographically redundant backups is supported. 'Disabled' stands for high availability with zone redundancy is supported in conjunction with geographically redundant backups is not supported. Will be deprecated in the future. Look to Supported Features for 'ZoneRedundantHaAndGeoBackup'.",
        SerializedName = @"zoneRedundantHaAndGeoBackupSupported",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string ZoneRedundantHaAndGeoBackupSupported { get;  }
        /// <summary>
        /// Indicates if high availability with zone redundancy is supported in this location. 'Enabled' means high availability with
        /// zone redundancy is supported. 'Disabled' stands for high availability with zone redundancy is not supported. Will be deprecated
        /// in the future. Look to Supported Features for 'ZoneRedundantHa'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Indicates if high availability with zone redundancy is supported in this location. 'Enabled' means high availability with zone redundancy is supported. 'Disabled' stands for high availability with zone redundancy is not supported. Will be deprecated in the future. Look to Supported Features for  'ZoneRedundantHa'.",
        SerializedName = @"zoneRedundantHaSupported",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string ZoneRedundantHaSupported { get;  }

    }
    /// Capability for the Azure Database for PostgreSQL flexible server.
    internal partial interface ICapabilityInternal :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal
    {
        /// <summary>
        /// Indicates if fast provisioning is supported. 'Enabled' means fast provisioning is supported. 'Disabled' stands for fast
        /// provisioning is not supported. Will be deprecated in the future. Look to Supported Features for 'FastProvisioning'.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string FastProvisioningSupported { get; set; }
        /// <summary>
        /// Indicates if geographically redundant backups are supported in this location. 'Enabled' means geographically redundant
        /// backups are supported. 'Disabled' stands for geographically redundant backup is not supported. Will be deprecated in the
        /// future. Look to Supported Features for 'GeoBackup'.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string GeoBackupSupported { get; set; }
        /// <summary>Name of flexible servers capabilities.</summary>
        string Name { get; set; }
        /// <summary>
        /// Indicates if resizing the storage, without interrupting the operation of the database engine, is supported in this location
        /// for the given subscription. 'Enabled' means resizing the storage without interrupting the operation of the database engine
        /// is supported. 'Disabled' means resizing the storage without interrupting the operation of the database engine is not supported.
        /// Will be deprecated in the future. Look to Supported Features for 'OnlineResize'.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string OnlineResizeSupported { get; set; }
        /// <summary>
        /// Indicates if this location is restricted. 'Enabled' means location is restricted. 'Disabled' stands for location is not
        /// restricted. Will be deprecated in the future. Look to Supported Features for 'Restricted'.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string Restricted { get; set; }
        /// <summary>
        /// Indicates if storage autogrow is supported in this location. 'Enabled' means storage autogrow is supported. 'Disabled'
        /// stands for storage autogrow is not supported. Will be deprecated in the future. Look to Supported Features for 'StorageAutoGrowth'.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string StorageAutoGrowthSupported { get; set; }
        /// <summary>List of compute tiers supporting fast provisioning.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IFastProvisioningEditionCapability> SupportedFastProvisioningEdition { get; set; }
        /// <summary>Features supported.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISupportedFeature> SupportedFeature { get; set; }
        /// <summary>List of supported compute tiers.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapability> SupportedServerEdition { get; set; }
        /// <summary>List of supported major versions of PostgreSQL database engine.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerVersionCapability> SupportedServerVersion { get; set; }
        /// <summary>
        /// Indicates if high availability with zone redundancy is supported in conjunction with geographically redundant backups
        /// in this location. 'Enabled' means high availability with zone redundancy is supported in conjunction with geographically
        /// redundant backups is supported. 'Disabled' stands for high availability with zone redundancy is supported in conjunction
        /// with geographically redundant backups is not supported. Will be deprecated in the future. Look to Supported Features for
        /// 'ZoneRedundantHaAndGeoBackup'.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string ZoneRedundantHaAndGeoBackupSupported { get; set; }
        /// <summary>
        /// Indicates if high availability with zone redundancy is supported in this location. 'Enabled' means high availability with
        /// zone redundancy is supported. 'Disabled' stands for high availability with zone redundancy is not supported. Will be deprecated
        /// in the future. Look to Supported Features for 'ZoneRedundantHa'.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string ZoneRedundantHaSupported { get; set; }

    }
}
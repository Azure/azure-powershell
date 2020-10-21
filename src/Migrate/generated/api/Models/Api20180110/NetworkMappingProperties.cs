namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Network Mapping Properties.</summary>
    public partial class NetworkMappingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal
    {

        /// <summary>Backing field for <see cref="FabricSpecificSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingFabricSpecificSettings _fabricSpecificSetting;

        /// <summary>The fabric specific settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingFabricSpecificSettings FabricSpecificSetting { get => (this._fabricSpecificSetting = this._fabricSpecificSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.NetworkMappingFabricSpecificSettings()); set => this._fabricSpecificSetting = value; }

        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string FabricSpecificSettingInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingFabricSpecificSettingsInternal)FabricSpecificSetting).InstanceType; }

        /// <summary>Internal Acessors for FabricSpecificSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingFabricSpecificSettings Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal.FabricSpecificSetting { get => (this._fabricSpecificSetting = this._fabricSpecificSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.NetworkMappingFabricSpecificSettings()); set { {_fabricSpecificSetting = value;} } }

        /// <summary>Internal Acessors for FabricSpecificSettingInstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal.FabricSpecificSettingInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingFabricSpecificSettingsInternal)FabricSpecificSetting).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingFabricSpecificSettingsInternal)FabricSpecificSetting).InstanceType = value; }

        /// <summary>Backing field for <see cref="PrimaryFabricFriendlyName" /> property.</summary>
        private string _primaryFabricFriendlyName;

        /// <summary>The primary fabric friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PrimaryFabricFriendlyName { get => this._primaryFabricFriendlyName; set => this._primaryFabricFriendlyName = value; }

        /// <summary>Backing field for <see cref="PrimaryNetworkFriendlyName" /> property.</summary>
        private string _primaryNetworkFriendlyName;

        /// <summary>The primary network friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PrimaryNetworkFriendlyName { get => this._primaryNetworkFriendlyName; set => this._primaryNetworkFriendlyName = value; }

        /// <summary>Backing field for <see cref="PrimaryNetworkId" /> property.</summary>
        private string _primaryNetworkId;

        /// <summary>The primary network id for network mapping.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PrimaryNetworkId { get => this._primaryNetworkId; set => this._primaryNetworkId = value; }

        /// <summary>Backing field for <see cref="RecoveryFabricArmId" /> property.</summary>
        private string _recoveryFabricArmId;

        /// <summary>The recovery fabric ARM id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryFabricArmId { get => this._recoveryFabricArmId; set => this._recoveryFabricArmId = value; }

        /// <summary>Backing field for <see cref="RecoveryFabricFriendlyName" /> property.</summary>
        private string _recoveryFabricFriendlyName;

        /// <summary>The recovery fabric friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryFabricFriendlyName { get => this._recoveryFabricFriendlyName; set => this._recoveryFabricFriendlyName = value; }

        /// <summary>Backing field for <see cref="RecoveryNetworkFriendlyName" /> property.</summary>
        private string _recoveryNetworkFriendlyName;

        /// <summary>The recovery network friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryNetworkFriendlyName { get => this._recoveryNetworkFriendlyName; set => this._recoveryNetworkFriendlyName = value; }

        /// <summary>Backing field for <see cref="RecoveryNetworkId" /> property.</summary>
        private string _recoveryNetworkId;

        /// <summary>The recovery network id for network mapping.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryNetworkId { get => this._recoveryNetworkId; set => this._recoveryNetworkId = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private string _state;

        /// <summary>The pairing state for network mapping.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string State { get => this._state; set => this._state = value; }

        /// <summary>Creates an new <see cref="NetworkMappingProperties" /> instance.</summary>
        public NetworkMappingProperties()
        {

        }
    }
    /// Network Mapping Properties.
    public partial interface INetworkMappingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the Instance type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string FabricSpecificSettingInstanceType { get;  }
        /// <summary>The primary fabric friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary fabric friendly name.",
        SerializedName = @"primaryFabricFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryFabricFriendlyName { get; set; }
        /// <summary>The primary network friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary network friendly name.",
        SerializedName = @"primaryNetworkFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryNetworkFriendlyName { get; set; }
        /// <summary>The primary network id for network mapping.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary network id for network mapping.",
        SerializedName = @"primaryNetworkId",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryNetworkId { get; set; }
        /// <summary>The recovery fabric ARM id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery fabric ARM id.",
        SerializedName = @"recoveryFabricArmId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryFabricArmId { get; set; }
        /// <summary>The recovery fabric friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery fabric friendly name.",
        SerializedName = @"recoveryFabricFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryFabricFriendlyName { get; set; }
        /// <summary>The recovery network friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery network friendly name.",
        SerializedName = @"recoveryNetworkFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryNetworkFriendlyName { get; set; }
        /// <summary>The recovery network id for network mapping.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery network id for network mapping.",
        SerializedName = @"recoveryNetworkId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryNetworkId { get; set; }
        /// <summary>The pairing state for network mapping.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The pairing state for network mapping.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string State { get; set; }

    }
    /// Network Mapping Properties.
    internal partial interface INetworkMappingPropertiesInternal

    {
        /// <summary>The fabric specific settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingFabricSpecificSettings FabricSpecificSetting { get; set; }
        /// <summary>Gets the Instance type.</summary>
        string FabricSpecificSettingInstanceType { get; set; }
        /// <summary>The primary fabric friendly name.</summary>
        string PrimaryFabricFriendlyName { get; set; }
        /// <summary>The primary network friendly name.</summary>
        string PrimaryNetworkFriendlyName { get; set; }
        /// <summary>The primary network id for network mapping.</summary>
        string PrimaryNetworkId { get; set; }
        /// <summary>The recovery fabric ARM id.</summary>
        string RecoveryFabricArmId { get; set; }
        /// <summary>The recovery fabric friendly name.</summary>
        string RecoveryFabricFriendlyName { get; set; }
        /// <summary>The recovery network friendly name.</summary>
        string RecoveryNetworkFriendlyName { get; set; }
        /// <summary>The recovery network id for network mapping.</summary>
        string RecoveryNetworkId { get; set; }
        /// <summary>The pairing state for network mapping.</summary>
        string State { get; set; }

    }
}
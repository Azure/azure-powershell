namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>A2A Network Mapping fabric specific settings.</summary>
    public partial class AzureToAzureNetworkMappingSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureNetworkMappingSettings,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureNetworkMappingSettingsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingFabricSpecificSettings"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingFabricSpecificSettings __networkMappingFabricSpecificSettings = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.NetworkMappingFabricSpecificSettings();

        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingFabricSpecificSettingsInternal)__networkMappingFabricSpecificSettings).InstanceType; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingFabricSpecificSettingsInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingFabricSpecificSettingsInternal)__networkMappingFabricSpecificSettings).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingFabricSpecificSettingsInternal)__networkMappingFabricSpecificSettings).InstanceType = value; }

        /// <summary>Backing field for <see cref="PrimaryFabricLocation" /> property.</summary>
        private string _primaryFabricLocation;

        /// <summary>The primary fabric location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PrimaryFabricLocation { get => this._primaryFabricLocation; set => this._primaryFabricLocation = value; }

        /// <summary>Backing field for <see cref="RecoveryFabricLocation" /> property.</summary>
        private string _recoveryFabricLocation;

        /// <summary>The recovery fabric location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryFabricLocation { get => this._recoveryFabricLocation; set => this._recoveryFabricLocation = value; }

        /// <summary>Creates an new <see cref="AzureToAzureNetworkMappingSettings" /> instance.</summary>
        public AzureToAzureNetworkMappingSettings()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__networkMappingFabricSpecificSettings), __networkMappingFabricSpecificSettings);
            await eventListener.AssertObjectIsValid(nameof(__networkMappingFabricSpecificSettings), __networkMappingFabricSpecificSettings);
        }
    }
    /// A2A Network Mapping fabric specific settings.
    public partial interface IAzureToAzureNetworkMappingSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingFabricSpecificSettings
    {
        /// <summary>The primary fabric location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary fabric location.",
        SerializedName = @"primaryFabricLocation",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryFabricLocation { get; set; }
        /// <summary>The recovery fabric location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery fabric location.",
        SerializedName = @"recoveryFabricLocation",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryFabricLocation { get; set; }

    }
    /// A2A Network Mapping fabric specific settings.
    internal partial interface IAzureToAzureNetworkMappingSettingsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingFabricSpecificSettingsInternal
    {
        /// <summary>The primary fabric location.</summary>
        string PrimaryFabricLocation { get; set; }
        /// <summary>The recovery fabric location.</summary>
        string RecoveryFabricLocation { get; set; }

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>E2A Network Mapping fabric specific settings.</summary>
    public partial class VmmToAzureNetworkMappingSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVmmToAzureNetworkMappingSettings,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVmmToAzureNetworkMappingSettingsInternal,
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

        /// <summary>Creates an new <see cref="VmmToAzureNetworkMappingSettings" /> instance.</summary>
        public VmmToAzureNetworkMappingSettings()
        {

        }
    }
    /// E2A Network Mapping fabric specific settings.
    public partial interface IVmmToAzureNetworkMappingSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingFabricSpecificSettings
    {

    }
    /// E2A Network Mapping fabric specific settings.
    internal partial interface IVmmToAzureNetworkMappingSettingsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingFabricSpecificSettingsInternal
    {

    }
}
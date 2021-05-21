namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class DefaultRolloutSpecificationCanary :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationCanary,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationCanaryInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICanaryTrafficRegionRolloutConfiguration"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICanaryTrafficRegionRolloutConfiguration __canaryTrafficRegionRolloutConfiguration = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.CanaryTrafficRegionRolloutConfiguration();

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string[] Region { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICanaryTrafficRegionRolloutConfigurationInternal)__canaryTrafficRegionRolloutConfiguration).Region; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICanaryTrafficRegionRolloutConfigurationInternal)__canaryTrafficRegionRolloutConfiguration).Region = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string[] SkipRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICanaryTrafficRegionRolloutConfigurationInternal)__canaryTrafficRegionRolloutConfiguration).SkipRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICanaryTrafficRegionRolloutConfigurationInternal)__canaryTrafficRegionRolloutConfiguration).SkipRegion = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="DefaultRolloutSpecificationCanary" /> instance.</summary>
        public DefaultRolloutSpecificationCanary()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__canaryTrafficRegionRolloutConfiguration), __canaryTrafficRegionRolloutConfiguration);
            await eventListener.AssertObjectIsValid(nameof(__canaryTrafficRegionRolloutConfiguration), __canaryTrafficRegionRolloutConfiguration);
        }
    }
    public partial interface IDefaultRolloutSpecificationCanary :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICanaryTrafficRegionRolloutConfiguration
    {

    }
    internal partial interface IDefaultRolloutSpecificationCanaryInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICanaryTrafficRegionRolloutConfigurationInternal
    {

    }
}
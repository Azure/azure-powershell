namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class DefaultRolloutSpecificationRestOfTheWorldGroupTwo :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationRestOfTheWorldGroupTwo,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationRestOfTheWorldGroupTwoInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration __trafficRegionRolloutConfiguration = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TrafficRegionRolloutConfiguration();

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string[] Region { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionsInternal)__trafficRegionRolloutConfiguration).Region; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionsInternal)__trafficRegionRolloutConfiguration).Region = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public global::System.TimeSpan? WaitDuration { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfigurationInternal)__trafficRegionRolloutConfiguration).WaitDuration; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfigurationInternal)__trafficRegionRolloutConfiguration).WaitDuration = value ?? default(global::System.TimeSpan); }

        /// <summary>
        /// Creates an new <see cref="DefaultRolloutSpecificationRestOfTheWorldGroupTwo" /> instance.
        /// </summary>
        public DefaultRolloutSpecificationRestOfTheWorldGroupTwo()
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
            await eventListener.AssertNotNull(nameof(__trafficRegionRolloutConfiguration), __trafficRegionRolloutConfiguration);
            await eventListener.AssertObjectIsValid(nameof(__trafficRegionRolloutConfiguration), __trafficRegionRolloutConfiguration);
        }
    }
    public partial interface IDefaultRolloutSpecificationRestOfTheWorldGroupTwo :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration
    {

    }
    internal partial interface IDefaultRolloutSpecificationRestOfTheWorldGroupTwoInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfigurationInternal
    {

    }
}
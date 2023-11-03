namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class TrafficRegionRolloutConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfigurationInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegions"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegions __trafficRegions = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TrafficRegions();

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string[] Region { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionsInternal)__trafficRegions).Region; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionsInternal)__trafficRegions).Region = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="WaitDuration" /> property.</summary>
        private global::System.TimeSpan? _waitDuration;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public global::System.TimeSpan? WaitDuration { get => this._waitDuration; set => this._waitDuration = value; }

        /// <summary>Creates an new <see cref="TrafficRegionRolloutConfiguration" /> instance.</summary>
        public TrafficRegionRolloutConfiguration()
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
            await eventListener.AssertNotNull(nameof(__trafficRegions), __trafficRegions);
            await eventListener.AssertObjectIsValid(nameof(__trafficRegions), __trafficRegions);
        }
    }
    public partial interface ITrafficRegionRolloutConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegions
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"waitDuration",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan? WaitDuration { get; set; }

    }
    internal partial interface ITrafficRegionRolloutConfigurationInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionsInternal
    {
        global::System.TimeSpan? WaitDuration { get; set; }

    }
}
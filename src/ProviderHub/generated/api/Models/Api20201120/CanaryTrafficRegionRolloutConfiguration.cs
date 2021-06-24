namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class CanaryTrafficRegionRolloutConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICanaryTrafficRegionRolloutConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICanaryTrafficRegionRolloutConfigurationInternal
    {

        /// <summary>Backing field for <see cref="Region" /> property.</summary>
        private string[] _region;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string[] Region { get => this._region; set => this._region = value; }

        /// <summary>Backing field for <see cref="SkipRegion" /> property.</summary>
        private string[] _skipRegion;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string[] SkipRegion { get => this._skipRegion; set => this._skipRegion = value; }

        /// <summary>Creates an new <see cref="CanaryTrafficRegionRolloutConfiguration" /> instance.</summary>
        public CanaryTrafficRegionRolloutConfiguration()
        {

        }
    }
    public partial interface ICanaryTrafficRegionRolloutConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"regions",
        PossibleTypes = new [] { typeof(string) })]
        string[] Region { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"skipRegions",
        PossibleTypes = new [] { typeof(string) })]
        string[] SkipRegion { get; set; }

    }
    internal partial interface ICanaryTrafficRegionRolloutConfigurationInternal

    {
        string[] Region { get; set; }

        string[] SkipRegion { get; set; }

    }
}
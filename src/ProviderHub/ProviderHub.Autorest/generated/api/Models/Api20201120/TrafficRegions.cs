namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class TrafficRegions :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegions,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionsInternal
    {

        /// <summary>Backing field for <see cref="Region" /> property.</summary>
        private string[] _region;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string[] Region { get => this._region; set => this._region = value; }

        /// <summary>Creates an new <see cref="TrafficRegions" /> instance.</summary>
        public TrafficRegions()
        {

        }
    }
    public partial interface ITrafficRegions :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"regions",
        PossibleTypes = new [] { typeof(string) })]
        string[] Region { get; set; }

    }
    internal partial interface ITrafficRegionsInternal

    {
        string[] Region { get; set; }

    }
}
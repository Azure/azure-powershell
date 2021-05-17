namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class CheckinManifestParams :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckinManifestParams,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckinManifestParamsInternal
    {

        /// <summary>Backing field for <see cref="BaselineArmManifestLocation" /> property.</summary>
        private string _baselineArmManifestLocation;

        /// <summary>The baseline ARM manifest location supplied to the checkin manifest operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string BaselineArmManifestLocation { get => this._baselineArmManifestLocation; set => this._baselineArmManifestLocation = value; }

        /// <summary>Backing field for <see cref="Environment" /> property.</summary>
        private string _environment;

        /// <summary>The environment supplied to the checkin manifest operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string Environment { get => this._environment; set => this._environment = value; }

        /// <summary>Creates an new <see cref="CheckinManifestParams" /> instance.</summary>
        public CheckinManifestParams()
        {

        }
    }
    public partial interface ICheckinManifestParams :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        /// <summary>The baseline ARM manifest location supplied to the checkin manifest operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The baseline ARM manifest location supplied to the checkin manifest operation.",
        SerializedName = @"baselineArmManifestLocation",
        PossibleTypes = new [] { typeof(string) })]
        string BaselineArmManifestLocation { get; set; }
        /// <summary>The environment supplied to the checkin manifest operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The environment supplied to the checkin manifest operation.",
        SerializedName = @"environment",
        PossibleTypes = new [] { typeof(string) })]
        string Environment { get; set; }

    }
    internal partial interface ICheckinManifestParamsInternal

    {
        /// <summary>The baseline ARM manifest location supplied to the checkin manifest operation.</summary>
        string BaselineArmManifestLocation { get; set; }
        /// <summary>The environment supplied to the checkin manifest operation.</summary>
        string Environment { get; set; }

    }
}
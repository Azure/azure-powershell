namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class LoggingHiddenPropertyPath :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingHiddenPropertyPath,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingHiddenPropertyPathInternal
    {

        /// <summary>Backing field for <see cref="HiddenPathsOnRequest" /> property.</summary>
        private string[] _hiddenPathsOnRequest;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string[] HiddenPathsOnRequest { get => this._hiddenPathsOnRequest; set => this._hiddenPathsOnRequest = value; }

        /// <summary>Backing field for <see cref="HiddenPathsOnResponse" /> property.</summary>
        private string[] _hiddenPathsOnResponse;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string[] HiddenPathsOnResponse { get => this._hiddenPathsOnResponse; set => this._hiddenPathsOnResponse = value; }

        /// <summary>Creates an new <see cref="LoggingHiddenPropertyPath" /> instance.</summary>
        public LoggingHiddenPropertyPath()
        {

        }
    }
    public partial interface ILoggingHiddenPropertyPath :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"hiddenPathsOnRequest",
        PossibleTypes = new [] { typeof(string) })]
        string[] HiddenPathsOnRequest { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"hiddenPathsOnResponse",
        PossibleTypes = new [] { typeof(string) })]
        string[] HiddenPathsOnResponse { get; set; }

    }
    internal partial interface ILoggingHiddenPropertyPathInternal

    {
        string[] HiddenPathsOnRequest { get; set; }

        string[] HiddenPathsOnResponse { get; set; }

    }
}
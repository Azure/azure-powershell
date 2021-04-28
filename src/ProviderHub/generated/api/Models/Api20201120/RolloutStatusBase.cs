namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class RolloutStatusBase :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRolloutStatusBase,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRolloutStatusBaseInternal
    {

        /// <summary>Backing field for <see cref="CompletedRegion" /> property.</summary>
        private string[] _completedRegion;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string[] CompletedRegion { get => this._completedRegion; set => this._completedRegion = value; }

        /// <summary>Backing field for <see cref="FailedOrSkippedRegion" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRolloutStatusBaseFailedOrSkippedRegions _failedOrSkippedRegion;

        /// <summary>Dictionary of <ExtendedErrorInfo></summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRolloutStatusBaseFailedOrSkippedRegions FailedOrSkippedRegion { get => (this._failedOrSkippedRegion = this._failedOrSkippedRegion ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.RolloutStatusBaseFailedOrSkippedRegions()); set => this._failedOrSkippedRegion = value; }

        /// <summary>Creates an new <see cref="RolloutStatusBase" /> instance.</summary>
        public RolloutStatusBase()
        {

        }
    }
    public partial interface IRolloutStatusBase :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"completedRegions",
        PossibleTypes = new [] { typeof(string) })]
        string[] CompletedRegion { get; set; }
        /// <summary>Dictionary of <ExtendedErrorInfo></summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Dictionary of <ExtendedErrorInfo>",
        SerializedName = @"failedOrSkippedRegions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRolloutStatusBaseFailedOrSkippedRegions) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRolloutStatusBaseFailedOrSkippedRegions FailedOrSkippedRegion { get; set; }

    }
    internal partial interface IRolloutStatusBaseInternal

    {
        string[] CompletedRegion { get; set; }
        /// <summary>Dictionary of <ExtendedErrorInfo></summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRolloutStatusBaseFailedOrSkippedRegions FailedOrSkippedRegion { get; set; }

    }
}
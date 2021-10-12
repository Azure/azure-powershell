namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ReRegisterSubscriptionMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IReRegisterSubscriptionMetadata,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IReRegisterSubscriptionMetadataInternal
    {

        /// <summary>Backing field for <see cref="ConcurrencyLimit" /> property.</summary>
        private int? _concurrencyLimit;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public int? ConcurrencyLimit { get => this._concurrencyLimit; set => this._concurrencyLimit = value; }

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private bool _enabled;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public bool Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>Creates an new <see cref="ReRegisterSubscriptionMetadata" /> instance.</summary>
        public ReRegisterSubscriptionMetadata()
        {

        }
    }
    public partial interface IReRegisterSubscriptionMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"concurrencyLimit",
        PossibleTypes = new [] { typeof(int) })]
        int? ConcurrencyLimit { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool Enabled { get; set; }

    }
    internal partial interface IReRegisterSubscriptionMetadataInternal

    {
        int? ConcurrencyLimit { get; set; }

        bool Enabled { get; set; }

    }
}
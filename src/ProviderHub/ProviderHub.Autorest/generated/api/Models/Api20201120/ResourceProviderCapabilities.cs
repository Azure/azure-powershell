namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceProviderCapabilities :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderCapabilities,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderCapabilitiesInternal
    {

        /// <summary>Backing field for <see cref="Effect" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceProviderCapabilitiesEffect _effect;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceProviderCapabilitiesEffect Effect { get => this._effect; set => this._effect = value; }

        /// <summary>Backing field for <see cref="QuotaId" /> property.</summary>
        private string _quotaId;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string QuotaId { get => this._quotaId; set => this._quotaId = value; }

        /// <summary>Backing field for <see cref="RequiredFeature" /> property.</summary>
        private string[] _requiredFeature;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string[] RequiredFeature { get => this._requiredFeature; set => this._requiredFeature = value; }

        /// <summary>Creates an new <see cref="ResourceProviderCapabilities" /> instance.</summary>
        public ResourceProviderCapabilities()
        {

        }
    }
    public partial interface IResourceProviderCapabilities :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"effect",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceProviderCapabilitiesEffect) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceProviderCapabilitiesEffect Effect { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"quotaId",
        PossibleTypes = new [] { typeof(string) })]
        string QuotaId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"requiredFeatures",
        PossibleTypes = new [] { typeof(string) })]
        string[] RequiredFeature { get; set; }

    }
    internal partial interface IResourceProviderCapabilitiesInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceProviderCapabilitiesEffect Effect { get; set; }

        string QuotaId { get; set; }

        string[] RequiredFeature { get; set; }

    }
}
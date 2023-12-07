namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class CustomRolloutSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICustomRolloutSpecification,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICustomRolloutSpecificationInternal
    {

        /// <summary>Backing field for <see cref="Canary" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegions _canary;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegions Canary { get => (this._canary = this._canary ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TrafficRegions()); set => this._canary = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string[] CanaryRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionsInternal)Canary).Region; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionsInternal)Canary).Region = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for Canary</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegions Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICustomRolloutSpecificationInternal.Canary { get => (this._canary = this._canary ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TrafficRegions()); set { {_canary = value;} } }

        /// <summary>Backing field for <see cref="ProviderRegistration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration _providerRegistration;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration ProviderRegistration { get => (this._providerRegistration = this._providerRegistration ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ProviderRegistration()); set => this._providerRegistration = value; }

        /// <summary>Backing field for <see cref="ResourceTypeRegistration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration[] _resourceTypeRegistration;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration[] ResourceTypeRegistration { get => this._resourceTypeRegistration; set => this._resourceTypeRegistration = value; }

        /// <summary>Creates an new <see cref="CustomRolloutSpecification" /> instance.</summary>
        public CustomRolloutSpecification()
        {

        }
    }
    public partial interface ICustomRolloutSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"regions",
        PossibleTypes = new [] { typeof(string) })]
        string[] CanaryRegion { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"providerRegistration",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration ProviderRegistration { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"resourceTypeRegistrations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration[] ResourceTypeRegistration { get; set; }

    }
    internal partial interface ICustomRolloutSpecificationInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegions Canary { get; set; }

        string[] CanaryRegion { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration ProviderRegistration { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration[] ResourceTypeRegistration { get; set; }

    }
}
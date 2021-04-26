namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class FeaturesRule :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRule,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRuleInternal
    {

        /// <summary>Backing field for <see cref="RequiredFeaturesPolicy" /> property.</summary>
        private string _requiredFeaturesPolicy;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string RequiredFeaturesPolicy { get => this._requiredFeaturesPolicy; set => this._requiredFeaturesPolicy = value; }

        /// <summary>Creates an new <see cref="FeaturesRule" /> instance.</summary>
        public FeaturesRule()
        {

        }
    }
    public partial interface IFeaturesRule :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"requiredFeaturesPolicy",
        PossibleTypes = new [] { typeof(string) })]
        string RequiredFeaturesPolicy { get; set; }

    }
    internal partial interface IFeaturesRuleInternal

    {
        string RequiredFeaturesPolicy { get; set; }

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class TemplateDeploymentOptions :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptions,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptionsInternal
    {

        /// <summary>Backing field for <see cref="PreflightOption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.PreflightOption[] _preflightOption;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.PreflightOption[] PreflightOption { get => this._preflightOption; set => this._preflightOption = value; }

        /// <summary>Backing field for <see cref="PreflightSupported" /> property.</summary>
        private bool? _preflightSupported;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public bool? PreflightSupported { get => this._preflightSupported; set => this._preflightSupported = value; }

        /// <summary>Creates an new <see cref="TemplateDeploymentOptions" /> instance.</summary>
        public TemplateDeploymentOptions()
        {

        }
    }
    public partial interface ITemplateDeploymentOptions :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"preflightOptions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.PreflightOption) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.PreflightOption[] PreflightOption { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"preflightSupported",
        PossibleTypes = new [] { typeof(bool) })]
        bool? PreflightSupported { get; set; }

    }
    internal partial interface ITemplateDeploymentOptionsInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.PreflightOption[] PreflightOption { get; set; }

        bool? PreflightSupported { get; set; }

    }
}
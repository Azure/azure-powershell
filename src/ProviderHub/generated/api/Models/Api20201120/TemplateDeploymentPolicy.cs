namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class TemplateDeploymentPolicy :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentPolicy,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentPolicyInternal
    {

        /// <summary>Backing field for <see cref="Capability" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TemplateDeploymentCapabilities _capability;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TemplateDeploymentCapabilities Capability { get => this._capability; set => this._capability = value; }

        /// <summary>Backing field for <see cref="PreflightOption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TemplateDeploymentPreflightOptions _preflightOption;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TemplateDeploymentPreflightOptions PreflightOption { get => this._preflightOption; set => this._preflightOption = value; }

        /// <summary>Creates an new <see cref="TemplateDeploymentPolicy" /> instance.</summary>
        public TemplateDeploymentPolicy()
        {

        }
    }
    public partial interface ITemplateDeploymentPolicy :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"capabilities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TemplateDeploymentCapabilities) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TemplateDeploymentCapabilities Capability { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"preflightOptions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TemplateDeploymentPreflightOptions) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TemplateDeploymentPreflightOptions PreflightOption { get; set; }

    }
    internal partial interface ITemplateDeploymentPolicyInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TemplateDeploymentCapabilities Capability { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TemplateDeploymentPreflightOptions PreflightOption { get; set; }

    }
}
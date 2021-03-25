namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class TemplateDeploymentPolicy :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentPolicy,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentPolicyInternal
    {

        /// <summary>Backing field for <see cref="Capability" /> property.</summary>
        private string _capability;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string Capability { get => this._capability; set => this._capability = value; }

        /// <summary>Backing field for <see cref="PreflightOption" /> property.</summary>
        private string _preflightOption;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string PreflightOption { get => this._preflightOption; set => this._preflightOption = value; }

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
        PossibleTypes = new [] { typeof(string) })]
        string Capability { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"preflightOptions",
        PossibleTypes = new [] { typeof(string) })]
        string PreflightOption { get; set; }

    }
    internal partial interface ITemplateDeploymentPolicyInternal

    {
        string Capability { get; set; }

        string PreflightOption { get; set; }

    }
}
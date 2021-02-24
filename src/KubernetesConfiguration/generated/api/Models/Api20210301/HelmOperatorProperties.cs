namespace Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Extensions;

    /// <summary>Properties for Helm operator.</summary>
    public partial class HelmOperatorProperties :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IHelmOperatorProperties,
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IHelmOperatorPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ChartValue" /> property.</summary>
        private string _chartValue;

        /// <summary>Values override for the operator Helm chart.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string ChartValue { get => this._chartValue; set => this._chartValue = value; }

        /// <summary>Backing field for <see cref="ChartVersion" /> property.</summary>
        private string _chartVersion;

        /// <summary>Version of the operator Helm chart.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string ChartVersion { get => this._chartVersion; set => this._chartVersion = value; }

        /// <summary>Creates an new <see cref="HelmOperatorProperties" /> instance.</summary>
        public HelmOperatorProperties()
        {

        }
    }
    /// Properties for Helm operator.
    public partial interface IHelmOperatorProperties :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>Values override for the operator Helm chart.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Values override for the operator Helm chart.",
        SerializedName = @"chartValues",
        PossibleTypes = new [] { typeof(string) })]
        string ChartValue { get; set; }
        /// <summary>Version of the operator Helm chart.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Version of the operator Helm chart.",
        SerializedName = @"chartVersion",
        PossibleTypes = new [] { typeof(string) })]
        string ChartVersion { get; set; }

    }
    /// Properties for Helm operator.
    internal partial interface IHelmOperatorPropertiesInternal

    {
        /// <summary>Values override for the operator Helm chart.</summary>
        string ChartValue { get; set; }
        /// <summary>Version of the operator Helm chart.</summary>
        string ChartVersion { get; set; }

    }
}
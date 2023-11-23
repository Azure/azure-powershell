namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>Parameters supplied to the Update Environment operation.</summary>
    public partial class EnvironmentUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentUpdateParametersInternal
    {

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentUpdateParametersTags _tag;

        /// <summary>Key-value pairs of additional properties for the environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentUpdateParametersTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.EnvironmentUpdateParametersTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="EnvironmentUpdateParameters" /> instance.</summary>
        public EnvironmentUpdateParameters()
        {

        }
    }
    /// Parameters supplied to the Update Environment operation.
    public partial interface IEnvironmentUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable
    {
        /// <summary>Key-value pairs of additional properties for the environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Key-value pairs of additional properties for the environment.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentUpdateParametersTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentUpdateParametersTags Tag { get; set; }

    }
    /// Parameters supplied to the Update Environment operation.
    internal partial interface IEnvironmentUpdateParametersInternal

    {
        /// <summary>Key-value pairs of additional properties for the environment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentUpdateParametersTags Tag { get; set; }

    }
}
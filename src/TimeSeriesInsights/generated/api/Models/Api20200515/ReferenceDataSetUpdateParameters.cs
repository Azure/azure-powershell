namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>Parameters supplied to the Update Reference Data Set operation.</summary>
    public partial class ReferenceDataSetUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IReferenceDataSetUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IReferenceDataSetUpdateParametersInternal
    {

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IReferenceDataSetUpdateParametersTags _tag;

        /// <summary>Key-value pairs of additional properties for the reference data set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IReferenceDataSetUpdateParametersTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ReferenceDataSetUpdateParametersTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="ReferenceDataSetUpdateParameters" /> instance.</summary>
        public ReferenceDataSetUpdateParameters()
        {

        }
    }
    /// Parameters supplied to the Update Reference Data Set operation.
    public partial interface IReferenceDataSetUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable
    {
        /// <summary>Key-value pairs of additional properties for the reference data set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Key-value pairs of additional properties for the reference data set.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IReferenceDataSetUpdateParametersTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IReferenceDataSetUpdateParametersTags Tag { get; set; }

    }
    /// Parameters supplied to the Update Reference Data Set operation.
    internal partial interface IReferenceDataSetUpdateParametersInternal

    {
        /// <summary>Key-value pairs of additional properties for the reference data set.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IReferenceDataSetUpdateParametersTags Tag { get; set; }

    }
}
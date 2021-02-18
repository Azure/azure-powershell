namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>The response of the List Environments operation.</summary>
    public partial class EnvironmentListResponse :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentListResponse,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentListResponseInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentResource[] _value;

        /// <summary>Result of the List Environments operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentResource[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="EnvironmentListResponse" /> instance.</summary>
        public EnvironmentListResponse()
        {

        }
    }
    /// The response of the List Environments operation.
    public partial interface IEnvironmentListResponse :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable
    {
        /// <summary>Result of the List Environments operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Result of the List Environments operation.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentResource[] Value { get; set; }

    }
    /// The response of the List Environments operation.
    internal partial interface IEnvironmentListResponseInternal

    {
        /// <summary>Result of the List Environments operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentResource[] Value { get; set; }

    }
}
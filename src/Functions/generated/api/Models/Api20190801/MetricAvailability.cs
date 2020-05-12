namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Retention policy of a resource metric.</summary>
    public partial class MetricAvailability :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricAvailability,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricAvailabilityInternal
    {

        /// <summary>Backing field for <see cref="BlobDuration" /> property.</summary>
        private string _blobDuration;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string BlobDuration { get => this._blobDuration; set => this._blobDuration = value; }

        /// <summary>Backing field for <see cref="TimeGrain" /> property.</summary>
        private string _timeGrain;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TimeGrain { get => this._timeGrain; set => this._timeGrain = value; }

        /// <summary>Creates an new <see cref="MetricAvailability" /> instance.</summary>
        public MetricAvailability()
        {

        }
    }
    /// Retention policy of a resource metric.
    public partial interface IMetricAvailability :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"blobDuration",
        PossibleTypes = new [] { typeof(string) })]
        string BlobDuration { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"timeGrain",
        PossibleTypes = new [] { typeof(string) })]
        string TimeGrain { get; set; }

    }
    /// Retention policy of a resource metric.
    internal partial interface IMetricAvailabilityInternal

    {
        string BlobDuration { get; set; }

        string TimeGrain { get; set; }

    }
}
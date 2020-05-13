namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Metrics availability and retention.</summary>
    public partial class ResourceMetricAvailability :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricAvailability,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricAvailabilityInternal
    {

        /// <summary>Internal Acessors for Retention</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricAvailabilityInternal.Retention { get => this._retention; set { {_retention = value;} } }

        /// <summary>Internal Acessors for TimeGrain</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricAvailabilityInternal.TimeGrain { get => this._timeGrain; set { {_timeGrain = value;} } }

        /// <summary>Backing field for <see cref="Retention" /> property.</summary>
        private string _retention;

        /// <summary>Retention period for the current time grain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Retention { get => this._retention; }

        /// <summary>Backing field for <see cref="TimeGrain" /> property.</summary>
        private string _timeGrain;

        /// <summary>Time grain .</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TimeGrain { get => this._timeGrain; }

        /// <summary>Creates an new <see cref="ResourceMetricAvailability" /> instance.</summary>
        public ResourceMetricAvailability()
        {

        }
    }
    /// Metrics availability and retention.
    public partial interface IResourceMetricAvailability :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Retention period for the current time grain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Retention period for the current time grain.",
        SerializedName = @"retention",
        PossibleTypes = new [] { typeof(string) })]
        string Retention { get;  }
        /// <summary>Time grain .</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Time grain .",
        SerializedName = @"timeGrain",
        PossibleTypes = new [] { typeof(string) })]
        string TimeGrain { get;  }

    }
    /// Metrics availability and retention.
    internal partial interface IResourceMetricAvailabilityInternal

    {
        /// <summary>Retention period for the current time grain.</summary>
        string Retention { get; set; }
        /// <summary>Time grain .</summary>
        string TimeGrain { get; set; }

    }
}
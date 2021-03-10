namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ThrottlingMetric :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingMetric,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingMetricInternal
    {

        /// <summary>Backing field for <see cref="Interval" /> property.</summary>
        private global::System.TimeSpan? _interval;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public global::System.TimeSpan? Interval { get => this._interval; set => this._interval = value; }

        /// <summary>Backing field for <see cref="Limit" /> property.</summary>
        private long _limit;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public long Limit { get => this._limit; set => this._limit = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ThrottlingMetricType _type;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ThrottlingMetricType Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="ThrottlingMetric" /> instance.</summary>
        public ThrottlingMetric()
        {

        }
    }
    public partial interface IThrottlingMetric :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"interval",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan? Interval { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"limit",
        PossibleTypes = new [] { typeof(long) })]
        long Limit { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ThrottlingMetricType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ThrottlingMetricType Type { get; set; }

    }
    internal partial interface IThrottlingMetricInternal

    {
        global::System.TimeSpan? Interval { get; set; }

        long Limit { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ThrottlingMetricType Type { get; set; }

    }
}
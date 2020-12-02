namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>
    /// An object that represents the local timestamp property. It contains the format of local timestamp that needs to be used
    /// and the corresponding timezone offset information. If a value isn't specified for localTimestamp, or if null, then the
    /// local timestamp will not be ingressed with the events.
    /// </summary>
    public partial class LocalTimestamp :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ILocalTimestamp,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ILocalTimestampInternal
    {

        /// <summary>Backing field for <see cref="Format" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.LocalTimestampFormat? _format;

        /// <summary>
        /// An enum that represents the format of the local timestamp property that needs to be set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.LocalTimestampFormat? Format { get => this._format; set => this._format = value; }

        /// <summary>Internal Acessors for TimeZoneOffset</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ILocalTimestampTimeZoneOffset Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ILocalTimestampInternal.TimeZoneOffset { get => (this._timeZoneOffset = this._timeZoneOffset ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.LocalTimestampTimeZoneOffset()); set { {_timeZoneOffset = value;} } }

        /// <summary>Backing field for <see cref="TimeZoneOffset" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ILocalTimestampTimeZoneOffset _timeZoneOffset;

        /// <summary>
        /// An object that represents the offset information for the local timestamp format specified. Should not be specified for
        /// LocalTimestampFormat - Embedded.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ILocalTimestampTimeZoneOffset TimeZoneOffset { get => (this._timeZoneOffset = this._timeZoneOffset ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.LocalTimestampTimeZoneOffset()); set => this._timeZoneOffset = value; }

        /// <summary>
        /// The event property that will be contain the offset information to calculate the local timestamp. When the LocalTimestampFormat
        /// is Iana, the property name will contain the name of the column which contains IANA Timezone Name (eg: Americas/Los Angeles).
        /// When LocalTimestampFormat is Timespan, it contains the name of property which contains values representing the offset
        /// (eg: P1D or 1.00:00:00)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public string TimeZoneOffsetPropertyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ILocalTimestampTimeZoneOffsetInternal)TimeZoneOffset).PropertyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ILocalTimestampTimeZoneOffsetInternal)TimeZoneOffset).PropertyName = value; }

        /// <summary>Creates an new <see cref="LocalTimestamp" /> instance.</summary>
        public LocalTimestamp()
        {

        }
    }
    /// An object that represents the local timestamp property. It contains the format of local timestamp that needs to be used
    /// and the corresponding timezone offset information. If a value isn't specified for localTimestamp, or if null, then the
    /// local timestamp will not be ingressed with the events.
    public partial interface ILocalTimestamp :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable
    {
        /// <summary>
        /// An enum that represents the format of the local timestamp property that needs to be set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"An enum that represents the format of the local timestamp property that needs to be set.",
        SerializedName = @"format",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.LocalTimestampFormat) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.LocalTimestampFormat? Format { get; set; }
        /// <summary>
        /// The event property that will be contain the offset information to calculate the local timestamp. When the LocalTimestampFormat
        /// is Iana, the property name will contain the name of the column which contains IANA Timezone Name (eg: Americas/Los Angeles).
        /// When LocalTimestampFormat is Timespan, it contains the name of property which contains values representing the offset
        /// (eg: P1D or 1.00:00:00)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The event property that will be contain the offset information to calculate the local timestamp. When the LocalTimestampFormat is Iana, the property name will contain the name of the column which contains IANA Timezone Name (eg: Americas/Los Angeles). When LocalTimestampFormat is Timespan, it contains the name of property which contains values representing the offset (eg: P1D or 1.00:00:00)",
        SerializedName = @"propertyName",
        PossibleTypes = new [] { typeof(string) })]
        string TimeZoneOffsetPropertyName { get; set; }

    }
    /// An object that represents the local timestamp property. It contains the format of local timestamp that needs to be used
    /// and the corresponding timezone offset information. If a value isn't specified for localTimestamp, or if null, then the
    /// local timestamp will not be ingressed with the events.
    internal partial interface ILocalTimestampInternal

    {
        /// <summary>
        /// An enum that represents the format of the local timestamp property that needs to be set.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.LocalTimestampFormat? Format { get; set; }
        /// <summary>
        /// An object that represents the offset information for the local timestamp format specified. Should not be specified for
        /// LocalTimestampFormat - Embedded.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ILocalTimestampTimeZoneOffset TimeZoneOffset { get; set; }
        /// <summary>
        /// The event property that will be contain the offset information to calculate the local timestamp. When the LocalTimestampFormat
        /// is Iana, the property name will contain the name of the column which contains IANA Timezone Name (eg: Americas/Los Angeles).
        /// When LocalTimestampFormat is Timespan, it contains the name of property which contains values representing the offset
        /// (eg: P1D or 1.00:00:00)
        /// </summary>
        string TimeZoneOffsetPropertyName { get; set; }

    }
}
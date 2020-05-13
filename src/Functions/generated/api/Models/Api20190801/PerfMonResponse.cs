namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Performance monitor API response.</summary>
    public partial class PerfMonResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonResponse,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonResponseInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>The response code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Code { get => this._code; set => this._code = value; }

        /// <summary>Backing field for <see cref="Data" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSet _data;

        /// <summary>The performance monitor counters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSet Data { get => (this._data = this._data ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.PerfMonSet()); set => this._data = value; }

        /// <summary>End time of the period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? DataEndTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSetInternal)Data).EndTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSetInternal)Data).EndTime = value; }

        /// <summary>Unique key name of the counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DataName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSetInternal)Data).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSetInternal)Data).Name = value; }

        /// <summary>Start time of the period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? DataStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSetInternal)Data).StartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSetInternal)Data).StartTime = value; }

        /// <summary>Presented time grain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DataTimeGrain { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSetInternal)Data).TimeGrain; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSetInternal)Data).TimeGrain = value; }

        /// <summary>Collection of workers that are active during this time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSample[] DataValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSetInternal)Data).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSetInternal)Data).Value = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>The message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Internal Acessors for Data</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSet Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonResponseInternal.Data { get => (this._data = this._data ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.PerfMonSet()); set { {_data = value;} } }

        /// <summary>Creates an new <see cref="PerfMonResponse" /> instance.</summary>
        public PerfMonResponse()
        {

        }
    }
    /// Performance monitor API response.
    public partial interface IPerfMonResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The response code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The response code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>End time of the period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"End time of the period.",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? DataEndTime { get; set; }
        /// <summary>Unique key name of the counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Unique key name of the counter.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string DataName { get; set; }
        /// <summary>Start time of the period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start time of the period.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? DataStartTime { get; set; }
        /// <summary>Presented time grain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Presented time grain.",
        SerializedName = @"timeGrain",
        PossibleTypes = new [] { typeof(string) })]
        string DataTimeGrain { get; set; }
        /// <summary>Collection of workers that are active during this time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of workers that are active during this time.",
        SerializedName = @"values",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSample) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSample[] DataValue { get; set; }
        /// <summary>The message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }

    }
    /// Performance monitor API response.
    internal partial interface IPerfMonResponseInternal

    {
        /// <summary>The response code.</summary>
        string Code { get; set; }
        /// <summary>The performance monitor counters.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSet Data { get; set; }
        /// <summary>End time of the period.</summary>
        global::System.DateTime? DataEndTime { get; set; }
        /// <summary>Unique key name of the counter.</summary>
        string DataName { get; set; }
        /// <summary>Start time of the period.</summary>
        global::System.DateTime? DataStartTime { get; set; }
        /// <summary>Presented time grain.</summary>
        string DataTimeGrain { get; set; }
        /// <summary>Collection of workers that are active during this time.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSample[] DataValue { get; set; }
        /// <summary>The message.</summary>
        string Message { get; set; }

    }
}
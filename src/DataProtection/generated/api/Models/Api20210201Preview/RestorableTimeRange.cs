namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    public partial class RestorableTimeRange :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestorableTimeRange,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestorableTimeRangeInternal
    {

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private string _endTime;

        /// <summary>End time for the available restore range</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string EndTime { get => this._endTime; set => this._endTime = value; }

        /// <summary>Backing field for <see cref="ObjectType" /> property.</summary>
        private string _objectType;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string ObjectType { get => this._objectType; set => this._objectType = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private string _startTime;

        /// <summary>Start time for the available restore range</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Creates an new <see cref="RestorableTimeRange" /> instance.</summary>
        public RestorableTimeRange()
        {

        }
    }
    public partial interface IRestorableTimeRange :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>End time for the available restore range</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"End time for the available restore range",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(string) })]
        string EndTime { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"objectType",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectType { get; set; }
        /// <summary>Start time for the available restore range</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Start time for the available restore range",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(string) })]
        string StartTime { get; set; }

    }
    internal partial interface IRestorableTimeRangeInternal

    {
        /// <summary>End time for the available restore range</summary>
        string EndTime { get; set; }

        string ObjectType { get; set; }
        /// <summary>Start time for the available restore range</summary>
        string StartTime { get; set; }

    }
}
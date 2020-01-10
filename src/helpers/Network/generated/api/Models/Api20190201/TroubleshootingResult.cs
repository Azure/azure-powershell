namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Troubleshooting information gained from specified resource.</summary>
    public partial class TroubleshootingResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingResultInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>The result code of the troubleshooting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Code { get => this._code; set => this._code = value; }

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private global::System.DateTime? _endTime;

        /// <summary>The end time of the troubleshooting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public global::System.DateTime? EndTime { get => this._endTime; set => this._endTime = value; }

        /// <summary>Backing field for <see cref="Result" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingDetails[] _result;

        /// <summary>Information from troubleshooting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingDetails[] Result { get => this._result; set => this._result = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>The start time of the troubleshooting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Creates an new <see cref="TroubleshootingResult" /> instance.</summary>
        public TroubleshootingResult()
        {

        }
    }
    /// Troubleshooting information gained from specified resource.
    public partial interface ITroubleshootingResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The result code of the troubleshooting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The result code of the troubleshooting.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>The end time of the troubleshooting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The end time of the troubleshooting.",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Information from troubleshooting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Information from troubleshooting.",
        SerializedName = @"results",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingDetails[] Result { get; set; }
        /// <summary>The start time of the troubleshooting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The start time of the troubleshooting.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }

    }
    /// Troubleshooting information gained from specified resource.
    internal partial interface ITroubleshootingResultInternal

    {
        /// <summary>The result code of the troubleshooting.</summary>
        string Code { get; set; }
        /// <summary>The end time of the troubleshooting.</summary>
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Information from troubleshooting.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingDetails[] Result { get; set; }
        /// <summary>The start time of the troubleshooting.</summary>
        global::System.DateTime? StartTime { get; set; }

    }
}
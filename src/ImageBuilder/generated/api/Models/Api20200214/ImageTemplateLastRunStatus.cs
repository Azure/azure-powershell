namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>Describes the latest status of running an image template</summary>
    public partial class ImageTemplateLastRunStatus :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateLastRunStatus,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateLastRunStatusInternal
    {

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private global::System.DateTime? _endTime;

        /// <summary>End time of the last run (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public global::System.DateTime? EndTime { get => this._endTime; set => this._endTime = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Verbose information about the last run state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Backing field for <see cref="RunState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunState? _runState;

        /// <summary>State of the last run</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunState? RunState { get => this._runState; set => this._runState = value; }

        /// <summary>Backing field for <see cref="RunSubState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunSubState? _runSubState;

        /// <summary>Sub-state of the last run</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunSubState? RunSubState { get => this._runSubState; set => this._runSubState = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>Start time of the last run (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Creates an new <see cref="ImageTemplateLastRunStatus" /> instance.</summary>
        public ImageTemplateLastRunStatus()
        {

        }
    }
    /// Describes the latest status of running an image template
    public partial interface IImageTemplateLastRunStatus :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable
    {
        /// <summary>End time of the last run (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"End time of the last run (UTC)",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Verbose information about the last run state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Verbose information about the last run state",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>State of the last run</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"State of the last run",
        SerializedName = @"runState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunState) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunState? RunState { get; set; }
        /// <summary>Sub-state of the last run</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sub-state of the last run",
        SerializedName = @"runSubState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunSubState) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunSubState? RunSubState { get; set; }
        /// <summary>Start time of the last run (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start time of the last run (UTC)",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }

    }
    /// Describes the latest status of running an image template
    public partial interface IImageTemplateLastRunStatusInternal

    {
        /// <summary>End time of the last run (UTC)</summary>
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Verbose information about the last run state</summary>
        string Message { get; set; }
        /// <summary>State of the last run</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunState? RunState { get; set; }
        /// <summary>Sub-state of the last run</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunSubState? RunSubState { get; set; }
        /// <summary>Start time of the last run (UTC)</summary>
        global::System.DateTime? StartTime { get; set; }

    }
}
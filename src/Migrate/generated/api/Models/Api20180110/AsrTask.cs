namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Task of the Job.</summary>
    public partial class AsrTask :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTask,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal
    {

        /// <summary>Backing field for <see cref="AllowedAction" /> property.</summary>
        private string[] _allowedAction;

        /// <summary>The state/actions applicable on this task.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] AllowedAction { get => this._allowedAction; set => this._allowedAction = value; }

        /// <summary>Backing field for <see cref="CustomDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetails _customDetail;

        /// <summary>The custom task details based on the task type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetails CustomDetail { get => (this._customDetail = this._customDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.TaskTypeDetails()); set => this._customDetail = value; }

        /// <summary>The type of task details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CustomDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetailsInternal)CustomDetail).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetailsInternal)CustomDetail).InstanceType = value ?? null; }

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private global::System.DateTime? _endTime;

        /// <summary>The end time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? EndTime { get => this._endTime; set => this._endTime = value; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetails[] _error;

        /// <summary>The task error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetails[] Error { get => this._error; set => this._error = value; }

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>The name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Backing field for <see cref="GroupTaskCustomDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IGroupTaskDetails _groupTaskCustomDetail;

        /// <summary>
        /// The custom task details based on the task type, if the task type is GroupTaskDetails or one of the types derived from
        /// it.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IGroupTaskDetails GroupTaskCustomDetail { get => (this._groupTaskCustomDetail = this._groupTaskCustomDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.GroupTaskDetails()); set => this._groupTaskCustomDetail = value; }

        /// <summary>The child tasks.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTask[] GroupTaskCustomDetailChildTask { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IGroupTaskDetailsInternal)GroupTaskCustomDetail).ChildTask; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IGroupTaskDetailsInternal)GroupTaskCustomDetail).ChildTask = value ?? null /* arrayOf */; }

        /// <summary>The type of task details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string GroupTaskCustomDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IGroupTaskDetailsInternal)GroupTaskCustomDetail).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IGroupTaskDetailsInternal)GroupTaskCustomDetail).InstanceType = value ?? null; }

        /// <summary>Internal Acessors for CustomDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal.CustomDetail { get => (this._customDetail = this._customDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.TaskTypeDetails()); set { {_customDetail = value;} } }

        /// <summary>Internal Acessors for GroupTaskCustomDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IGroupTaskDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTaskInternal.GroupTaskCustomDetail { get => (this._groupTaskCustomDetail = this._groupTaskCustomDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.GroupTaskDetails()); set { {_groupTaskCustomDetail = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The unique Task name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>The start time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private string _state;

        /// <summary>
        /// The State. It is one of these values - NotStarted, InProgress, Succeeded, Failed, Cancelled, Suspended or Other.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string State { get => this._state; set => this._state = value; }

        /// <summary>Backing field for <see cref="StateDescription" /> property.</summary>
        private string _stateDescription;

        /// <summary>
        /// The description of the task state. For example - For Succeeded state, description can be Completed, PartiallySucceeded,
        /// CompletedWithInformation or Skipped.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string StateDescription { get => this._stateDescription; set => this._stateDescription = value; }

        /// <summary>Backing field for <see cref="TaskId" /> property.</summary>
        private string _taskId;

        /// <summary>The Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TaskId { get => this._taskId; set => this._taskId = value; }

        /// <summary>Backing field for <see cref="TaskType" /> property.</summary>
        private string _taskType;

        /// <summary>The type of task. Details in CustomDetails property depend on this type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TaskType { get => this._taskType; set => this._taskType = value; }

        /// <summary>Creates an new <see cref="AsrTask" /> instance.</summary>
        public AsrTask()
        {

        }
    }
    /// Task of the Job.
    public partial interface IAsrTask :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The state/actions applicable on this task.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The state/actions applicable on this task.",
        SerializedName = @"allowedActions",
        PossibleTypes = new [] { typeof(string) })]
        string[] AllowedAction { get; set; }
        /// <summary>The type of task details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of task details.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string CustomDetailInstanceType { get; set; }
        /// <summary>The end time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The end time.",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndTime { get; set; }
        /// <summary>The task error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The task error details.",
        SerializedName = @"errors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetails[] Error { get; set; }
        /// <summary>The name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>The child tasks.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The child tasks.",
        SerializedName = @"childTasks",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTask) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTask[] GroupTaskCustomDetailChildTask { get; set; }
        /// <summary>The type of task details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of task details.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string GroupTaskCustomDetailInstanceType { get; set; }
        /// <summary>The unique Task name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The unique Task name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The start time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The start time.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }
        /// <summary>
        /// The State. It is one of these values - NotStarted, InProgress, Succeeded, Failed, Cancelled, Suspended or Other.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The State. It is one of these values - NotStarted, InProgress, Succeeded, Failed, Cancelled, Suspended or Other.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string State { get; set; }
        /// <summary>
        /// The description of the task state. For example - For Succeeded state, description can be Completed, PartiallySucceeded,
        /// CompletedWithInformation or Skipped.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The description of the task state. For example - For Succeeded state, description can be Completed, PartiallySucceeded, CompletedWithInformation or Skipped.",
        SerializedName = @"stateDescription",
        PossibleTypes = new [] { typeof(string) })]
        string StateDescription { get; set; }
        /// <summary>The Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Id.",
        SerializedName = @"taskId",
        PossibleTypes = new [] { typeof(string) })]
        string TaskId { get; set; }
        /// <summary>The type of task. Details in CustomDetails property depend on this type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of task. Details in CustomDetails property depend on this type.",
        SerializedName = @"taskType",
        PossibleTypes = new [] { typeof(string) })]
        string TaskType { get; set; }

    }
    /// Task of the Job.
    internal partial interface IAsrTaskInternal

    {
        /// <summary>The state/actions applicable on this task.</summary>
        string[] AllowedAction { get; set; }
        /// <summary>The custom task details based on the task type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITaskTypeDetails CustomDetail { get; set; }
        /// <summary>The type of task details.</summary>
        string CustomDetailInstanceType { get; set; }
        /// <summary>The end time.</summary>
        global::System.DateTime? EndTime { get; set; }
        /// <summary>The task error details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetails[] Error { get; set; }
        /// <summary>The name.</summary>
        string FriendlyName { get; set; }
        /// <summary>
        /// The custom task details based on the task type, if the task type is GroupTaskDetails or one of the types derived from
        /// it.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IGroupTaskDetails GroupTaskCustomDetail { get; set; }
        /// <summary>The child tasks.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAsrTask[] GroupTaskCustomDetailChildTask { get; set; }
        /// <summary>The type of task details.</summary>
        string GroupTaskCustomDetailInstanceType { get; set; }
        /// <summary>The unique Task name.</summary>
        string Name { get; set; }
        /// <summary>The start time.</summary>
        global::System.DateTime? StartTime { get; set; }
        /// <summary>
        /// The State. It is one of these values - NotStarted, InProgress, Succeeded, Failed, Cancelled, Suspended or Other.
        /// </summary>
        string State { get; set; }
        /// <summary>
        /// The description of the task state. For example - For Succeeded state, description can be Completed, PartiallySucceeded,
        /// CompletedWithInformation or Skipped.
        /// </summary>
        string StateDescription { get; set; }
        /// <summary>The Id.</summary>
        string TaskId { get; set; }
        /// <summary>The type of task. Details in CustomDetails property depend on this type.</summary>
        string TaskType { get; set; }

    }
}
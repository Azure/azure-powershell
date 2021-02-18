namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>ProcessThreadInfo resource specific properties</summary>
    public partial class ProcessThreadInfoProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal
    {

        /// <summary>Backing field for <see cref="BasePriority" /> property.</summary>
        private int? _basePriority;

        /// <summary>Base priority.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? BasePriority { get => this._basePriority; set => this._basePriority = value; }

        /// <summary>Backing field for <see cref="CurrentPriority" /> property.</summary>
        private int? _currentPriority;

        /// <summary>Current thread priority.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? CurrentPriority { get => this._currentPriority; set => this._currentPriority = value; }

        /// <summary>Backing field for <see cref="Href" /> property.</summary>
        private string _href;

        /// <summary>HRef URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Href { get => this._href; set => this._href = value; }

        /// <summary>Backing field for <see cref="Identifier" /> property.</summary>
        private int? _identifier;

        /// <summary>Site extension ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Identifier { get => this._identifier; }

        /// <summary>Internal Acessors for Identifier</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal.Identifier { get => this._identifier; set { {_identifier = value;} } }

        /// <summary>Backing field for <see cref="PriorityLevel" /> property.</summary>
        private string _priorityLevel;

        /// <summary>Thread priority level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PriorityLevel { get => this._priorityLevel; set => this._priorityLevel = value; }

        /// <summary>Backing field for <see cref="Process" /> property.</summary>
        private string _process;

        /// <summary>Process URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Process { get => this._process; set => this._process = value; }

        /// <summary>Backing field for <see cref="StartAddress" /> property.</summary>
        private string _startAddress;

        /// <summary>Start address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string StartAddress { get => this._startAddress; set => this._startAddress = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>Start time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private string _state;

        /// <summary>Thread state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string State { get => this._state; set => this._state = value; }

        /// <summary>Backing field for <see cref="TotalProcessorTime" /> property.</summary>
        private string _totalProcessorTime;

        /// <summary>Total processor time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TotalProcessorTime { get => this._totalProcessorTime; set => this._totalProcessorTime = value; }

        /// <summary>Backing field for <see cref="UserProcessorTime" /> property.</summary>
        private string _userProcessorTime;

        /// <summary>User processor time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string UserProcessorTime { get => this._userProcessorTime; set => this._userProcessorTime = value; }

        /// <summary>Backing field for <see cref="WaitReason" /> property.</summary>
        private string _waitReason;

        /// <summary>Wait reason.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string WaitReason { get => this._waitReason; set => this._waitReason = value; }

        /// <summary>Creates an new <see cref="ProcessThreadInfoProperties" /> instance.</summary>
        public ProcessThreadInfoProperties()
        {

        }
    }
    /// ProcessThreadInfo resource specific properties
    public partial interface IProcessThreadInfoProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Base priority.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Base priority.",
        SerializedName = @"base_priority",
        PossibleTypes = new [] { typeof(int) })]
        int? BasePriority { get; set; }
        /// <summary>Current thread priority.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Current thread priority.",
        SerializedName = @"current_priority",
        PossibleTypes = new [] { typeof(int) })]
        int? CurrentPriority { get; set; }
        /// <summary>HRef URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"HRef URI.",
        SerializedName = @"href",
        PossibleTypes = new [] { typeof(string) })]
        string Href { get; set; }
        /// <summary>Site extension ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Site extension ID.",
        SerializedName = @"identifier",
        PossibleTypes = new [] { typeof(int) })]
        int? Identifier { get;  }
        /// <summary>Thread priority level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Thread priority level.",
        SerializedName = @"priority_level",
        PossibleTypes = new [] { typeof(string) })]
        string PriorityLevel { get; set; }
        /// <summary>Process URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Process URI.",
        SerializedName = @"process",
        PossibleTypes = new [] { typeof(string) })]
        string Process { get; set; }
        /// <summary>Start address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start address.",
        SerializedName = @"start_address",
        PossibleTypes = new [] { typeof(string) })]
        string StartAddress { get; set; }
        /// <summary>Start time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start time.",
        SerializedName = @"start_time",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }
        /// <summary>Thread state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Thread state.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string State { get; set; }
        /// <summary>Total processor time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Total processor time.",
        SerializedName = @"total_processor_time",
        PossibleTypes = new [] { typeof(string) })]
        string TotalProcessorTime { get; set; }
        /// <summary>User processor time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"User processor time.",
        SerializedName = @"user_processor_time",
        PossibleTypes = new [] { typeof(string) })]
        string UserProcessorTime { get; set; }
        /// <summary>Wait reason.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Wait reason.",
        SerializedName = @"wait_reason",
        PossibleTypes = new [] { typeof(string) })]
        string WaitReason { get; set; }

    }
    /// ProcessThreadInfo resource specific properties
    internal partial interface IProcessThreadInfoPropertiesInternal

    {
        /// <summary>Base priority.</summary>
        int? BasePriority { get; set; }
        /// <summary>Current thread priority.</summary>
        int? CurrentPriority { get; set; }
        /// <summary>HRef URI.</summary>
        string Href { get; set; }
        /// <summary>Site extension ID.</summary>
        int? Identifier { get; set; }
        /// <summary>Thread priority level.</summary>
        string PriorityLevel { get; set; }
        /// <summary>Process URI.</summary>
        string Process { get; set; }
        /// <summary>Start address.</summary>
        string StartAddress { get; set; }
        /// <summary>Start time.</summary>
        global::System.DateTime? StartTime { get; set; }
        /// <summary>Thread state.</summary>
        string State { get; set; }
        /// <summary>Total processor time.</summary>
        string TotalProcessorTime { get; set; }
        /// <summary>User processor time.</summary>
        string UserProcessorTime { get; set; }
        /// <summary>Wait reason.</summary>
        string WaitReason { get; set; }

    }
}
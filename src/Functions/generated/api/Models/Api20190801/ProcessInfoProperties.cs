namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>ProcessInfo resource specific properties</summary>
    public partial class ProcessInfoProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Child" /> property.</summary>
        private string[] _child;

        /// <summary>Child process list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] Child { get => this._child; set => this._child = value; }

        /// <summary>Backing field for <see cref="CommandLine" /> property.</summary>
        private string _commandLine;

        /// <summary>Command line.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string CommandLine { get => this._commandLine; set => this._commandLine = value; }

        /// <summary>Backing field for <see cref="DeploymentName" /> property.</summary>
        private string _deploymentName;

        /// <summary>Deployment name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DeploymentName { get => this._deploymentName; set => this._deploymentName = value; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of process.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="EnvironmentVariable" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesEnvironmentVariables _environmentVariable;

        /// <summary>List of environment variables.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesEnvironmentVariables EnvironmentVariable { get => (this._environmentVariable = this._environmentVariable ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessInfoPropertiesEnvironmentVariables()); set => this._environmentVariable = value; }

        /// <summary>Backing field for <see cref="FileName" /> property.</summary>
        private string _fileName;

        /// <summary>File name of this process.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string FileName { get => this._fileName; set => this._fileName = value; }

        /// <summary>Backing field for <see cref="HandleCount" /> property.</summary>
        private int? _handleCount;

        /// <summary>Handle count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? HandleCount { get => this._handleCount; set => this._handleCount = value; }

        /// <summary>Backing field for <see cref="Href" /> property.</summary>
        private string _href;

        /// <summary>HRef URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Href { get => this._href; set => this._href = value; }

        /// <summary>Backing field for <see cref="Identifier" /> property.</summary>
        private int? _identifier;

        /// <summary>ARM Identifier for deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Identifier { get => this._identifier; }

        /// <summary>Backing field for <see cref="IisProfileTimeoutInSecond" /> property.</summary>
        private double? _iisProfileTimeoutInSecond;

        /// <summary>IIS Profile timeout (seconds).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public double? IisProfileTimeoutInSecond { get => this._iisProfileTimeoutInSecond; set => this._iisProfileTimeoutInSecond = value; }

        /// <summary>Backing field for <see cref="IsIisProfileRunning" /> property.</summary>
        private bool? _isIisProfileRunning;

        /// <summary>Is the IIS Profile running?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsIisProfileRunning { get => this._isIisProfileRunning; set => this._isIisProfileRunning = value; }

        /// <summary>Backing field for <see cref="IsProfileRunning" /> property.</summary>
        private bool? _isProfileRunning;

        /// <summary>Is profile running?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsProfileRunning { get => this._isProfileRunning; set => this._isProfileRunning = value; }

        /// <summary>Backing field for <see cref="IsScmSite" /> property.</summary>
        private bool? _isScmSite;

        /// <summary>Is this the SCM site?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsScmSite { get => this._isScmSite; set => this._isScmSite = value; }

        /// <summary>Backing field for <see cref="IsWebjob" /> property.</summary>
        private bool? _isWebjob;

        /// <summary>Is this a Web Job?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsWebjob { get => this._isWebjob; set => this._isWebjob = value; }

        /// <summary>Internal Acessors for Identifier</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal.Identifier { get => this._identifier; set { {_identifier = value;} } }

        /// <summary>Backing field for <see cref="Minidump" /> property.</summary>
        private string _minidump;

        /// <summary>Minidump URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Minidump { get => this._minidump; set => this._minidump = value; }

        /// <summary>Backing field for <see cref="Module" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfo[] _module;

        /// <summary>List of modules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfo[] Module { get => this._module; set => this._module = value; }

        /// <summary>Backing field for <see cref="ModuleCount" /> property.</summary>
        private int? _moduleCount;

        /// <summary>Module count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? ModuleCount { get => this._moduleCount; set => this._moduleCount = value; }

        /// <summary>Backing field for <see cref="NonPagedSystemMemory" /> property.</summary>
        private long? _nonPagedSystemMemory;

        /// <summary>Non-paged system memory.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? NonPagedSystemMemory { get => this._nonPagedSystemMemory; set => this._nonPagedSystemMemory = value; }

        /// <summary>Backing field for <see cref="OpenFileHandle" /> property.</summary>
        private string[] _openFileHandle;

        /// <summary>List of open files.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] OpenFileHandle { get => this._openFileHandle; set => this._openFileHandle = value; }

        /// <summary>Backing field for <see cref="PagedMemory" /> property.</summary>
        private long? _pagedMemory;

        /// <summary>Paged memory.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? PagedMemory { get => this._pagedMemory; set => this._pagedMemory = value; }

        /// <summary>Backing field for <see cref="PagedSystemMemory" /> property.</summary>
        private long? _pagedSystemMemory;

        /// <summary>Paged system memory.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? PagedSystemMemory { get => this._pagedSystemMemory; set => this._pagedSystemMemory = value; }

        /// <summary>Backing field for <see cref="Parent" /> property.</summary>
        private string _parent;

        /// <summary>Parent process.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Parent { get => this._parent; set => this._parent = value; }

        /// <summary>Backing field for <see cref="PeakPagedMemory" /> property.</summary>
        private long? _peakPagedMemory;

        /// <summary>Peak paged memory.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? PeakPagedMemory { get => this._peakPagedMemory; set => this._peakPagedMemory = value; }

        /// <summary>Backing field for <see cref="PeakVirtualMemory" /> property.</summary>
        private long? _peakVirtualMemory;

        /// <summary>Peak virtual memory usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? PeakVirtualMemory { get => this._peakVirtualMemory; set => this._peakVirtualMemory = value; }

        /// <summary>Backing field for <see cref="PeakWorkingSet" /> property.</summary>
        private long? _peakWorkingSet;

        /// <summary>Peak working set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? PeakWorkingSet { get => this._peakWorkingSet; set => this._peakWorkingSet = value; }

        /// <summary>Backing field for <see cref="PrivateMemory" /> property.</summary>
        private long? _privateMemory;

        /// <summary>Private memory size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? PrivateMemory { get => this._privateMemory; set => this._privateMemory = value; }

        /// <summary>Backing field for <see cref="PrivilegedCpuTime" /> property.</summary>
        private string _privilegedCpuTime;

        /// <summary>Privileged CPU time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PrivilegedCpuTime { get => this._privilegedCpuTime; set => this._privilegedCpuTime = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>Start time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Backing field for <see cref="Thread" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfo[] _thread;

        /// <summary>Thread list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfo[] Thread { get => this._thread; set => this._thread = value; }

        /// <summary>Backing field for <see cref="ThreadCount" /> property.</summary>
        private int? _threadCount;

        /// <summary>Thread count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? ThreadCount { get => this._threadCount; set => this._threadCount = value; }

        /// <summary>Backing field for <see cref="TimeStamp" /> property.</summary>
        private global::System.DateTime? _timeStamp;

        /// <summary>Time stamp.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? TimeStamp { get => this._timeStamp; set => this._timeStamp = value; }

        /// <summary>Backing field for <see cref="TotalCpuTime" /> property.</summary>
        private string _totalCpuTime;

        /// <summary>Total CPU time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TotalCpuTime { get => this._totalCpuTime; set => this._totalCpuTime = value; }

        /// <summary>Backing field for <see cref="UserCpuTime" /> property.</summary>
        private string _userCpuTime;

        /// <summary>User CPU time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string UserCpuTime { get => this._userCpuTime; set => this._userCpuTime = value; }

        /// <summary>Backing field for <see cref="UserName" /> property.</summary>
        private string _userName;

        /// <summary>User name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string UserName { get => this._userName; set => this._userName = value; }

        /// <summary>Backing field for <see cref="VirtualMemory" /> property.</summary>
        private long? _virtualMemory;

        /// <summary>Virtual memory size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? VirtualMemory { get => this._virtualMemory; set => this._virtualMemory = value; }

        /// <summary>Backing field for <see cref="WorkingSet" /> property.</summary>
        private long? _workingSet;

        /// <summary>Working set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? WorkingSet { get => this._workingSet; set => this._workingSet = value; }

        /// <summary>Creates an new <see cref="ProcessInfoProperties" /> instance.</summary>
        public ProcessInfoProperties()
        {

        }
    }
    /// ProcessInfo resource specific properties
    public partial interface IProcessInfoProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Child process list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Child process list.",
        SerializedName = @"children",
        PossibleTypes = new [] { typeof(string) })]
        string[] Child { get; set; }
        /// <summary>Command line.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Command line.",
        SerializedName = @"command_line",
        PossibleTypes = new [] { typeof(string) })]
        string CommandLine { get; set; }
        /// <summary>Deployment name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Deployment name.",
        SerializedName = @"deployment_name",
        PossibleTypes = new [] { typeof(string) })]
        string DeploymentName { get; set; }
        /// <summary>Description of process.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of process.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>List of environment variables.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of environment variables.",
        SerializedName = @"environment_variables",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesEnvironmentVariables) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesEnvironmentVariables EnvironmentVariable { get; set; }
        /// <summary>File name of this process.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"File name of this process.",
        SerializedName = @"file_name",
        PossibleTypes = new [] { typeof(string) })]
        string FileName { get; set; }
        /// <summary>Handle count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Handle count.",
        SerializedName = @"handle_count",
        PossibleTypes = new [] { typeof(int) })]
        int? HandleCount { get; set; }
        /// <summary>HRef URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"HRef URI.",
        SerializedName = @"href",
        PossibleTypes = new [] { typeof(string) })]
        string Href { get; set; }
        /// <summary>ARM Identifier for deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ARM Identifier for deployment.",
        SerializedName = @"identifier",
        PossibleTypes = new [] { typeof(int) })]
        int? Identifier { get;  }
        /// <summary>IIS Profile timeout (seconds).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IIS Profile timeout (seconds).",
        SerializedName = @"iis_profile_timeout_in_seconds",
        PossibleTypes = new [] { typeof(double) })]
        double? IisProfileTimeoutInSecond { get; set; }
        /// <summary>Is the IIS Profile running?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Is the IIS Profile running?",
        SerializedName = @"is_iis_profile_running",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsIisProfileRunning { get; set; }
        /// <summary>Is profile running?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Is profile running?",
        SerializedName = @"is_profile_running",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsProfileRunning { get; set; }
        /// <summary>Is this the SCM site?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Is this the SCM site?",
        SerializedName = @"is_scm_site",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsScmSite { get; set; }
        /// <summary>Is this a Web Job?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Is this a Web Job?",
        SerializedName = @"is_webjob",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsWebjob { get; set; }
        /// <summary>Minidump URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minidump URI.",
        SerializedName = @"minidump",
        PossibleTypes = new [] { typeof(string) })]
        string Minidump { get; set; }
        /// <summary>List of modules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of modules.",
        SerializedName = @"modules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfo[] Module { get; set; }
        /// <summary>Module count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Module count.",
        SerializedName = @"module_count",
        PossibleTypes = new [] { typeof(int) })]
        int? ModuleCount { get; set; }
        /// <summary>Non-paged system memory.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Non-paged system memory.",
        SerializedName = @"non_paged_system_memory",
        PossibleTypes = new [] { typeof(long) })]
        long? NonPagedSystemMemory { get; set; }
        /// <summary>List of open files.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of open files.",
        SerializedName = @"open_file_handles",
        PossibleTypes = new [] { typeof(string) })]
        string[] OpenFileHandle { get; set; }
        /// <summary>Paged memory.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Paged memory.",
        SerializedName = @"paged_memory",
        PossibleTypes = new [] { typeof(long) })]
        long? PagedMemory { get; set; }
        /// <summary>Paged system memory.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Paged system memory.",
        SerializedName = @"paged_system_memory",
        PossibleTypes = new [] { typeof(long) })]
        long? PagedSystemMemory { get; set; }
        /// <summary>Parent process.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Parent process.",
        SerializedName = @"parent",
        PossibleTypes = new [] { typeof(string) })]
        string Parent { get; set; }
        /// <summary>Peak paged memory.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Peak paged memory.",
        SerializedName = @"peak_paged_memory",
        PossibleTypes = new [] { typeof(long) })]
        long? PeakPagedMemory { get; set; }
        /// <summary>Peak virtual memory usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Peak virtual memory usage.",
        SerializedName = @"peak_virtual_memory",
        PossibleTypes = new [] { typeof(long) })]
        long? PeakVirtualMemory { get; set; }
        /// <summary>Peak working set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Peak working set.",
        SerializedName = @"peak_working_set",
        PossibleTypes = new [] { typeof(long) })]
        long? PeakWorkingSet { get; set; }
        /// <summary>Private memory size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Private memory size.",
        SerializedName = @"private_memory",
        PossibleTypes = new [] { typeof(long) })]
        long? PrivateMemory { get; set; }
        /// <summary>Privileged CPU time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Privileged CPU time.",
        SerializedName = @"privileged_cpu_time",
        PossibleTypes = new [] { typeof(string) })]
        string PrivilegedCpuTime { get; set; }
        /// <summary>Start time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start time.",
        SerializedName = @"start_time",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }
        /// <summary>Thread list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Thread list.",
        SerializedName = @"threads",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfo[] Thread { get; set; }
        /// <summary>Thread count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Thread count.",
        SerializedName = @"thread_count",
        PossibleTypes = new [] { typeof(int) })]
        int? ThreadCount { get; set; }
        /// <summary>Time stamp.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Time stamp.",
        SerializedName = @"time_stamp",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? TimeStamp { get; set; }
        /// <summary>Total CPU time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Total CPU time.",
        SerializedName = @"total_cpu_time",
        PossibleTypes = new [] { typeof(string) })]
        string TotalCpuTime { get; set; }
        /// <summary>User CPU time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"User CPU time.",
        SerializedName = @"user_cpu_time",
        PossibleTypes = new [] { typeof(string) })]
        string UserCpuTime { get; set; }
        /// <summary>User name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"User name.",
        SerializedName = @"user_name",
        PossibleTypes = new [] { typeof(string) })]
        string UserName { get; set; }
        /// <summary>Virtual memory size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Virtual memory size.",
        SerializedName = @"virtual_memory",
        PossibleTypes = new [] { typeof(long) })]
        long? VirtualMemory { get; set; }
        /// <summary>Working set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Working set.",
        SerializedName = @"working_set",
        PossibleTypes = new [] { typeof(long) })]
        long? WorkingSet { get; set; }

    }
    /// ProcessInfo resource specific properties
    internal partial interface IProcessInfoPropertiesInternal

    {
        /// <summary>Child process list.</summary>
        string[] Child { get; set; }
        /// <summary>Command line.</summary>
        string CommandLine { get; set; }
        /// <summary>Deployment name.</summary>
        string DeploymentName { get; set; }
        /// <summary>Description of process.</summary>
        string Description { get; set; }
        /// <summary>List of environment variables.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesEnvironmentVariables EnvironmentVariable { get; set; }
        /// <summary>File name of this process.</summary>
        string FileName { get; set; }
        /// <summary>Handle count.</summary>
        int? HandleCount { get; set; }
        /// <summary>HRef URI.</summary>
        string Href { get; set; }
        /// <summary>ARM Identifier for deployment.</summary>
        int? Identifier { get; set; }
        /// <summary>IIS Profile timeout (seconds).</summary>
        double? IisProfileTimeoutInSecond { get; set; }
        /// <summary>Is the IIS Profile running?</summary>
        bool? IsIisProfileRunning { get; set; }
        /// <summary>Is profile running?</summary>
        bool? IsProfileRunning { get; set; }
        /// <summary>Is this the SCM site?</summary>
        bool? IsScmSite { get; set; }
        /// <summary>Is this a Web Job?</summary>
        bool? IsWebjob { get; set; }
        /// <summary>Minidump URI.</summary>
        string Minidump { get; set; }
        /// <summary>List of modules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfo[] Module { get; set; }
        /// <summary>Module count.</summary>
        int? ModuleCount { get; set; }
        /// <summary>Non-paged system memory.</summary>
        long? NonPagedSystemMemory { get; set; }
        /// <summary>List of open files.</summary>
        string[] OpenFileHandle { get; set; }
        /// <summary>Paged memory.</summary>
        long? PagedMemory { get; set; }
        /// <summary>Paged system memory.</summary>
        long? PagedSystemMemory { get; set; }
        /// <summary>Parent process.</summary>
        string Parent { get; set; }
        /// <summary>Peak paged memory.</summary>
        long? PeakPagedMemory { get; set; }
        /// <summary>Peak virtual memory usage.</summary>
        long? PeakVirtualMemory { get; set; }
        /// <summary>Peak working set.</summary>
        long? PeakWorkingSet { get; set; }
        /// <summary>Private memory size.</summary>
        long? PrivateMemory { get; set; }
        /// <summary>Privileged CPU time.</summary>
        string PrivilegedCpuTime { get; set; }
        /// <summary>Start time.</summary>
        global::System.DateTime? StartTime { get; set; }
        /// <summary>Thread list.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfo[] Thread { get; set; }
        /// <summary>Thread count.</summary>
        int? ThreadCount { get; set; }
        /// <summary>Time stamp.</summary>
        global::System.DateTime? TimeStamp { get; set; }
        /// <summary>Total CPU time.</summary>
        string TotalCpuTime { get; set; }
        /// <summary>User CPU time.</summary>
        string UserCpuTime { get; set; }
        /// <summary>User name.</summary>
        string UserName { get; set; }
        /// <summary>Virtual memory size.</summary>
        long? VirtualMemory { get; set; }
        /// <summary>Working set.</summary>
        long? WorkingSet { get; set; }

    }
}
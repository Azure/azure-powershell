namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Process Information.</summary>
    public partial class ProcessInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfo,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Child process list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] Child { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).Child; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).Child = value; }

        /// <summary>Command line.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CommandLine { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).CommandLine; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).CommandLine = value; }

        /// <summary>Deployment name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DeploymentName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).DeploymentName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).DeploymentName = value; }

        /// <summary>Description of process.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).Description = value; }

        /// <summary>List of environment variables.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesEnvironmentVariables EnvironmentVariable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).EnvironmentVariable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).EnvironmentVariable = value; }

        /// <summary>File name of this process.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string FileName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).FileName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).FileName = value; }

        /// <summary>Handle count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? HandleCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).HandleCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).HandleCount = value; }

        /// <summary>HRef URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Href { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).Href; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).Href = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>ARM Identifier for deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? Identifier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).Identifier; }

        /// <summary>IIS Profile timeout (seconds).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public double? IisProfileTimeoutInSecond { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).IisProfileTimeoutInSecond; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).IisProfileTimeoutInSecond = value; }

        /// <summary>Is the IIS Profile running?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IsIisProfileRunning { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).IsIisProfileRunning; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).IsIisProfileRunning = value; }

        /// <summary>Is profile running?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IsProfileRunning { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).IsProfileRunning; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).IsProfileRunning = value; }

        /// <summary>Is this the SCM site?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IsScmSite { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).IsScmSite; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).IsScmSite = value; }

        /// <summary>Is this a Web Job?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IsWebjob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).IsWebjob; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).IsWebjob = value; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Internal Acessors for Identifier</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal.Identifier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).Identifier; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).Identifier = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessInfoProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Minidump URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Minidump { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).Minidump; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).Minidump = value; }

        /// <summary>List of modules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfo[] Module { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).Module; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).Module = value; }

        /// <summary>Module count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? ModuleCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).ModuleCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).ModuleCount = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Non-paged system memory.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? NonPagedSystemMemory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).NonPagedSystemMemory; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).NonPagedSystemMemory = value; }

        /// <summary>List of open files.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] OpenFileHandle { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).OpenFileHandle; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).OpenFileHandle = value; }

        /// <summary>Paged memory.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? PagedMemory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).PagedMemory; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).PagedMemory = value; }

        /// <summary>Paged system memory.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? PagedSystemMemory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).PagedSystemMemory; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).PagedSystemMemory = value; }

        /// <summary>Parent process.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Parent { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).Parent; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).Parent = value; }

        /// <summary>Peak paged memory.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? PeakPagedMemory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).PeakPagedMemory; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).PeakPagedMemory = value; }

        /// <summary>Peak virtual memory usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? PeakVirtualMemory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).PeakVirtualMemory; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).PeakVirtualMemory = value; }

        /// <summary>Peak working set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? PeakWorkingSet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).PeakWorkingSet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).PeakWorkingSet = value; }

        /// <summary>Private memory size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? PrivateMemory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).PrivateMemory; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).PrivateMemory = value; }

        /// <summary>Privileged CPU time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrivilegedCpuTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).PrivilegedCpuTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).PrivilegedCpuTime = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoProperties _property;

        /// <summary>ProcessInfo resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessInfoProperties()); set => this._property = value; }

        /// <summary>Start time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? StartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).StartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).StartTime = value; }

        /// <summary>Thread list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfo[] Thread { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).Thread; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).Thread = value; }

        /// <summary>Thread count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? ThreadCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).ThreadCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).ThreadCount = value; }

        /// <summary>Time stamp.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? TimeStamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).TimeStamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).TimeStamp = value; }

        /// <summary>Total CPU time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string TotalCpuTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).TotalCpuTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).TotalCpuTime = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>User CPU time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string UserCpuTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).UserCpuTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).UserCpuTime = value; }

        /// <summary>User name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string UserName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).UserName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).UserName = value; }

        /// <summary>Virtual memory size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? VirtualMemory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).VirtualMemory; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).VirtualMemory = value; }

        /// <summary>Working set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? WorkingSet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).WorkingSet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesInternal)Property).WorkingSet = value; }

        /// <summary>Creates an new <see cref="ProcessInfo" /> instance.</summary>
        public ProcessInfo()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// Process Information.
    public partial interface IProcessInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
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
    /// Process Information.
    internal partial interface IProcessInfoInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
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
        /// <summary>ProcessInfo resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoProperties Property { get; set; }
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
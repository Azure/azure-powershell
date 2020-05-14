namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    public partial class ContainerCpuStatistics :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatistics,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal
    {

        /// <summary>Backing field for <see cref="CpuUsage" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsage _cpuUsage;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsage CpuUsage { get => (this._cpuUsage = this._cpuUsage ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerCpuUsage()); set => this._cpuUsage = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? CpuUsageKernelModeUsage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsageInternal)CpuUsage).KernelModeUsage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsageInternal)CpuUsage).KernelModeUsage = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long[] CpuUsagePerCpuUsage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsageInternal)CpuUsage).PerCpuUsage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsageInternal)CpuUsage).PerCpuUsage = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? CpuUsageTotalUsage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsageInternal)CpuUsage).TotalUsage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsageInternal)CpuUsage).TotalUsage = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? CpuUsageUserModeUsage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsageInternal)CpuUsage).UserModeUsage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsageInternal)CpuUsage).UserModeUsage = value; }

        /// <summary>Internal Acessors for CpuUsage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsage Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal.CpuUsage { get => (this._cpuUsage = this._cpuUsage ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerCpuUsage()); set { {_cpuUsage = value;} } }

        /// <summary>Internal Acessors for ThrottlingData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerThrottlingData Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal.ThrottlingData { get => (this._throttlingData = this._throttlingData ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerThrottlingData()); set { {_throttlingData = value;} } }

        /// <summary>Backing field for <see cref="OnlineCpuCount" /> property.</summary>
        private int? _onlineCpuCount;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? OnlineCpuCount { get => this._onlineCpuCount; set => this._onlineCpuCount = value; }

        /// <summary>Backing field for <see cref="SystemCpuUsage" /> property.</summary>
        private long? _systemCpuUsage;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? SystemCpuUsage { get => this._systemCpuUsage; set => this._systemCpuUsage = value; }

        /// <summary>Backing field for <see cref="ThrottlingData" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerThrottlingData _throttlingData;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerThrottlingData ThrottlingData { get => (this._throttlingData = this._throttlingData ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerThrottlingData()); set => this._throttlingData = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? ThrottlingDataPeriod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerThrottlingDataInternal)ThrottlingData).Period; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerThrottlingDataInternal)ThrottlingData).Period = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? ThrottlingDataThrottledPeriod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerThrottlingDataInternal)ThrottlingData).ThrottledPeriod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerThrottlingDataInternal)ThrottlingData).ThrottledPeriod = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? ThrottlingDataThrottledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerThrottlingDataInternal)ThrottlingData).ThrottledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerThrottlingDataInternal)ThrottlingData).ThrottledTime = value; }

        /// <summary>Creates an new <see cref="ContainerCpuStatistics" /> instance.</summary>
        public ContainerCpuStatistics()
        {

        }
    }
    public partial interface IContainerCpuStatistics :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"kernelModeUsage",
        PossibleTypes = new [] { typeof(long) })]
        long? CpuUsageKernelModeUsage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"perCpuUsage",
        PossibleTypes = new [] { typeof(long) })]
        long[] CpuUsagePerCpuUsage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"totalUsage",
        PossibleTypes = new [] { typeof(long) })]
        long? CpuUsageTotalUsage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"userModeUsage",
        PossibleTypes = new [] { typeof(long) })]
        long? CpuUsageUserModeUsage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"onlineCpuCount",
        PossibleTypes = new [] { typeof(int) })]
        int? OnlineCpuCount { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"systemCpuUsage",
        PossibleTypes = new [] { typeof(long) })]
        long? SystemCpuUsage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"periods",
        PossibleTypes = new [] { typeof(int) })]
        int? ThrottlingDataPeriod { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"throttledPeriods",
        PossibleTypes = new [] { typeof(int) })]
        int? ThrottlingDataThrottledPeriod { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"throttledTime",
        PossibleTypes = new [] { typeof(int) })]
        int? ThrottlingDataThrottledTime { get; set; }

    }
    internal partial interface IContainerCpuStatisticsInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsage CpuUsage { get; set; }

        long? CpuUsageKernelModeUsage { get; set; }

        long[] CpuUsagePerCpuUsage { get; set; }

        long? CpuUsageTotalUsage { get; set; }

        long? CpuUsageUserModeUsage { get; set; }

        int? OnlineCpuCount { get; set; }

        long? SystemCpuUsage { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerThrottlingData ThrottlingData { get; set; }

        int? ThrottlingDataPeriod { get; set; }

        int? ThrottlingDataThrottledPeriod { get; set; }

        int? ThrottlingDataThrottledTime { get; set; }

    }
}
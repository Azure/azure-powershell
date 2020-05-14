namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    public partial class ContainerInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfo,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal
    {

        /// <summary>Backing field for <see cref="CurrentCpuStat" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatistics _currentCpuStat;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatistics CurrentCpuStat { get => (this._currentCpuStat = this._currentCpuStat ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerCpuStatistics()); set => this._currentCpuStat = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? CurrentCpuStatOnlineCpuCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)CurrentCpuStat).OnlineCpuCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)CurrentCpuStat).OnlineCpuCount = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? CurrentCpuStatSystemCpuUsage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)CurrentCpuStat).SystemCpuUsage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)CurrentCpuStat).SystemCpuUsage = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? CurrentCpuStatsCpuUsageKernelModeUsage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)CurrentCpuStat).CpuUsageKernelModeUsage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)CurrentCpuStat).CpuUsageKernelModeUsage = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long[] CurrentCpuStatsCpuUsagePerCpuUsage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)CurrentCpuStat).CpuUsagePerCpuUsage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)CurrentCpuStat).CpuUsagePerCpuUsage = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? CurrentCpuStatsCpuUsageTotalUsage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)CurrentCpuStat).CpuUsageTotalUsage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)CurrentCpuStat).CpuUsageTotalUsage = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? CurrentCpuStatsCpuUsageUserModeUsage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)CurrentCpuStat).CpuUsageUserModeUsage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)CurrentCpuStat).CpuUsageUserModeUsage = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? CurrentCpuStatsThrottlingDataPeriod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)CurrentCpuStat).ThrottlingDataPeriod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)CurrentCpuStat).ThrottlingDataPeriod = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? CurrentCpuStatsThrottlingDataThrottledPeriod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)CurrentCpuStat).ThrottlingDataThrottledPeriod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)CurrentCpuStat).ThrottlingDataThrottledPeriod = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? CurrentCpuStatsThrottlingDataThrottledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)CurrentCpuStat).ThrottlingDataThrottledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)CurrentCpuStat).ThrottlingDataThrottledTime = value; }

        /// <summary>Backing field for <see cref="CurrentTimeStamp" /> property.</summary>
        private global::System.DateTime? _currentTimeStamp;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? CurrentTimeStamp { get => this._currentTimeStamp; set => this._currentTimeStamp = value; }

        /// <summary>Backing field for <see cref="Eth0" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatistics _eth0;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatistics Eth0 { get => (this._eth0 = this._eth0 ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerNetworkInterfaceStatistics()); set => this._eth0 = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? Eth0RxByte { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)Eth0).RxByte; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)Eth0).RxByte = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? Eth0RxDropped { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)Eth0).RxDropped; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)Eth0).RxDropped = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? Eth0RxError { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)Eth0).RxError; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)Eth0).RxError = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? Eth0RxPacket { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)Eth0).RxPacket; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)Eth0).RxPacket = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? Eth0TxByte { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)Eth0).TxByte; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)Eth0).TxByte = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? Eth0TxDropped { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)Eth0).TxDropped; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)Eth0).TxDropped = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? Eth0TxError { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)Eth0).TxError; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)Eth0).TxError = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? Eth0TxPacket { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)Eth0).TxPacket; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)Eth0).TxPacket = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="MemoryStat" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerMemoryStatistics _memoryStat;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerMemoryStatistics MemoryStat { get => (this._memoryStat = this._memoryStat ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerMemoryStatistics()); set => this._memoryStat = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? MemoryStatLimit { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerMemoryStatisticsInternal)MemoryStat).Limit; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerMemoryStatisticsInternal)MemoryStat).Limit = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? MemoryStatMaxUsage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerMemoryStatisticsInternal)MemoryStat).MaxUsage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerMemoryStatisticsInternal)MemoryStat).MaxUsage = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? MemoryStatUsage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerMemoryStatisticsInternal)MemoryStat).Usage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerMemoryStatisticsInternal)MemoryStat).Usage = value; }

        /// <summary>Internal Acessors for CurrentCpuStat</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatistics Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal.CurrentCpuStat { get => (this._currentCpuStat = this._currentCpuStat ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerCpuStatistics()); set { {_currentCpuStat = value;} } }

        /// <summary>Internal Acessors for CurrentCpuStatCpuUsage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsage Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal.CurrentCpuStatCpuUsage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)CurrentCpuStat).CpuUsage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)CurrentCpuStat).CpuUsage = value; }

        /// <summary>Internal Acessors for CurrentCpuStatThrottlingData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerThrottlingData Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal.CurrentCpuStatThrottlingData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)CurrentCpuStat).ThrottlingData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)CurrentCpuStat).ThrottlingData = value; }

        /// <summary>Internal Acessors for Eth0</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatistics Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal.Eth0 { get => (this._eth0 = this._eth0 ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerNetworkInterfaceStatistics()); set { {_eth0 = value;} } }

        /// <summary>Internal Acessors for MemoryStat</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerMemoryStatistics Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal.MemoryStat { get => (this._memoryStat = this._memoryStat ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerMemoryStatistics()); set { {_memoryStat = value;} } }

        /// <summary>Internal Acessors for PreviouCpuStatCpuUsage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsage Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal.PreviouCpuStatCpuUsage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)PreviousCpuStat).CpuUsage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)PreviousCpuStat).CpuUsage = value; }

        /// <summary>Internal Acessors for PreviouCpuStatThrottlingData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerThrottlingData Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal.PreviouCpuStatThrottlingData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)PreviousCpuStat).ThrottlingData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)PreviousCpuStat).ThrottlingData = value; }

        /// <summary>Internal Acessors for PreviousCpuStat</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatistics Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal.PreviousCpuStat { get => (this._previousCpuStat = this._previousCpuStat ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerCpuStatistics()); set { {_previousCpuStat = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? PreviouCpuStatOnlineCpuCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)PreviousCpuStat).OnlineCpuCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)PreviousCpuStat).OnlineCpuCount = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? PreviouCpuStatSystemCpuUsage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)PreviousCpuStat).SystemCpuUsage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)PreviousCpuStat).SystemCpuUsage = value; }

        /// <summary>Backing field for <see cref="PreviousCpuStat" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatistics _previousCpuStat;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatistics PreviousCpuStat { get => (this._previousCpuStat = this._previousCpuStat ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerCpuStatistics()); set => this._previousCpuStat = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? PreviousCpuStatsCpuUsageKernelModeUsage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)PreviousCpuStat).CpuUsageKernelModeUsage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)PreviousCpuStat).CpuUsageKernelModeUsage = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long[] PreviousCpuStatsCpuUsagePerCpuUsage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)PreviousCpuStat).CpuUsagePerCpuUsage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)PreviousCpuStat).CpuUsagePerCpuUsage = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? PreviousCpuStatsCpuUsageTotalUsage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)PreviousCpuStat).CpuUsageTotalUsage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)PreviousCpuStat).CpuUsageTotalUsage = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? PreviousCpuStatsCpuUsageUserModeUsage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)PreviousCpuStat).CpuUsageUserModeUsage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)PreviousCpuStat).CpuUsageUserModeUsage = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? PreviousCpuStatsThrottlingDataPeriod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)PreviousCpuStat).ThrottlingDataPeriod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)PreviousCpuStat).ThrottlingDataPeriod = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? PreviousCpuStatsThrottlingDataThrottledPeriod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)PreviousCpuStat).ThrottlingDataThrottledPeriod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)PreviousCpuStat).ThrottlingDataThrottledPeriod = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? PreviousCpuStatsThrottlingDataThrottledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)PreviousCpuStat).ThrottlingDataThrottledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)PreviousCpuStat).ThrottlingDataThrottledTime = value; }

        /// <summary>Backing field for <see cref="PreviousTimeStamp" /> property.</summary>
        private global::System.DateTime? _previousTimeStamp;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? PreviousTimeStamp { get => this._previousTimeStamp; set => this._previousTimeStamp = value; }

        /// <summary>Creates an new <see cref="ContainerInfo" /> instance.</summary>
        public ContainerInfo()
        {

        }
    }
    public partial interface IContainerInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"onlineCpuCount",
        PossibleTypes = new [] { typeof(int) })]
        int? CurrentCpuStatOnlineCpuCount { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"systemCpuUsage",
        PossibleTypes = new [] { typeof(long) })]
        long? CurrentCpuStatSystemCpuUsage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"kernelModeUsage",
        PossibleTypes = new [] { typeof(long) })]
        long? CurrentCpuStatsCpuUsageKernelModeUsage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"perCpuUsage",
        PossibleTypes = new [] { typeof(long) })]
        long[] CurrentCpuStatsCpuUsagePerCpuUsage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"totalUsage",
        PossibleTypes = new [] { typeof(long) })]
        long? CurrentCpuStatsCpuUsageTotalUsage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"userModeUsage",
        PossibleTypes = new [] { typeof(long) })]
        long? CurrentCpuStatsCpuUsageUserModeUsage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"periods",
        PossibleTypes = new [] { typeof(int) })]
        int? CurrentCpuStatsThrottlingDataPeriod { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"throttledPeriods",
        PossibleTypes = new [] { typeof(int) })]
        int? CurrentCpuStatsThrottlingDataThrottledPeriod { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"throttledTime",
        PossibleTypes = new [] { typeof(int) })]
        int? CurrentCpuStatsThrottlingDataThrottledTime { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"currentTimeStamp",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CurrentTimeStamp { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"rxBytes",
        PossibleTypes = new [] { typeof(long) })]
        long? Eth0RxByte { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"rxDropped",
        PossibleTypes = new [] { typeof(long) })]
        long? Eth0RxDropped { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"rxErrors",
        PossibleTypes = new [] { typeof(long) })]
        long? Eth0RxError { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"rxPackets",
        PossibleTypes = new [] { typeof(long) })]
        long? Eth0RxPacket { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"txBytes",
        PossibleTypes = new [] { typeof(long) })]
        long? Eth0TxByte { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"txDropped",
        PossibleTypes = new [] { typeof(long) })]
        long? Eth0TxDropped { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"txErrors",
        PossibleTypes = new [] { typeof(long) })]
        long? Eth0TxError { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"txPackets",
        PossibleTypes = new [] { typeof(long) })]
        long? Eth0TxPacket { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"limit",
        PossibleTypes = new [] { typeof(long) })]
        long? MemoryStatLimit { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"maxUsage",
        PossibleTypes = new [] { typeof(long) })]
        long? MemoryStatMaxUsage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"usage",
        PossibleTypes = new [] { typeof(long) })]
        long? MemoryStatUsage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"onlineCpuCount",
        PossibleTypes = new [] { typeof(int) })]
        int? PreviouCpuStatOnlineCpuCount { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"systemCpuUsage",
        PossibleTypes = new [] { typeof(long) })]
        long? PreviouCpuStatSystemCpuUsage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"kernelModeUsage",
        PossibleTypes = new [] { typeof(long) })]
        long? PreviousCpuStatsCpuUsageKernelModeUsage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"perCpuUsage",
        PossibleTypes = new [] { typeof(long) })]
        long[] PreviousCpuStatsCpuUsagePerCpuUsage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"totalUsage",
        PossibleTypes = new [] { typeof(long) })]
        long? PreviousCpuStatsCpuUsageTotalUsage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"userModeUsage",
        PossibleTypes = new [] { typeof(long) })]
        long? PreviousCpuStatsCpuUsageUserModeUsage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"periods",
        PossibleTypes = new [] { typeof(int) })]
        int? PreviousCpuStatsThrottlingDataPeriod { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"throttledPeriods",
        PossibleTypes = new [] { typeof(int) })]
        int? PreviousCpuStatsThrottlingDataThrottledPeriod { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"throttledTime",
        PossibleTypes = new [] { typeof(int) })]
        int? PreviousCpuStatsThrottlingDataThrottledTime { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"previousTimeStamp",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? PreviousTimeStamp { get; set; }

    }
    internal partial interface IContainerInfoInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatistics CurrentCpuStat { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsage CurrentCpuStatCpuUsage { get; set; }

        int? CurrentCpuStatOnlineCpuCount { get; set; }

        long? CurrentCpuStatSystemCpuUsage { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerThrottlingData CurrentCpuStatThrottlingData { get; set; }

        long? CurrentCpuStatsCpuUsageKernelModeUsage { get; set; }

        long[] CurrentCpuStatsCpuUsagePerCpuUsage { get; set; }

        long? CurrentCpuStatsCpuUsageTotalUsage { get; set; }

        long? CurrentCpuStatsCpuUsageUserModeUsage { get; set; }

        int? CurrentCpuStatsThrottlingDataPeriod { get; set; }

        int? CurrentCpuStatsThrottlingDataThrottledPeriod { get; set; }

        int? CurrentCpuStatsThrottlingDataThrottledTime { get; set; }

        global::System.DateTime? CurrentTimeStamp { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatistics Eth0 { get; set; }

        long? Eth0RxByte { get; set; }

        long? Eth0RxDropped { get; set; }

        long? Eth0RxError { get; set; }

        long? Eth0RxPacket { get; set; }

        long? Eth0TxByte { get; set; }

        long? Eth0TxDropped { get; set; }

        long? Eth0TxError { get; set; }

        long? Eth0TxPacket { get; set; }

        string Id { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerMemoryStatistics MemoryStat { get; set; }

        long? MemoryStatLimit { get; set; }

        long? MemoryStatMaxUsage { get; set; }

        long? MemoryStatUsage { get; set; }

        string Name { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsage PreviouCpuStatCpuUsage { get; set; }

        int? PreviouCpuStatOnlineCpuCount { get; set; }

        long? PreviouCpuStatSystemCpuUsage { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerThrottlingData PreviouCpuStatThrottlingData { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatistics PreviousCpuStat { get; set; }

        long? PreviousCpuStatsCpuUsageKernelModeUsage { get; set; }

        long[] PreviousCpuStatsCpuUsagePerCpuUsage { get; set; }

        long? PreviousCpuStatsCpuUsageTotalUsage { get; set; }

        long? PreviousCpuStatsCpuUsageUserModeUsage { get; set; }

        int? PreviousCpuStatsThrottlingDataPeriod { get; set; }

        int? PreviousCpuStatsThrottlingDataThrottledPeriod { get; set; }

        int? PreviousCpuStatsThrottlingDataThrottledTime { get; set; }

        global::System.DateTime? PreviousTimeStamp { get; set; }

    }
}
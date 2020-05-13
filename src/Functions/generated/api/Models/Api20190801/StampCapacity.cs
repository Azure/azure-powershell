namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Stamp capacity information.</summary>
    public partial class StampCapacity :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal
    {

        /// <summary>Backing field for <see cref="AvailableCapacity" /> property.</summary>
        private long? _availableCapacity;

        /// <summary>Available capacity (# of machines, bytes of storage etc...).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? AvailableCapacity { get => this._availableCapacity; set => this._availableCapacity = value; }

        /// <summary>Backing field for <see cref="ComputeMode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions? _computeMode;

        /// <summary>Shared/dedicated workers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions? ComputeMode { get => this._computeMode; set => this._computeMode = value; }

        /// <summary>Backing field for <see cref="ExcludeFromCapacityAllocation" /> property.</summary>
        private bool? _excludeFromCapacityAllocation;

        /// <summary>
        /// If <code>true</code>, it includes basic apps.
        /// Basic apps are not used for capacity allocation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? ExcludeFromCapacityAllocation { get => this._excludeFromCapacityAllocation; set => this._excludeFromCapacityAllocation = value; }

        /// <summary>Backing field for <see cref="IsApplicableForAllComputeMode" /> property.</summary>
        private bool? _isApplicableForAllComputeMode;

        /// <summary>
        /// <code>true</code> if capacity is applicable for all apps; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsApplicableForAllComputeMode { get => this._isApplicableForAllComputeMode; set => this._isApplicableForAllComputeMode = value; }

        /// <summary>Backing field for <see cref="IsLinux" /> property.</summary>
        private bool? _isLinux;

        /// <summary>Is this a linux stamp capacity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsLinux { get => this._isLinux; set => this._isLinux = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the stamp.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="SiteMode" /> property.</summary>
        private string _siteMode;

        /// <summary>Shared or Dedicated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SiteMode { get => this._siteMode; set => this._siteMode = value; }

        /// <summary>Backing field for <see cref="TotalCapacity" /> property.</summary>
        private long? _totalCapacity;

        /// <summary>Total capacity (# of machines, bytes of storage etc...).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? TotalCapacity { get => this._totalCapacity; set => this._totalCapacity = value; }

        /// <summary>Backing field for <see cref="Unit" /> property.</summary>
        private string _unit;

        /// <summary>Name of the unit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Unit { get => this._unit; set => this._unit = value; }

        /// <summary>Backing field for <see cref="WorkerSize" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WorkerSizeOptions? _workerSize;

        /// <summary>Size of the machines.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WorkerSizeOptions? WorkerSize { get => this._workerSize; set => this._workerSize = value; }

        /// <summary>Backing field for <see cref="WorkerSizeId" /> property.</summary>
        private int? _workerSizeId;

        /// <summary>
        /// Size ID of machines:
        /// 0 - Small
        /// 1 - Medium
        /// 2 - Large
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? WorkerSizeId { get => this._workerSizeId; set => this._workerSizeId = value; }

        /// <summary>Creates an new <see cref="StampCapacity" /> instance.</summary>
        public StampCapacity()
        {

        }
    }
    /// Stamp capacity information.
    public partial interface IStampCapacity :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Available capacity (# of machines, bytes of storage etc...).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Available capacity (# of machines, bytes of storage etc...).",
        SerializedName = @"availableCapacity",
        PossibleTypes = new [] { typeof(long) })]
        long? AvailableCapacity { get; set; }
        /// <summary>Shared/dedicated workers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Shared/dedicated workers.",
        SerializedName = @"computeMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions? ComputeMode { get; set; }
        /// <summary>
        /// If <code>true</code>, it includes basic apps.
        /// Basic apps are not used for capacity allocation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If <code>true</code>, it includes basic apps.
        Basic apps are not used for capacity allocation.",
        SerializedName = @"excludeFromCapacityAllocation",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ExcludeFromCapacityAllocation { get; set; }
        /// <summary>
        /// <code>true</code> if capacity is applicable for all apps; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if capacity is applicable for all apps; otherwise, <code>false</code>.",
        SerializedName = @"isApplicableForAllComputeModes",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsApplicableForAllComputeMode { get; set; }
        /// <summary>Is this a linux stamp capacity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Is this a linux stamp capacity",
        SerializedName = @"isLinux",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsLinux { get; set; }
        /// <summary>Name of the stamp.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the stamp.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Shared or Dedicated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Shared or Dedicated.",
        SerializedName = @"siteMode",
        PossibleTypes = new [] { typeof(string) })]
        string SiteMode { get; set; }
        /// <summary>Total capacity (# of machines, bytes of storage etc...).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Total capacity (# of machines, bytes of storage etc...).",
        SerializedName = @"totalCapacity",
        PossibleTypes = new [] { typeof(long) })]
        long? TotalCapacity { get; set; }
        /// <summary>Name of the unit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the unit.",
        SerializedName = @"unit",
        PossibleTypes = new [] { typeof(string) })]
        string Unit { get; set; }
        /// <summary>Size of the machines.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Size of the machines.",
        SerializedName = @"workerSize",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WorkerSizeOptions) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WorkerSizeOptions? WorkerSize { get; set; }
        /// <summary>
        /// Size ID of machines:
        /// 0 - Small
        /// 1 - Medium
        /// 2 - Large
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Size ID of machines:
        0 - Small
        1 - Medium
        2 - Large",
        SerializedName = @"workerSizeId",
        PossibleTypes = new [] { typeof(int) })]
        int? WorkerSizeId { get; set; }

    }
    /// Stamp capacity information.
    internal partial interface IStampCapacityInternal

    {
        /// <summary>Available capacity (# of machines, bytes of storage etc...).</summary>
        long? AvailableCapacity { get; set; }
        /// <summary>Shared/dedicated workers.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions? ComputeMode { get; set; }
        /// <summary>
        /// If <code>true</code>, it includes basic apps.
        /// Basic apps are not used for capacity allocation.
        /// </summary>
        bool? ExcludeFromCapacityAllocation { get; set; }
        /// <summary>
        /// <code>true</code> if capacity is applicable for all apps; otherwise, <code>false</code>.
        /// </summary>
        bool? IsApplicableForAllComputeMode { get; set; }
        /// <summary>Is this a linux stamp capacity</summary>
        bool? IsLinux { get; set; }
        /// <summary>Name of the stamp.</summary>
        string Name { get; set; }
        /// <summary>Shared or Dedicated.</summary>
        string SiteMode { get; set; }
        /// <summary>Total capacity (# of machines, bytes of storage etc...).</summary>
        long? TotalCapacity { get; set; }
        /// <summary>Name of the unit.</summary>
        string Unit { get; set; }
        /// <summary>Size of the machines.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WorkerSizeOptions? WorkerSize { get; set; }
        /// <summary>
        /// Size ID of machines:
        /// 0 - Small
        /// 1 - Medium
        /// 2 - Large
        /// </summary>
        int? WorkerSizeId { get; set; }

    }
}
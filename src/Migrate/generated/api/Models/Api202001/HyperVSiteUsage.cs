namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Hyper-V site usage.</summary>
    public partial class HyperVSiteUsage :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteUsage,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteUsageInternal
    {

        /// <summary>Backing field for <see cref="ClusterCount" /> property.</summary>
        private int? _clusterCount;

        /// <summary>Number of clusters part of the site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? ClusterCount { get => this._clusterCount; set => this._clusterCount = value; }

        /// <summary>Backing field for <see cref="HostCount" /> property.</summary>
        private int? _hostCount;

        /// <summary>Number of hosts part of the site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? HostCount { get => this._hostCount; set => this._hostCount = value; }

        /// <summary>Backing field for <see cref="MachineCount" /> property.</summary>
        private int? _machineCount;

        /// <summary>Number of machines discovered in the site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? MachineCount { get => this._machineCount; set => this._machineCount = value; }

        /// <summary>Backing field for <see cref="RunAsAccountCount" /> property.</summary>
        private int? _runAsAccountCount;

        /// <summary>Number of run as accounts in the site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? RunAsAccountCount { get => this._runAsAccountCount; set => this._runAsAccountCount = value; }

        /// <summary>Creates an new <see cref="HyperVSiteUsage" /> instance.</summary>
        public HyperVSiteUsage()
        {

        }
    }
    /// Hyper-V site usage.
    public partial interface IHyperVSiteUsage :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Number of clusters part of the site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of clusters part of the site.",
        SerializedName = @"clusterCount",
        PossibleTypes = new [] { typeof(int) })]
        int? ClusterCount { get; set; }
        /// <summary>Number of hosts part of the site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of hosts part of the site.",
        SerializedName = @"hostCount",
        PossibleTypes = new [] { typeof(int) })]
        int? HostCount { get; set; }
        /// <summary>Number of machines discovered in the site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of machines discovered in the site.",
        SerializedName = @"machineCount",
        PossibleTypes = new [] { typeof(int) })]
        int? MachineCount { get; set; }
        /// <summary>Number of run as accounts in the site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of run as accounts in the site.",
        SerializedName = @"runAsAccountCount",
        PossibleTypes = new [] { typeof(int) })]
        int? RunAsAccountCount { get; set; }

    }
    /// Hyper-V site usage.
    internal partial interface IHyperVSiteUsageInternal

    {
        /// <summary>Number of clusters part of the site.</summary>
        int? ClusterCount { get; set; }
        /// <summary>Number of hosts part of the site.</summary>
        int? HostCount { get; set; }
        /// <summary>Number of machines discovered in the site.</summary>
        int? MachineCount { get; set; }
        /// <summary>Number of run as accounts in the site.</summary>
        int? RunAsAccountCount { get; set; }

    }
}
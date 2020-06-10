namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    public partial class ContainerCpuUsage :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsage,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsageInternal
    {

        /// <summary>Backing field for <see cref="KernelModeUsage" /> property.</summary>
        private long? _kernelModeUsage;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? KernelModeUsage { get => this._kernelModeUsage; set => this._kernelModeUsage = value; }

        /// <summary>Backing field for <see cref="PerCpuUsage" /> property.</summary>
        private long[] _perCpuUsage;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long[] PerCpuUsage { get => this._perCpuUsage; set => this._perCpuUsage = value; }

        /// <summary>Backing field for <see cref="TotalUsage" /> property.</summary>
        private long? _totalUsage;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? TotalUsage { get => this._totalUsage; set => this._totalUsage = value; }

        /// <summary>Backing field for <see cref="UserModeUsage" /> property.</summary>
        private long? _userModeUsage;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? UserModeUsage { get => this._userModeUsage; set => this._userModeUsage = value; }

        /// <summary>Creates an new <see cref="ContainerCpuUsage" /> instance.</summary>
        public ContainerCpuUsage()
        {

        }
    }
    public partial interface IContainerCpuUsage :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"kernelModeUsage",
        PossibleTypes = new [] { typeof(long) })]
        long? KernelModeUsage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"perCpuUsage",
        PossibleTypes = new [] { typeof(long) })]
        long[] PerCpuUsage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"totalUsage",
        PossibleTypes = new [] { typeof(long) })]
        long? TotalUsage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"userModeUsage",
        PossibleTypes = new [] { typeof(long) })]
        long? UserModeUsage { get; set; }

    }
    internal partial interface IContainerCpuUsageInternal

    {
        long? KernelModeUsage { get; set; }

        long[] PerCpuUsage { get; set; }

        long? TotalUsage { get; set; }

        long? UserModeUsage { get; set; }

    }
}
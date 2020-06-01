namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    public partial class ContainerMemoryStatistics :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerMemoryStatistics,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerMemoryStatisticsInternal
    {

        /// <summary>Backing field for <see cref="Limit" /> property.</summary>
        private long? _limit;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? Limit { get => this._limit; set => this._limit = value; }

        /// <summary>Backing field for <see cref="MaxUsage" /> property.</summary>
        private long? _maxUsage;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? MaxUsage { get => this._maxUsage; set => this._maxUsage = value; }

        /// <summary>Backing field for <see cref="Usage" /> property.</summary>
        private long? _usage;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? Usage { get => this._usage; set => this._usage = value; }

        /// <summary>Creates an new <see cref="ContainerMemoryStatistics" /> instance.</summary>
        public ContainerMemoryStatistics()
        {

        }
    }
    public partial interface IContainerMemoryStatistics :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"limit",
        PossibleTypes = new [] { typeof(long) })]
        long? Limit { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"maxUsage",
        PossibleTypes = new [] { typeof(long) })]
        long? MaxUsage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"usage",
        PossibleTypes = new [] { typeof(long) })]
        long? Usage { get; set; }

    }
    internal partial interface IContainerMemoryStatisticsInternal

    {
        long? Limit { get; set; }

        long? MaxUsage { get; set; }

        long? Usage { get; set; }

    }
}
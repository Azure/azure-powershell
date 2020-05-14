namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Metric limits set on an app.</summary>
    public partial class SiteLimits :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLimits,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLimitsInternal
    {

        /// <summary>Backing field for <see cref="MaxDiskSizeInMb" /> property.</summary>
        private long? _maxDiskSizeInMb;

        /// <summary>Maximum allowed disk size usage in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? MaxDiskSizeInMb { get => this._maxDiskSizeInMb; set => this._maxDiskSizeInMb = value; }

        /// <summary>Backing field for <see cref="MaxMemoryInMb" /> property.</summary>
        private long? _maxMemoryInMb;

        /// <summary>Maximum allowed memory usage in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? MaxMemoryInMb { get => this._maxMemoryInMb; set => this._maxMemoryInMb = value; }

        /// <summary>Backing field for <see cref="MaxPercentageCpu" /> property.</summary>
        private double? _maxPercentageCpu;

        /// <summary>Maximum allowed CPU usage percentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public double? MaxPercentageCpu { get => this._maxPercentageCpu; set => this._maxPercentageCpu = value; }

        /// <summary>Creates an new <see cref="SiteLimits" /> instance.</summary>
        public SiteLimits()
        {

        }
    }
    /// Metric limits set on an app.
    public partial interface ISiteLimits :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Maximum allowed disk size usage in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum allowed disk size usage in MB.",
        SerializedName = @"maxDiskSizeInMb",
        PossibleTypes = new [] { typeof(long) })]
        long? MaxDiskSizeInMb { get; set; }
        /// <summary>Maximum allowed memory usage in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum allowed memory usage in MB.",
        SerializedName = @"maxMemoryInMb",
        PossibleTypes = new [] { typeof(long) })]
        long? MaxMemoryInMb { get; set; }
        /// <summary>Maximum allowed CPU usage percentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum allowed CPU usage percentage.",
        SerializedName = @"maxPercentageCpu",
        PossibleTypes = new [] { typeof(double) })]
        double? MaxPercentageCpu { get; set; }

    }
    /// Metric limits set on an app.
    internal partial interface ISiteLimitsInternal

    {
        /// <summary>Maximum allowed disk size usage in MB.</summary>
        long? MaxDiskSizeInMb { get; set; }
        /// <summary>Maximum allowed memory usage in MB.</summary>
        long? MaxMemoryInMb { get; set; }
        /// <summary>Maximum allowed CPU usage percentage.</summary>
        double? MaxPercentageCpu { get; set; }

    }
}
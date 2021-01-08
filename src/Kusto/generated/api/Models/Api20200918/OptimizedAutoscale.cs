namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>A class that contains the optimized auto scale definition.</summary>
    public partial class OptimizedAutoscale :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IOptimizedAutoscale,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IOptimizedAutoscaleInternal
    {

        /// <summary>Backing field for <see cref="IsEnabled" /> property.</summary>
        private bool _isEnabled;

        /// <summary>
        /// A boolean value that indicate if the optimized autoscale feature is enabled or not.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public bool IsEnabled { get => this._isEnabled; set => this._isEnabled = value; }

        /// <summary>Backing field for <see cref="Maximum" /> property.</summary>
        private int _maximum;

        /// <summary>Maximum allowed instances count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public int Maximum { get => this._maximum; set => this._maximum = value; }

        /// <summary>Backing field for <see cref="Minimum" /> property.</summary>
        private int _minimum;

        /// <summary>Minimum allowed instances count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public int Minimum { get => this._minimum; set => this._minimum = value; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private int _version;

        /// <summary>The version of the template defined, for instance 1.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public int Version { get => this._version; set => this._version = value; }

        /// <summary>Creates an new <see cref="OptimizedAutoscale" /> instance.</summary>
        public OptimizedAutoscale()
        {

        }
    }
    /// A class that contains the optimized auto scale definition.
    public partial interface IOptimizedAutoscale :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>
        /// A boolean value that indicate if the optimized autoscale feature is enabled or not.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"A boolean value that indicate if the optimized autoscale feature is enabled or not.",
        SerializedName = @"isEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool IsEnabled { get; set; }
        /// <summary>Maximum allowed instances count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Maximum allowed instances count.",
        SerializedName = @"maximum",
        PossibleTypes = new [] { typeof(int) })]
        int Maximum { get; set; }
        /// <summary>Minimum allowed instances count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Minimum allowed instances count.",
        SerializedName = @"minimum",
        PossibleTypes = new [] { typeof(int) })]
        int Minimum { get; set; }
        /// <summary>The version of the template defined, for instance 1.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The version of the template defined, for instance 1.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(int) })]
        int Version { get; set; }

    }
    /// A class that contains the optimized auto scale definition.
    internal partial interface IOptimizedAutoscaleInternal

    {
        /// <summary>
        /// A boolean value that indicate if the optimized autoscale feature is enabled or not.
        /// </summary>
        bool IsEnabled { get; set; }
        /// <summary>Maximum allowed instances count.</summary>
        int Maximum { get; set; }
        /// <summary>Minimum allowed instances count.</summary>
        int Minimum { get; set; }
        /// <summary>The version of the template defined, for instance 1.</summary>
        int Version { get; set; }

    }
}
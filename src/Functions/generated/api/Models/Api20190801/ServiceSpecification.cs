namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Resource metrics service provided by Microsoft.Insights resource provider.</summary>
    public partial class ServiceSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IServiceSpecification,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IServiceSpecificationInternal
    {

        /// <summary>Backing field for <see cref="LogSpecification" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILogSpecification[] _logSpecification;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILogSpecification[] LogSpecification { get => this._logSpecification; set => this._logSpecification = value; }

        /// <summary>Backing field for <see cref="MetricSpecification" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricSpecification[] _metricSpecification;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricSpecification[] MetricSpecification { get => this._metricSpecification; set => this._metricSpecification = value; }

        /// <summary>Creates an new <see cref="ServiceSpecification" /> instance.</summary>
        public ServiceSpecification()
        {

        }
    }
    /// Resource metrics service provided by Microsoft.Insights resource provider.
    public partial interface IServiceSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"logSpecifications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILogSpecification) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILogSpecification[] LogSpecification { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"metricSpecifications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricSpecification) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricSpecification[] MetricSpecification { get; set; }

    }
    /// Resource metrics service provided by Microsoft.Insights resource provider.
    internal partial interface IServiceSpecificationInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILogSpecification[] LogSpecification { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricSpecification[] MetricSpecification { get; set; }

    }
}
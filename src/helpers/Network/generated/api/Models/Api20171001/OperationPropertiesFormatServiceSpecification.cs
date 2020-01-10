namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Specification of the service.</summary>
    public partial class OperationPropertiesFormatServiceSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOperationPropertiesFormatServiceSpecification,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOperationPropertiesFormatServiceSpecificationInternal
    {

        /// <summary>Backing field for <see cref="LogSpecification" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILogSpecification[] _logSpecification;

        /// <summary>Operation log specification.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILogSpecification[] LogSpecification { get => this._logSpecification; set => this._logSpecification = value; }

        /// <summary>Backing field for <see cref="MetricSpecification" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IMetricSpecification[] _metricSpecification;

        /// <summary>Operation service specification.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IMetricSpecification[] MetricSpecification { get => this._metricSpecification; set => this._metricSpecification = value; }

        /// <summary>
        /// Creates an new <see cref="OperationPropertiesFormatServiceSpecification" /> instance.
        /// </summary>
        public OperationPropertiesFormatServiceSpecification()
        {

        }
    }
    /// Specification of the service.
    public partial interface IOperationPropertiesFormatServiceSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Operation log specification.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Operation log specification.",
        SerializedName = @"logSpecifications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILogSpecification) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILogSpecification[] LogSpecification { get; set; }
        /// <summary>Operation service specification.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Operation service specification.",
        SerializedName = @"metricSpecifications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IMetricSpecification) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IMetricSpecification[] MetricSpecification { get; set; }

    }
    /// Specification of the service.
    internal partial interface IOperationPropertiesFormatServiceSpecificationInternal

    {
        /// <summary>Operation log specification.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILogSpecification[] LogSpecification { get; set; }
        /// <summary>Operation service specification.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IMetricSpecification[] MetricSpecification { get; set; }

    }
}
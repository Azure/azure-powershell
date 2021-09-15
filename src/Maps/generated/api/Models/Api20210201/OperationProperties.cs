namespace Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Extensions;

    /// <summary>Properties of operation, include metric specifications.</summary>
    public partial class OperationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationPropertiesInternal
    {

        /// <summary>Internal Acessors for ServiceSpecification</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IServiceSpecification Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationPropertiesInternal.ServiceSpecification { get => (this._serviceSpecification = this._serviceSpecification ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ServiceSpecification()); set { {_serviceSpecification = value;} } }

        /// <summary>Backing field for <see cref="ServiceSpecification" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IServiceSpecification _serviceSpecification;

        /// <summary>One property of operation, include metric specifications.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IServiceSpecification ServiceSpecification { get => (this._serviceSpecification = this._serviceSpecification ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ServiceSpecification()); set => this._serviceSpecification = value; }

        /// <summary>Metric specifications of operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMetricSpecification[] ServiceSpecificationMetricSpecification { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IServiceSpecificationInternal)ServiceSpecification).MetricSpecification; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IServiceSpecificationInternal)ServiceSpecification).MetricSpecification = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="OperationProperties" /> instance.</summary>
        public OperationProperties()
        {

        }
    }
    /// Properties of operation, include metric specifications.
    public partial interface IOperationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.IJsonSerializable
    {
        /// <summary>Metric specifications of operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Metric specifications of operation.",
        SerializedName = @"metricSpecifications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMetricSpecification) })]
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMetricSpecification[] ServiceSpecificationMetricSpecification { get; set; }

    }
    /// Properties of operation, include metric specifications.
    internal partial interface IOperationPropertiesInternal

    {
        /// <summary>One property of operation, include metric specifications.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IServiceSpecification ServiceSpecification { get; set; }
        /// <summary>Metric specifications of operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMetricSpecification[] ServiceSpecificationMetricSpecification { get; set; }

    }
}
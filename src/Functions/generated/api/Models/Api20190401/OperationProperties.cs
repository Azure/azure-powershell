namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Properties of operation, include metric specifications.</summary>
    public partial class OperationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IOperationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IOperationPropertiesInternal
    {

        /// <summary>Internal Acessors for ServiceSpecification</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSpecification Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IOperationPropertiesInternal.ServiceSpecification { get => (this._serviceSpecification = this._serviceSpecification ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ServiceSpecification()); set { {_serviceSpecification = value;} } }

        /// <summary>Backing field for <see cref="ServiceSpecification" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSpecification _serviceSpecification;

        /// <summary>One property of operation, include metric specifications.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSpecification ServiceSpecification { get => (this._serviceSpecification = this._serviceSpecification ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ServiceSpecification()); set => this._serviceSpecification = value; }

        /// <summary>Metric specifications of operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IMetricSpecification[] ServiceSpecificationMetricSpecification { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSpecificationInternal)ServiceSpecification).MetricSpecification; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSpecificationInternal)ServiceSpecification).MetricSpecification = value; }

        /// <summary>Creates an new <see cref="OperationProperties" /> instance.</summary>
        public OperationProperties()
        {

        }
    }
    /// Properties of operation, include metric specifications.
    public partial interface IOperationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Metric specifications of operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Metric specifications of operation.",
        SerializedName = @"metricSpecifications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IMetricSpecification) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IMetricSpecification[] ServiceSpecificationMetricSpecification { get; set; }

    }
    /// Properties of operation, include metric specifications.
    internal partial interface IOperationPropertiesInternal

    {
        /// <summary>One property of operation, include metric specifications.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSpecification ServiceSpecification { get; set; }
        /// <summary>Metric specifications of operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IMetricSpecification[] ServiceSpecificationMetricSpecification { get; set; }

    }
}
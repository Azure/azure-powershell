namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>Extra Operation properties</summary>
    public partial class OperationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationPropertiesInternal
    {

        /// <summary>Internal Acessors for ServiceSpecification</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IServiceSpecification Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationPropertiesInternal.ServiceSpecification { get => (this._serviceSpecification = this._serviceSpecification ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ServiceSpecification()); set { {_serviceSpecification = value;} } }

        /// <summary>Backing field for <see cref="ServiceSpecification" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IServiceSpecification _serviceSpecification;

        /// <summary>Service specifications of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IServiceSpecification ServiceSpecification { get => (this._serviceSpecification = this._serviceSpecification ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ServiceSpecification()); set => this._serviceSpecification = value; }

        /// <summary>Specifications of the Log for Azure Monitoring</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ILogSpecification[] ServiceSpecificationLogSpecification { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IServiceSpecificationInternal)ServiceSpecification).LogSpecification; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IServiceSpecificationInternal)ServiceSpecification).LogSpecification = value ?? null /* arrayOf */; }

        /// <summary>Specifications of the Metrics for Azure Monitoring</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IMetricSpecification[] ServiceSpecificationMetricSpecification { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IServiceSpecificationInternal)ServiceSpecification).MetricSpecification; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IServiceSpecificationInternal)ServiceSpecification).MetricSpecification = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="OperationProperties" /> instance.</summary>
        public OperationProperties()
        {

        }
    }
    /// Extra Operation properties
    public partial interface IOperationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IJsonSerializable
    {
        /// <summary>Specifications of the Log for Azure Monitoring</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifications of the Log for Azure Monitoring",
        SerializedName = @"logSpecifications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ILogSpecification) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ILogSpecification[] ServiceSpecificationLogSpecification { get; set; }
        /// <summary>Specifications of the Metrics for Azure Monitoring</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifications of the Metrics for Azure Monitoring",
        SerializedName = @"metricSpecifications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IMetricSpecification) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IMetricSpecification[] ServiceSpecificationMetricSpecification { get; set; }

    }
    /// Extra Operation properties
    internal partial interface IOperationPropertiesInternal

    {
        /// <summary>Service specifications of the operation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IServiceSpecification ServiceSpecification { get; set; }
        /// <summary>Specifications of the Log for Azure Monitoring</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ILogSpecification[] ServiceSpecificationLogSpecification { get; set; }
        /// <summary>Specifications of the Metrics for Azure Monitoring</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IMetricSpecification[] ServiceSpecificationMetricSpecification { get; set; }

    }
}
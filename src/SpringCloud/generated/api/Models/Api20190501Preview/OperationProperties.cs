namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Extra Operation properties</summary>
    public partial class OperationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IOperationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IOperationPropertiesInternal
    {

        /// <summary>Internal Acessors for ServiceSpecification</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceSpecification Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IOperationPropertiesInternal.ServiceSpecification { get => (this._serviceSpecification = this._serviceSpecification ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ServiceSpecification()); set { {_serviceSpecification = value;} } }

        /// <summary>Backing field for <see cref="ServiceSpecification" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceSpecification _serviceSpecification;

        /// <summary>Service specifications of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceSpecification ServiceSpecification { get => (this._serviceSpecification = this._serviceSpecification ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ServiceSpecification()); set => this._serviceSpecification = value; }

        /// <summary>Specifications of the Log for Azure Monitoring</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ILogSpecification[] ServiceSpecificationLogSpecification { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceSpecificationInternal)ServiceSpecification).LogSpecification; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceSpecificationInternal)ServiceSpecification).LogSpecification = value; }

        /// <summary>Specifications of the Metrics for Azure Monitoring</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IMetricSpecification[] ServiceSpecificationMetricSpecification { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceSpecificationInternal)ServiceSpecification).MetricSpecification; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceSpecificationInternal)ServiceSpecification).MetricSpecification = value; }

        /// <summary>Creates an new <see cref="OperationProperties" /> instance.</summary>
        public OperationProperties()
        {

        }
    }
    /// Extra Operation properties
    public partial interface IOperationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>Specifications of the Log for Azure Monitoring</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifications of the Log for Azure Monitoring",
        SerializedName = @"logSpecifications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ILogSpecification) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ILogSpecification[] ServiceSpecificationLogSpecification { get; set; }
        /// <summary>Specifications of the Metrics for Azure Monitoring</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifications of the Metrics for Azure Monitoring",
        SerializedName = @"metricSpecifications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IMetricSpecification) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IMetricSpecification[] ServiceSpecificationMetricSpecification { get; set; }

    }
    /// Extra Operation properties
    public partial interface IOperationPropertiesInternal

    {
        /// <summary>Service specifications of the operation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceSpecification ServiceSpecification { get; set; }
        /// <summary>Specifications of the Log for Azure Monitoring</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ILogSpecification[] ServiceSpecificationLogSpecification { get; set; }
        /// <summary>Specifications of the Metrics for Azure Monitoring</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IMetricSpecification[] ServiceSpecificationMetricSpecification { get; set; }

    }
}
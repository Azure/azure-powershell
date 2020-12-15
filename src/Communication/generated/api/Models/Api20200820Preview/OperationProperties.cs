namespace Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Extensions;

    /// <summary>Extra Operation properties.</summary>
    public partial class OperationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationPropertiesInternal
    {

        /// <summary>Internal Acessors for ServiceSpecification</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IServiceSpecification Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationPropertiesInternal.ServiceSpecification { get => (this._serviceSpecification = this._serviceSpecification ?? new Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ServiceSpecification()); set { {_serviceSpecification = value;} } }

        /// <summary>Backing field for <see cref="ServiceSpecification" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IServiceSpecification _serviceSpecification;

        /// <summary>The service specifications.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IServiceSpecification ServiceSpecification { get => (this._serviceSpecification = this._serviceSpecification ?? new Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ServiceSpecification()); set => this._serviceSpecification = value; }

        /// <summary>Specifications of the Metrics for Azure Monitoring.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IMetricSpecification[] ServiceSpecificationMetricSpecification { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IServiceSpecificationInternal)ServiceSpecification).MetricSpecification; set => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IServiceSpecificationInternal)ServiceSpecification).MetricSpecification = value; }

        /// <summary>Creates an new <see cref="OperationProperties" /> instance.</summary>
        public OperationProperties()
        {

        }
    }
    /// Extra Operation properties.
    public partial interface IOperationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.IJsonSerializable
    {
        /// <summary>Specifications of the Metrics for Azure Monitoring.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifications of the Metrics for Azure Monitoring.",
        SerializedName = @"metricSpecifications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IMetricSpecification) })]
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IMetricSpecification[] ServiceSpecificationMetricSpecification { get; set; }

    }
    /// Extra Operation properties.
    internal partial interface IOperationPropertiesInternal

    {
        /// <summary>The service specifications.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IServiceSpecification ServiceSpecification { get; set; }
        /// <summary>Specifications of the Metrics for Azure Monitoring.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IMetricSpecification[] ServiceSpecificationMetricSpecification { get; set; }

    }
}
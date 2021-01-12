namespace Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Extensions;

    /// <summary>An object that describes a specification.</summary>
    public partial class ServiceSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IServiceSpecification,
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IServiceSpecificationInternal
    {

        /// <summary>Backing field for <see cref="MetricSpecification" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IMetricSpecification[] _metricSpecification;

        /// <summary>Specifications of the Metrics for Azure Monitoring.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IMetricSpecification[] MetricSpecification { get => this._metricSpecification; set => this._metricSpecification = value; }

        /// <summary>Creates an new <see cref="ServiceSpecification" /> instance.</summary>
        public ServiceSpecification()
        {

        }
    }
    /// An object that describes a specification.
    public partial interface IServiceSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.IJsonSerializable
    {
        /// <summary>Specifications of the Metrics for Azure Monitoring.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifications of the Metrics for Azure Monitoring.",
        SerializedName = @"metricSpecifications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IMetricSpecification) })]
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IMetricSpecification[] MetricSpecification { get; set; }

    }
    /// An object that describes a specification.
    internal partial interface IServiceSpecificationInternal

    {
        /// <summary>Specifications of the Metrics for Azure Monitoring.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IMetricSpecification[] MetricSpecification { get; set; }

    }
}
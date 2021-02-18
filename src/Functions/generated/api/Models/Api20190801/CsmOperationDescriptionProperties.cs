namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Properties available for a Microsoft.Web resource provider operation.</summary>
    public partial class CsmOperationDescriptionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionPropertiesInternal
    {

        /// <summary>Internal Acessors for ServiceSpecification</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IServiceSpecification Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionPropertiesInternal.ServiceSpecification { get => (this._serviceSpecification = this._serviceSpecification ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ServiceSpecification()); set { {_serviceSpecification = value;} } }

        /// <summary>Backing field for <see cref="ServiceSpecification" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IServiceSpecification _serviceSpecification;

        /// <summary>Resource metrics service provided by Microsoft.Insights resource provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IServiceSpecification ServiceSpecification { get => (this._serviceSpecification = this._serviceSpecification ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ServiceSpecification()); set => this._serviceSpecification = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILogSpecification[] ServiceSpecificationLogSpecification { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IServiceSpecificationInternal)ServiceSpecification).LogSpecification; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IServiceSpecificationInternal)ServiceSpecification).LogSpecification = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricSpecification[] ServiceSpecificationMetricSpecification { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IServiceSpecificationInternal)ServiceSpecification).MetricSpecification; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IServiceSpecificationInternal)ServiceSpecification).MetricSpecification = value; }

        /// <summary>Creates an new <see cref="CsmOperationDescriptionProperties" /> instance.</summary>
        public CsmOperationDescriptionProperties()
        {

        }
    }
    /// Properties available for a Microsoft.Web resource provider operation.
    public partial interface ICsmOperationDescriptionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"logSpecifications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILogSpecification) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILogSpecification[] ServiceSpecificationLogSpecification { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"metricSpecifications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricSpecification) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricSpecification[] ServiceSpecificationMetricSpecification { get; set; }

    }
    /// Properties available for a Microsoft.Web resource provider operation.
    internal partial interface ICsmOperationDescriptionPropertiesInternal

    {
        /// <summary>Resource metrics service provided by Microsoft.Insights resource provider.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IServiceSpecification ServiceSpecification { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILogSpecification[] ServiceSpecificationLogSpecification { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricSpecification[] ServiceSpecificationMetricSpecification { get; set; }

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Description of operation properties format.</summary>
    public partial class OperationPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOperationPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOperationPropertiesFormatInternal
    {

        /// <summary>Internal Acessors for ServiceSpecification</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOperationPropertiesFormatServiceSpecification Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOperationPropertiesFormatInternal.ServiceSpecification { get => (this._serviceSpecification = this._serviceSpecification ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.OperationPropertiesFormatServiceSpecification()); set { {_serviceSpecification = value;} } }

        /// <summary>Backing field for <see cref="ServiceSpecification" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOperationPropertiesFormatServiceSpecification _serviceSpecification;

        /// <summary>Specification of the service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOperationPropertiesFormatServiceSpecification ServiceSpecification { get => (this._serviceSpecification = this._serviceSpecification ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.OperationPropertiesFormatServiceSpecification()); set => this._serviceSpecification = value; }

        /// <summary>Operation log specification.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILogSpecification[] ServiceSpecificationLogSpecification { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOperationPropertiesFormatServiceSpecificationInternal)ServiceSpecification).LogSpecification; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOperationPropertiesFormatServiceSpecificationInternal)ServiceSpecification).LogSpecification = value; }

        /// <summary>Operation service specification.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IMetricSpecification[] ServiceSpecificationMetricSpecification { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOperationPropertiesFormatServiceSpecificationInternal)ServiceSpecification).MetricSpecification; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOperationPropertiesFormatServiceSpecificationInternal)ServiceSpecification).MetricSpecification = value; }

        /// <summary>Creates an new <see cref="OperationPropertiesFormat" /> instance.</summary>
        public OperationPropertiesFormat()
        {

        }
    }
    /// Description of operation properties format.
    public partial interface IOperationPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Operation log specification.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Operation log specification.",
        SerializedName = @"logSpecifications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILogSpecification) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILogSpecification[] ServiceSpecificationLogSpecification { get; set; }
        /// <summary>Operation service specification.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Operation service specification.",
        SerializedName = @"metricSpecifications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IMetricSpecification) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IMetricSpecification[] ServiceSpecificationMetricSpecification { get; set; }

    }
    /// Description of operation properties format.
    internal partial interface IOperationPropertiesFormatInternal

    {
        /// <summary>Specification of the service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOperationPropertiesFormatServiceSpecification ServiceSpecification { get; set; }
        /// <summary>Operation log specification.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILogSpecification[] ServiceSpecificationLogSpecification { get; set; }
        /// <summary>Operation service specification.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IMetricSpecification[] ServiceSpecificationMetricSpecification { get; set; }

    }
}
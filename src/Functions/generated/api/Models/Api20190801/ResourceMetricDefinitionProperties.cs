namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>ResourceMetricDefinition resource specific properties</summary>
    public partial class ResourceMetricDefinitionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricDefinitionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricDefinitionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="MetricAvailability" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricAvailability[] _metricAvailability;

        /// <summary>List of time grains supported for the metric together with retention period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricAvailability[] MetricAvailability { get => this._metricAvailability; }

        /// <summary>Internal Acessors for MetricAvailability</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricAvailability[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricDefinitionPropertiesInternal.MetricAvailability { get => this._metricAvailability; set { {_metricAvailability = value;} } }

        /// <summary>Internal Acessors for PrimaryAggregationType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricDefinitionPropertiesInternal.PrimaryAggregationType { get => this._primaryAggregationType; set { {_primaryAggregationType = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricDefinitionProperties1 Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricDefinitionPropertiesInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ResourceMetricDefinitionProperties1()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ResourceUri</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricDefinitionPropertiesInternal.ResourceUri { get => this._resourceUri; set { {_resourceUri = value;} } }

        /// <summary>Internal Acessors for Unit</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricDefinitionPropertiesInternal.Unit { get => this._unit; set { {_unit = value;} } }

        /// <summary>Backing field for <see cref="PrimaryAggregationType" /> property.</summary>
        private string _primaryAggregationType;

        /// <summary>Primary aggregation type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PrimaryAggregationType { get => this._primaryAggregationType; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricDefinitionProperties1 _property;

        /// <summary>Resource metric definition properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricDefinitionProperties1 Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ResourceMetricDefinitionProperties1()); }

        /// <summary>Backing field for <see cref="ResourceUri" /> property.</summary>
        private string _resourceUri;

        /// <summary>Resource URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ResourceUri { get => this._resourceUri; }

        /// <summary>Backing field for <see cref="Unit" /> property.</summary>
        private string _unit;

        /// <summary>Unit of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Unit { get => this._unit; }

        /// <summary>Creates an new <see cref="ResourceMetricDefinitionProperties" /> instance.</summary>
        public ResourceMetricDefinitionProperties()
        {

        }
    }
    /// ResourceMetricDefinition resource specific properties
    public partial interface IResourceMetricDefinitionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>List of time grains supported for the metric together with retention period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of time grains supported for the metric together with retention period.",
        SerializedName = @"metricAvailabilities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricAvailability) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricAvailability[] MetricAvailability { get;  }
        /// <summary>Primary aggregation type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Primary aggregation type.",
        SerializedName = @"primaryAggregationType",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryAggregationType { get;  }
        /// <summary>Resource metric definition properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource metric definition properties.",
        SerializedName = @"properties",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricDefinitionProperties1) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricDefinitionProperties1 Property { get;  }
        /// <summary>Resource URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource URI.",
        SerializedName = @"resourceUri",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceUri { get;  }
        /// <summary>Unit of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Unit of the metric.",
        SerializedName = @"unit",
        PossibleTypes = new [] { typeof(string) })]
        string Unit { get;  }

    }
    /// ResourceMetricDefinition resource specific properties
    internal partial interface IResourceMetricDefinitionPropertiesInternal

    {
        /// <summary>List of time grains supported for the metric together with retention period.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricAvailability[] MetricAvailability { get; set; }
        /// <summary>Primary aggregation type.</summary>
        string PrimaryAggregationType { get; set; }
        /// <summary>Resource metric definition properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricDefinitionProperties1 Property { get; set; }
        /// <summary>Resource URI.</summary>
        string ResourceUri { get; set; }
        /// <summary>Unit of the metric.</summary>
        string Unit { get; set; }

    }
}
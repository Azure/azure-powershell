// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Metric specification for an operation.</summary>
    public partial class MetricSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMetricSpecification,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMetricSpecificationInternal
    {

        /// <summary>Backing field for <see cref="AggregationType" /> property.</summary>
        private string _aggregationType;

        /// <summary>Aggregation type of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string AggregationType { get => this._aggregationType; set => this._aggregationType = value; }

        /// <summary>Backing field for <see cref="Category" /> property.</summary>
        private string _category;

        /// <summary>Category of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Category { get => this._category; set => this._category = value; }

        /// <summary>Backing field for <see cref="DisplayDescription" /> property.</summary>
        private string _displayDescription;

        /// <summary>Display description of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string DisplayDescription { get => this._displayDescription; set => this._displayDescription = value; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>Display name of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="SupportedAggregationType" /> property.</summary>
        private System.Collections.Generic.List<string> _supportedAggregationType;

        /// <summary>Supported aggregation types for the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> SupportedAggregationType { get => this._supportedAggregationType; set => this._supportedAggregationType = value; }

        /// <summary>Backing field for <see cref="SupportedTimeGrainType" /> property.</summary>
        private System.Collections.Generic.List<string> _supportedTimeGrainType;

        /// <summary>Supported time grain types for the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> SupportedTimeGrainType { get => this._supportedTimeGrainType; set => this._supportedTimeGrainType = value; }

        /// <summary>Backing field for <see cref="Unit" /> property.</summary>
        private string _unit;

        /// <summary>Unit of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Unit { get => this._unit; set => this._unit = value; }

        /// <summary>Creates an new <see cref="MetricSpecification" /> instance.</summary>
        public MetricSpecification()
        {

        }
    }
    /// Metric specification for an operation.
    public partial interface IMetricSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Aggregation type of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Aggregation type of the metric.",
        SerializedName = @"aggregationType",
        PossibleTypes = new [] { typeof(string) })]
        string AggregationType { get; set; }
        /// <summary>Category of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Category of the metric.",
        SerializedName = @"category",
        PossibleTypes = new [] { typeof(string) })]
        string Category { get; set; }
        /// <summary>Display description of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Display description of the metric.",
        SerializedName = @"displayDescription",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get; set; }
        /// <summary>Display name of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Display name of the metric.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>Name of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name of the metric.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Supported aggregation types for the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Supported aggregation types for the metric.",
        SerializedName = @"supportedAggregationTypes",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> SupportedAggregationType { get; set; }
        /// <summary>Supported time grain types for the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Supported time grain types for the metric.",
        SerializedName = @"supportedTimeGrainTypes",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> SupportedTimeGrainType { get; set; }
        /// <summary>Unit of the metric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Unit of the metric.",
        SerializedName = @"unit",
        PossibleTypes = new [] { typeof(string) })]
        string Unit { get; set; }

    }
    /// Metric specification for an operation.
    internal partial interface IMetricSpecificationInternal

    {
        /// <summary>Aggregation type of the metric.</summary>
        string AggregationType { get; set; }
        /// <summary>Category of the metric.</summary>
        string Category { get; set; }
        /// <summary>Display description of the metric.</summary>
        string DisplayDescription { get; set; }
        /// <summary>Display name of the metric.</summary>
        string DisplayName { get; set; }
        /// <summary>Name of the metric.</summary>
        string Name { get; set; }
        /// <summary>Supported aggregation types for the metric.</summary>
        System.Collections.Generic.List<string> SupportedAggregationType { get; set; }
        /// <summary>Supported time grain types for the metric.</summary>
        System.Collections.Generic.List<string> SupportedTimeGrainType { get; set; }
        /// <summary>Unit of the metric.</summary>
        string Unit { get; set; }

    }
}
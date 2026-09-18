// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Impact on some metric if this recommended action is applied.</summary>
    public partial class ImpactRecord :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IImpactRecord,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IImpactRecordInternal
    {

        /// <summary>Backing field for <see cref="AbsoluteValue" /> property.</summary>
        private double? _absoluteValue;

        /// <summary>Absolute value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public double? AbsoluteValue { get => this._absoluteValue; set => this._absoluteValue = value; }

        /// <summary>Backing field for <see cref="DimensionName" /> property.</summary>
        private string _dimensionName;

        /// <summary>Dimension name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string DimensionName { get => this._dimensionName; set => this._dimensionName = value; }

        /// <summary>Backing field for <see cref="QueryId" /> property.</summary>
        private long? _queryId;

        /// <summary>
        /// Optional property that can be used to store the identifier of the query, if the metric is for a specific query.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public long? QueryId { get => this._queryId; set => this._queryId = value; }

        /// <summary>Backing field for <see cref="Unit" /> property.</summary>
        private string _unit;

        /// <summary>Dimension unit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Unit { get => this._unit; set => this._unit = value; }

        /// <summary>Creates an new <see cref="ImpactRecord" /> instance.</summary>
        public ImpactRecord()
        {

        }
    }
    /// Impact on some metric if this recommended action is applied.
    public partial interface IImpactRecord :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Absolute value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Absolute value.",
        SerializedName = @"absoluteValue",
        PossibleTypes = new [] { typeof(double) })]
        double? AbsoluteValue { get; set; }
        /// <summary>Dimension name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Dimension name.",
        SerializedName = @"dimensionName",
        PossibleTypes = new [] { typeof(string) })]
        string DimensionName { get; set; }
        /// <summary>
        /// Optional property that can be used to store the identifier of the query, if the metric is for a specific query.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Optional property that can be used to store the identifier of the query, if the metric is for a specific query.",
        SerializedName = @"queryId",
        PossibleTypes = new [] { typeof(long) })]
        long? QueryId { get; set; }
        /// <summary>Dimension unit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Dimension unit.",
        SerializedName = @"unit",
        PossibleTypes = new [] { typeof(string) })]
        string Unit { get; set; }

    }
    /// Impact on some metric if this recommended action is applied.
    internal partial interface IImpactRecordInternal

    {
        /// <summary>Absolute value.</summary>
        double? AbsoluteValue { get; set; }
        /// <summary>Dimension name.</summary>
        string DimensionName { get; set; }
        /// <summary>
        /// Optional property that can be used to store the identifier of the query, if the metric is for a specific query.
        /// </summary>
        long? QueryId { get; set; }
        /// <summary>Dimension unit.</summary>
        string Unit { get; set; }

    }
}
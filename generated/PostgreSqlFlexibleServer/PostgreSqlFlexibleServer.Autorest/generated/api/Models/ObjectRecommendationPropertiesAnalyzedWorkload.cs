// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Workload information for the recommended action.</summary>
    public partial class ObjectRecommendationPropertiesAnalyzedWorkload :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesAnalyzedWorkload,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesAnalyzedWorkloadInternal
    {

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private global::System.DateTime? _endTime;

        /// <summary>End time (UTC) of the workload analyzed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public global::System.DateTime? EndTime { get => this._endTime; set => this._endTime = value; }

        /// <summary>Backing field for <see cref="QueryCount" /> property.</summary>
        private int? _queryCount;

        /// <summary>
        /// Number of queries from the workload that were examined to produce this recommendation. For DROP INDEX recommendations
        /// it's 0 (zero).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? QueryCount { get => this._queryCount; set => this._queryCount = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>Start time (UTC) of the workload analyzed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>
        /// Creates an new <see cref="ObjectRecommendationPropertiesAnalyzedWorkload" /> instance.
        /// </summary>
        public ObjectRecommendationPropertiesAnalyzedWorkload()
        {

        }
    }
    /// Workload information for the recommended action.
    public partial interface IObjectRecommendationPropertiesAnalyzedWorkload :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>End time (UTC) of the workload analyzed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"End time (UTC) of the workload analyzed.",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndTime { get; set; }
        /// <summary>
        /// Number of queries from the workload that were examined to produce this recommendation. For DROP INDEX recommendations
        /// it's 0 (zero).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Number of queries from the workload that were examined to produce this recommendation. For DROP INDEX recommendations it's 0 (zero).",
        SerializedName = @"queryCount",
        PossibleTypes = new [] { typeof(int) })]
        int? QueryCount { get; set; }
        /// <summary>Start time (UTC) of the workload analyzed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Start time (UTC) of the workload analyzed.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }

    }
    /// Workload information for the recommended action.
    internal partial interface IObjectRecommendationPropertiesAnalyzedWorkloadInternal

    {
        /// <summary>End time (UTC) of the workload analyzed.</summary>
        global::System.DateTime? EndTime { get; set; }
        /// <summary>
        /// Number of queries from the workload that were examined to produce this recommendation. For DROP INDEX recommendations
        /// it's 0 (zero).
        /// </summary>
        int? QueryCount { get; set; }
        /// <summary>Start time (UTC) of the workload analyzed.</summary>
        global::System.DateTime? StartTime { get; set; }

    }
}
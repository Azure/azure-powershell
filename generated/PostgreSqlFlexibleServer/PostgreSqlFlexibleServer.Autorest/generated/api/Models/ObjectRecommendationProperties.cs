// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Object recommendation properties.</summary>
    public partial class ObjectRecommendationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AnalyzedWorkload" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesAnalyzedWorkload _analyzedWorkload;

        /// <summary>Workload information for the recommended action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesAnalyzedWorkload AnalyzedWorkload { get => (this._analyzedWorkload = this._analyzedWorkload ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ObjectRecommendationPropertiesAnalyzedWorkload()); set => this._analyzedWorkload = value; }

        /// <summary>End time (UTC) of the workload analyzed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public global::System.DateTime? AnalyzedWorkloadEndTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesAnalyzedWorkloadInternal)AnalyzedWorkload).EndTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesAnalyzedWorkloadInternal)AnalyzedWorkload).EndTime = value ?? default(global::System.DateTime); }

        /// <summary>
        /// Number of queries from the workload that were examined to produce this recommendation. For DROP INDEX recommendations
        /// it's 0 (zero).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public int? AnalyzedWorkloadQueryCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesAnalyzedWorkloadInternal)AnalyzedWorkload).QueryCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesAnalyzedWorkloadInternal)AnalyzedWorkload).QueryCount = value ?? default(int); }

        /// <summary>Start time (UTC) of the workload analyzed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public global::System.DateTime? AnalyzedWorkloadStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesAnalyzedWorkloadInternal)AnalyzedWorkload).StartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesAnalyzedWorkloadInternal)AnalyzedWorkload).StartTime = value ?? default(global::System.DateTime); }

        /// <summary>Backing field for <see cref="CurrentState" /> property.</summary>
        private string _currentState;

        /// <summary>Current state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string CurrentState { get => this._currentState; set => this._currentState = value; }

        /// <summary>Backing field for <see cref="Detail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetails _detail;

        /// <summary>Recommendation details for the recommended action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetails Detail { get => (this._detail = this._detail ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ObjectRecommendationDetails()); }

        /// <summary>Database name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string DetailDatabaseName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetailsInternal)Detail).DatabaseName; }

        /// <summary>Index included columns.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> DetailIncludedColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetailsInternal)Detail).IncludedColumn; }

        /// <summary>Index columns.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> DetailIndexColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetailsInternal)Detail).IndexColumn; }

        /// <summary>Index name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string DetailIndexName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetailsInternal)Detail).IndexName; }

        /// <summary>Index type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string DetailIndexType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetailsInternal)Detail).IndexType; }

        /// <summary>Schema name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string DetailSchema { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetailsInternal)Detail).Schema; }

        /// <summary>Table name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string DetailTable { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetailsInternal)Detail).Table; }

        /// <summary>Backing field for <see cref="EstimatedImpact" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IImpactRecord> _estimatedImpact;

        /// <summary>Estimated impact of this recommended action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IImpactRecord> EstimatedImpact { get => this._estimatedImpact; }

        /// <summary>Backing field for <see cref="ImplementationDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesImplementationDetails _implementationDetail;

        /// <summary>Implementation details for the recommended action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesImplementationDetails ImplementationDetail { get => (this._implementationDetail = this._implementationDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ObjectRecommendationPropertiesImplementationDetails()); set => this._implementationDetail = value; }

        /// <summary>Method of implementation for recommended action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string ImplementationDetailMethod { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesImplementationDetailsInternal)ImplementationDetail).Method; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesImplementationDetailsInternal)ImplementationDetail).Method = value ?? null; }

        /// <summary>Implementation script for the recommended action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string ImplementationDetailScript { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesImplementationDetailsInternal)ImplementationDetail).Script; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesImplementationDetailsInternal)ImplementationDetail).Script = value ?? null; }

        /// <summary>Backing field for <see cref="ImprovedQueryId" /> property.</summary>
        private System.Collections.Generic.List<long> _improvedQueryId;

        /// <summary>
        /// List of identifiers for all queries identified as targets for improvement if the recommendation is applied. The list is
        /// only populated for CREATE INDEX recommendations.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<long> ImprovedQueryId { get => this._improvedQueryId; set => this._improvedQueryId = value; }

        /// <summary>Backing field for <see cref="InitialRecommendedTime" /> property.</summary>
        private global::System.DateTime? _initialRecommendedTime;

        /// <summary>Creation time (UTC) of this recommendation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public global::System.DateTime? InitialRecommendedTime { get => this._initialRecommendedTime; set => this._initialRecommendedTime = value; }

        /// <summary>Backing field for <see cref="LastRecommendedTime" /> property.</summary>
        private global::System.DateTime? _lastRecommendedTime;

        /// <summary>Last time (UTC) that this recommendation was produced.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public global::System.DateTime? LastRecommendedTime { get => this._lastRecommendedTime; set => this._lastRecommendedTime = value; }

        /// <summary>Internal Acessors for AnalyzedWorkload</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesAnalyzedWorkload Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal.AnalyzedWorkload { get => (this._analyzedWorkload = this._analyzedWorkload ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ObjectRecommendationPropertiesAnalyzedWorkload()); set { {_analyzedWorkload = value;} } }

        /// <summary>Internal Acessors for Detail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetails Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal.Detail { get => (this._detail = this._detail ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ObjectRecommendationDetails()); set { {_detail = value;} } }

        /// <summary>Internal Acessors for DetailDatabaseName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal.DetailDatabaseName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetailsInternal)Detail).DatabaseName; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetailsInternal)Detail).DatabaseName = value ?? null; }

        /// <summary>Internal Acessors for DetailIncludedColumn</summary>
        System.Collections.Generic.List<string> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal.DetailIncludedColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetailsInternal)Detail).IncludedColumn; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetailsInternal)Detail).IncludedColumn = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for DetailIndexColumn</summary>
        System.Collections.Generic.List<string> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal.DetailIndexColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetailsInternal)Detail).IndexColumn; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetailsInternal)Detail).IndexColumn = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for DetailIndexName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal.DetailIndexName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetailsInternal)Detail).IndexName; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetailsInternal)Detail).IndexName = value ?? null; }

        /// <summary>Internal Acessors for DetailIndexType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal.DetailIndexType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetailsInternal)Detail).IndexType; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetailsInternal)Detail).IndexType = value ?? null; }

        /// <summary>Internal Acessors for DetailSchema</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal.DetailSchema { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetailsInternal)Detail).Schema; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetailsInternal)Detail).Schema = value ?? null; }

        /// <summary>Internal Acessors for DetailTable</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal.DetailTable { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetailsInternal)Detail).Table; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetailsInternal)Detail).Table = value ?? null; }

        /// <summary>Internal Acessors for EstimatedImpact</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IImpactRecord> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal.EstimatedImpact { get => this._estimatedImpact; set { {_estimatedImpact = value;} } }

        /// <summary>Internal Acessors for ImplementationDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesImplementationDetails Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal.ImplementationDetail { get => (this._implementationDetail = this._implementationDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ObjectRecommendationPropertiesImplementationDetails()); set { {_implementationDetail = value;} } }

        /// <summary>Backing field for <see cref="RecommendationReason" /> property.</summary>
        private string _recommendationReason;

        /// <summary>Reason for this recommendation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string RecommendationReason { get => this._recommendationReason; set => this._recommendationReason = value; }

        /// <summary>Backing field for <see cref="RecommendationType" /> property.</summary>
        private string _recommendationType;

        /// <summary>Type for this recommendation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string RecommendationType { get => this._recommendationType; set => this._recommendationType = value; }

        /// <summary>Backing field for <see cref="TimesRecommended" /> property.</summary>
        private int? _timesRecommended;

        /// <summary>Number of times this recommendation has been produced.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? TimesRecommended { get => this._timesRecommended; set => this._timesRecommended = value; }

        /// <summary>Creates an new <see cref="ObjectRecommendationProperties" /> instance.</summary>
        public ObjectRecommendationProperties()
        {

        }
    }
    /// Object recommendation properties.
    public partial interface IObjectRecommendationProperties :
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
        global::System.DateTime? AnalyzedWorkloadEndTime { get; set; }
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
        int? AnalyzedWorkloadQueryCount { get; set; }
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
        global::System.DateTime? AnalyzedWorkloadStartTime { get; set; }
        /// <summary>Current state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Current state.",
        SerializedName = @"currentState",
        PossibleTypes = new [] { typeof(string) })]
        string CurrentState { get; set; }
        /// <summary>Database name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Database name.",
        SerializedName = @"databaseName",
        PossibleTypes = new [] { typeof(string) })]
        string DetailDatabaseName { get;  }
        /// <summary>Index included columns.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Index included columns.",
        SerializedName = @"includedColumns",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> DetailIncludedColumn { get;  }
        /// <summary>Index columns.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Index columns.",
        SerializedName = @"indexColumns",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> DetailIndexColumn { get;  }
        /// <summary>Index name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Index name.",
        SerializedName = @"indexName",
        PossibleTypes = new [] { typeof(string) })]
        string DetailIndexName { get;  }
        /// <summary>Index type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Index type.",
        SerializedName = @"indexType",
        PossibleTypes = new [] { typeof(string) })]
        string DetailIndexType { get;  }
        /// <summary>Schema name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Schema name.",
        SerializedName = @"schema",
        PossibleTypes = new [] { typeof(string) })]
        string DetailSchema { get;  }
        /// <summary>Table name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Table name.",
        SerializedName = @"table",
        PossibleTypes = new [] { typeof(string) })]
        string DetailTable { get;  }
        /// <summary>Estimated impact of this recommended action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Estimated impact of this recommended action.",
        SerializedName = @"estimatedImpact",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IImpactRecord) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IImpactRecord> EstimatedImpact { get;  }
        /// <summary>Method of implementation for recommended action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Method of implementation for recommended action.",
        SerializedName = @"method",
        PossibleTypes = new [] { typeof(string) })]
        string ImplementationDetailMethod { get; set; }
        /// <summary>Implementation script for the recommended action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Implementation script for the recommended action.",
        SerializedName = @"script",
        PossibleTypes = new [] { typeof(string) })]
        string ImplementationDetailScript { get; set; }
        /// <summary>
        /// List of identifiers for all queries identified as targets for improvement if the recommendation is applied. The list is
        /// only populated for CREATE INDEX recommendations.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"List of identifiers for all queries identified as targets for improvement if the recommendation is applied. The list is only populated for CREATE INDEX recommendations.",
        SerializedName = @"improvedQueryIds",
        PossibleTypes = new [] { typeof(long) })]
        System.Collections.Generic.List<long> ImprovedQueryId { get; set; }
        /// <summary>Creation time (UTC) of this recommendation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Creation time (UTC) of this recommendation.",
        SerializedName = @"initialRecommendedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? InitialRecommendedTime { get; set; }
        /// <summary>Last time (UTC) that this recommendation was produced.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Last time (UTC) that this recommendation was produced.",
        SerializedName = @"lastRecommendedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastRecommendedTime { get; set; }
        /// <summary>Reason for this recommendation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Reason for this recommendation.",
        SerializedName = @"recommendationReason",
        PossibleTypes = new [] { typeof(string) })]
        string RecommendationReason { get; set; }
        /// <summary>Type for this recommendation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Type for this recommendation.",
        SerializedName = @"recommendationType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("CreateIndex", "DropIndex", "ReIndex", "AnalyzeTable", "VacuumTable")]
        string RecommendationType { get; set; }
        /// <summary>Number of times this recommendation has been produced.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Number of times this recommendation has been produced.",
        SerializedName = @"timesRecommended",
        PossibleTypes = new [] { typeof(int) })]
        int? TimesRecommended { get; set; }

    }
    /// Object recommendation properties.
    internal partial interface IObjectRecommendationPropertiesInternal

    {
        /// <summary>Workload information for the recommended action.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesAnalyzedWorkload AnalyzedWorkload { get; set; }
        /// <summary>End time (UTC) of the workload analyzed.</summary>
        global::System.DateTime? AnalyzedWorkloadEndTime { get; set; }
        /// <summary>
        /// Number of queries from the workload that were examined to produce this recommendation. For DROP INDEX recommendations
        /// it's 0 (zero).
        /// </summary>
        int? AnalyzedWorkloadQueryCount { get; set; }
        /// <summary>Start time (UTC) of the workload analyzed.</summary>
        global::System.DateTime? AnalyzedWorkloadStartTime { get; set; }
        /// <summary>Current state.</summary>
        string CurrentState { get; set; }
        /// <summary>Recommendation details for the recommended action.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetails Detail { get; set; }
        /// <summary>Database name.</summary>
        string DetailDatabaseName { get; set; }
        /// <summary>Index included columns.</summary>
        System.Collections.Generic.List<string> DetailIncludedColumn { get; set; }
        /// <summary>Index columns.</summary>
        System.Collections.Generic.List<string> DetailIndexColumn { get; set; }
        /// <summary>Index name.</summary>
        string DetailIndexName { get; set; }
        /// <summary>Index type.</summary>
        string DetailIndexType { get; set; }
        /// <summary>Schema name.</summary>
        string DetailSchema { get; set; }
        /// <summary>Table name.</summary>
        string DetailTable { get; set; }
        /// <summary>Estimated impact of this recommended action.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IImpactRecord> EstimatedImpact { get; set; }
        /// <summary>Implementation details for the recommended action.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesImplementationDetails ImplementationDetail { get; set; }
        /// <summary>Method of implementation for recommended action.</summary>
        string ImplementationDetailMethod { get; set; }
        /// <summary>Implementation script for the recommended action.</summary>
        string ImplementationDetailScript { get; set; }
        /// <summary>
        /// List of identifiers for all queries identified as targets for improvement if the recommendation is applied. The list is
        /// only populated for CREATE INDEX recommendations.
        /// </summary>
        System.Collections.Generic.List<long> ImprovedQueryId { get; set; }
        /// <summary>Creation time (UTC) of this recommendation.</summary>
        global::System.DateTime? InitialRecommendedTime { get; set; }
        /// <summary>Last time (UTC) that this recommendation was produced.</summary>
        global::System.DateTime? LastRecommendedTime { get; set; }
        /// <summary>Reason for this recommendation.</summary>
        string RecommendationReason { get; set; }
        /// <summary>Type for this recommendation.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("CreateIndex", "DropIndex", "ReIndex", "AnalyzeTable", "VacuumTable")]
        string RecommendationType { get; set; }
        /// <summary>Number of times this recommendation has been produced.</summary>
        int? TimesRecommended { get; set; }

    }
}
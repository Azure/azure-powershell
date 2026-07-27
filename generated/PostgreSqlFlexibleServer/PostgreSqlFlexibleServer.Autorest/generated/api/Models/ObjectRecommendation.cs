// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Object recommendation properties.</summary>
    public partial class ObjectRecommendation :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendation,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IProxyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IProxyResource __proxyResource = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ProxyResource();

        /// <summary>End time (UTC) of the workload analyzed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public global::System.DateTime? AnalyzedWorkloadEndTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).AnalyzedWorkloadEndTime; }

        /// <summary>
        /// Number of queries from the workload that were examined to produce this recommendation. For DROP INDEX recommendations
        /// it's 0 (zero).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public int? AnalyzedWorkloadQueryCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).AnalyzedWorkloadQueryCount; }

        /// <summary>Start time (UTC) of the workload analyzed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public global::System.DateTime? AnalyzedWorkloadStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).AnalyzedWorkloadStartTime; }

        /// <summary>Current state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string CurrentState { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).CurrentState; }

        /// <summary>Database name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 1, Width = 20)]
        public string DetailDatabaseName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).DetailDatabaseName; }

        /// <summary>Index included columns.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public System.Collections.Generic.List<string> DetailIncludedColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).DetailIncludedColumn; }

        /// <summary>Index columns.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public System.Collections.Generic.List<string> DetailIndexColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).DetailIndexColumn; }

        /// <summary>Index name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string DetailIndexName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).DetailIndexName; }

        /// <summary>Index type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string DetailIndexType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).DetailIndexType; }

        /// <summary>Schema name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 2, Width = 20)]
        public string DetailSchema { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).DetailSchema; }

        /// <summary>Table name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 3, Width = 20)]
        public string DetailTable { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).DetailTable; }

        /// <summary>Estimated impact of this recommended action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IImpactRecord> EstimatedImpact { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).EstimatedImpact; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).Id; }

        /// <summary>Method of implementation for recommended action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string ImplementationDetailMethod { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).ImplementationDetailMethod; }

        /// <summary>Implementation script for the recommended action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 4, Width = 60)]
        public string ImplementationDetailScript { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).ImplementationDetailScript; }

        /// <summary>
        /// List of identifiers for all queries identified as targets for improvement if the recommendation is applied. The list is
        /// only populated for CREATE INDEX recommendations.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public System.Collections.Generic.List<long> ImprovedQueryId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).ImprovedQueryId; }

        /// <summary>Creation time (UTC) of this recommendation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public global::System.DateTime? InitialRecommendedTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).InitialRecommendedTime; }

        /// <summary>Backing field for <see cref="Kind" /> property.</summary>
        private string _kind;

        /// <summary>Always empty.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string Kind { get => this._kind; set => this._kind = value; }

        /// <summary>Last time (UTC) that this recommendation was produced.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public global::System.DateTime? LastRecommendedTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).LastRecommendedTime; }

        /// <summary>Internal Acessors for AnalyzedWorkload</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesAnalyzedWorkload Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.AnalyzedWorkload { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).AnalyzedWorkload; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).AnalyzedWorkload = value ?? null /* model class */; }

        /// <summary>Internal Acessors for AnalyzedWorkloadEndTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.AnalyzedWorkloadEndTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).AnalyzedWorkloadEndTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).AnalyzedWorkloadEndTime = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for AnalyzedWorkloadQueryCount</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.AnalyzedWorkloadQueryCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).AnalyzedWorkloadQueryCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).AnalyzedWorkloadQueryCount = value ?? default(int); }

        /// <summary>Internal Acessors for AnalyzedWorkloadStartTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.AnalyzedWorkloadStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).AnalyzedWorkloadStartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).AnalyzedWorkloadStartTime = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for CurrentState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.CurrentState { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).CurrentState; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).CurrentState = value ?? null; }

        /// <summary>Internal Acessors for Detail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetails Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.Detail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).Detail; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).Detail = value ?? null /* model class */; }

        /// <summary>Internal Acessors for DetailDatabaseName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.DetailDatabaseName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).DetailDatabaseName; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).DetailDatabaseName = value ?? null; }

        /// <summary>Internal Acessors for DetailIncludedColumn</summary>
        System.Collections.Generic.List<string> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.DetailIncludedColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).DetailIncludedColumn; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).DetailIncludedColumn = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for DetailIndexColumn</summary>
        System.Collections.Generic.List<string> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.DetailIndexColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).DetailIndexColumn; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).DetailIndexColumn = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for DetailIndexName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.DetailIndexName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).DetailIndexName; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).DetailIndexName = value ?? null; }

        /// <summary>Internal Acessors for DetailIndexType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.DetailIndexType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).DetailIndexType; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).DetailIndexType = value ?? null; }

        /// <summary>Internal Acessors for DetailSchema</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.DetailSchema { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).DetailSchema; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).DetailSchema = value ?? null; }

        /// <summary>Internal Acessors for DetailTable</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.DetailTable { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).DetailTable; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).DetailTable = value ?? null; }

        /// <summary>Internal Acessors for EstimatedImpact</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IImpactRecord> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.EstimatedImpact { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).EstimatedImpact; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).EstimatedImpact = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for ImplementationDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesImplementationDetails Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.ImplementationDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).ImplementationDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).ImplementationDetail = value ?? null /* model class */; }

        /// <summary>Internal Acessors for ImplementationDetailMethod</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.ImplementationDetailMethod { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).ImplementationDetailMethod; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).ImplementationDetailMethod = value ?? null; }

        /// <summary>Internal Acessors for ImplementationDetailScript</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.ImplementationDetailScript { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).ImplementationDetailScript; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).ImplementationDetailScript = value ?? null; }

        /// <summary>Internal Acessors for ImprovedQueryId</summary>
        System.Collections.Generic.List<long> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.ImprovedQueryId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).ImprovedQueryId; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).ImprovedQueryId = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for InitialRecommendedTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.InitialRecommendedTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).InitialRecommendedTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).InitialRecommendedTime = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for LastRecommendedTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.LastRecommendedTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).LastRecommendedTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).LastRecommendedTime = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationProperties Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ObjectRecommendationProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for RecommendationReason</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.RecommendationReason { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).RecommendationReason; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).RecommendationReason = value ?? null; }

        /// <summary>Internal Acessors for RecommendationType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.RecommendationType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).RecommendationType; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).RecommendationType = value ?? null; }

        /// <summary>Internal Acessors for TimesRecommended</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationInternal.TimesRecommended { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).TimesRecommended; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).TimesRecommended = value ?? default(int); }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).Id = value ?? null; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).Name = value ?? null; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISystemData Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemData = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SystemDataCreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataCreatedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataCreatedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataLastModifiedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType = value ?? null; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).Type = value ?? null; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 0, Width = 40)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationProperties _property;

        /// <summary>Properties of an object recommendation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ObjectRecommendationProperties()); }

        /// <summary>Reason for this recommendation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 5, Width = 60)]
        public string RecommendationReason { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).RecommendationReason; }

        /// <summary>Type for this recommendation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string RecommendationType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).RecommendationType; }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemData = value ?? null /* model class */; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType; }

        /// <summary>Number of times this recommendation has been produced.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public int? TimesRecommended { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)Property).TimesRecommended; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).Type; }

        /// <summary>Creates an new <see cref="ObjectRecommendation" /> instance.</summary>
        public ObjectRecommendation()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyResource), __proxyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyResource), __proxyResource);
        }
    }
    /// Object recommendation properties.
    public partial interface IObjectRecommendation :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IProxyResource
    {
        /// <summary>End time (UTC) of the workload analyzed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"End time (UTC) of the workload analyzed.",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? AnalyzedWorkloadEndTime { get;  }
        /// <summary>
        /// Number of queries from the workload that were examined to produce this recommendation. For DROP INDEX recommendations
        /// it's 0 (zero).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Number of queries from the workload that were examined to produce this recommendation. For DROP INDEX recommendations it's 0 (zero).",
        SerializedName = @"queryCount",
        PossibleTypes = new [] { typeof(int) })]
        int? AnalyzedWorkloadQueryCount { get;  }
        /// <summary>Start time (UTC) of the workload analyzed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Start time (UTC) of the workload analyzed.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? AnalyzedWorkloadStartTime { get;  }
        /// <summary>Current state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Current state.",
        SerializedName = @"currentState",
        PossibleTypes = new [] { typeof(string) })]
        string CurrentState { get;  }
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
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Method of implementation for recommended action.",
        SerializedName = @"method",
        PossibleTypes = new [] { typeof(string) })]
        string ImplementationDetailMethod { get;  }
        /// <summary>Implementation script for the recommended action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Implementation script for the recommended action.",
        SerializedName = @"script",
        PossibleTypes = new [] { typeof(string) })]
        string ImplementationDetailScript { get;  }
        /// <summary>
        /// List of identifiers for all queries identified as targets for improvement if the recommendation is applied. The list is
        /// only populated for CREATE INDEX recommendations.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"List of identifiers for all queries identified as targets for improvement if the recommendation is applied. The list is only populated for CREATE INDEX recommendations.",
        SerializedName = @"improvedQueryIds",
        PossibleTypes = new [] { typeof(long) })]
        System.Collections.Generic.List<long> ImprovedQueryId { get;  }
        /// <summary>Creation time (UTC) of this recommendation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Creation time (UTC) of this recommendation.",
        SerializedName = @"initialRecommendedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? InitialRecommendedTime { get;  }
        /// <summary>Always empty.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Always empty.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(string) })]
        string Kind { get; set; }
        /// <summary>Last time (UTC) that this recommendation was produced.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Last time (UTC) that this recommendation was produced.",
        SerializedName = @"lastRecommendedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastRecommendedTime { get;  }
        /// <summary>Reason for this recommendation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Reason for this recommendation.",
        SerializedName = @"recommendationReason",
        PossibleTypes = new [] { typeof(string) })]
        string RecommendationReason { get;  }
        /// <summary>Type for this recommendation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Type for this recommendation.",
        SerializedName = @"recommendationType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("CreateIndex", "DropIndex", "ReIndex", "AnalyzeTable", "VacuumTable")]
        string RecommendationType { get;  }
        /// <summary>Number of times this recommendation has been produced.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Number of times this recommendation has been produced.",
        SerializedName = @"timesRecommended",
        PossibleTypes = new [] { typeof(int) })]
        int? TimesRecommended { get;  }

    }
    /// Object recommendation properties.
    internal partial interface IObjectRecommendationInternal :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IProxyResourceInternal
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
        /// <summary>Always empty.</summary>
        string Kind { get; set; }
        /// <summary>Last time (UTC) that this recommendation was produced.</summary>
        global::System.DateTime? LastRecommendedTime { get; set; }
        /// <summary>Properties of an object recommendation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationProperties Property { get; set; }
        /// <summary>Reason for this recommendation.</summary>
        string RecommendationReason { get; set; }
        /// <summary>Type for this recommendation.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("CreateIndex", "DropIndex", "ReIndex", "AnalyzeTable", "VacuumTable")]
        string RecommendationType { get; set; }
        /// <summary>Number of times this recommendation has been produced.</summary>
        int? TimesRecommended { get; set; }

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The properties of the view.</summary>
    public partial class ViewProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewProperties,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Accumulated" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AccumulatedType? _accumulated;

        /// <summary>Show costs accumulated over time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AccumulatedType? Accumulated { get => this._accumulated; set => this._accumulated = value; }

        /// <summary>Backing field for <see cref="Chart" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ChartType? _chart;

        /// <summary>Chart type of the main view in Cost Analysis. Required.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ChartType? Chart { get => this._chart; set => this._chart = value; }

        /// <summary>
        /// Array of column names to be included in the report. Any valid report column name is allowed. If not provided, then report
        /// includes all columns.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] ConfigurationColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).ConfigurationColumn; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).ConfigurationColumn = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="CreatedOn" /> property.</summary>
        private global::System.DateTime? _createdOn;

        /// <summary>Date the user created this view.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public global::System.DateTime? CreatedOn { get => this._createdOn; }

        /// <summary>
        /// Dictionary of aggregation expression to use in the report. The key of each item in the dictionary is the alias for the
        /// aggregated column. Report can have up to 2 aggregation clauses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetAggregation DatasetAggregation { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).DatasetAggregation; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).DatasetAggregation = value ?? null /* model class */; }

        /// <summary>Has filter expression to use in the report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter DatasetFilter { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).DatasetFilter; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).DatasetFilter = value ?? null /* model class */; }

        /// <summary>The granularity of rows in the report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType? DatasetGranularity { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).DatasetGranularity; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).DatasetGranularity = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType)""); }

        /// <summary>
        /// Array of group by expression to use in the report. Report can have up to 2 group by clauses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigGrouping[] DatasetGrouping { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).DatasetGrouping; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).DatasetGrouping = value ?? null /* arrayOf */; }

        /// <summary>Array of order by expression to use in the report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigSorting[] DatasetSorting { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).DatasetSorting; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).DatasetSorting = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>User input name of the view. Required.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="Kpi" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IKpiProperties[] _kpi;

        /// <summary>List of KPIs to show in Cost Analysis UI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IKpiProperties[] Kpi { get => this._kpi; set => this._kpi = value; }

        /// <summary>Backing field for <see cref="Metric" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.MetricType? _metric;

        /// <summary>Metric to use when displaying costs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.MetricType? Metric { get => this._metric; set => this._metric = value; }

        /// <summary>Internal Acessors for CreatedOn</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal.CreatedOn { get => this._createdOn; set { {_createdOn = value;} } }

        /// <summary>Internal Acessors for DatasetConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetConfiguration Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal.DatasetConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).DatasetConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).DatasetConfiguration = value; }

        /// <summary>Internal Acessors for ModifiedOn</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal.ModifiedOn { get => this._modifiedOn; set { {_modifiedOn = value;} } }

        /// <summary>Internal Acessors for Query</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinition Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal.Query { get => (this._query = this._query ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigDefinition()); set { {_query = value;} } }

        /// <summary>Internal Acessors for QueryDataset</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDataset Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal.QueryDataset { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).Dataset; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).Dataset = value; }

        /// <summary>Internal Acessors for QueryTimePeriod</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigTimePeriod Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal.QueryTimePeriod { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).TimePeriod; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).TimePeriod = value; }

        /// <summary>Internal Acessors for QueryType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal.QueryType { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).Type = value; }

        /// <summary>Backing field for <see cref="ModifiedOn" /> property.</summary>
        private global::System.DateTime? _modifiedOn;

        /// <summary>Date when the user last modified this view.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public global::System.DateTime? ModifiedOn { get => this._modifiedOn; }

        /// <summary>Backing field for <see cref="Pivot" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IPivotProperties[] _pivot;

        /// <summary>Configuration of 3 sub-views in the Cost Analysis UI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IPivotProperties[] Pivot { get => this._pivot; set => this._pivot = value; }

        /// <summary>Backing field for <see cref="Query" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinition _query;

        /// <summary>Query body configuration. Required.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinition Query { get => (this._query = this._query ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigDefinition()); set => this._query = value; }

        /// <summary>
        /// The time frame for pulling data for the report. If custom, then a specific time period must be provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportTimeframeType? QueryTimeframe { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).Timeframe; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).Timeframe = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportTimeframeType)""); }

        /// <summary>
        /// The type of the report. Usage represents actual usage, forecast represents forecasted data and UsageAndForecast represents
        /// both usage and forecasted data. Actual usage and forecasted data can be differentiated based on dates.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string QueryType { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).Type; }

        /// <summary>Backing field for <see cref="Scope" /> property.</summary>
        private string _scope;

        /// <summary>
        /// Cost Management scope to save the view on. This includes 'subscriptions/{subscriptionId}' for subscription scope, 'subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}'
        /// for resourceGroup scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}'
        /// for Department scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}'
        /// for EnrollmentAccount scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}'
        /// for BillingProfile scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/invoiceSections/{invoiceSectionId}'
        /// for InvoiceSection scope, 'providers/Microsoft.Management/managementGroups/{managementGroupId}' for Management Group scope,
        /// '/providers/Microsoft.CostManagement/externalBillingAccounts/{externalBillingAccountName}' for ExternalBillingAccount
        /// scope, and '/providers/Microsoft.CostManagement/externalSubscriptions/{externalSubscriptionName}' for ExternalSubscription
        /// scope.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string Scope { get => this._scope; set => this._scope = value; }

        /// <summary>The start date to pull data from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? TimePeriodFrom { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).TimePeriodFrom; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).TimePeriodFrom = value ?? default(global::System.DateTime); }

        /// <summary>The end date to pull data to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? TimePeriodTo { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).TimePeriodTo; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal)Query).TimePeriodTo = value ?? default(global::System.DateTime); }

        /// <summary>Creates an new <see cref="ViewProperties" /> instance.</summary>
        public ViewProperties()
        {

        }
    }
    /// The properties of the view.
    public partial interface IViewProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>Show costs accumulated over time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Show costs accumulated over time.",
        SerializedName = @"accumulated",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AccumulatedType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AccumulatedType? Accumulated { get; set; }
        /// <summary>Chart type of the main view in Cost Analysis. Required.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Chart type of the main view in Cost Analysis. Required.",
        SerializedName = @"chart",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ChartType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ChartType? Chart { get; set; }
        /// <summary>
        /// Array of column names to be included in the report. Any valid report column name is allowed. If not provided, then report
        /// includes all columns.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of column names to be included in the report. Any valid report column name is allowed. If not provided, then report includes all columns.",
        SerializedName = @"columns",
        PossibleTypes = new [] { typeof(string) })]
        string[] ConfigurationColumn { get; set; }
        /// <summary>Date the user created this view.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Date the user created this view.",
        SerializedName = @"createdOn",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreatedOn { get;  }
        /// <summary>
        /// Dictionary of aggregation expression to use in the report. The key of each item in the dictionary is the alias for the
        /// aggregated column. Report can have up to 2 aggregation clauses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Dictionary of aggregation expression to use in the report. The key of each item in the dictionary is the alias for the aggregated column. Report can have up to 2 aggregation clauses.",
        SerializedName = @"aggregation",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetAggregation) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetAggregation DatasetAggregation { get; set; }
        /// <summary>Has filter expression to use in the report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Has filter expression to use in the report.",
        SerializedName = @"filter",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter DatasetFilter { get; set; }
        /// <summary>The granularity of rows in the report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The granularity of rows in the report.",
        SerializedName = @"granularity",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType? DatasetGranularity { get; set; }
        /// <summary>
        /// Array of group by expression to use in the report. Report can have up to 2 group by clauses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of group by expression to use in the report. Report can have up to 2 group by clauses.",
        SerializedName = @"grouping",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigGrouping) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigGrouping[] DatasetGrouping { get; set; }
        /// <summary>Array of order by expression to use in the report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of order by expression to use in the report.",
        SerializedName = @"sorting",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigSorting) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigSorting[] DatasetSorting { get; set; }
        /// <summary>User input name of the view. Required.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"User input name of the view. Required.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>List of KPIs to show in Cost Analysis UI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of KPIs to show in Cost Analysis UI.",
        SerializedName = @"kpis",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IKpiProperties) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IKpiProperties[] Kpi { get; set; }
        /// <summary>Metric to use when displaying costs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Metric to use when displaying costs.",
        SerializedName = @"metric",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.MetricType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.MetricType? Metric { get; set; }
        /// <summary>Date when the user last modified this view.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Date when the user last modified this view.",
        SerializedName = @"modifiedOn",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ModifiedOn { get;  }
        /// <summary>Configuration of 3 sub-views in the Cost Analysis UI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Configuration of 3 sub-views in the Cost Analysis UI.",
        SerializedName = @"pivots",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IPivotProperties) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IPivotProperties[] Pivot { get; set; }
        /// <summary>
        /// The time frame for pulling data for the report. If custom, then a specific time period must be provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The time frame for pulling data for the report. If custom, then a specific time period must be provided.",
        SerializedName = @"timeframe",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportTimeframeType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportTimeframeType? QueryTimeframe { get; set; }
        /// <summary>
        /// The type of the report. Usage represents actual usage, forecast represents forecasted data and UsageAndForecast represents
        /// both usage and forecasted data. Actual usage and forecasted data can be differentiated based on dates.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of the report. Usage represents actual usage, forecast represents forecasted data and UsageAndForecast represents both usage and forecasted data. Actual usage and forecasted data can be differentiated based on dates.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string QueryType { get;  }
        /// <summary>
        /// Cost Management scope to save the view on. This includes 'subscriptions/{subscriptionId}' for subscription scope, 'subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}'
        /// for resourceGroup scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}'
        /// for Department scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}'
        /// for EnrollmentAccount scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}'
        /// for BillingProfile scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/invoiceSections/{invoiceSectionId}'
        /// for InvoiceSection scope, 'providers/Microsoft.Management/managementGroups/{managementGroupId}' for Management Group scope,
        /// '/providers/Microsoft.CostManagement/externalBillingAccounts/{externalBillingAccountName}' for ExternalBillingAccount
        /// scope, and '/providers/Microsoft.CostManagement/externalSubscriptions/{externalSubscriptionName}' for ExternalSubscription
        /// scope.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Cost Management scope to save the view on. This includes 'subscriptions/{subscriptionId}' for subscription scope, 'subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for resourceGroup scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}' for Department scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for BillingProfile scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/invoiceSections/{invoiceSectionId}' for InvoiceSection scope, 'providers/Microsoft.Management/managementGroups/{managementGroupId}' for Management Group scope, '/providers/Microsoft.CostManagement/externalBillingAccounts/{externalBillingAccountName}' for ExternalBillingAccount scope, and '/providers/Microsoft.CostManagement/externalSubscriptions/{externalSubscriptionName}' for ExternalSubscription scope.",
        SerializedName = @"scope",
        PossibleTypes = new [] { typeof(string) })]
        string Scope { get; set; }
        /// <summary>The start date to pull data from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The start date to pull data from.",
        SerializedName = @"from",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? TimePeriodFrom { get; set; }
        /// <summary>The end date to pull data to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The end date to pull data to.",
        SerializedName = @"to",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? TimePeriodTo { get; set; }

    }
    /// The properties of the view.
    public partial interface IViewPropertiesInternal

    {
        /// <summary>Show costs accumulated over time.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AccumulatedType? Accumulated { get; set; }
        /// <summary>Chart type of the main view in Cost Analysis. Required.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ChartType? Chart { get; set; }
        /// <summary>
        /// Array of column names to be included in the report. Any valid report column name is allowed. If not provided, then report
        /// includes all columns.
        /// </summary>
        string[] ConfigurationColumn { get; set; }
        /// <summary>Date the user created this view.</summary>
        global::System.DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Dictionary of aggregation expression to use in the report. The key of each item in the dictionary is the alias for the
        /// aggregated column. Report can have up to 2 aggregation clauses.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetAggregation DatasetAggregation { get; set; }
        /// <summary>
        /// Has configuration information for the data in the report. The configuration will be ignored if aggregation and grouping
        /// are provided.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetConfiguration DatasetConfiguration { get; set; }
        /// <summary>Has filter expression to use in the report.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter DatasetFilter { get; set; }
        /// <summary>The granularity of rows in the report.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType? DatasetGranularity { get; set; }
        /// <summary>
        /// Array of group by expression to use in the report. Report can have up to 2 group by clauses.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigGrouping[] DatasetGrouping { get; set; }
        /// <summary>Array of order by expression to use in the report.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigSorting[] DatasetSorting { get; set; }
        /// <summary>User input name of the view. Required.</summary>
        string DisplayName { get; set; }
        /// <summary>List of KPIs to show in Cost Analysis UI.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IKpiProperties[] Kpi { get; set; }
        /// <summary>Metric to use when displaying costs.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.MetricType? Metric { get; set; }
        /// <summary>Date when the user last modified this view.</summary>
        global::System.DateTime? ModifiedOn { get; set; }
        /// <summary>Configuration of 3 sub-views in the Cost Analysis UI.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IPivotProperties[] Pivot { get; set; }
        /// <summary>Query body configuration. Required.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinition Query { get; set; }
        /// <summary>Has definition for data in this report config.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDataset QueryDataset { get; set; }
        /// <summary>Has time period for pulling data for the report.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigTimePeriod QueryTimePeriod { get; set; }
        /// <summary>
        /// The time frame for pulling data for the report. If custom, then a specific time period must be provided.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportTimeframeType? QueryTimeframe { get; set; }
        /// <summary>
        /// The type of the report. Usage represents actual usage, forecast represents forecasted data and UsageAndForecast represents
        /// both usage and forecasted data. Actual usage and forecasted data can be differentiated based on dates.
        /// </summary>
        string QueryType { get; set; }
        /// <summary>
        /// Cost Management scope to save the view on. This includes 'subscriptions/{subscriptionId}' for subscription scope, 'subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}'
        /// for resourceGroup scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}'
        /// for Department scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}'
        /// for EnrollmentAccount scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}'
        /// for BillingProfile scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/invoiceSections/{invoiceSectionId}'
        /// for InvoiceSection scope, 'providers/Microsoft.Management/managementGroups/{managementGroupId}' for Management Group scope,
        /// '/providers/Microsoft.CostManagement/externalBillingAccounts/{externalBillingAccountName}' for ExternalBillingAccount
        /// scope, and '/providers/Microsoft.CostManagement/externalSubscriptions/{externalSubscriptionName}' for ExternalSubscription
        /// scope.
        /// </summary>
        string Scope { get; set; }
        /// <summary>The start date to pull data from.</summary>
        global::System.DateTime? TimePeriodFrom { get; set; }
        /// <summary>The end date to pull data to.</summary>
        global::System.DateTime? TimePeriodTo { get; set; }

    }
}
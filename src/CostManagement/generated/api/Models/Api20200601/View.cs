namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>States and configurations of Cost Analysis.</summary>
    public partial class View :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IView,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResource __proxyResource = new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ProxyResource();

        /// <summary>Show costs accumulated over time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AccumulatedType? Accumulated { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).Accumulated; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).Accumulated = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AccumulatedType)""); }

        /// <summary>Chart type of the main view in Cost Analysis. Required.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ChartType? Chart { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).Chart; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).Chart = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ChartType)""); }

        /// <summary>
        /// Array of column names to be included in the report. Any valid report column name is allowed. If not provided, then report
        /// includes all columns.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] ConfigurationColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).ConfigurationColumn; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).ConfigurationColumn = value ?? null /* arrayOf */; }

        /// <summary>Date the user created this view.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? CreatedOn { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).CreatedOn; }

        /// <summary>
        /// Dictionary of aggregation expression to use in the report. The key of each item in the dictionary is the alias for the
        /// aggregated column. Report can have up to 2 aggregation clauses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetAggregation DatasetAggregation { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).DatasetAggregation; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).DatasetAggregation = value ?? null /* model class */; }

        /// <summary>Has filter expression to use in the report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter DatasetFilter { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).DatasetFilter; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).DatasetFilter = value ?? null /* model class */; }

        /// <summary>The granularity of rows in the report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType? DatasetGranularity { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).DatasetGranularity; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).DatasetGranularity = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType)""); }

        /// <summary>
        /// Array of group by expression to use in the report. Report can have up to 2 group by clauses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigGrouping[] DatasetGrouping { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).DatasetGrouping; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).DatasetGrouping = value ?? null /* arrayOf */; }

        /// <summary>Array of order by expression to use in the report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigSorting[] DatasetSorting { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).DatasetSorting; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).DatasetSorting = value ?? null /* arrayOf */; }

        /// <summary>User input name of the view. Required.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).DisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).DisplayName = value ?? null; }

        /// <summary>
        /// eTag of the resource. To handle concurrent update scenario, this field will be used to determine whether the user is updating
        /// the latest version or not.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public string ETag { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)__proxyResource).ETag; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)__proxyResource).ETag = value ?? null; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)__proxyResource).Id; }

        /// <summary>List of KPIs to show in Cost Analysis UI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IKpiProperties[] Kpi { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).Kpi; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).Kpi = value ?? null /* arrayOf */; }

        /// <summary>Metric to use when displaying costs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.MetricType? Metric { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).Metric; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).Metric = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.MetricType)""); }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)__proxyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)__proxyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)__proxyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)__proxyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)__proxyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)__proxyResource).Type = value; }

        /// <summary>Internal Acessors for CreatedOn</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal.CreatedOn { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).CreatedOn; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).CreatedOn = value; }

        /// <summary>Internal Acessors for DatasetConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetConfiguration Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal.DatasetConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).DatasetConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).DatasetConfiguration = value; }

        /// <summary>Internal Acessors for ModifiedOn</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal.ModifiedOn { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).ModifiedOn; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).ModifiedOn = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewProperties Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ViewProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Query</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinition Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal.Query { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).Query; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).Query = value; }

        /// <summary>Internal Acessors for QueryDataset</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDataset Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal.QueryDataset { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).QueryDataset; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).QueryDataset = value; }

        /// <summary>Internal Acessors for QueryTimePeriod</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigTimePeriod Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal.QueryTimePeriod { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).QueryTimePeriod; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).QueryTimePeriod = value; }

        /// <summary>Internal Acessors for QueryType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal.QueryType { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).QueryType; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).QueryType = value; }

        /// <summary>Date when the user last modified this view.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? ModifiedOn { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).ModifiedOn; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)__proxyResource).Name; }

        /// <summary>Configuration of 3 sub-views in the Cost Analysis UI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IPivotProperties[] Pivot { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).Pivot; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).Pivot = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewProperties _property;

        /// <summary>The properties of the view.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ViewProperties()); set => this._property = value; }

        /// <summary>
        /// The time frame for pulling data for the report. If custom, then a specific time period must be provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportTimeframeType? QueryTimeframe { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).QueryTimeframe; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).QueryTimeframe = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportTimeframeType)""); }

        /// <summary>
        /// The type of the report. Usage represents actual usage, forecast represents forecasted data and UsageAndForecast represents
        /// both usage and forecasted data. Actual usage and forecasted data can be differentiated based on dates.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string QueryType { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).QueryType; }

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
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string Scope { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).Scope; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).Scope = value ?? null; }

        /// <summary>The start date to pull data from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? TimePeriodFrom { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).TimePeriodFrom; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).TimePeriodFrom = value ?? default(global::System.DateTime); }

        /// <summary>The end date to pull data to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? TimePeriodTo { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).TimePeriodTo; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewPropertiesInternal)Property).TimePeriodTo = value ?? default(global::System.DateTime); }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)__proxyResource).Type; }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyResource), __proxyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyResource), __proxyResource);
        }

        /// <summary>Creates an new <see cref="View" /> instance.</summary>
        public View()
        {

        }
    }
    /// States and configurations of Cost Analysis.
    public partial interface IView :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResource
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
    /// States and configurations of Cost Analysis.
    public partial interface IViewInternal :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal
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
        /// <summary>The properties of the view.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewProperties Property { get; set; }
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
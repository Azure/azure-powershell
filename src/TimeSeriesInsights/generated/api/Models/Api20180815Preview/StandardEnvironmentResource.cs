namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>
    /// An environment is a set of time-series data available for query, and is the top level Azure Time Series Insights resource.
    /// Standard environments have data retention limits.
    /// </summary>
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.DoNotFormat]
    public partial class StandardEnvironmentResource :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentResource,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResource __environmentResource = new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.EnvironmentResource();

        /// <summary>
        /// The fully qualified domain name used to access the environment data, e.g. to query the environment's events or upload
        /// reference data for the environment.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public string DataAccessFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).DataAccessFqdn; }

        /// <summary>
        /// An id used to access the environment data, e.g. to query the environment's events or upload reference data for the environment.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public string DataAccessId { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).DataAccessId; }

        /// <summary>
        /// ISO8601 timespan specifying the minimum number of days the environment's events will be available for query.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public global::System.TimeSpan DataRetentionTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreationPropertiesInternal)Property).DataRetentionTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreationPropertiesInternal)Property).DataRetentionTime = value; }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IResourceInternal)__environmentResource).Id; }

        /// <summary>
        /// This string represents the state of ingress operations on an environment. It can be "Disabled", "Ready", "Running", "Paused"
        /// or "Unknown"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.IngressState? IngressState { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).IngressState; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).IngressState = value; }

        /// <summary>The kind of the environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourceInternal)__environmentResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourceInternal)__environmentResource).Kind = value; }

        /// <summary>Resource location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITrackedResourceInternal)__environmentResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITrackedResourceInternal)__environmentResource).Location = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IResourceInternal)__environmentResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IResourceInternal)__environmentResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IResourceInternal)__environmentResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IResourceInternal)__environmentResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IResourceInternal)__environmentResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IResourceInternal)__environmentResource).Type = value; }

        /// <summary>Internal Acessors for DataAccessFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentResourceInternal.DataAccessFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).DataAccessFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).DataAccessFqdn = value; }

        /// <summary>Internal Acessors for DataAccessId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentResourceInternal.DataAccessId { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).DataAccessId; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).DataAccessId = value; }

        /// <summary>Internal Acessors for IngressStateDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentStateDetails Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentResourceInternal.IngressStateDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).IngressStateDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).IngressStateDetail = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentResourceProperties Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.StandardEnvironmentResourceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for PropertyUsageStateDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IWarmStoragePropertiesUsageStateDetails Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentResourceInternal.PropertyUsageStateDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).PropertyUsageStateDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).PropertyUsageStateDetail = value; }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentStatus Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentResourceInternal.Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).Status = value; }

        /// <summary>Internal Acessors for StatusIngress</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IIngressEnvironmentStatus Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentResourceInternal.StatusIngress { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).StatusIngress; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).StatusIngress = value; }

        /// <summary>Internal Acessors for StatusWarmStorage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IWarmStorageEnvironmentStatus Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentResourceInternal.StatusWarmStorage { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).StatusWarmStorage; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).StatusWarmStorage = value; }

        /// <summary>Internal Acessors for WarmStoragePropertiesUsage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IWarmStoragePropertiesUsage Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentResourceInternal.WarmStoragePropertiesUsage { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).WarmStoragePropertiesUsage; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).WarmStoragePropertiesUsage = value; }

        /// <summary>Resource name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IResourceInternal)__environmentResource).Name; }

        /// <summary>
        /// The list of event properties which will be used to partition data in the environment.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITimeSeriesIdProperty[] PartitionKeyProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreationPropertiesInternal)Property).PartitionKeyProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreationPropertiesInternal)Property).PartitionKeyProperty = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentResourceProperties _property;

        /// <summary>Properties of the standard environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentResourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.StandardEnvironmentResourceProperties()); set => this._property = value; }

        /// <summary>
        /// This string represents the state of warm storage properties usage. It can be "Ok", "Error", "Unknown".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.WarmStoragePropertiesState? PropertyUsageState { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).PropertyUsageState; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).PropertyUsageState = value; }

        /// <summary>
        /// The sku determines the type of environment, either standard (S1 or S2) or long-term (L1). For standard environments the
        /// sku determines the capacity of the environment, the ingress rate, and the billing rate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ISku Sku { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourceInternal)__environmentResource).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourceInternal)__environmentResource).Sku = value; }

        /// <summary>
        /// The capacity of the sku. For standard environments, this value can be changed to support scale out of environments after
        /// they have been created.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public int SkuCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourceInternal)__environmentResource).SkuCapacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourceInternal)__environmentResource).SkuCapacity = value; }

        /// <summary>The name of this SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.SkuName SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourceInternal)__environmentResource).SkuName; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourceInternal)__environmentResource).SkuName = value; }

        /// <summary>
        /// Contains the code that represents the reason of an environment being in a particular state. Can be used to programmatically
        /// handle specific cases.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public string StateDetailCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).StateDetailCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).StateDetailCode = value; }

        /// <summary>
        /// A value that represents the number of properties used by the environment for S1/S2 SKU and number of properties used by
        /// Warm Store for PAYG SKU
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public int? StateDetailCurrentCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).StateDetailCurrentCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).StateDetailCurrentCount = value; }

        /// <summary>
        /// A value that represents the maximum number of properties used allowed by the environment for S1/S2 SKU and maximum number
        /// of properties allowed by Warm Store for PAYG SKU.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public int? StateDetailMaxCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).StateDetailMaxCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).StateDetailMaxCount = value; }

        /// <summary>A message that describes the state in detail.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public string StateDetailMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).StateDetailMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourcePropertiesInternal)Property).StateDetailMessage = value; }

        /// <summary>
        /// The behavior the Time Series Insights service should take when the environment's capacity has been exceeded. If "PauseIngress"
        /// is specified, new events will not be read from the event source. If "PurgeOldData" is specified, new events will continue
        /// to be read and old events will be deleted from the environment. The default behavior is PurgeOldData.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.StorageLimitExceededBehavior? StorageLimitExceededBehavior { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreationPropertiesInternal)Property).StorageLimitExceededBehavior; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreationPropertiesInternal)Property).StorageLimitExceededBehavior = value; }

        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITrackedResourceInternal)__environmentResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITrackedResourceInternal)__environmentResource).Tag = value; }

        /// <summary>Resource type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IResourceInternal)__environmentResource).Type; }

        /// <summary>Creates an new <see cref="StandardEnvironmentResource" /> instance.</summary>
        public StandardEnvironmentResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__environmentResource), __environmentResource);
            await eventListener.AssertObjectIsValid(nameof(__environmentResource), __environmentResource);
        }
    }
    /// An environment is a set of time-series data available for query, and is the top level Azure Time Series Insights resource.
    /// Standard environments have data retention limits.
    public partial interface IStandardEnvironmentResource :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResource
    {
        /// <summary>
        /// The fully qualified domain name used to access the environment data, e.g. to query the environment's events or upload
        /// reference data for the environment.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The fully qualified domain name used to access the environment data, e.g. to query the environment's events or upload reference data for the environment.",
        SerializedName = @"dataAccessFqdn",
        PossibleTypes = new [] { typeof(string) })]
        string DataAccessFqdn { get;  }
        /// <summary>
        /// An id used to access the environment data, e.g. to query the environment's events or upload reference data for the environment.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"An id used to access the environment data, e.g. to query the environment's events or upload reference data for the environment.",
        SerializedName = @"dataAccessId",
        PossibleTypes = new [] { typeof(string) })]
        string DataAccessId { get;  }
        /// <summary>
        /// ISO8601 timespan specifying the minimum number of days the environment's events will be available for query.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"ISO8601 timespan specifying the minimum number of days the environment's events will be available for query.",
        SerializedName = @"dataRetentionTime",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan DataRetentionTime { get; set; }
        /// <summary>
        /// This string represents the state of ingress operations on an environment. It can be "Disabled", "Ready", "Running", "Paused"
        /// or "Unknown"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This string represents the state of ingress operations on an environment. It can be ""Disabled"", ""Ready"", ""Running"", ""Paused"" or ""Unknown""",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.IngressState) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.IngressState? IngressState { get; set; }
        /// <summary>
        /// The list of event properties which will be used to partition data in the environment.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of event properties which will be used to partition data in the environment.",
        SerializedName = @"partitionKeyProperties",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITimeSeriesIdProperty) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITimeSeriesIdProperty[] PartitionKeyProperty { get; set; }
        /// <summary>
        /// This string represents the state of warm storage properties usage. It can be "Ok", "Error", "Unknown".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This string represents the state of warm storage properties usage. It can be ""Ok"", ""Error"", ""Unknown"".",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.WarmStoragePropertiesState) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.WarmStoragePropertiesState? PropertyUsageState { get; set; }
        /// <summary>
        /// Contains the code that represents the reason of an environment being in a particular state. Can be used to programmatically
        /// handle specific cases.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Contains the code that represents the reason of an environment being in a particular state. Can be used to programmatically handle specific cases.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string StateDetailCode { get; set; }
        /// <summary>
        /// A value that represents the number of properties used by the environment for S1/S2 SKU and number of properties used by
        /// Warm Store for PAYG SKU
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value that represents the number of properties used by the environment for S1/S2 SKU and number of properties used by Warm Store for PAYG SKU",
        SerializedName = @"currentCount",
        PossibleTypes = new [] { typeof(int) })]
        int? StateDetailCurrentCount { get; set; }
        /// <summary>
        /// A value that represents the maximum number of properties used allowed by the environment for S1/S2 SKU and maximum number
        /// of properties allowed by Warm Store for PAYG SKU.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value that represents the maximum number of properties used allowed by the environment for S1/S2 SKU and maximum number of properties allowed by Warm Store for PAYG SKU.",
        SerializedName = @"maxCount",
        PossibleTypes = new [] { typeof(int) })]
        int? StateDetailMaxCount { get; set; }
        /// <summary>A message that describes the state in detail.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A message that describes the state in detail.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string StateDetailMessage { get; set; }
        /// <summary>
        /// The behavior the Time Series Insights service should take when the environment's capacity has been exceeded. If "PauseIngress"
        /// is specified, new events will not be read from the event source. If "PurgeOldData" is specified, new events will continue
        /// to be read and old events will be deleted from the environment. The default behavior is PurgeOldData.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The behavior the Time Series Insights service should take when the environment's capacity has been exceeded. If ""PauseIngress"" is specified, new events will not be read from the event source. If ""PurgeOldData"" is specified, new events will continue to be read and old events will be deleted from the environment. The default behavior is PurgeOldData.",
        SerializedName = @"storageLimitExceededBehavior",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.StorageLimitExceededBehavior) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.StorageLimitExceededBehavior? StorageLimitExceededBehavior { get; set; }

    }
    /// An environment is a set of time-series data available for query, and is the top level Azure Time Series Insights resource.
    /// Standard environments have data retention limits.
    internal partial interface IStandardEnvironmentResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentResourceInternal
    {
        /// <summary>
        /// The fully qualified domain name used to access the environment data, e.g. to query the environment's events or upload
        /// reference data for the environment.
        /// </summary>
        string DataAccessFqdn { get; set; }
        /// <summary>
        /// An id used to access the environment data, e.g. to query the environment's events or upload reference data for the environment.
        /// </summary>
        string DataAccessId { get; set; }
        /// <summary>
        /// ISO8601 timespan specifying the minimum number of days the environment's events will be available for query.
        /// </summary>
        global::System.TimeSpan DataRetentionTime { get; set; }
        /// <summary>
        /// This string represents the state of ingress operations on an environment. It can be "Disabled", "Ready", "Running", "Paused"
        /// or "Unknown"
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.IngressState? IngressState { get; set; }
        /// <summary>An object that contains the details about an environment's state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentStateDetails IngressStateDetail { get; set; }
        /// <summary>
        /// The list of event properties which will be used to partition data in the environment.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITimeSeriesIdProperty[] PartitionKeyProperty { get; set; }
        /// <summary>Properties of the standard environment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentResourceProperties Property { get; set; }
        /// <summary>
        /// This string represents the state of warm storage properties usage. It can be "Ok", "Error", "Unknown".
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.WarmStoragePropertiesState? PropertyUsageState { get; set; }
        /// <summary>An object that contains the details about warm storage properties usage state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IWarmStoragePropertiesUsageStateDetails PropertyUsageStateDetail { get; set; }
        /// <summary>
        /// Contains the code that represents the reason of an environment being in a particular state. Can be used to programmatically
        /// handle specific cases.
        /// </summary>
        string StateDetailCode { get; set; }
        /// <summary>
        /// A value that represents the number of properties used by the environment for S1/S2 SKU and number of properties used by
        /// Warm Store for PAYG SKU
        /// </summary>
        int? StateDetailCurrentCount { get; set; }
        /// <summary>
        /// A value that represents the maximum number of properties used allowed by the environment for S1/S2 SKU and maximum number
        /// of properties allowed by Warm Store for PAYG SKU.
        /// </summary>
        int? StateDetailMaxCount { get; set; }
        /// <summary>A message that describes the state in detail.</summary>
        string StateDetailMessage { get; set; }
        /// <summary>
        /// An object that represents the status of the environment, and its internal state in the Time Series Insights service.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentStatus Status { get; set; }
        /// <summary>An object that represents the status of ingress on an environment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IIngressEnvironmentStatus StatusIngress { get; set; }
        /// <summary>An object that represents the status of warm storage on an environment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IWarmStorageEnvironmentStatus StatusWarmStorage { get; set; }
        /// <summary>
        /// The behavior the Time Series Insights service should take when the environment's capacity has been exceeded. If "PauseIngress"
        /// is specified, new events will not be read from the event source. If "PurgeOldData" is specified, new events will continue
        /// to be read and old events will be deleted from the environment. The default behavior is PurgeOldData.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.StorageLimitExceededBehavior? StorageLimitExceededBehavior { get; set; }
        /// <summary>An object that contains the status of warm storage properties usage.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IWarmStoragePropertiesUsage WarmStoragePropertiesUsage { get; set; }

    }
}
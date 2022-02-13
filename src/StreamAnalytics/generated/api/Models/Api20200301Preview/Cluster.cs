namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>A Stream Analytics Cluster object</summary>
    public partial class Cluster :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.ICluster,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.ITrackedResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.TrackedResource();

        /// <summary>Represents the number of streaming units currently being used on the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public int? CapacityAllocated { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterPropertiesInternal)Property).CapacityAllocated; }

        /// <summary>
        /// Represents the sum of the SUs of all streaming jobs associated with the cluster. If all of the jobs were running, this
        /// would be the capacity allocated.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public int? CapacityAssigned { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterPropertiesInternal)Property).CapacityAssigned; }

        /// <summary>Unique identifier for the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string ClusterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterPropertiesInternal)Property).ClusterId; }

        /// <summary>The date this cluster was created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public global::System.DateTime? CreatedDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterPropertiesInternal)Property).CreatedDate; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>
        /// The current entity tag for the cluster. This is an opaque string. You can use it to detect whether the resource has changed
        /// between requests. You can also use it in the If-Match or If-None-Match headers for write operations for optimistic concurrency.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; }

        /// <summary>
        /// Fully qualified resource Id for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal)__trackedResource).Id; }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.ITrackedResourceInternal)__trackedResource).Location = value ?? null; }

        /// <summary>Internal Acessors for CapacityAllocated</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterInternal.CapacityAllocated { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterPropertiesInternal)Property).CapacityAllocated; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterPropertiesInternal)Property).CapacityAllocated = value; }

        /// <summary>Internal Acessors for CapacityAssigned</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterInternal.CapacityAssigned { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterPropertiesInternal)Property).CapacityAssigned; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterPropertiesInternal)Property).CapacityAssigned = value; }

        /// <summary>Internal Acessors for ClusterId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterInternal.ClusterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterPropertiesInternal)Property).ClusterId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterPropertiesInternal)Property).ClusterId = value; }

        /// <summary>Internal Acessors for CreatedDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterInternal.CreatedDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterPropertiesInternal)Property).CreatedDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterPropertiesInternal)Property).CreatedDate = value; }

        /// <summary>Internal Acessors for Etag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterInternal.Etag { get => this._etag; set { {_etag = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterProperties Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.ClusterProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ClusterProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterSku Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.ClusterSku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal)__trackedResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal)__trackedResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal)__trackedResource).Type = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal)__trackedResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterProperties _property;

        /// <summary>The properties associated with a Stream Analytics cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.ClusterProperties()); set => this._property = value; }

        /// <summary>
        /// The status of the cluster provisioning. The three terminal states are: Succeeded, Failed and Canceled
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ClusterProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterPropertiesInternal)Property).ProvisioningState; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterSku _sku;

        /// <summary>
        /// The SKU of the cluster. This determines the size/capacity of the cluster. Required on PUT (CreateOrUpdate) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterSku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.ClusterSku()); set => this._sku = value; }

        /// <summary>
        /// Denotes the number of streaming units the cluster can support. Valid values for this property are multiples of 36 with
        /// a minimum value of 36 and maximum value of 216. Required on PUT (CreateOrUpdate) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public int? SkuCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterSkuInternal)Sku).Capacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterSkuInternal)Sku).Capacity = value ?? default(int); }

        /// <summary>
        /// Specifies the SKU name of the cluster. Required on PUT (CreateOrUpdate) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ClusterSkuName? SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterSkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterSkuInternal)Sku).Name = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ClusterSkuName)""); }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.ITrackedResourceInternal)__trackedResource).Tag = value ?? null /* model class */; }

        /// <summary>
        /// The type of the resource. Ex- Microsoft.Compute/virtualMachines or Microsoft.Storage/storageAccounts.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal)__trackedResource).Type; }

        /// <summary>Creates an new <see cref="Cluster" /> instance.</summary>
        public Cluster()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// A Stream Analytics Cluster object
    public partial interface ICluster :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.ITrackedResource
    {
        /// <summary>Represents the number of streaming units currently being used on the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Represents the number of streaming units currently being used on the cluster.",
        SerializedName = @"capacityAllocated",
        PossibleTypes = new [] { typeof(int) })]
        int? CapacityAllocated { get;  }
        /// <summary>
        /// Represents the sum of the SUs of all streaming jobs associated with the cluster. If all of the jobs were running, this
        /// would be the capacity allocated.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Represents the sum of the SUs of all streaming jobs associated with the cluster. If all of the jobs were running, this would be the capacity allocated.",
        SerializedName = @"capacityAssigned",
        PossibleTypes = new [] { typeof(int) })]
        int? CapacityAssigned { get;  }
        /// <summary>Unique identifier for the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Unique identifier for the cluster.",
        SerializedName = @"clusterId",
        PossibleTypes = new [] { typeof(string) })]
        string ClusterId { get;  }
        /// <summary>The date this cluster was created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The date this cluster was created.",
        SerializedName = @"createdDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreatedDate { get;  }
        /// <summary>
        /// The current entity tag for the cluster. This is an opaque string. You can use it to detect whether the resource has changed
        /// between requests. You can also use it in the If-Match or If-None-Match headers for write operations for optimistic concurrency.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The current entity tag for the cluster. This is an opaque string. You can use it to detect whether the resource has changed between requests. You can also use it in the If-Match or If-None-Match headers for write operations for optimistic concurrency.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get;  }
        /// <summary>
        /// The status of the cluster provisioning. The three terminal states are: Succeeded, Failed and Canceled
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The status of the cluster provisioning. The three terminal states are: Succeeded, Failed and Canceled",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ClusterProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ClusterProvisioningState? ProvisioningState { get;  }
        /// <summary>
        /// Denotes the number of streaming units the cluster can support. Valid values for this property are multiples of 36 with
        /// a minimum value of 36 and maximum value of 216. Required on PUT (CreateOrUpdate) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Denotes the number of streaming units the cluster can support. Valid values for this property are multiples of 36 with a minimum value of 36 and maximum value of 216. Required on PUT (CreateOrUpdate) requests.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? SkuCapacity { get; set; }
        /// <summary>
        /// Specifies the SKU name of the cluster. Required on PUT (CreateOrUpdate) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the SKU name of the cluster. Required on PUT (CreateOrUpdate) requests.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ClusterSkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ClusterSkuName? SkuName { get; set; }

    }
    /// A Stream Analytics Cluster object
    internal partial interface IClusterInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.ITrackedResourceInternal
    {
        /// <summary>Represents the number of streaming units currently being used on the cluster.</summary>
        int? CapacityAllocated { get; set; }
        /// <summary>
        /// Represents the sum of the SUs of all streaming jobs associated with the cluster. If all of the jobs were running, this
        /// would be the capacity allocated.
        /// </summary>
        int? CapacityAssigned { get; set; }
        /// <summary>Unique identifier for the cluster.</summary>
        string ClusterId { get; set; }
        /// <summary>The date this cluster was created.</summary>
        global::System.DateTime? CreatedDate { get; set; }
        /// <summary>
        /// The current entity tag for the cluster. This is an opaque string. You can use it to detect whether the resource has changed
        /// between requests. You can also use it in the If-Match or If-None-Match headers for write operations for optimistic concurrency.
        /// </summary>
        string Etag { get; set; }
        /// <summary>The properties associated with a Stream Analytics cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterProperties Property { get; set; }
        /// <summary>
        /// The status of the cluster provisioning. The three terminal states are: Succeeded, Failed and Canceled
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ClusterProvisioningState? ProvisioningState { get; set; }
        /// <summary>
        /// The SKU of the cluster. This determines the size/capacity of the cluster. Required on PUT (CreateOrUpdate) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterSku Sku { get; set; }
        /// <summary>
        /// Denotes the number of streaming units the cluster can support. Valid values for this property are multiples of 36 with
        /// a minimum value of 36 and maximum value of 216. Required on PUT (CreateOrUpdate) requests.
        /// </summary>
        int? SkuCapacity { get; set; }
        /// <summary>
        /// Specifies the SKU name of the cluster. Required on PUT (CreateOrUpdate) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ClusterSkuName? SkuName { get; set; }

    }
}
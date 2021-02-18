namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Worker pool of an App Service Environment ARM resource.</summary>
    public partial class WorkerPoolResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResource,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Current number of instances assigned to the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? Capacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).Capacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).Capacity = value; }

        /// <summary>Shared or dedicated app hosting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions? ComputeMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolInternal)Property).ComputeMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolInternal)Property).ComputeMode = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Names of all instances in the worker pool (read only).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] InstanceName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolInternal)Property).InstanceName; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Internal Acessors for InstanceName</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal.InstanceName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolInternal)Property).InstanceName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolInternal)Property).InstanceName = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPool Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.WorkerPool()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescription Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuDescription()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for SkuCapacity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal.SkuCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).SkuCapacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).SkuCapacity = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPool _property;

        /// <summary>Core resource properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPool Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.WorkerPool()); set => this._property = value; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescription _sku;

        /// <summary>Description of a SKU for a scalable resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescription Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuDescription()); set => this._sku = value; }

        /// <summary>Capabilities of the SKU, e.g., is traffic manager enabled?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability[] SkuCapability { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).Capability; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).Capability = value; }

        /// <summary>Default number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? SkuCapacityDefault { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).SkuCapacityDefault; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).SkuCapacityDefault = value; }

        /// <summary>Maximum number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? SkuCapacityMaximum { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).SkuCapacityMaximum; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).SkuCapacityMaximum = value; }

        /// <summary>Minimum number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? SkuCapacityMinimum { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).SkuCapacityMinimum; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).SkuCapacityMinimum = value; }

        /// <summary>Available scale configurations for an App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SkuCapacityScaleType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).SkuCapacityScaleType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).SkuCapacityScaleType = value; }

        /// <summary>Family code of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SkuFamily { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).Family; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).Family = value; }

        /// <summary>Locations of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] SkuLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).Location = value; }

        /// <summary>Name of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).Name = value; }

        /// <summary>Size specifier of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SkuSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).Size; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).Size = value; }

        /// <summary>Service tier of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).Tier = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Number of instances in the worker pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? WorkerCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolInternal)Property).WorkerCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolInternal)Property).WorkerCount = value; }

        /// <summary>VM size of the worker pool instances.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string WorkerSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolInternal)Property).WorkerSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolInternal)Property).WorkerSize = value; }

        /// <summary>Worker size ID for referencing this worker pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? WorkerSizeId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolInternal)Property).WorkerSizeId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolInternal)Property).WorkerSizeId = value; }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }

        /// <summary>Creates an new <see cref="WorkerPoolResource" /> instance.</summary>
        public WorkerPoolResource()
        {

        }
    }
    /// Worker pool of an App Service Environment ARM resource.
    public partial interface IWorkerPoolResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>Current number of instances assigned to the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Current number of instances assigned to the resource.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? Capacity { get; set; }
        /// <summary>Shared or dedicated app hosting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Shared or dedicated app hosting.",
        SerializedName = @"computeMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions? ComputeMode { get; set; }
        /// <summary>Names of all instances in the worker pool (read only).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Names of all instances in the worker pool (read only).",
        SerializedName = @"instanceNames",
        PossibleTypes = new [] { typeof(string) })]
        string[] InstanceName { get;  }
        /// <summary>Capabilities of the SKU, e.g., is traffic manager enabled?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Capabilities of the SKU, e.g., is traffic manager enabled?",
        SerializedName = @"capabilities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability[] SkuCapability { get; set; }
        /// <summary>Default number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Default number of workers for this App Service plan SKU.",
        SerializedName = @"default",
        PossibleTypes = new [] { typeof(int) })]
        int? SkuCapacityDefault { get; set; }
        /// <summary>Maximum number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum number of workers for this App Service plan SKU.",
        SerializedName = @"maximum",
        PossibleTypes = new [] { typeof(int) })]
        int? SkuCapacityMaximum { get; set; }
        /// <summary>Minimum number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minimum number of workers for this App Service plan SKU.",
        SerializedName = @"minimum",
        PossibleTypes = new [] { typeof(int) })]
        int? SkuCapacityMinimum { get; set; }
        /// <summary>Available scale configurations for an App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Available scale configurations for an App Service plan.",
        SerializedName = @"scaleType",
        PossibleTypes = new [] { typeof(string) })]
        string SkuCapacityScaleType { get; set; }
        /// <summary>Family code of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Family code of the resource SKU.",
        SerializedName = @"family",
        PossibleTypes = new [] { typeof(string) })]
        string SkuFamily { get; set; }
        /// <summary>Locations of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Locations of the SKU.",
        SerializedName = @"locations",
        PossibleTypes = new [] { typeof(string) })]
        string[] SkuLocation { get; set; }
        /// <summary>Name of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the resource SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string SkuName { get; set; }
        /// <summary>Size specifier of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Size specifier of the resource SKU.",
        SerializedName = @"size",
        PossibleTypes = new [] { typeof(string) })]
        string SkuSize { get; set; }
        /// <summary>Service tier of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Service tier of the resource SKU.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        string SkuTier { get; set; }
        /// <summary>Number of instances in the worker pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of instances in the worker pool.",
        SerializedName = @"workerCount",
        PossibleTypes = new [] { typeof(int) })]
        int? WorkerCount { get; set; }
        /// <summary>VM size of the worker pool instances.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VM size of the worker pool instances.",
        SerializedName = @"workerSize",
        PossibleTypes = new [] { typeof(string) })]
        string WorkerSize { get; set; }
        /// <summary>Worker size ID for referencing this worker pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Worker size ID for referencing this worker pool.",
        SerializedName = @"workerSizeId",
        PossibleTypes = new [] { typeof(int) })]
        int? WorkerSizeId { get; set; }

    }
    /// Worker pool of an App Service Environment ARM resource.
    internal partial interface IWorkerPoolResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>Current number of instances assigned to the resource.</summary>
        int? Capacity { get; set; }
        /// <summary>Shared or dedicated app hosting.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions? ComputeMode { get; set; }
        /// <summary>Names of all instances in the worker pool (read only).</summary>
        string[] InstanceName { get; set; }
        /// <summary>Core resource properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPool Property { get; set; }
        /// <summary>Description of a SKU for a scalable resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescription Sku { get; set; }
        /// <summary>Capabilities of the SKU, e.g., is traffic manager enabled?</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability[] SkuCapability { get; set; }
        /// <summary>Min, max, and default scale values of the SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity SkuCapacity { get; set; }
        /// <summary>Default number of workers for this App Service plan SKU.</summary>
        int? SkuCapacityDefault { get; set; }
        /// <summary>Maximum number of workers for this App Service plan SKU.</summary>
        int? SkuCapacityMaximum { get; set; }
        /// <summary>Minimum number of workers for this App Service plan SKU.</summary>
        int? SkuCapacityMinimum { get; set; }
        /// <summary>Available scale configurations for an App Service plan.</summary>
        string SkuCapacityScaleType { get; set; }
        /// <summary>Family code of the resource SKU.</summary>
        string SkuFamily { get; set; }
        /// <summary>Locations of the SKU.</summary>
        string[] SkuLocation { get; set; }
        /// <summary>Name of the resource SKU.</summary>
        string SkuName { get; set; }
        /// <summary>Size specifier of the resource SKU.</summary>
        string SkuSize { get; set; }
        /// <summary>Service tier of the resource SKU.</summary>
        string SkuTier { get; set; }
        /// <summary>Number of instances in the worker pool.</summary>
        int? WorkerCount { get; set; }
        /// <summary>VM size of the worker pool instances.</summary>
        string WorkerSize { get; set; }
        /// <summary>Worker size ID for referencing this worker pool.</summary>
        int? WorkerSizeId { get; set; }

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The resource requirements.</summary>
    public partial class ResourceRequirements :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirements,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal
    {

        /// <summary>Backing field for <see cref="Limit" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceLimits _limit;

        /// <summary>The resource limits of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceLimits Limit { get => (this._limit = this._limit ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ResourceLimits()); set => this._limit = value; }

        /// <summary>The CPU limit of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public double? LimitCpu { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceLimitsInternal)Limit).Cpu; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceLimitsInternal)Limit).Cpu = value ?? default(double); }

        /// <summary>The memory limit in GB of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public double? LimitMemoryInGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceLimitsInternal)Limit).MemoryInGb; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceLimitsInternal)Limit).MemoryInGb = value ?? default(double); }

        /// <summary>The count of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? LimitsGpuCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceLimitsInternal)Limit).GpuCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceLimitsInternal)Limit).GpuCount = value ?? default(int); }

        /// <summary>The SKU of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku? LimitsGpuSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceLimitsInternal)Limit).GpuSku; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceLimitsInternal)Limit).GpuSku = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku)""); }

        /// <summary>Internal Acessors for Limit</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceLimits Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal.Limit { get => (this._limit = this._limit ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ResourceLimits()); set { {_limit = value;} } }

        /// <summary>Internal Acessors for LimitGpu</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResource Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal.LimitGpu { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceLimitsInternal)Limit).Gpu; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceLimitsInternal)Limit).Gpu = value; }

        /// <summary>Internal Acessors for Request</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequests Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal.Request { get => (this._request = this._request ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ResourceRequests()); set { {_request = value;} } }

        /// <summary>Internal Acessors for RequestGpu</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResource Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal.RequestGpu { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)Request).Gpu; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)Request).Gpu = value; }

        /// <summary>Backing field for <see cref="Request" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequests _request;

        /// <summary>The resource requests of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequests Request { get => (this._request = this._request ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ResourceRequests()); set => this._request = value; }

        /// <summary>The CPU request of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public double RequestCpu { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)Request).Cpu; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)Request).Cpu = value ; }

        /// <summary>The memory request in GB of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public double RequestMemoryInGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)Request).MemoryInGb; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)Request).MemoryInGb = value ; }

        /// <summary>The count of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? RequestsGpuCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)Request).GpuCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)Request).GpuCount = value ?? default(int); }

        /// <summary>The SKU of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku? RequestsGpuSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)Request).GpuSku; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)Request).GpuSku = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku)""); }

        /// <summary>Creates an new <see cref="ResourceRequirements" /> instance.</summary>
        public ResourceRequirements()
        {

        }
    }
    /// The resource requirements.
    public partial interface IResourceRequirements :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The CPU limit of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The CPU limit of this container instance.",
        SerializedName = @"cpu",
        PossibleTypes = new [] { typeof(double) })]
        double? LimitCpu { get; set; }
        /// <summary>The memory limit in GB of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The memory limit in GB of this container instance.",
        SerializedName = @"memoryInGB",
        PossibleTypes = new [] { typeof(double) })]
        double? LimitMemoryInGb { get; set; }
        /// <summary>The count of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The count of the GPU resource.",
        SerializedName = @"count",
        PossibleTypes = new [] { typeof(int) })]
        int? LimitsGpuCount { get; set; }
        /// <summary>The SKU of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The SKU of the GPU resource.",
        SerializedName = @"sku",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku? LimitsGpuSku { get; set; }
        /// <summary>The CPU request of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The CPU request of this container instance.",
        SerializedName = @"cpu",
        PossibleTypes = new [] { typeof(double) })]
        double RequestCpu { get; set; }
        /// <summary>The memory request in GB of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The memory request in GB of this container instance.",
        SerializedName = @"memoryInGB",
        PossibleTypes = new [] { typeof(double) })]
        double RequestMemoryInGb { get; set; }
        /// <summary>The count of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The count of the GPU resource.",
        SerializedName = @"count",
        PossibleTypes = new [] { typeof(int) })]
        int? RequestsGpuCount { get; set; }
        /// <summary>The SKU of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The SKU of the GPU resource.",
        SerializedName = @"sku",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku? RequestsGpuSku { get; set; }

    }
    /// The resource requirements.
    internal partial interface IResourceRequirementsInternal

    {
        /// <summary>The resource limits of this container instance.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceLimits Limit { get; set; }
        /// <summary>The CPU limit of this container instance.</summary>
        double? LimitCpu { get; set; }
        /// <summary>The GPU limit of this container instance.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResource LimitGpu { get; set; }
        /// <summary>The memory limit in GB of this container instance.</summary>
        double? LimitMemoryInGb { get; set; }
        /// <summary>The count of the GPU resource.</summary>
        int? LimitsGpuCount { get; set; }
        /// <summary>The SKU of the GPU resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku? LimitsGpuSku { get; set; }
        /// <summary>The resource requests of this container instance.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequests Request { get; set; }
        /// <summary>The CPU request of this container instance.</summary>
        double RequestCpu { get; set; }
        /// <summary>The GPU request of this container instance.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResource RequestGpu { get; set; }
        /// <summary>The memory request in GB of this container instance.</summary>
        double RequestMemoryInGb { get; set; }
        /// <summary>The count of the GPU resource.</summary>
        int? RequestsGpuCount { get; set; }
        /// <summary>The SKU of the GPU resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku? RequestsGpuSku { get; set; }

    }
}
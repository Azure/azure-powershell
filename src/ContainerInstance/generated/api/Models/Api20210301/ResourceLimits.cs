namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The resource limits.</summary>
    public partial class ResourceLimits :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceLimits,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceLimitsInternal
    {

        /// <summary>Backing field for <see cref="Cpu" /> property.</summary>
        private double? _cpu;

        /// <summary>The CPU limit of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public double? Cpu { get => this._cpu; set => this._cpu = value; }

        /// <summary>Backing field for <see cref="Gpu" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResource _gpu;

        /// <summary>The GPU limit of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResource Gpu { get => (this._gpu = this._gpu ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.GpuResource()); set => this._gpu = value; }

        /// <summary>The count of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? GpuCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResourceInternal)Gpu).Count; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResourceInternal)Gpu).Count = value ?? default(int); }

        /// <summary>The SKU of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku? GpuSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResourceInternal)Gpu).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResourceInternal)Gpu).Sku = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku)""); }

        /// <summary>Backing field for <see cref="MemoryInGb" /> property.</summary>
        private double? _memoryInGb;

        /// <summary>The memory limit in GB of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public double? MemoryInGb { get => this._memoryInGb; set => this._memoryInGb = value; }

        /// <summary>Internal Acessors for Gpu</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResource Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceLimitsInternal.Gpu { get => (this._gpu = this._gpu ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.GpuResource()); set { {_gpu = value;} } }

        /// <summary>Creates an new <see cref="ResourceLimits" /> instance.</summary>
        public ResourceLimits()
        {

        }
    }
    /// The resource limits.
    public partial interface IResourceLimits :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The CPU limit of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The CPU limit of this container instance.",
        SerializedName = @"cpu",
        PossibleTypes = new [] { typeof(double) })]
        double? Cpu { get; set; }
        /// <summary>The count of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The count of the GPU resource.",
        SerializedName = @"count",
        PossibleTypes = new [] { typeof(int) })]
        int? GpuCount { get; set; }
        /// <summary>The SKU of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The SKU of the GPU resource.",
        SerializedName = @"sku",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku? GpuSku { get; set; }
        /// <summary>The memory limit in GB of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The memory limit in GB of this container instance.",
        SerializedName = @"memoryInGB",
        PossibleTypes = new [] { typeof(double) })]
        double? MemoryInGb { get; set; }

    }
    /// The resource limits.
    internal partial interface IResourceLimitsInternal

    {
        /// <summary>The CPU limit of this container instance.</summary>
        double? Cpu { get; set; }
        /// <summary>The GPU limit of this container instance.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResource Gpu { get; set; }
        /// <summary>The count of the GPU resource.</summary>
        int? GpuCount { get; set; }
        /// <summary>The SKU of the GPU resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku? GpuSku { get; set; }
        /// <summary>The memory limit in GB of this container instance.</summary>
        double? MemoryInGb { get; set; }

    }
}
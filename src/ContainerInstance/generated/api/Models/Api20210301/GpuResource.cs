namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The GPU resource.</summary>
    public partial class GpuResource :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResource,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResourceInternal
    {

        /// <summary>Backing field for <see cref="Count" /> property.</summary>
        private int _count;

        /// <summary>The count of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public int Count { get => this._count; set => this._count = value; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku _sku;

        /// <summary>The SKU of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku Sku { get => this._sku; set => this._sku = value; }

        /// <summary>Creates an new <see cref="GpuResource" /> instance.</summary>
        public GpuResource()
        {

        }
    }
    /// The GPU resource.
    public partial interface IGpuResource :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The count of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The count of the GPU resource.",
        SerializedName = @"count",
        PossibleTypes = new [] { typeof(int) })]
        int Count { get; set; }
        /// <summary>The SKU of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The SKU of the GPU resource.",
        SerializedName = @"sku",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku Sku { get; set; }

    }
    /// The GPU resource.
    internal partial interface IGpuResourceInternal

    {
        /// <summary>The count of the GPU resource.</summary>
        int Count { get; set; }
        /// <summary>The SKU of the GPU resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku Sku { get; set; }

    }
}
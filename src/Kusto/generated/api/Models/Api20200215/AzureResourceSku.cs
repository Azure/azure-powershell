namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Azure resource SKU definition.</summary>
    public partial class AzureResourceSku :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureResourceSku,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureResourceSkuInternal
    {

        /// <summary>Backing field for <see cref="Capacity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureCapacity _capacity;

        /// <summary>The number of instances of the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureCapacity Capacity { get => (this._capacity = this._capacity ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.AzureCapacity()); set => this._capacity = value; }

        /// <summary>The default capacity that would be used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public int CapacityDefault { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureCapacityInternal)Capacity).Default; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureCapacityInternal)Capacity).Default = value; }

        /// <summary>Maximum allowed capacity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public int CapacityMaximum { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureCapacityInternal)Capacity).Maximum; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureCapacityInternal)Capacity).Maximum = value; }

        /// <summary>Minimum allowed capacity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public int CapacityMinimum { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureCapacityInternal)Capacity).Minimum; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureCapacityInternal)Capacity).Minimum = value; }

        /// <summary>Scale type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureScaleType CapacityScaleType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureCapacityInternal)Capacity).ScaleType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureCapacityInternal)Capacity).ScaleType = value; }

        /// <summary>Internal Acessors for Capacity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureCapacity Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureResourceSkuInternal.Capacity { get => (this._capacity = this._capacity ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.AzureCapacity()); set { {_capacity = value;} } }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureSku Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureResourceSkuInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.AzureSku()); set { {_sku = value;} } }

        /// <summary>Backing field for <see cref="ResourceType" /> property.</summary>
        private string _resourceType;

        /// <summary>Resource Namespace and Type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string ResourceType { get => this._resourceType; set => this._resourceType = value; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureSku _sku;

        /// <summary>The SKU details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureSku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.AzureSku()); set => this._sku = value; }

        /// <summary>The number of instances of the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public int? SkuCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureSkuInternal)Sku).Capacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureSkuInternal)Sku).Capacity = value; }

        /// <summary>SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureSkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureSkuInternal)Sku).Name = value; }

        /// <summary>SKU tier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureSkuInternal)Sku).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureSkuInternal)Sku).Tier = value; }

        /// <summary>Creates an new <see cref="AzureResourceSku" /> instance.</summary>
        public AzureResourceSku()
        {

        }
    }
    /// Azure resource SKU definition.
    public partial interface IAzureResourceSku :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The default capacity that would be used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The default capacity that would be used.",
        SerializedName = @"default",
        PossibleTypes = new [] { typeof(int) })]
        int CapacityDefault { get; set; }
        /// <summary>Maximum allowed capacity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Maximum allowed capacity.",
        SerializedName = @"maximum",
        PossibleTypes = new [] { typeof(int) })]
        int CapacityMaximum { get; set; }
        /// <summary>Minimum allowed capacity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Minimum allowed capacity.",
        SerializedName = @"minimum",
        PossibleTypes = new [] { typeof(int) })]
        int CapacityMinimum { get; set; }
        /// <summary>Scale type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Scale type.",
        SerializedName = @"scaleType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureScaleType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureScaleType CapacityScaleType { get; set; }
        /// <summary>Resource Namespace and Type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource Namespace and Type.",
        SerializedName = @"resourceType",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceType { get; set; }
        /// <summary>The number of instances of the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The number of instances of the cluster.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? SkuCapacity { get; set; }
        /// <summary>SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"SKU name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName SkuName { get; set; }
        /// <summary>SKU tier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"SKU tier.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier SkuTier { get; set; }

    }
    /// Azure resource SKU definition.
    internal partial interface IAzureResourceSkuInternal

    {
        /// <summary>The number of instances of the cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureCapacity Capacity { get; set; }
        /// <summary>The default capacity that would be used.</summary>
        int CapacityDefault { get; set; }
        /// <summary>Maximum allowed capacity.</summary>
        int CapacityMaximum { get; set; }
        /// <summary>Minimum allowed capacity.</summary>
        int CapacityMinimum { get; set; }
        /// <summary>Scale type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureScaleType CapacityScaleType { get; set; }
        /// <summary>Resource Namespace and Type.</summary>
        string ResourceType { get; set; }
        /// <summary>The SKU details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureSku Sku { get; set; }
        /// <summary>The number of instances of the cluster.</summary>
        int? SkuCapacity { get; set; }
        /// <summary>SKU name.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName SkuName { get; set; }
        /// <summary>SKU tier.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier SkuTier { get; set; }

    }
}
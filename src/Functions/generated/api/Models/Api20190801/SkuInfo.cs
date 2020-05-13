namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>SKU discovery information.</summary>
    public partial class SkuInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfo,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal
    {

        /// <summary>Backing field for <see cref="Capacity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity _capacity;

        /// <summary>Min, max, and default scale values of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity Capacity { get => (this._capacity = this._capacity ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuCapacity()); set => this._capacity = value; }

        /// <summary>Default number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? CapacityDefault { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacityInternal)Capacity).Default; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacityInternal)Capacity).Default = value; }

        /// <summary>Maximum number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? CapacityMaximum { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacityInternal)Capacity).Maximum; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacityInternal)Capacity).Maximum = value; }

        /// <summary>Minimum number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? CapacityMinimum { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacityInternal)Capacity).Minimum; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacityInternal)Capacity).Minimum = value; }

        /// <summary>Available scale configurations for an App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CapacityScaleType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacityInternal)Capacity).ScaleType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacityInternal)Capacity).ScaleType = value; }

        /// <summary>Internal Acessors for Capacity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal.Capacity { get => (this._capacity = this._capacity ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuCapacity()); set { {_capacity = value;} } }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescription Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuDescription()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for SkuCapacity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal.SkuCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).SkuCapacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).SkuCapacity = value; }

        /// <summary>Backing field for <see cref="ResourceType" /> property.</summary>
        private string _resourceType;

        /// <summary>Resource type that this SKU applies to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ResourceType { get => this._resourceType; set => this._resourceType = value; }

        /// <summary>Current number of instances assigned to the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? Schemas576Capacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).Capacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)Sku).Capacity = value; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescription _sku;

        /// <summary>Name and tier of the SKU.</summary>
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

        /// <summary>Creates an new <see cref="SkuInfo" /> instance.</summary>
        public SkuInfo()
        {

        }
    }
    /// SKU discovery information.
    public partial interface ISkuInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Default number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Default number of workers for this App Service plan SKU.",
        SerializedName = @"default",
        PossibleTypes = new [] { typeof(int) })]
        int? CapacityDefault { get; set; }
        /// <summary>Maximum number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum number of workers for this App Service plan SKU.",
        SerializedName = @"maximum",
        PossibleTypes = new [] { typeof(int) })]
        int? CapacityMaximum { get; set; }
        /// <summary>Minimum number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minimum number of workers for this App Service plan SKU.",
        SerializedName = @"minimum",
        PossibleTypes = new [] { typeof(int) })]
        int? CapacityMinimum { get; set; }
        /// <summary>Available scale configurations for an App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Available scale configurations for an App Service plan.",
        SerializedName = @"scaleType",
        PossibleTypes = new [] { typeof(string) })]
        string CapacityScaleType { get; set; }
        /// <summary>Resource type that this SKU applies to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource type that this SKU applies to.",
        SerializedName = @"resourceType",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceType { get; set; }
        /// <summary>Current number of instances assigned to the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Current number of instances assigned to the resource.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? Schemas576Capacity { get; set; }
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

    }
    /// SKU discovery information.
    internal partial interface ISkuInfoInternal

    {
        /// <summary>Min, max, and default scale values of the SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity Capacity { get; set; }
        /// <summary>Default number of workers for this App Service plan SKU.</summary>
        int? CapacityDefault { get; set; }
        /// <summary>Maximum number of workers for this App Service plan SKU.</summary>
        int? CapacityMaximum { get; set; }
        /// <summary>Minimum number of workers for this App Service plan SKU.</summary>
        int? CapacityMinimum { get; set; }
        /// <summary>Available scale configurations for an App Service plan.</summary>
        string CapacityScaleType { get; set; }
        /// <summary>Resource type that this SKU applies to.</summary>
        string ResourceType { get; set; }
        /// <summary>Current number of instances assigned to the resource.</summary>
        int? Schemas576Capacity { get; set; }
        /// <summary>Name and tier of the SKU.</summary>
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

    }
}
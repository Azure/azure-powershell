namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Description of a SKU for a scalable resource.</summary>
    public partial class SkuDescription :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescription,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal
    {

        /// <summary>Backing field for <see cref="Capability" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability[] _capability;

        /// <summary>Capabilities of the SKU, e.g., is traffic manager enabled?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability[] Capability { get => this._capability; set => this._capability = value; }

        /// <summary>Backing field for <see cref="Capacity" /> property.</summary>
        private int? _capacity;

        /// <summary>Current number of instances assigned to the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Capacity { get => this._capacity; set => this._capacity = value; }

        /// <summary>Backing field for <see cref="Family" /> property.</summary>
        private string _family;

        /// <summary>Family code of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Family { get => this._family; set => this._family = value; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string[] _location;

        /// <summary>Locations of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] Location { get => this._location; set => this._location = value; }

        /// <summary>Internal Acessors for SkuCapacity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal.SkuCapacity { get => (this._skuCapacity = this._skuCapacity ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuCapacity()); set { {_skuCapacity = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Size" /> property.</summary>
        private string _size;

        /// <summary>Size specifier of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Size { get => this._size; set => this._size = value; }

        /// <summary>Backing field for <see cref="SkuCapacity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity _skuCapacity;

        /// <summary>Min, max, and default scale values of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity SkuCapacity { get => (this._skuCapacity = this._skuCapacity ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuCapacity()); set => this._skuCapacity = value; }

        /// <summary>Default number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? SkuCapacityDefault { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacityInternal)SkuCapacity).Default; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacityInternal)SkuCapacity).Default = value; }

        /// <summary>Maximum number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? SkuCapacityMaximum { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacityInternal)SkuCapacity).Maximum; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacityInternal)SkuCapacity).Maximum = value; }

        /// <summary>Minimum number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? SkuCapacityMinimum { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacityInternal)SkuCapacity).Minimum; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacityInternal)SkuCapacity).Minimum = value; }

        /// <summary>Available scale configurations for an App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SkuCapacityScaleType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacityInternal)SkuCapacity).ScaleType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacityInternal)SkuCapacity).ScaleType = value; }

        /// <summary>Backing field for <see cref="Tier" /> property.</summary>
        private string _tier;

        /// <summary>Service tier of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Tier { get => this._tier; set => this._tier = value; }

        /// <summary>Creates an new <see cref="SkuDescription" /> instance.</summary>
        public SkuDescription()
        {

        }
    }
    /// Description of a SKU for a scalable resource.
    public partial interface ISkuDescription :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Capabilities of the SKU, e.g., is traffic manager enabled?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Capabilities of the SKU, e.g., is traffic manager enabled?",
        SerializedName = @"capabilities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability[] Capability { get; set; }
        /// <summary>Current number of instances assigned to the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Current number of instances assigned to the resource.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? Capacity { get; set; }
        /// <summary>Family code of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Family code of the resource SKU.",
        SerializedName = @"family",
        PossibleTypes = new [] { typeof(string) })]
        string Family { get; set; }
        /// <summary>Locations of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Locations of the SKU.",
        SerializedName = @"locations",
        PossibleTypes = new [] { typeof(string) })]
        string[] Location { get; set; }
        /// <summary>Name of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the resource SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Size specifier of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Size specifier of the resource SKU.",
        SerializedName = @"size",
        PossibleTypes = new [] { typeof(string) })]
        string Size { get; set; }
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
        /// <summary>Service tier of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Service tier of the resource SKU.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        string Tier { get; set; }

    }
    /// Description of a SKU for a scalable resource.
    internal partial interface ISkuDescriptionInternal

    {
        /// <summary>Capabilities of the SKU, e.g., is traffic manager enabled?</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability[] Capability { get; set; }
        /// <summary>Current number of instances assigned to the resource.</summary>
        int? Capacity { get; set; }
        /// <summary>Family code of the resource SKU.</summary>
        string Family { get; set; }
        /// <summary>Locations of the SKU.</summary>
        string[] Location { get; set; }
        /// <summary>Name of the resource SKU.</summary>
        string Name { get; set; }
        /// <summary>Size specifier of the resource SKU.</summary>
        string Size { get; set; }
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
        /// <summary>Service tier of the resource SKU.</summary>
        string Tier { get; set; }

    }
}
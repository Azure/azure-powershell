namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>A Global SKU Description.</summary>
    public partial class GlobalCsmSkuDescription :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGlobalCsmSkuDescription,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGlobalCsmSkuDescriptionInternal
    {

        /// <summary>Backing field for <see cref="Capability" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability[] _capability;

        /// <summary>Capabilities of the SKU, e.g., is traffic manager enabled?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability[] Capability { get => this._capability; set => this._capability = value; }

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

        /// <summary>Internal Acessors for Capacity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGlobalCsmSkuDescriptionInternal.Capacity { get => (this._capacity = this._capacity ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuCapacity()); set { {_capacity = value;} } }

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

        /// <summary>Backing field for <see cref="Tier" /> property.</summary>
        private string _tier;

        /// <summary>Service Tier of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Tier { get => this._tier; set => this._tier = value; }

        /// <summary>Creates an new <see cref="GlobalCsmSkuDescription" /> instance.</summary>
        public GlobalCsmSkuDescription()
        {

        }
    }
    /// A Global SKU Description.
    public partial interface IGlobalCsmSkuDescription :
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
        /// <summary>Service Tier of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Service Tier of the resource SKU.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        string Tier { get; set; }

    }
    /// A Global SKU Description.
    internal partial interface IGlobalCsmSkuDescriptionInternal

    {
        /// <summary>Capabilities of the SKU, e.g., is traffic manager enabled?</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability[] Capability { get; set; }
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
        /// <summary>Family code of the resource SKU.</summary>
        string Family { get; set; }
        /// <summary>Locations of the SKU.</summary>
        string[] Location { get; set; }
        /// <summary>Name of the resource SKU.</summary>
        string Name { get; set; }
        /// <summary>Size specifier of the resource SKU.</summary>
        string Size { get; set; }
        /// <summary>Service Tier of the resource SKU.</summary>
        string Tier { get; set; }

    }
}
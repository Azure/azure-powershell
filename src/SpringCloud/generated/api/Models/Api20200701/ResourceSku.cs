namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Describes an available Azure Spring Cloud SKU.</summary>
    public partial class ResourceSku :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSku,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal
    {

        /// <summary>Backing field for <see cref="Capacity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISkuCapacity _capacity;

        /// <summary>Gets the capacity of SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISkuCapacity Capacity { get => (this._capacity = this._capacity ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.SkuCapacity()); set => this._capacity = value; }

        /// <summary>Gets or sets the default.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public int? CapacityDefault { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISkuCapacityInternal)Capacity).Default; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISkuCapacityInternal)Capacity).Default = value; }

        /// <summary>Gets or sets the maximum.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public int? CapacityMaximum { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISkuCapacityInternal)Capacity).Maximum; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISkuCapacityInternal)Capacity).Maximum = value; }

        /// <summary>Gets or sets the minimum.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public int CapacityMinimum { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISkuCapacityInternal)Capacity).Minimum; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISkuCapacityInternal)Capacity).Minimum = value; }

        /// <summary>Gets or sets the type of the scale.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.SkuScaleType? CapacityScaleType { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISkuCapacityInternal)Capacity).ScaleType; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISkuCapacityInternal)Capacity).ScaleType = value; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string[] _location;

        /// <summary>Gets the set of locations that the SKU is available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string[] Location { get => this._location; set => this._location = value; }

        /// <summary>Backing field for <see cref="LocationInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuLocationInfo[] _locationInfo;

        /// <summary>
        /// Gets a list of locations and availability zones in those locations where the SKU is available.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuLocationInfo[] LocationInfo { get => this._locationInfo; set => this._locationInfo = value; }

        /// <summary>Internal Acessors for Capacity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISkuCapacity Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal.Capacity { get => (this._capacity = this._capacity ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.SkuCapacity()); set { {_capacity = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Gets the name of SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="ResourceType" /> property.</summary>
        private string _resourceType;

        /// <summary>Gets the type of resource the SKU applies to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string ResourceType { get => this._resourceType; set => this._resourceType = value; }

        /// <summary>Backing field for <see cref="Restriction" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictions[] _restriction;

        /// <summary>
        /// Gets the restrictions because of which SKU cannot be used. This is
        /// empty if there are no restrictions.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictions[] Restriction { get => this._restriction; set => this._restriction = value; }

        /// <summary>Backing field for <see cref="Tier" /> property.</summary>
        private string _tier;

        /// <summary>Gets the tier of SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Tier { get => this._tier; set => this._tier = value; }

        /// <summary>Creates an new <see cref="ResourceSku" /> instance.</summary>
        public ResourceSku()
        {

        }
    }
    /// Describes an available Azure Spring Cloud SKU.
    public partial interface IResourceSku :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the default.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the default.",
        SerializedName = @"default",
        PossibleTypes = new [] { typeof(int) })]
        int? CapacityDefault { get; set; }
        /// <summary>Gets or sets the maximum.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the maximum.",
        SerializedName = @"maximum",
        PossibleTypes = new [] { typeof(int) })]
        int? CapacityMaximum { get; set; }
        /// <summary>Gets or sets the minimum.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Gets or sets the minimum.",
        SerializedName = @"minimum",
        PossibleTypes = new [] { typeof(int) })]
        int CapacityMinimum { get; set; }
        /// <summary>Gets or sets the type of the scale.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the type of the scale.",
        SerializedName = @"scaleType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.SkuScaleType) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.SkuScaleType? CapacityScaleType { get; set; }
        /// <summary>Gets the set of locations that the SKU is available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the set of locations that the SKU is available.",
        SerializedName = @"locations",
        PossibleTypes = new [] { typeof(string) })]
        string[] Location { get; set; }
        /// <summary>
        /// Gets a list of locations and availability zones in those locations where the SKU is available.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets a list of locations and availability zones in those locations where the SKU is available.",
        SerializedName = @"locationInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuLocationInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuLocationInfo[] LocationInfo { get; set; }
        /// <summary>Gets the name of SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the name of SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Gets the type of resource the SKU applies to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the type of resource the SKU applies to.",
        SerializedName = @"resourceType",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceType { get; set; }
        /// <summary>
        /// Gets the restrictions because of which SKU cannot be used. This is
        /// empty if there are no restrictions.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the restrictions because of which SKU cannot be used. This is
        empty if there are no restrictions.",
        SerializedName = @"restrictions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictions) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictions[] Restriction { get; set; }
        /// <summary>Gets the tier of SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the tier of SKU.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        string Tier { get; set; }

    }
    /// Describes an available Azure Spring Cloud SKU.
    public partial interface IResourceSkuInternal

    {
        /// <summary>Gets the capacity of SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISkuCapacity Capacity { get; set; }
        /// <summary>Gets or sets the default.</summary>
        int? CapacityDefault { get; set; }
        /// <summary>Gets or sets the maximum.</summary>
        int? CapacityMaximum { get; set; }
        /// <summary>Gets or sets the minimum.</summary>
        int CapacityMinimum { get; set; }
        /// <summary>Gets or sets the type of the scale.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.SkuScaleType? CapacityScaleType { get; set; }
        /// <summary>Gets the set of locations that the SKU is available.</summary>
        string[] Location { get; set; }
        /// <summary>
        /// Gets a list of locations and availability zones in those locations where the SKU is available.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuLocationInfo[] LocationInfo { get; set; }
        /// <summary>Gets the name of SKU.</summary>
        string Name { get; set; }
        /// <summary>Gets the type of resource the SKU applies to.</summary>
        string ResourceType { get; set; }
        /// <summary>
        /// Gets the restrictions because of which SKU cannot be used. This is
        /// empty if there are no restrictions.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictions[] Restriction { get; set; }
        /// <summary>Gets the tier of SKU.</summary>
        string Tier { get; set; }

    }
}
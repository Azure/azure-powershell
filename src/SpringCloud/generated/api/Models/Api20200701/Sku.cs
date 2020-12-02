namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Sku of Azure Spring Cloud</summary>
    public partial class Sku :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISku,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISkuInternal
    {

        /// <summary>Backing field for <see cref="Capacity" /> property.</summary>
        private int? _capacity;

        /// <summary>Current capacity of the target resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public int? Capacity { get => this._capacity; set => this._capacity = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the Sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Tier" /> property.</summary>
        private string _tier;

        /// <summary>Tier of the Sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Tier { get => this._tier; set => this._tier = value; }

        /// <summary>Creates an new <see cref="Sku" /> instance.</summary>
        public Sku()
        {

        }
    }
    /// Sku of Azure Spring Cloud
    public partial interface ISku :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>Current capacity of the target resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Current capacity of the target resource",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? Capacity { get; set; }
        /// <summary>Name of the Sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the Sku",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Tier of the Sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Tier of the Sku",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        string Tier { get; set; }

    }
    /// Sku of Azure Spring Cloud
    public partial interface ISkuInternal

    {
        /// <summary>Current capacity of the target resource</summary>
        int? Capacity { get; set; }
        /// <summary>Name of the Sku</summary>
        string Name { get; set; }
        /// <summary>Tier of the Sku</summary>
        string Tier { get; set; }

    }
}
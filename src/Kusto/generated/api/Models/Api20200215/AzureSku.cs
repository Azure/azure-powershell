namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Azure SKU definition.</summary>
    public partial class AzureSku :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureSku,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureSkuInternal
    {

        /// <summary>Backing field for <see cref="Capacity" /> property.</summary>
        private int? _capacity;

        /// <summary>The number of instances of the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public int? Capacity { get => this._capacity; set => this._capacity = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName _name;

        /// <summary>SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Tier" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier _tier;

        /// <summary>SKU tier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier Tier { get => this._tier; set => this._tier = value; }

        /// <summary>Creates an new <see cref="AzureSku" /> instance.</summary>
        public AzureSku()
        {

        }
    }
    /// Azure SKU definition.
    public partial interface IAzureSku :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The number of instances of the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The number of instances of the cluster.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? Capacity { get; set; }
        /// <summary>SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"SKU name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName Name { get; set; }
        /// <summary>SKU tier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"SKU tier.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier Tier { get; set; }

    }
    /// Azure SKU definition.
    internal partial interface IAzureSkuInternal

    {
        /// <summary>The number of instances of the cluster.</summary>
        int? Capacity { get; set; }
        /// <summary>SKU name.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName Name { get; set; }
        /// <summary>SKU tier.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier Tier { get; set; }

    }
}
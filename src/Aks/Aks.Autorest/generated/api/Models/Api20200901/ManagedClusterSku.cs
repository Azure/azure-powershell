namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    public partial class ManagedClusterSku :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterSku,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterSkuInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ManagedClusterSkuName? _name;

        /// <summary>Name of a managed cluster SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ManagedClusterSkuName? Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Tier" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ManagedClusterSkuTier? _tier;

        /// <summary>Tier of a managed cluster SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ManagedClusterSkuTier? Tier { get => this._tier; set => this._tier = value; }

        /// <summary>Creates an new <see cref="ManagedClusterSku" /> instance.</summary>
        public ManagedClusterSku()
        {

        }
    }
    public partial interface IManagedClusterSku :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>Name of a managed cluster SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of a managed cluster SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ManagedClusterSkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ManagedClusterSkuName? Name { get; set; }
        /// <summary>Tier of a managed cluster SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Tier of a managed cluster SKU.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ManagedClusterSkuTier) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ManagedClusterSkuTier? Tier { get; set; }

    }
    internal partial interface IManagedClusterSkuInternal

    {
        /// <summary>Name of a managed cluster SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ManagedClusterSkuName? Name { get; set; }
        /// <summary>Tier of a managed cluster SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ManagedClusterSkuTier? Tier { get; set; }

    }
}
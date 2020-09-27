namespace Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Extensions;

    public partial class Sku :
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.ISku,
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.ISkuInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>SKU of the dedicated HSM</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="Sku" /> instance.</summary>
        public Sku()
        {

        }
    }
    public partial interface ISku :
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.IJsonSerializable
    {
        /// <summary>SKU of the dedicated HSM</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SKU of the dedicated HSM",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    internal partial interface ISkuInternal

    {
        /// <summary>SKU of the dedicated HSM</summary>
        string Name { get; set; }

    }
}
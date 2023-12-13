namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>SKU details</summary>
    public partial class Sku :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ISku,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ISkuInternal
    {

        /// <summary>Backing field for <see cref="Family" /> property.</summary>
        private string _family= @"A";

        /// <summary>SKU family name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Family { get => this._family; }

        /// <summary>Internal Acessors for Family</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ISkuInternal.Family { get => this._family; set { {_family = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SkuName _name;

        /// <summary>
        /// SKU name to specify whether the key vault is a standard vault or a premium vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SkuName Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="Sku" /> instance.</summary>
        public Sku()
        {

        }
    }
    /// SKU details
    public partial interface ISku :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IJsonSerializable
    {
        /// <summary>SKU family name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Description = @"SKU family name",
        SerializedName = @"family",
        PossibleTypes = new [] { typeof(string) })]
        string Family { get;  }
        /// <summary>
        /// SKU name to specify whether the key vault is a standard vault or a premium vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"SKU name to specify whether the key vault is a standard vault or a premium vault.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SkuName Name { get; set; }

    }
    /// SKU details
    internal partial interface ISkuInternal

    {
        /// <summary>SKU family name</summary>
        string Family { get; set; }
        /// <summary>
        /// SKU name to specify whether the key vault is a standard vault or a premium vault.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SkuName Name { get; set; }

    }
}
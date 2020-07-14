namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>The parameters used to check the availability of the vault name.</summary>
    public partial class VaultCheckNameAvailabilityParameters :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCheckNameAvailabilityParameters,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCheckNameAvailabilityParametersInternal
    {

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCheckNameAvailabilityParametersInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The vault name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type= @"Microsoft.KeyVault/vaults";

        /// <summary>The type of resource, Microsoft.KeyVault/vaults</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="VaultCheckNameAvailabilityParameters" /> instance.</summary>
        public VaultCheckNameAvailabilityParameters()
        {

        }
    }
    /// The parameters used to check the availability of the vault name.
    public partial interface IVaultCheckNameAvailabilityParameters :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IJsonSerializable
    {
        /// <summary>The vault name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The vault name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The type of resource, Microsoft.KeyVault/vaults</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Description = @"The type of resource, Microsoft.KeyVault/vaults",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// The parameters used to check the availability of the vault name.
    internal partial interface IVaultCheckNameAvailabilityParametersInternal

    {
        /// <summary>The vault name.</summary>
        string Name { get; set; }
        /// <summary>The type of resource, Microsoft.KeyVault/vaults</summary>
        string Type { get; set; }

    }
}
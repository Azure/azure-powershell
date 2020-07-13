namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>List of vaults</summary>
    public partial class VaultListResult :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultListResult,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of vaults.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVault[] _value;

        /// <summary>The list of vaults.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVault[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="VaultListResult" /> instance.</summary>
        public VaultListResult()
        {

        }
    }
    /// List of vaults
    public partial interface IVaultListResult :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IJsonSerializable
    {
        /// <summary>The URL to get the next set of vaults.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URL to get the next set of vaults.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The list of vaults.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of vaults.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVault) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVault[] Value { get; set; }

    }
    /// List of vaults
    internal partial interface IVaultListResultInternal

    {
        /// <summary>The URL to get the next set of vaults.</summary>
        string NextLink { get; set; }
        /// <summary>The list of vaults.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVault[] Value { get; set; }

    }
}
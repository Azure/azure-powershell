namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The List SAS credentials operation response.</summary>
    public partial class ListAccountSasResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IListAccountSasResponse,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IListAccountSasResponseInternal
    {

        /// <summary>Backing field for <see cref="AccountSasToken" /> property.</summary>
        private string _accountSasToken;

        /// <summary>List SAS credentials of storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string AccountSasToken { get => this._accountSasToken; }

        /// <summary>Internal Acessors for AccountSasToken</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IListAccountSasResponseInternal.AccountSasToken { get => this._accountSasToken; set { {_accountSasToken = value;} } }

        /// <summary>Creates an new <see cref="ListAccountSasResponse" /> instance.</summary>
        public ListAccountSasResponse()
        {

        }
    }
    /// The List SAS credentials operation response.
    public partial interface IListAccountSasResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>List SAS credentials of storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List SAS credentials of storage account.",
        SerializedName = @"accountSasToken",
        PossibleTypes = new [] { typeof(string) })]
        string AccountSasToken { get;  }

    }
    /// The List SAS credentials operation response.
    internal partial interface IListAccountSasResponseInternal

    {
        /// <summary>List SAS credentials of storage account.</summary>
        string AccountSasToken { get; set; }

    }
}
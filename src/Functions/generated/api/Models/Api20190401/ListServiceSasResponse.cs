namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The List service SAS credentials operation response.</summary>
    public partial class ListServiceSasResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IListServiceSasResponse,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IListServiceSasResponseInternal
    {

        /// <summary>Internal Acessors for ServiceSasToken</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IListServiceSasResponseInternal.ServiceSasToken { get => this._serviceSasToken; set { {_serviceSasToken = value;} } }

        /// <summary>Backing field for <see cref="ServiceSasToken" /> property.</summary>
        private string _serviceSasToken;

        /// <summary>List service SAS credentials of specific resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ServiceSasToken { get => this._serviceSasToken; }

        /// <summary>Creates an new <see cref="ListServiceSasResponse" /> instance.</summary>
        public ListServiceSasResponse()
        {

        }
    }
    /// The List service SAS credentials operation response.
    public partial interface IListServiceSasResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>List service SAS credentials of specific resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List service SAS credentials of specific resource.",
        SerializedName = @"serviceSasToken",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceSasToken { get;  }

    }
    /// The List service SAS credentials operation response.
    internal partial interface IListServiceSasResponseInternal

    {
        /// <summary>List service SAS credentials of specific resource.</summary>
        string ServiceSasToken { get; set; }

    }
}
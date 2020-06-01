namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    public partial class BlobServiceItems :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServiceItems,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServiceItemsInternal
    {

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServiceProperties[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServiceItemsInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServiceProperties[] _value;

        /// <summary>List of blob services returned.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServiceProperties[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="BlobServiceItems" /> instance.</summary>
        public BlobServiceItems()
        {

        }
    }
    public partial interface IBlobServiceItems :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>List of blob services returned.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of blob services returned.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServiceProperties) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServiceProperties[] Value { get;  }

    }
    internal partial interface IBlobServiceItemsInternal

    {
        /// <summary>List of blob services returned.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServiceProperties[] Value { get; set; }

    }
}
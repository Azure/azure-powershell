namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The response from the List Storage SKUs operation.</summary>
    public partial class StorageSkuListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageSkuListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageSkuListResultInternal
    {

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISku[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageSkuListResultInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISku[] _value;

        /// <summary>Get the list result of storage SKUs and their properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISku[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="StorageSkuListResult" /> instance.</summary>
        public StorageSkuListResult()
        {

        }
    }
    /// The response from the List Storage SKUs operation.
    public partial interface IStorageSkuListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Get the list result of storage SKUs and their properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Get the list result of storage SKUs and their properties.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISku) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISku[] Value { get;  }

    }
    /// The response from the List Storage SKUs operation.
    internal partial interface IStorageSkuListResultInternal

    {
        /// <summary>Get the list result of storage SKUs and their properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISku[] Value { get; set; }

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Extensions;

    /// <summary>GetBitLockerKeys response</summary>
    public partial class GetBitLockerKeysResponse :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IGetBitLockerKeysResponse,
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IGetBitLockerKeysResponseInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveBitLockerKey[] _value;

        /// <summary>drive status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveBitLockerKey[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="GetBitLockerKeysResponse" /> instance.</summary>
        public GetBitLockerKeysResponse()
        {

        }
    }
    /// GetBitLockerKeys response
    public partial interface IGetBitLockerKeysResponse :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.IJsonSerializable
    {
        /// <summary>drive status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"drive status",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveBitLockerKey) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveBitLockerKey[] Value { get; set; }

    }
    /// GetBitLockerKeys response
    internal partial interface IGetBitLockerKeysResponseInternal

    {
        /// <summary>drive status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveBitLockerKey[] Value { get; set; }

    }
}
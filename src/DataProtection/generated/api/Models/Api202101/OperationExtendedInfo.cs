namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Operation Extended Info</summary>
    public partial class OperationExtendedInfo :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IOperationExtendedInfo,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IOperationExtendedInfoInternal
    {

        /// <summary>Backing field for <see cref="ObjectType" /> property.</summary>
        private string _objectType;

        /// <summary>
        /// This property will be used as the discriminator for deciding the specific types in the polymorphic chain of types.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string ObjectType { get => this._objectType; set => this._objectType = value; }

        /// <summary>Creates an new <see cref="OperationExtendedInfo" /> instance.</summary>
        public OperationExtendedInfo()
        {

        }
    }
    /// Operation Extended Info
    public partial interface IOperationExtendedInfo :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>
        /// This property will be used as the discriminator for deciding the specific types in the polymorphic chain of types.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This property will be used as the discriminator for deciding the specific types in the polymorphic chain of types.",
        SerializedName = @"objectType",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectType { get; set; }

    }
    /// Operation Extended Info
    internal partial interface IOperationExtendedInfoInternal

    {
        /// <summary>
        /// This property will be used as the discriminator for deciding the specific types in the polymorphic chain of types.
        /// </summary>
        string ObjectType { get; set; }

    }
}
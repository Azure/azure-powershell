namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Base class for Backup Feature support</summary>
    public partial class FeatureValidationRequestBase :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IFeatureValidationRequestBase,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IFeatureValidationRequestBaseInternal
    {

        /// <summary>Backing field for <see cref="ObjectType" /> property.</summary>
        private string _objectType;

        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string ObjectType { get => this._objectType; set => this._objectType = value; }

        /// <summary>Creates an new <see cref="FeatureValidationRequestBase" /> instance.</summary>
        public FeatureValidationRequestBase()
        {

        }
    }
    /// Base class for Backup Feature support
    public partial interface IFeatureValidationRequestBase :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Type of the specific object - used for deserializing",
        SerializedName = @"objectType",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectType { get; set; }

    }
    /// Base class for Backup Feature support
    internal partial interface IFeatureValidationRequestBaseInternal

    {
        /// <summary>Type of the specific object - used for deserializing</summary>
        string ObjectType { get; set; }

    }
}
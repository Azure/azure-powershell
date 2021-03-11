namespace Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Extensions;

    /// <summary>Specifies which access keys to reset to a new random value.</summary>
    public partial class RegenerateKeyParameters :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IRegenerateKeyParameters,
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IRegenerateKeyParametersInternal
    {

        /// <summary>Backing field for <see cref="KeyType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AccessKeyType _keyType;

        /// <summary>Which access key to regenerate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AccessKeyType KeyType { get => this._keyType; set => this._keyType = value; }

        /// <summary>Creates an new <see cref="RegenerateKeyParameters" /> instance.</summary>
        public RegenerateKeyParameters()
        {

        }
    }
    /// Specifies which access keys to reset to a new random value.
    public partial interface IRegenerateKeyParameters :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.IJsonSerializable
    {
        /// <summary>Which access key to regenerate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Which access key to regenerate.",
        SerializedName = @"keyType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AccessKeyType) })]
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AccessKeyType KeyType { get; set; }

    }
    /// Specifies which access keys to reset to a new random value.
    internal partial interface IRegenerateKeyParametersInternal

    {
        /// <summary>Which access key to regenerate.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AccessKeyType KeyType { get; set; }

    }
}
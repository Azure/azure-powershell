namespace Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Extensions;

    /// <summary>The secret access keys used for authenticating connections to redis</summary>
    public partial class AccessKeys :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IAccessKeys,
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IAccessKeysInternal
    {

        /// <summary>Internal Acessors for PrimaryKey</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IAccessKeysInternal.PrimaryKey { get => this._primaryKey; set { {_primaryKey = value;} } }

        /// <summary>Internal Acessors for SecondaryKey</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IAccessKeysInternal.SecondaryKey { get => this._secondaryKey; set { {_secondaryKey = value;} } }

        /// <summary>Backing field for <see cref="PrimaryKey" /> property.</summary>
        private string _primaryKey;

        /// <summary>The current primary key that clients can use to authenticate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public string PrimaryKey { get => this._primaryKey; }

        /// <summary>Backing field for <see cref="SecondaryKey" /> property.</summary>
        private string _secondaryKey;

        /// <summary>The current secondary key that clients can use to authenticate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public string SecondaryKey { get => this._secondaryKey; }

        /// <summary>Creates an new <see cref="AccessKeys" /> instance.</summary>
        public AccessKeys()
        {

        }
    }
    /// The secret access keys used for authenticating connections to redis
    public partial interface IAccessKeys :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.IJsonSerializable
    {
        /// <summary>The current primary key that clients can use to authenticate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The current primary key that clients can use to authenticate",
        SerializedName = @"primaryKey",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryKey { get;  }
        /// <summary>The current secondary key that clients can use to authenticate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The current secondary key that clients can use to authenticate",
        SerializedName = @"secondaryKey",
        PossibleTypes = new [] { typeof(string) })]
        string SecondaryKey { get;  }

    }
    /// The secret access keys used for authenticating connections to redis
    internal partial interface IAccessKeysInternal

    {
        /// <summary>The current primary key that clients can use to authenticate</summary>
        string PrimaryKey { get; set; }
        /// <summary>The current secondary key that clients can use to authenticate</summary>
        string SecondaryKey { get; set; }

    }
}
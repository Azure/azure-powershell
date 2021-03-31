namespace Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Extensions;

    /// <summary>Persistence-related configuration for the RedisEnterprise database</summary>
    public partial class Persistence :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IPersistence,
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IPersistenceInternal
    {

        /// <summary>Backing field for <see cref="AofEnabled" /> property.</summary>
        private bool? _aofEnabled;

        /// <summary>Sets whether AOF is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public bool? AofEnabled { get => this._aofEnabled; set => this._aofEnabled = value; }

        /// <summary>Backing field for <see cref="AofFrequency" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AofFrequency? _aofFrequency;

        /// <summary>Sets the frequency at which data is written to disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AofFrequency? AofFrequency { get => this._aofFrequency; set => this._aofFrequency = value; }

        /// <summary>Backing field for <see cref="RdbEnabled" /> property.</summary>
        private bool? _rdbEnabled;

        /// <summary>Sets whether RDB is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public bool? RdbEnabled { get => this._rdbEnabled; set => this._rdbEnabled = value; }

        /// <summary>Backing field for <see cref="RdbFrequency" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.RdbFrequency? _rdbFrequency;

        /// <summary>Sets the frequency at which a snapshot of the database is created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.RdbFrequency? RdbFrequency { get => this._rdbFrequency; set => this._rdbFrequency = value; }

        /// <summary>Creates an new <see cref="Persistence" /> instance.</summary>
        public Persistence()
        {

        }
    }
    /// Persistence-related configuration for the RedisEnterprise database
    public partial interface IPersistence :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.IJsonSerializable
    {
        /// <summary>Sets whether AOF is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sets whether AOF is enabled.",
        SerializedName = @"aofEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AofEnabled { get; set; }
        /// <summary>Sets the frequency at which data is written to disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sets the frequency at which data is written to disk.",
        SerializedName = @"aofFrequency",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AofFrequency) })]
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AofFrequency? AofFrequency { get; set; }
        /// <summary>Sets whether RDB is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sets whether RDB is enabled.",
        SerializedName = @"rdbEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? RdbEnabled { get; set; }
        /// <summary>Sets the frequency at which a snapshot of the database is created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sets the frequency at which a snapshot of the database is created.",
        SerializedName = @"rdbFrequency",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.RdbFrequency) })]
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.RdbFrequency? RdbFrequency { get; set; }

    }
    /// Persistence-related configuration for the RedisEnterprise database
    internal partial interface IPersistenceInternal

    {
        /// <summary>Sets whether AOF is enabled.</summary>
        bool? AofEnabled { get; set; }
        /// <summary>Sets the frequency at which data is written to disk.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AofFrequency? AofFrequency { get; set; }
        /// <summary>Sets whether RDB is enabled.</summary>
        bool? RdbEnabled { get; set; }
        /// <summary>Sets the frequency at which a snapshot of the database is created.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.RdbFrequency? RdbFrequency { get; set; }

    }
}
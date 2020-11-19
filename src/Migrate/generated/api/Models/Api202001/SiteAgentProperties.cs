namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class for site agent properties.</summary>
    public partial class SiteAgentProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>ID of the agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Backing field for <see cref="KeyVaultId" /> property.</summary>
        private string _keyVaultId;

        /// <summary>Key vault ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string KeyVaultId { get => this._keyVaultId; set => this._keyVaultId = value; }

        /// <summary>Backing field for <see cref="KeyVaultUri" /> property.</summary>
        private string _keyVaultUri;

        /// <summary>Key vault URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string KeyVaultUri { get => this._keyVaultUri; set => this._keyVaultUri = value; }

        /// <summary>Backing field for <see cref="LastHeartBeatUtc" /> property.</summary>
        private global::System.DateTime? _lastHeartBeatUtc;

        /// <summary>Last heartbeat time of the agent in UTC.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastHeartBeatUtc { get => this._lastHeartBeatUtc; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentPropertiesInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for LastHeartBeatUtc</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentPropertiesInternal.LastHeartBeatUtc { get => this._lastHeartBeatUtc; set { {_lastHeartBeatUtc = value;} } }

        /// <summary>Internal Acessors for Version</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentPropertiesInternal.Version { get => this._version; set { {_version = value;} } }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>Version of the agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Version { get => this._version; }

        /// <summary>Creates an new <see cref="SiteAgentProperties" /> instance.</summary>
        public SiteAgentProperties()
        {

        }
    }
    /// Class for site agent properties.
    public partial interface ISiteAgentProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>ID of the agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ID of the agent.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Key vault ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Key vault ARM Id.",
        SerializedName = @"keyVaultId",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultId { get; set; }
        /// <summary>Key vault URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Key vault URI.",
        SerializedName = @"keyVaultUri",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultUri { get; set; }
        /// <summary>Last heartbeat time of the agent in UTC.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Last heartbeat time of the agent in UTC.",
        SerializedName = @"lastHeartBeatUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastHeartBeatUtc { get;  }
        /// <summary>Version of the agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Version of the agent.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get;  }

    }
    /// Class for site agent properties.
    internal partial interface ISiteAgentPropertiesInternal

    {
        /// <summary>ID of the agent.</summary>
        string Id { get; set; }
        /// <summary>Key vault ARM Id.</summary>
        string KeyVaultId { get; set; }
        /// <summary>Key vault URI.</summary>
        string KeyVaultUri { get; set; }
        /// <summary>Last heartbeat time of the agent in UTC.</summary>
        global::System.DateTime? LastHeartBeatUtc { get; set; }
        /// <summary>Version of the agent.</summary>
        string Version { get; set; }

    }
}
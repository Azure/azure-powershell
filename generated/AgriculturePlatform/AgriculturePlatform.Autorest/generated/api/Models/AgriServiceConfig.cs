// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Extensions;

    /// <summary>Config of the AgriService resource instance.</summary>
    public partial class AgriServiceConfig :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfig,
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal
    {

        /// <summary>Backing field for <see cref="AppServiceResourceId" /> property.</summary>
        private string _appServiceResourceId;

        /// <summary>App service resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string AppServiceResourceId { get => this._appServiceResourceId; }

        /// <summary>Backing field for <see cref="CosmosDbResourceId" /> property.</summary>
        private string _cosmosDbResourceId;

        /// <summary>Cosmos Db resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string CosmosDbResourceId { get => this._cosmosDbResourceId; }

        /// <summary>Backing field for <see cref="InstanceUri" /> property.</summary>
        private string _instanceUri;

        /// <summary>Instance URI of the AgriService instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string InstanceUri { get => this._instanceUri; }

        /// <summary>Backing field for <see cref="KeyVaultResourceId" /> property.</summary>
        private string _keyVaultResourceId;

        /// <summary>Key vault resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string KeyVaultResourceId { get => this._keyVaultResourceId; }

        /// <summary>Internal Acessors for AppServiceResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal.AppServiceResourceId { get => this._appServiceResourceId; set { {_appServiceResourceId = value;} } }

        /// <summary>Internal Acessors for CosmosDbResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal.CosmosDbResourceId { get => this._cosmosDbResourceId; set { {_cosmosDbResourceId = value;} } }

        /// <summary>Internal Acessors for InstanceUri</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal.InstanceUri { get => this._instanceUri; set { {_instanceUri = value;} } }

        /// <summary>Internal Acessors for KeyVaultResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal.KeyVaultResourceId { get => this._keyVaultResourceId; set { {_keyVaultResourceId = value;} } }

        /// <summary>Internal Acessors for RedisCacheResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal.RedisCacheResourceId { get => this._redisCacheResourceId; set { {_redisCacheResourceId = value;} } }

        /// <summary>Internal Acessors for StorageAccountResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal.StorageAccountResourceId { get => this._storageAccountResourceId; set { {_storageAccountResourceId = value;} } }

        /// <summary>Internal Acessors for Version</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal.Version { get => this._version; set { {_version = value;} } }

        /// <summary>Backing field for <see cref="RedisCacheResourceId" /> property.</summary>
        private string _redisCacheResourceId;

        /// <summary>Redis cache resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string RedisCacheResourceId { get => this._redisCacheResourceId; }

        /// <summary>Backing field for <see cref="StorageAccountResourceId" /> property.</summary>
        private string _storageAccountResourceId;

        /// <summary>Storage account resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string StorageAccountResourceId { get => this._storageAccountResourceId; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>Version of AgriService instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string Version { get => this._version; }

        /// <summary>Creates an new <see cref="AgriServiceConfig" /> instance.</summary>
        public AgriServiceConfig()
        {

        }
    }
    /// Config of the AgriService resource instance.
    public partial interface IAgriServiceConfig :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IJsonSerializable
    {
        /// <summary>App service resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"App service resource Id.",
        SerializedName = @"appServiceResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string AppServiceResourceId { get;  }
        /// <summary>Cosmos Db resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Cosmos Db resource Id.",
        SerializedName = @"cosmosDbResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string CosmosDbResourceId { get;  }
        /// <summary>Instance URI of the AgriService instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Instance URI of the AgriService instance.",
        SerializedName = @"instanceUri",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceUri { get;  }
        /// <summary>Key vault resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Key vault resource Id.",
        SerializedName = @"keyVaultResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultResourceId { get;  }
        /// <summary>Redis cache resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Redis cache resource Id.",
        SerializedName = @"redisCacheResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string RedisCacheResourceId { get;  }
        /// <summary>Storage account resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Storage account resource Id.",
        SerializedName = @"storageAccountResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountResourceId { get;  }
        /// <summary>Version of AgriService instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Version of AgriService instance.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get;  }

    }
    /// Config of the AgriService resource instance.
    internal partial interface IAgriServiceConfigInternal

    {
        /// <summary>App service resource Id.</summary>
        string AppServiceResourceId { get; set; }
        /// <summary>Cosmos Db resource Id.</summary>
        string CosmosDbResourceId { get; set; }
        /// <summary>Instance URI of the AgriService instance.</summary>
        string InstanceUri { get; set; }
        /// <summary>Key vault resource Id.</summary>
        string KeyVaultResourceId { get; set; }
        /// <summary>Redis cache resource Id.</summary>
        string RedisCacheResourceId { get; set; }
        /// <summary>Storage account resource Id.</summary>
        string StorageAccountResourceId { get; set; }
        /// <summary>Version of AgriService instance.</summary>
        string Version { get; set; }

    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Extensions;

    /// <summary>The updatable properties of the AgriServiceResource.</summary>
    public partial class AgriServiceResourceUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateProperties,
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal
    {

        /// <summary>Backing field for <see cref="Config" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfig _config;

        /// <summary>Config of the AgriService instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfig Config { get => (this._config = this._config ?? new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceConfig()); set => this._config = value; }

        /// <summary>App service resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ConfigAppServiceResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal)Config).AppServiceResourceId; }

        /// <summary>Cosmos Db resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ConfigCosmosDbResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal)Config).CosmosDbResourceId; }

        /// <summary>Instance URI of the AgriService instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ConfigInstanceUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal)Config).InstanceUri; }

        /// <summary>Key vault resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ConfigKeyVaultResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal)Config).KeyVaultResourceId; }

        /// <summary>Redis cache resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ConfigRedisCacheResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal)Config).RedisCacheResourceId; }

        /// <summary>Storage account resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ConfigStorageAccountResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal)Config).StorageAccountResourceId; }

        /// <summary>Version of AgriService instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ConfigVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal)Config).Version; }

        /// <summary>Backing field for <see cref="DataConnectorCredentials" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap> _dataConnectorCredentials;

        /// <summary>Data connector credentials of AgriService instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap> DataConnectorCredentials { get => this._dataConnectorCredentials; set => this._dataConnectorCredentials = value; }

        /// <summary>Backing field for <see cref="InstalledSolution" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap> _installedSolution;

        /// <summary>AgriService installed solutions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap> InstalledSolution { get => this._installedSolution; set => this._installedSolution = value; }

        /// <summary>Internal Acessors for Config</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfig Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal.Config { get => (this._config = this._config ?? new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceConfig()); set { {_config = value;} } }

        /// <summary>Internal Acessors for ConfigAppServiceResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal.ConfigAppServiceResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal)Config).AppServiceResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal)Config).AppServiceResourceId = value; }

        /// <summary>Internal Acessors for ConfigCosmosDbResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal.ConfigCosmosDbResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal)Config).CosmosDbResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal)Config).CosmosDbResourceId = value; }

        /// <summary>Internal Acessors for ConfigInstanceUri</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal.ConfigInstanceUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal)Config).InstanceUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal)Config).InstanceUri = value; }

        /// <summary>Internal Acessors for ConfigKeyVaultResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal.ConfigKeyVaultResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal)Config).KeyVaultResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal)Config).KeyVaultResourceId = value; }

        /// <summary>Internal Acessors for ConfigRedisCacheResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal.ConfigRedisCacheResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal)Config).RedisCacheResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal)Config).RedisCacheResourceId = value; }

        /// <summary>Internal Acessors for ConfigStorageAccountResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal.ConfigStorageAccountResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal)Config).StorageAccountResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal)Config).StorageAccountResourceId = value; }

        /// <summary>Internal Acessors for ConfigVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal.ConfigVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal)Config).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfigInternal)Config).Version = value; }

        /// <summary>Creates an new <see cref="AgriServiceResourceUpdateProperties" /> instance.</summary>
        public AgriServiceResourceUpdateProperties()
        {

        }
    }
    /// The updatable properties of the AgriServiceResource.
    public partial interface IAgriServiceResourceUpdateProperties :
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
        string ConfigAppServiceResourceId { get;  }
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
        string ConfigCosmosDbResourceId { get;  }
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
        string ConfigInstanceUri { get;  }
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
        string ConfigKeyVaultResourceId { get;  }
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
        string ConfigRedisCacheResourceId { get;  }
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
        string ConfigStorageAccountResourceId { get;  }
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
        string ConfigVersion { get;  }
        /// <summary>Data connector credentials of AgriService instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Data connector credentials of AgriService instance.",
        SerializedName = @"dataConnectorCredentials",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap> DataConnectorCredentials { get; set; }
        /// <summary>AgriService installed solutions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"AgriService installed solutions.",
        SerializedName = @"installedSolutions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap> InstalledSolution { get; set; }

    }
    /// The updatable properties of the AgriServiceResource.
    internal partial interface IAgriServiceResourceUpdatePropertiesInternal

    {
        /// <summary>Config of the AgriService instance.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfig Config { get; set; }
        /// <summary>App service resource Id.</summary>
        string ConfigAppServiceResourceId { get; set; }
        /// <summary>Cosmos Db resource Id.</summary>
        string ConfigCosmosDbResourceId { get; set; }
        /// <summary>Instance URI of the AgriService instance.</summary>
        string ConfigInstanceUri { get; set; }
        /// <summary>Key vault resource Id.</summary>
        string ConfigKeyVaultResourceId { get; set; }
        /// <summary>Redis cache resource Id.</summary>
        string ConfigRedisCacheResourceId { get; set; }
        /// <summary>Storage account resource Id.</summary>
        string ConfigStorageAccountResourceId { get; set; }
        /// <summary>Version of AgriService instance.</summary>
        string ConfigVersion { get; set; }
        /// <summary>Data connector credentials of AgriService instance.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap> DataConnectorCredentials { get; set; }
        /// <summary>AgriService installed solutions.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap> InstalledSolution { get; set; }

    }
}
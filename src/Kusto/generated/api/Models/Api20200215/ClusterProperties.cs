namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Class representing the Kusto cluster properties.</summary>
    public partial class ClusterProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IClusterProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IClusterPropertiesInternal
    {

        /// <summary>Backing field for <see cref="DataIngestionUri" /> property.</summary>
        private string _dataIngestionUri;

        /// <summary>The cluster data ingestion URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string DataIngestionUri { get => this._dataIngestionUri; }

        /// <summary>Backing field for <see cref="EnableDiskEncryption" /> property.</summary>
        private bool? _enableDiskEncryption;

        /// <summary>A boolean value that indicates if the cluster's disks are encrypted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public bool? EnableDiskEncryption { get => this._enableDiskEncryption; set => this._enableDiskEncryption = value; }

        /// <summary>Backing field for <see cref="EnablePurge" /> property.</summary>
        private bool? _enablePurge;

        /// <summary>A boolean value that indicates if the purge operations are enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public bool? EnablePurge { get => this._enablePurge; set => this._enablePurge = value; }

        /// <summary>Backing field for <see cref="EnableStreamingIngest" /> property.</summary>
        private bool? _enableStreamingIngest;

        /// <summary>A boolean value that indicates if the streaming ingest is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public bool? EnableStreamingIngest { get => this._enableStreamingIngest; set => this._enableStreamingIngest = value; }

        /// <summary>Backing field for <see cref="KeyVaultProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IKeyVaultProperties _keyVaultProperty;

        /// <summary>KeyVault properties for the cluster encryption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IKeyVaultProperties KeyVaultProperty { get => (this._keyVaultProperty = this._keyVaultProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.KeyVaultProperties()); set => this._keyVaultProperty = value; }

        /// <summary>The name of the key vault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IKeyVaultPropertiesInternal)KeyVaultProperty).KeyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IKeyVaultPropertiesInternal)KeyVaultProperty).KeyName = value; }

        /// <summary>The Uri of the key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyVaultUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IKeyVaultPropertiesInternal)KeyVaultProperty).KeyVaultUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IKeyVaultPropertiesInternal)KeyVaultProperty).KeyVaultUri = value; }

        /// <summary>The version of the key vault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IKeyVaultPropertiesInternal)KeyVaultProperty).KeyVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IKeyVaultPropertiesInternal)KeyVaultProperty).KeyVersion = value; }

        /// <summary>Backing field for <see cref="LanguageExtension" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ILanguageExtensionsList _languageExtension;

        /// <summary>List of the cluster's language extensions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ILanguageExtensionsList LanguageExtension { get => (this._languageExtension = this._languageExtension ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.LanguageExtensionsList()); set => this._languageExtension = value; }

        /// <summary>The list of language extensions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ILanguageExtension[] LanguageExtensionValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ILanguageExtensionsListInternal)LanguageExtension).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ILanguageExtensionsListInternal)LanguageExtension).Value = value; }

        /// <summary>Internal Acessors for DataIngestionUri</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IClusterPropertiesInternal.DataIngestionUri { get => this._dataIngestionUri; set { {_dataIngestionUri = value;} } }

        /// <summary>Internal Acessors for KeyVaultProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IKeyVaultProperties Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IClusterPropertiesInternal.KeyVaultProperty { get => (this._keyVaultProperty = this._keyVaultProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.KeyVaultProperties()); set { {_keyVaultProperty = value;} } }

        /// <summary>Internal Acessors for LanguageExtension</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ILanguageExtensionsList Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IClusterPropertiesInternal.LanguageExtension { get => (this._languageExtension = this._languageExtension ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.LanguageExtensionsList()); set { {_languageExtension = value;} } }

        /// <summary>Internal Acessors for OptimizedAutoscale</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IOptimizedAutoscale Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IClusterPropertiesInternal.OptimizedAutoscale { get => (this._optimizedAutoscale = this._optimizedAutoscale ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.OptimizedAutoscale()); set { {_optimizedAutoscale = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IClusterPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for State</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IClusterPropertiesInternal.State { get => this._state; set { {_state = value;} } }

        /// <summary>Internal Acessors for StateReason</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IClusterPropertiesInternal.StateReason { get => this._stateReason; set { {_stateReason = value;} } }

        /// <summary>Internal Acessors for Uri</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IClusterPropertiesInternal.Uri { get => this._uri; set { {_uri = value;} } }

        /// <summary>Internal Acessors for VirtualNetworkConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IVirtualNetworkConfiguration Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IClusterPropertiesInternal.VirtualNetworkConfiguration { get => (this._virtualNetworkConfiguration = this._virtualNetworkConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.VirtualNetworkConfiguration()); set { {_virtualNetworkConfiguration = value;} } }

        /// <summary>Backing field for <see cref="OptimizedAutoscale" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IOptimizedAutoscale _optimizedAutoscale;

        /// <summary>Optimized auto scale definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IOptimizedAutoscale OptimizedAutoscale { get => (this._optimizedAutoscale = this._optimizedAutoscale ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.OptimizedAutoscale()); set => this._optimizedAutoscale = value; }

        /// <summary>
        /// A boolean value that indicate if the optimized autoscale feature is enabled or not.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public bool OptimizedAutoscaleIsEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IOptimizedAutoscaleInternal)OptimizedAutoscale).IsEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IOptimizedAutoscaleInternal)OptimizedAutoscale).IsEnabled = value; }

        /// <summary>Maximum allowed instances count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public int OptimizedAutoscaleMaximum { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IOptimizedAutoscaleInternal)OptimizedAutoscale).Maximum; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IOptimizedAutoscaleInternal)OptimizedAutoscale).Maximum = value; }

        /// <summary>Minimum allowed instances count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public int OptimizedAutoscaleMinimum { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IOptimizedAutoscaleInternal)OptimizedAutoscale).Minimum; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IOptimizedAutoscaleInternal)OptimizedAutoscale).Minimum = value; }

        /// <summary>The version of the template defined, for instance 1.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public int OptimizedAutoscaleVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IOptimizedAutoscaleInternal)OptimizedAutoscale).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IOptimizedAutoscaleInternal)OptimizedAutoscale).Version = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? _provisioningState;

        /// <summary>The provisioned state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State? _state;

        /// <summary>The state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State? State { get => this._state; }

        /// <summary>Backing field for <see cref="StateReason" /> property.</summary>
        private string _stateReason;

        /// <summary>The reason for the cluster's current state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string StateReason { get => this._stateReason; }

        /// <summary>Backing field for <see cref="TrustedExternalTenant" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ITrustedExternalTenant[] _trustedExternalTenant;

        /// <summary>The cluster's external tenants.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ITrustedExternalTenant[] TrustedExternalTenant { get => this._trustedExternalTenant; set => this._trustedExternalTenant = value; }

        /// <summary>Backing field for <see cref="Uri" /> property.</summary>
        private string _uri;

        /// <summary>The cluster URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Uri { get => this._uri; }

        /// <summary>Backing field for <see cref="VirtualNetworkConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IVirtualNetworkConfiguration _virtualNetworkConfiguration;

        /// <summary>Virtual network definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IVirtualNetworkConfiguration VirtualNetworkConfiguration { get => (this._virtualNetworkConfiguration = this._virtualNetworkConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.VirtualNetworkConfiguration()); set => this._virtualNetworkConfiguration = value; }

        /// <summary>Data management's service public IP address resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string VirtualNetworkConfigurationDataManagementPublicIPId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IVirtualNetworkConfigurationInternal)VirtualNetworkConfiguration).DataManagementPublicIPId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IVirtualNetworkConfigurationInternal)VirtualNetworkConfiguration).DataManagementPublicIPId = value; }

        /// <summary>Engine service's public IP address resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string VirtualNetworkConfigurationEnginePublicIPId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IVirtualNetworkConfigurationInternal)VirtualNetworkConfiguration).EnginePublicIPId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IVirtualNetworkConfigurationInternal)VirtualNetworkConfiguration).EnginePublicIPId = value; }

        /// <summary>The subnet resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string VirtualNetworkConfigurationSubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IVirtualNetworkConfigurationInternal)VirtualNetworkConfiguration).SubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IVirtualNetworkConfigurationInternal)VirtualNetworkConfiguration).SubnetId = value; }

        /// <summary>Creates an new <see cref="ClusterProperties" /> instance.</summary>
        public ClusterProperties()
        {

        }
    }
    /// Class representing the Kusto cluster properties.
    public partial interface IClusterProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The cluster data ingestion URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The cluster data ingestion URI.",
        SerializedName = @"dataIngestionUri",
        PossibleTypes = new [] { typeof(string) })]
        string DataIngestionUri { get;  }
        /// <summary>A boolean value that indicates if the cluster's disks are encrypted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A boolean value that indicates if the cluster's disks are encrypted.",
        SerializedName = @"enableDiskEncryption",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableDiskEncryption { get; set; }
        /// <summary>A boolean value that indicates if the purge operations are enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A boolean value that indicates if the purge operations are enabled.",
        SerializedName = @"enablePurge",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnablePurge { get; set; }
        /// <summary>A boolean value that indicates if the streaming ingest is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A boolean value that indicates if the streaming ingest is enabled.",
        SerializedName = @"enableStreamingIngest",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableStreamingIngest { get; set; }
        /// <summary>The name of the key vault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the key vault key.",
        SerializedName = @"keyName",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultPropertyKeyName { get; set; }
        /// <summary>The Uri of the key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The Uri of the key vault.",
        SerializedName = @"keyVaultUri",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultPropertyKeyVaultUri { get; set; }
        /// <summary>The version of the key vault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The version of the key vault key.",
        SerializedName = @"keyVersion",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultPropertyKeyVersion { get; set; }
        /// <summary>The list of language extensions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of language extensions.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ILanguageExtension) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ILanguageExtension[] LanguageExtensionValue { get; set; }
        /// <summary>
        /// A boolean value that indicate if the optimized autoscale feature is enabled or not.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"A boolean value that indicate if the optimized autoscale feature is enabled or not.",
        SerializedName = @"isEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool OptimizedAutoscaleIsEnabled { get; set; }
        /// <summary>Maximum allowed instances count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Maximum allowed instances count.",
        SerializedName = @"maximum",
        PossibleTypes = new [] { typeof(int) })]
        int OptimizedAutoscaleMaximum { get; set; }
        /// <summary>Minimum allowed instances count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Minimum allowed instances count.",
        SerializedName = @"minimum",
        PossibleTypes = new [] { typeof(int) })]
        int OptimizedAutoscaleMinimum { get; set; }
        /// <summary>The version of the template defined, for instance 1.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The version of the template defined, for instance 1.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(int) })]
        int OptimizedAutoscaleVersion { get; set; }
        /// <summary>The provisioned state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioned state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>The state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The state of the resource.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State? State { get;  }
        /// <summary>The reason for the cluster's current state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The reason for the cluster's current state.",
        SerializedName = @"stateReason",
        PossibleTypes = new [] { typeof(string) })]
        string StateReason { get;  }
        /// <summary>The cluster's external tenants.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The cluster's external tenants.",
        SerializedName = @"trustedExternalTenants",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ITrustedExternalTenant) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ITrustedExternalTenant[] TrustedExternalTenant { get; set; }
        /// <summary>The cluster URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The cluster URI.",
        SerializedName = @"uri",
        PossibleTypes = new [] { typeof(string) })]
        string Uri { get;  }
        /// <summary>Data management's service public IP address resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Data management's service public IP address resource id.",
        SerializedName = @"dataManagementPublicIpId",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualNetworkConfigurationDataManagementPublicIPId { get; set; }
        /// <summary>Engine service's public IP address resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Engine service's public IP address resource id.",
        SerializedName = @"enginePublicIpId",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualNetworkConfigurationEnginePublicIPId { get; set; }
        /// <summary>The subnet resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The subnet resource id.",
        SerializedName = @"subnetId",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualNetworkConfigurationSubnetId { get; set; }

    }
    /// Class representing the Kusto cluster properties.
    internal partial interface IClusterPropertiesInternal

    {
        /// <summary>The cluster data ingestion URI.</summary>
        string DataIngestionUri { get; set; }
        /// <summary>A boolean value that indicates if the cluster's disks are encrypted.</summary>
        bool? EnableDiskEncryption { get; set; }
        /// <summary>A boolean value that indicates if the purge operations are enabled.</summary>
        bool? EnablePurge { get; set; }
        /// <summary>A boolean value that indicates if the streaming ingest is enabled.</summary>
        bool? EnableStreamingIngest { get; set; }
        /// <summary>KeyVault properties for the cluster encryption.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IKeyVaultProperties KeyVaultProperty { get; set; }
        /// <summary>The name of the key vault key.</summary>
        string KeyVaultPropertyKeyName { get; set; }
        /// <summary>The Uri of the key vault.</summary>
        string KeyVaultPropertyKeyVaultUri { get; set; }
        /// <summary>The version of the key vault key.</summary>
        string KeyVaultPropertyKeyVersion { get; set; }
        /// <summary>List of the cluster's language extensions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ILanguageExtensionsList LanguageExtension { get; set; }
        /// <summary>The list of language extensions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ILanguageExtension[] LanguageExtensionValue { get; set; }
        /// <summary>Optimized auto scale definition.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IOptimizedAutoscale OptimizedAutoscale { get; set; }
        /// <summary>
        /// A boolean value that indicate if the optimized autoscale feature is enabled or not.
        /// </summary>
        bool OptimizedAutoscaleIsEnabled { get; set; }
        /// <summary>Maximum allowed instances count.</summary>
        int OptimizedAutoscaleMaximum { get; set; }
        /// <summary>Minimum allowed instances count.</summary>
        int OptimizedAutoscaleMinimum { get; set; }
        /// <summary>The version of the template defined, for instance 1.</summary>
        int OptimizedAutoscaleVersion { get; set; }
        /// <summary>The provisioned state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State? State { get; set; }
        /// <summary>The reason for the cluster's current state.</summary>
        string StateReason { get; set; }
        /// <summary>The cluster's external tenants.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ITrustedExternalTenant[] TrustedExternalTenant { get; set; }
        /// <summary>The cluster URI.</summary>
        string Uri { get; set; }
        /// <summary>Virtual network definition.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IVirtualNetworkConfiguration VirtualNetworkConfiguration { get; set; }
        /// <summary>Data management's service public IP address resource id.</summary>
        string VirtualNetworkConfigurationDataManagementPublicIPId { get; set; }
        /// <summary>Engine service's public IP address resource id.</summary>
        string VirtualNetworkConfigurationEnginePublicIPId { get; set; }
        /// <summary>The subnet resource id.</summary>
        string VirtualNetworkConfigurationSubnetId { get; set; }

    }
}
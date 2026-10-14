// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>Workspace properties</summary>
    public partial class WorkspaceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal
    {

        /// <summary>Backing field for <see cref="AgentSubnetId" /> property.</summary>
        private string _agentSubnetId;

        /// <summary>Agent Subnet ID for agent resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string AgentSubnetId { get => this._agentSubnetId; set => this._agentSubnetId = value; }

        /// <summary>Backing field for <see cref="CustomerManagedKey" /> property.</summary>
        private string _customerManagedKey;

        /// <summary>Whether or not to use a customer managed key when encrypting data at rest</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string CustomerManagedKey { get => this._customerManagedKey; set => this._customerManagedKey = value; }

        /// <summary>Backing field for <see cref="KeyVaultProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IKeyVaultProperties _keyVaultProperty;

        /// <summary>
        /// The key to use for encrypting data at rest when customer managed keys are enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IKeyVaultProperties KeyVaultProperty { get => (this._keyVaultProperty = this._keyVaultProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.KeyVaultProperties()); set => this._keyVaultProperty = value; }

        /// <summary>The Key Name in Key Vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IKeyVaultPropertiesInternal)KeyVaultProperty).KeyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IKeyVaultPropertiesInternal)KeyVaultProperty).KeyName = value ?? null; }

        /// <summary>The Key Vault URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyVaultUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IKeyVaultPropertiesInternal)KeyVaultProperty).KeyVaultUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IKeyVaultPropertiesInternal)KeyVaultProperty).KeyVaultUri = value ?? null; }

        /// <summary>The Key Version in Key Vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IKeyVaultPropertiesInternal)KeyVaultProperty).KeyVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IKeyVaultPropertiesInternal)KeyVaultProperty).KeyVersion = value ?? null; }

        /// <summary>Backing field for <see cref="LogAnalyticsClusterId" /> property.</summary>
        private string _logAnalyticsClusterId;

        /// <summary>
        /// The Log Analytics Cluster to use for debug logs. This is required when Customer Managed Keys are enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string LogAnalyticsClusterId { get => this._logAnalyticsClusterId; set => this._logAnalyticsClusterId = value; }

        /// <summary>Backing field for <see cref="ManagedOnBehalfOfConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources _managedOnBehalfOfConfiguration;

        /// <summary>
        /// Managed-On-Behalf-Of configuration properties. This configuration exists for the resources where a resource provider manages
        /// those resources on behalf of the resource owner.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources ManagedOnBehalfOfConfiguration { get => (this._managedOnBehalfOfConfiguration = this._managedOnBehalfOfConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WithMoboBrokerResources()); }

        /// <summary>Managed-On-Behalf-Of broker resources</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> ManagedOnBehalfOfConfigurationMoboBrokerResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResourcesInternal)ManagedOnBehalfOfConfiguration).MoboBrokerResource; }

        /// <summary>Backing field for <see cref="ManagedResourceGroup" /> property.</summary>
        private string _managedResourceGroup;

        /// <summary>The resource group for resources managed on behalf of customer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ManagedResourceGroup { get => this._managedResourceGroup; }

        /// <summary>Internal Acessors for KeyVaultProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IKeyVaultProperties Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal.KeyVaultProperty { get => (this._keyVaultProperty = this._keyVaultProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.KeyVaultProperties()); set { {_keyVaultProperty = value;} } }

        /// <summary>Internal Acessors for ManagedOnBehalfOfConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal.ManagedOnBehalfOfConfiguration { get => (this._managedOnBehalfOfConfiguration = this._managedOnBehalfOfConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WithMoboBrokerResources()); set { {_managedOnBehalfOfConfiguration = value;} } }

        /// <summary>Internal Acessors for ManagedOnBehalfOfConfigurationMoboBrokerResource</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal.ManagedOnBehalfOfConfigurationMoboBrokerResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResourcesInternal)ManagedOnBehalfOfConfiguration).MoboBrokerResource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResourcesInternal)ManagedOnBehalfOfConfiguration).MoboBrokerResource = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for ManagedResourceGroup</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal.ManagedResourceGroup { get => this._managedResourceGroup; set { {_managedResourceGroup = value;} } }

        /// <summary>Internal Acessors for PrivateEndpointConnection</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection> Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal.PrivateEndpointConnection { get => this._privateEndpointConnection; set { {_privateEndpointConnection = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for WorkspaceApiUri</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal.WorkspaceApiUri { get => this._workspaceApiUri; set { {_workspaceApiUri = value;} } }

        /// <summary>Internal Acessors for WorkspaceIdentity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal.WorkspaceIdentity { get => (this._workspaceIdentity = this._workspaceIdentity ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.Identity()); set { {_workspaceIdentity = value;} } }

        /// <summary>Internal Acessors for WorkspaceIdentityClientId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal.WorkspaceIdentityClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)WorkspaceIdentity).ClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)WorkspaceIdentity).ClientId = value ?? null; }

        /// <summary>Internal Acessors for WorkspaceIdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal.WorkspaceIdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)WorkspaceIdentity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)WorkspaceIdentity).PrincipalId = value ?? null; }

        /// <summary>Internal Acessors for WorkspaceUiUri</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal.WorkspaceUiUri { get => this._workspaceUiUri; set { {_workspaceUiUri = value;} } }

        /// <summary>Backing field for <see cref="PrivateEndpointConnection" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection> _privateEndpointConnection;

        /// <summary>List of private endpoint connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection> PrivateEndpointConnection { get => this._privateEndpointConnection; }

        /// <summary>Backing field for <see cref="PrivateEndpointSubnetId" /> property.</summary>
        private string _privateEndpointSubnetId;

        /// <summary>Private Endpoint Subnet ID for private endpoint connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string PrivateEndpointSubnetId { get => this._privateEndpointSubnetId; set => this._privateEndpointSubnetId = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="PublicNetworkAccess" /> property.</summary>
        private string _publicNetworkAccess;

        /// <summary>
        /// Whether or not public network access is allowed for this resource. For security reasons, it is recommended to disable
        /// it whenever possible.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string PublicNetworkAccess { get => this._publicNetworkAccess; set => this._publicNetworkAccess = value; }

        /// <summary>Backing field for <see cref="SupercomputerId" /> property.</summary>
        private System.Collections.Generic.List<string> _supercomputerId;

        /// <summary>List of linked SuperComputers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> SupercomputerId { get => this._supercomputerId; set => this._supercomputerId = value; }

        /// <summary>Backing field for <see cref="WorkspaceApiUri" /> property.</summary>
        private string _workspaceApiUri;

        /// <summary>workspace API endpoint Uri.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string WorkspaceApiUri { get => this._workspaceApiUri; }

        /// <summary>Backing field for <see cref="WorkspaceIdentity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity _workspaceIdentity;

        /// <summary>Identity IDs used for leveraging Workspace resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity WorkspaceIdentity { get => (this._workspaceIdentity = this._workspaceIdentity ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.Identity()); set => this._workspaceIdentity = value; }

        /// <summary>The client ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string WorkspaceIdentityClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)WorkspaceIdentity).ClientId; }

        /// <summary>The resource ID of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string WorkspaceIdentityId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)WorkspaceIdentity).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)WorkspaceIdentity).Id = value ?? null; }

        /// <summary>The principal ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string WorkspaceIdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)WorkspaceIdentity).PrincipalId; }

        /// <summary>Backing field for <see cref="WorkspaceSubnetId" /> property.</summary>
        private string _workspaceSubnetId;

        /// <summary>Function Subnet ID for workspace resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string WorkspaceSubnetId { get => this._workspaceSubnetId; set => this._workspaceSubnetId = value; }

        /// <summary>Backing field for <see cref="WorkspaceUiUri" /> property.</summary>
        private string _workspaceUiUri;

        /// <summary>workspace User Interface Uri.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string WorkspaceUiUri { get => this._workspaceUiUri; }

        /// <summary>Creates an new <see cref="WorkspaceProperties" /> instance.</summary>
        public WorkspaceProperties()
        {

        }
    }
    /// Workspace properties
    public partial interface IWorkspaceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable
    {
        /// <summary>Agent Subnet ID for agent resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Agent Subnet ID for agent resources.",
        SerializedName = @"agentSubnetId",
        PossibleTypes = new [] { typeof(string) })]
        string AgentSubnetId { get; set; }
        /// <summary>Whether or not to use a customer managed key when encrypting data at rest</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Whether or not to use a customer managed key when encrypting data at rest",
        SerializedName = @"customerManagedKeys",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string CustomerManagedKey { get; set; }
        /// <summary>The Key Name in Key Vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The Key Name in Key Vault",
        SerializedName = @"keyName",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultPropertyKeyName { get; set; }
        /// <summary>The Key Vault URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The Key Vault URI",
        SerializedName = @"keyVaultUri",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultPropertyKeyVaultUri { get; set; }
        /// <summary>The Key Version in Key Vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The Key Version in Key Vault",
        SerializedName = @"keyVersion",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultPropertyKeyVersion { get; set; }
        /// <summary>
        /// The Log Analytics Cluster to use for debug logs. This is required when Customer Managed Keys are enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The Log Analytics Cluster to use for debug logs. This is required when Customer Managed Keys are enabled.",
        SerializedName = @"logAnalyticsClusterId",
        PossibleTypes = new [] { typeof(string) })]
        string LogAnalyticsClusterId { get; set; }
        /// <summary>Managed-On-Behalf-Of broker resources</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Managed-On-Behalf-Of broker resources",
        SerializedName = @"moboBrokerResources",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> ManagedOnBehalfOfConfigurationMoboBrokerResource { get;  }
        /// <summary>The resource group for resources managed on behalf of customer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The resource group for resources managed on behalf of customer.",
        SerializedName = @"managedResourceGroup",
        PossibleTypes = new [] { typeof(string) })]
        string ManagedResourceGroup { get;  }
        /// <summary>List of private endpoint connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"List of private endpoint connections.",
        SerializedName = @"privateEndpointConnections",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection> PrivateEndpointConnection { get;  }
        /// <summary>Private Endpoint Subnet ID for private endpoint connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Private Endpoint Subnet ID for private endpoint connections.",
        SerializedName = @"privateEndpointSubnetId",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateEndpointSubnetId { get; set; }
        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The status of the last operation.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Accepted", "Provisioning", "Updating", "Deleting")]
        string ProvisioningState { get;  }
        /// <summary>
        /// Whether or not public network access is allowed for this resource. For security reasons, it is recommended to disable
        /// it whenever possible.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Whether or not public network access is allowed for this resource. For security reasons, it is recommended to disable it whenever possible.",
        SerializedName = @"publicNetworkAccess",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string PublicNetworkAccess { get; set; }
        /// <summary>List of linked SuperComputers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"List of linked SuperComputers.",
        SerializedName = @"supercomputerIds",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> SupercomputerId { get; set; }
        /// <summary>workspace API endpoint Uri.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"workspace API endpoint Uri.",
        SerializedName = @"workspaceApiUri",
        PossibleTypes = new [] { typeof(string) })]
        string WorkspaceApiUri { get;  }
        /// <summary>The client ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The client ID of the assigned identity.",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string WorkspaceIdentityClientId { get;  }
        /// <summary>The resource ID of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The resource ID of the user assigned identity.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string WorkspaceIdentityId { get; set; }
        /// <summary>The principal ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The principal ID of the assigned identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string WorkspaceIdentityPrincipalId { get;  }
        /// <summary>Function Subnet ID for workspace resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Function Subnet ID for workspace resources.",
        SerializedName = @"workspaceSubnetId",
        PossibleTypes = new [] { typeof(string) })]
        string WorkspaceSubnetId { get; set; }
        /// <summary>workspace User Interface Uri.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"workspace User Interface Uri.",
        SerializedName = @"workspaceUiUri",
        PossibleTypes = new [] { typeof(string) })]
        string WorkspaceUiUri { get;  }

    }
    /// Workspace properties
    internal partial interface IWorkspacePropertiesInternal

    {
        /// <summary>Agent Subnet ID for agent resources.</summary>
        string AgentSubnetId { get; set; }
        /// <summary>Whether or not to use a customer managed key when encrypting data at rest</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string CustomerManagedKey { get; set; }
        /// <summary>
        /// The key to use for encrypting data at rest when customer managed keys are enabled.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IKeyVaultProperties KeyVaultProperty { get; set; }
        /// <summary>The Key Name in Key Vault</summary>
        string KeyVaultPropertyKeyName { get; set; }
        /// <summary>The Key Vault URI</summary>
        string KeyVaultPropertyKeyVaultUri { get; set; }
        /// <summary>The Key Version in Key Vault</summary>
        string KeyVaultPropertyKeyVersion { get; set; }
        /// <summary>
        /// The Log Analytics Cluster to use for debug logs. This is required when Customer Managed Keys are enabled.
        /// </summary>
        string LogAnalyticsClusterId { get; set; }
        /// <summary>
        /// Managed-On-Behalf-Of configuration properties. This configuration exists for the resources where a resource provider manages
        /// those resources on behalf of the resource owner.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources ManagedOnBehalfOfConfiguration { get; set; }
        /// <summary>Managed-On-Behalf-Of broker resources</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> ManagedOnBehalfOfConfigurationMoboBrokerResource { get; set; }
        /// <summary>The resource group for resources managed on behalf of customer.</summary>
        string ManagedResourceGroup { get; set; }
        /// <summary>List of private endpoint connections.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection> PrivateEndpointConnection { get; set; }
        /// <summary>Private Endpoint Subnet ID for private endpoint connections.</summary>
        string PrivateEndpointSubnetId { get; set; }
        /// <summary>The status of the last operation.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Accepted", "Provisioning", "Updating", "Deleting")]
        string ProvisioningState { get; set; }
        /// <summary>
        /// Whether or not public network access is allowed for this resource. For security reasons, it is recommended to disable
        /// it whenever possible.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string PublicNetworkAccess { get; set; }
        /// <summary>List of linked SuperComputers.</summary>
        System.Collections.Generic.List<string> SupercomputerId { get; set; }
        /// <summary>workspace API endpoint Uri.</summary>
        string WorkspaceApiUri { get; set; }
        /// <summary>Identity IDs used for leveraging Workspace resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity WorkspaceIdentity { get; set; }
        /// <summary>The client ID of the assigned identity.</summary>
        string WorkspaceIdentityClientId { get; set; }
        /// <summary>The resource ID of the user assigned identity.</summary>
        string WorkspaceIdentityId { get; set; }
        /// <summary>The principal ID of the assigned identity.</summary>
        string WorkspaceIdentityPrincipalId { get; set; }
        /// <summary>Function Subnet ID for workspace resources.</summary>
        string WorkspaceSubnetId { get; set; }
        /// <summary>workspace User Interface Uri.</summary>
        string WorkspaceUiUri { get; set; }

    }
}
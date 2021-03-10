namespace Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Extensions;

    /// <summary>The SourceControl Configuration object returned in Get & Put response.</summary>
    public partial class SourceControlConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationInternal,
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.IProxyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.IProxyResource __proxyResource = new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.ProxyResource();

        /// <summary>The compliance state of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceStateType? ComplianceStatusComplianceState { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).ComplianceStatusComplianceState; }

        /// <summary>Datetime the configuration was last applied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public global::System.DateTime? ComplianceStatusLastConfigApplied { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).ComplianceStatusLastConfigApplied; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).ComplianceStatusLastConfigApplied = value; }

        /// <summary>Message from when the configuration was applied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string ComplianceStatusMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).ComplianceStatusMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).ComplianceStatusMessage = value; }

        /// <summary>Level of the message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.MessageLevelType? ComplianceStatusMessageLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).ComplianceStatusMessageLevel; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).ComplianceStatusMessageLevel = value; }

        /// <summary>Name-value pairs of protected configuration settings for the configuration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IConfigurationProtectedSettings ConfigurationProtectedSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).ConfigurationProtectedSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).ConfigurationProtectedSetting = value; }

        /// <summary>Option to enable Helm Operator for this git configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public bool? EnableHelmOperator { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).EnableHelmOperator; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).EnableHelmOperator = value; }

        /// <summary>Values override for the operator Helm chart.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string HelmOperatorPropertyChartValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).HelmOperatorPropertyChartValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).HelmOperatorPropertyChartValue = value; }

        /// <summary>Version of the operator Helm chart.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string HelmOperatorPropertyChartVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).HelmOperatorPropertyChartVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).HelmOperatorPropertyChartVersion = value; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.IResourceInternal)__proxyResource).Id; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.IResourceInternal)__proxyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.IResourceInternal)__proxyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.IResourceInternal)__proxyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.IResourceInternal)__proxyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.IResourceInternal)__proxyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.IResourceInternal)__proxyResource).Type = value; }

        /// <summary>Internal Acessors for ComplianceStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IComplianceStatus Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationInternal.ComplianceStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).ComplianceStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).ComplianceStatus = value; }

        /// <summary>Internal Acessors for ComplianceStatusComplianceState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceStateType? Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationInternal.ComplianceStatusComplianceState { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).ComplianceStatusComplianceState; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).ComplianceStatusComplianceState = value; }

        /// <summary>Internal Acessors for HelmOperatorProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IHelmOperatorProperties Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationInternal.HelmOperatorProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).HelmOperatorProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).HelmOperatorProperty = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationProperties Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.SourceControlConfigurationProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ProvisioningStateType? Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for RepositoryPublicKey</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationInternal.RepositoryPublicKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).RepositoryPublicKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).RepositoryPublicKey = value; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.ISystemData Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationInternal.SystemData { get => (this._systemData = this._systemData ?? new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.SystemData()); set { {_systemData = value;} } }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.IResourceInternal)__proxyResource).Name; }

        /// <summary>Instance name of the operator - identifying the specific configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string OperatorInstanceName { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).OperatorInstanceName; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).OperatorInstanceName = value; }

        /// <summary>
        /// The namespace to which this operator is installed to. Maximum of 253 lower case alphanumeric characters, hyphen and period
        /// only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string OperatorNamespace { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).OperatorNamespace; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).OperatorNamespace = value; }

        /// <summary>Any Parameters for the Operator instance in string format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string OperatorParam { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).OperatorParam; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).OperatorParam = value; }

        /// <summary>Scope at which the operator will be installed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorScopeType? OperatorScope { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).OperatorScope; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).OperatorScope = value; }

        /// <summary>Type of the operator</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorType? OperatorType { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).OperatorType; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).OperatorType = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationProperties _property;

        /// <summary>Properties to create a Source Control Configuration resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.SourceControlConfigurationProperties()); set => this._property = value; }

        /// <summary>The provisioning state of the resource provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ProvisioningStateType? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).ProvisioningState; }

        /// <summary>
        /// Public Key associated with this SourceControl configuration (either generated within the cluster or provided by the user).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string RepositoryPublicKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).RepositoryPublicKey; }

        /// <summary>Url of the SourceControl Repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string RepositoryUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).RepositoryUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).RepositoryUrl = value; }

        /// <summary>
        /// Base64-encoded known_hosts contents containing public SSH keys required to access private Git instances
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string SshKnownHostsContent { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).SshKnownHostsContent; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)Property).SshKnownHostsContent = value; }

        /// <summary>Backing field for <see cref="SystemData" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.ISystemData _systemData;

        /// <summary>
        /// Top level metadata https://github.com/Azure/azure-resource-manager-rpc/blob/master/v1.0/common-api-contracts.md#system-metadata-for-all-azure-resources
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.ISystemData SystemData { get => (this._systemData = this._systemData ?? new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.SystemData()); }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.ISystemDataInternal)SystemData).CreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.ISystemDataInternal)SystemData).CreatedAt = value; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.ISystemDataInternal)SystemData).CreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.ISystemDataInternal)SystemData).CreatedBy = value; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.CreatedByType? SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.ISystemDataInternal)SystemData).CreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.ISystemDataInternal)SystemData).CreatedByType = value; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.ISystemDataInternal)SystemData).LastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.ISystemDataInternal)SystemData).LastModifiedAt = value; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.ISystemDataInternal)SystemData).LastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.ISystemDataInternal)SystemData).LastModifiedBy = value; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.CreatedByType? SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.ISystemDataInternal)SystemData).LastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.ISystemDataInternal)SystemData).LastModifiedByType = value; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.IResourceInternal)__proxyResource).Type; }

        /// <summary>Creates an new <see cref="SourceControlConfiguration" /> instance.</summary>
        public SourceControlConfiguration()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyResource), __proxyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyResource), __proxyResource);
        }
    }
    /// The SourceControl Configuration object returned in Get & Put response.
    public partial interface ISourceControlConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.IProxyResource
    {
        /// <summary>The compliance state of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The compliance state of the configuration.",
        SerializedName = @"complianceState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceStateType) })]
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceStateType? ComplianceStatusComplianceState { get;  }
        /// <summary>Datetime the configuration was last applied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Datetime the configuration was last applied.",
        SerializedName = @"lastConfigApplied",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ComplianceStatusLastConfigApplied { get; set; }
        /// <summary>Message from when the configuration was applied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Message from when the configuration was applied.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string ComplianceStatusMessage { get; set; }
        /// <summary>Level of the message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Level of the message.",
        SerializedName = @"messageLevel",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.MessageLevelType) })]
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.MessageLevelType? ComplianceStatusMessageLevel { get; set; }
        /// <summary>Name-value pairs of protected configuration settings for the configuration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name-value pairs of protected configuration settings for the configuration",
        SerializedName = @"configurationProtectedSettings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IConfigurationProtectedSettings) })]
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IConfigurationProtectedSettings ConfigurationProtectedSetting { get; set; }
        /// <summary>Option to enable Helm Operator for this git configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Option to enable Helm Operator for this git configuration.",
        SerializedName = @"enableHelmOperator",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableHelmOperator { get; set; }
        /// <summary>Values override for the operator Helm chart.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Values override for the operator Helm chart.",
        SerializedName = @"chartValues",
        PossibleTypes = new [] { typeof(string) })]
        string HelmOperatorPropertyChartValue { get; set; }
        /// <summary>Version of the operator Helm chart.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Version of the operator Helm chart.",
        SerializedName = @"chartVersion",
        PossibleTypes = new [] { typeof(string) })]
        string HelmOperatorPropertyChartVersion { get; set; }
        /// <summary>Instance name of the operator - identifying the specific configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Instance name of the operator - identifying the specific configuration.",
        SerializedName = @"operatorInstanceName",
        PossibleTypes = new [] { typeof(string) })]
        string OperatorInstanceName { get; set; }
        /// <summary>
        /// The namespace to which this operator is installed to. Maximum of 253 lower case alphanumeric characters, hyphen and period
        /// only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The namespace to which this operator is installed to. Maximum of 253 lower case alphanumeric characters, hyphen and period only.",
        SerializedName = @"operatorNamespace",
        PossibleTypes = new [] { typeof(string) })]
        string OperatorNamespace { get; set; }
        /// <summary>Any Parameters for the Operator instance in string format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Any Parameters for the Operator instance in string format.",
        SerializedName = @"operatorParams",
        PossibleTypes = new [] { typeof(string) })]
        string OperatorParam { get; set; }
        /// <summary>Scope at which the operator will be installed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Scope at which the operator will be installed.",
        SerializedName = @"operatorScope",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorScopeType) })]
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorScopeType? OperatorScope { get; set; }
        /// <summary>Type of the operator</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of the operator",
        SerializedName = @"operatorType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorType) })]
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorType? OperatorType { get; set; }
        /// <summary>The provisioning state of the resource provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the resource provider.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ProvisioningStateType) })]
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ProvisioningStateType? ProvisioningState { get;  }
        /// <summary>
        /// Public Key associated with this SourceControl configuration (either generated within the cluster or provided by the user).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Public Key associated with this SourceControl configuration (either generated within the cluster or provided by the user).",
        SerializedName = @"repositoryPublicKey",
        PossibleTypes = new [] { typeof(string) })]
        string RepositoryPublicKey { get;  }
        /// <summary>Url of the SourceControl Repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Url of the SourceControl Repository.",
        SerializedName = @"repositoryUrl",
        PossibleTypes = new [] { typeof(string) })]
        string RepositoryUrl { get; set; }
        /// <summary>
        /// Base64-encoded known_hosts contents containing public SSH keys required to access private Git instances
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Base64-encoded known_hosts contents containing public SSH keys required to access private Git instances",
        SerializedName = @"sshKnownHostsContents",
        PossibleTypes = new [] { typeof(string) })]
        string SshKnownHostsContent { get; set; }
        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The timestamp of resource creation (UTC).",
        SerializedName = @"createdAt",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SystemDataCreatedAt { get; set; }
        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identity that created the resource.",
        SerializedName = @"createdBy",
        PossibleTypes = new [] { typeof(string) })]
        string SystemDataCreatedBy { get; set; }
        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of identity that created the resource.",
        SerializedName = @"createdByType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.CreatedByType) })]
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.CreatedByType? SystemDataCreatedByType { get; set; }
        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of identity that last modified the resource.",
        SerializedName = @"lastModifiedAt",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SystemDataLastModifiedAt { get; set; }
        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identity that last modified the resource.",
        SerializedName = @"lastModifiedBy",
        PossibleTypes = new [] { typeof(string) })]
        string SystemDataLastModifiedBy { get; set; }
        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of identity that last modified the resource.",
        SerializedName = @"lastModifiedByType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.CreatedByType) })]
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.CreatedByType? SystemDataLastModifiedByType { get; set; }

    }
    /// The SourceControl Configuration object returned in Get & Put response.
    internal partial interface ISourceControlConfigurationInternal :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.IProxyResourceInternal
    {
        /// <summary>Compliance Status of the Configuration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IComplianceStatus ComplianceStatus { get; set; }
        /// <summary>The compliance state of the configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceStateType? ComplianceStatusComplianceState { get; set; }
        /// <summary>Datetime the configuration was last applied.</summary>
        global::System.DateTime? ComplianceStatusLastConfigApplied { get; set; }
        /// <summary>Message from when the configuration was applied.</summary>
        string ComplianceStatusMessage { get; set; }
        /// <summary>Level of the message.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.MessageLevelType? ComplianceStatusMessageLevel { get; set; }
        /// <summary>Name-value pairs of protected configuration settings for the configuration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IConfigurationProtectedSettings ConfigurationProtectedSetting { get; set; }
        /// <summary>Option to enable Helm Operator for this git configuration.</summary>
        bool? EnableHelmOperator { get; set; }
        /// <summary>Properties for Helm operator.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IHelmOperatorProperties HelmOperatorProperty { get; set; }
        /// <summary>Values override for the operator Helm chart.</summary>
        string HelmOperatorPropertyChartValue { get; set; }
        /// <summary>Version of the operator Helm chart.</summary>
        string HelmOperatorPropertyChartVersion { get; set; }
        /// <summary>Instance name of the operator - identifying the specific configuration.</summary>
        string OperatorInstanceName { get; set; }
        /// <summary>
        /// The namespace to which this operator is installed to. Maximum of 253 lower case alphanumeric characters, hyphen and period
        /// only.
        /// </summary>
        string OperatorNamespace { get; set; }
        /// <summary>Any Parameters for the Operator instance in string format.</summary>
        string OperatorParam { get; set; }
        /// <summary>Scope at which the operator will be installed.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorScopeType? OperatorScope { get; set; }
        /// <summary>Type of the operator</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorType? OperatorType { get; set; }
        /// <summary>Properties to create a Source Control Configuration resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationProperties Property { get; set; }
        /// <summary>The provisioning state of the resource provider.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ProvisioningStateType? ProvisioningState { get; set; }
        /// <summary>
        /// Public Key associated with this SourceControl configuration (either generated within the cluster or provided by the user).
        /// </summary>
        string RepositoryPublicKey { get; set; }
        /// <summary>Url of the SourceControl Repository.</summary>
        string RepositoryUrl { get; set; }
        /// <summary>
        /// Base64-encoded known_hosts contents containing public SSH keys required to access private Git instances
        /// </summary>
        string SshKnownHostsContent { get; set; }
        /// <summary>
        /// Top level metadata https://github.com/Azure/azure-resource-manager-rpc/blob/master/v1.0/common-api-contracts.md#system-metadata-for-all-azure-resources
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20.ISystemData SystemData { get; set; }
        /// <summary>The timestamp of resource creation (UTC).</summary>
        global::System.DateTime? SystemDataCreatedAt { get; set; }
        /// <summary>The identity that created the resource.</summary>
        string SystemDataCreatedBy { get; set; }
        /// <summary>The type of identity that created the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.CreatedByType? SystemDataCreatedByType { get; set; }
        /// <summary>The type of identity that last modified the resource.</summary>
        global::System.DateTime? SystemDataLastModifiedAt { get; set; }
        /// <summary>The identity that last modified the resource.</summary>
        string SystemDataLastModifiedBy { get; set; }
        /// <summary>The type of identity that last modified the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.CreatedByType? SystemDataLastModifiedByType { get; set; }

    }
}
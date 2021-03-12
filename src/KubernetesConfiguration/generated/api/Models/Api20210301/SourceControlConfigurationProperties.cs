namespace Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Extensions;

    /// <summary>Properties to create a Source Control Configuration resource</summary>
    public partial class SourceControlConfigurationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ComplianceStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IComplianceStatus _complianceStatus;

        /// <summary>Compliance Status of the Configuration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IComplianceStatus ComplianceStatus { get => (this._complianceStatus = this._complianceStatus ?? new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ComplianceStatus()); }

        /// <summary>The compliance state of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceStateType? ComplianceStatusComplianceState { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IComplianceStatusInternal)ComplianceStatus).ComplianceState; }

        /// <summary>Datetime the configuration was last applied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public global::System.DateTime? ComplianceStatusLastConfigApplied { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IComplianceStatusInternal)ComplianceStatus).LastConfigApplied; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IComplianceStatusInternal)ComplianceStatus).LastConfigApplied = value; }

        /// <summary>Message from when the configuration was applied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string ComplianceStatusMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IComplianceStatusInternal)ComplianceStatus).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IComplianceStatusInternal)ComplianceStatus).Message = value; }

        /// <summary>Level of the message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.MessageLevelType? ComplianceStatusMessageLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IComplianceStatusInternal)ComplianceStatus).MessageLevel; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IComplianceStatusInternal)ComplianceStatus).MessageLevel = value; }

        /// <summary>Backing field for <see cref="ConfigurationProtectedSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IConfigurationProtectedSettings _configurationProtectedSetting;

        /// <summary>Name-value pairs of protected configuration settings for the configuration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IConfigurationProtectedSettings ConfigurationProtectedSetting { get => (this._configurationProtectedSetting = this._configurationProtectedSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ConfigurationProtectedSettings()); set => this._configurationProtectedSetting = value; }

        /// <summary>Backing field for <see cref="EnableHelmOperator" /> property.</summary>
        private bool? _enableHelmOperator;

        /// <summary>Option to enable Helm Operator for this git configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public bool? EnableHelmOperator { get => this._enableHelmOperator; set => this._enableHelmOperator = value; }

        /// <summary>Backing field for <see cref="HelmOperatorProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IHelmOperatorProperties _helmOperatorProperty;

        /// <summary>Properties for Helm operator.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IHelmOperatorProperties HelmOperatorProperty { get => (this._helmOperatorProperty = this._helmOperatorProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.HelmOperatorProperties()); set => this._helmOperatorProperty = value; }

        /// <summary>Values override for the operator Helm chart.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string HelmOperatorPropertyChartValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IHelmOperatorPropertiesInternal)HelmOperatorProperty).ChartValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IHelmOperatorPropertiesInternal)HelmOperatorProperty).ChartValue = value; }

        /// <summary>Version of the operator Helm chart.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string HelmOperatorPropertyChartVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IHelmOperatorPropertiesInternal)HelmOperatorProperty).ChartVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IHelmOperatorPropertiesInternal)HelmOperatorProperty).ChartVersion = value; }

        /// <summary>Internal Acessors for ComplianceStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IComplianceStatus Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal.ComplianceStatus { get => (this._complianceStatus = this._complianceStatus ?? new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ComplianceStatus()); set { {_complianceStatus = value;} } }

        /// <summary>Internal Acessors for ComplianceStatusComplianceState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceStateType? Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal.ComplianceStatusComplianceState { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IComplianceStatusInternal)ComplianceStatus).ComplianceState; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IComplianceStatusInternal)ComplianceStatus).ComplianceState = value; }

        /// <summary>Internal Acessors for HelmOperatorProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IHelmOperatorProperties Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal.HelmOperatorProperty { get => (this._helmOperatorProperty = this._helmOperatorProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.HelmOperatorProperties()); set { {_helmOperatorProperty = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ProvisioningStateType? Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for RepositoryPublicKey</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal.RepositoryPublicKey { get => this._repositoryPublicKey; set { {_repositoryPublicKey = value;} } }

        /// <summary>Backing field for <see cref="OperatorInstanceName" /> property.</summary>
        private string _operatorInstanceName;

        /// <summary>Instance name of the operator - identifying the specific configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string OperatorInstanceName { get => this._operatorInstanceName; set => this._operatorInstanceName = value; }

        /// <summary>Backing field for <see cref="OperatorNamespace" /> property.</summary>
        private string _operatorNamespace;

        /// <summary>
        /// The namespace to which this operator is installed to. Maximum of 253 lower case alphanumeric characters, hyphen and period
        /// only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string OperatorNamespace { get => this._operatorNamespace; set => this._operatorNamespace = value; }

        /// <summary>Backing field for <see cref="OperatorParam" /> property.</summary>
        private string _operatorParam;

        /// <summary>Any Parameters for the Operator instance in string format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string OperatorParam { get => this._operatorParam; set => this._operatorParam = value; }

        /// <summary>Backing field for <see cref="OperatorScope" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorScopeType? _operatorScope;

        /// <summary>Scope at which the operator will be installed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorScopeType? OperatorScope { get => this._operatorScope; set => this._operatorScope = value; }

        /// <summary>Backing field for <see cref="OperatorType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorType? _operatorType;

        /// <summary>Type of the operator</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorType? OperatorType { get => this._operatorType; set => this._operatorType = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ProvisioningStateType? _provisioningState;

        /// <summary>The provisioning state of the resource provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ProvisioningStateType? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="RepositoryPublicKey" /> property.</summary>
        private string _repositoryPublicKey;

        /// <summary>
        /// Public Key associated with this SourceControl configuration (either generated within the cluster or provided by the user).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string RepositoryPublicKey { get => this._repositoryPublicKey; }

        /// <summary>Backing field for <see cref="RepositoryUrl" /> property.</summary>
        private string _repositoryUrl;

        /// <summary>Url of the SourceControl Repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string RepositoryUrl { get => this._repositoryUrl; set => this._repositoryUrl = value; }

        /// <summary>Backing field for <see cref="SshKnownHostsContent" /> property.</summary>
        private string _sshKnownHostsContent;

        /// <summary>
        /// Base64-encoded known_hosts contents containing public SSH keys required to access private Git instances
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string SshKnownHostsContent { get => this._sshKnownHostsContent; set => this._sshKnownHostsContent = value; }

        /// <summary>Creates an new <see cref="SourceControlConfigurationProperties" /> instance.</summary>
        public SourceControlConfigurationProperties()
        {

        }
    }
    /// Properties to create a Source Control Configuration resource
    public partial interface ISourceControlConfigurationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.IJsonSerializable
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

    }
    /// Properties to create a Source Control Configuration resource
    internal partial interface ISourceControlConfigurationPropertiesInternal

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

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Extensions;

    /// <summary>The SourceControl Configuration object.</summary>
    public partial class SourceControlConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal,
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IProxyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IProxyResource __proxyResource = new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ProxyResource();

        /// <summary>The compliance state of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceState? ComplianceStatusComplianceState { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).ComplianceStatusComplianceState; }

        /// <summary>Datetime the configuration was last applied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public global::System.DateTime? ComplianceStatusLastConfigApplied { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).ComplianceStatusLastConfigApplied; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).ComplianceStatusLastConfigApplied = value; }

        /// <summary>Message from when the configuration was applied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string ComplianceStatusMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).ComplianceStatusMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).ComplianceStatusMessage = value; }

        /// <summary>Level of the message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.MessageLevel? ComplianceStatusMessageLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).ComplianceStatusMessageLevel; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).ComplianceStatusMessageLevel = value; }

        /// <summary>Option to enable Helm Operator for this git configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.EnableHelmOperator? EnableHelmOperator { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).EnableHelmOperator; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).EnableHelmOperator = value; }

        /// <summary>Values override for the operator Helm chart.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string HelmOperatorPropertyChartValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).HelmOperatorPropertyChartValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).HelmOperatorPropertyChartValue = value; }

        /// <summary>Version of the operator Helm chart.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string HelmOperatorPropertyChartVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).HelmOperatorPropertyChartVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).HelmOperatorPropertyChartVersion = value; }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal)__proxyResource).Id; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal)__proxyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal)__proxyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal)__proxyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal)__proxyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal)__proxyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal)__proxyResource).Type = value; }

        /// <summary>Internal Acessors for ComplianceStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IComplianceStatus Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal.ComplianceStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).ComplianceStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).ComplianceStatus = value; }

        /// <summary>Internal Acessors for ComplianceStatusComplianceState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceState? Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal.ComplianceStatusComplianceState { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).ComplianceStatusComplianceState; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).ComplianceStatusComplianceState = value; }

        /// <summary>Internal Acessors for HelmOperatorProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IHelmOperatorProperties Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal.HelmOperatorProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).HelmOperatorProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).HelmOperatorProperty = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationProperties Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.SourceControlConfigurationProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for RepositoryPublicKey</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal.RepositoryPublicKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).RepositoryPublicKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).RepositoryPublicKey = value; }

        /// <summary>Resource name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal)__proxyResource).Name; }

        /// <summary>Instance name of the operator - identifying the specific configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string OperatorInstanceName { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).OperatorInstanceName; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).OperatorInstanceName = value; }

        /// <summary>
        /// The namespace to which this operator is installed to. Maximum of 253 lower case alphanumeric characters, hyphen and period
        /// only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string OperatorNamespace { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).OperatorNamespace; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).OperatorNamespace = value; }

        /// <summary>Any Parameters for the Operator instance in string format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string OperatorParam { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).OperatorParam; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).OperatorParam = value; }

        /// <summary>Scope at which the operator will be installed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorScope? OperatorScope { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).OperatorScope; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).OperatorScope = value; }

        /// <summary>Type of the operator</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorType? OperatorType { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).OperatorType; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).OperatorType = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationProperties _property;

        /// <summary>Properties to create a Source Control Configuration resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.SourceControlConfigurationProperties()); set => this._property = value; }

        /// <summary>The provisioning state of the resource provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).ProvisioningState; }

        /// <summary>
        /// Public Key associated with this SourceControl configuration (either generated within the cluster or provided by the user).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string RepositoryPublicKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).RepositoryPublicKey; }

        /// <summary>Url of the SourceControl Repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string RepositoryUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).RepositoryUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationPropertiesInternal)Property).RepositoryUrl = value; }

        /// <summary>Resource type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal)__proxyResource).Type; }

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
    /// The SourceControl Configuration object.
    public partial interface ISourceControlConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IProxyResource
    {
        /// <summary>The compliance state of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The compliance state of the configuration.",
        SerializedName = @"complianceState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceState) })]
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceState? ComplianceStatusComplianceState { get;  }
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.MessageLevel) })]
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.MessageLevel? ComplianceStatusMessageLevel { get; set; }
        /// <summary>Option to enable Helm Operator for this git configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Option to enable Helm Operator for this git configuration.",
        SerializedName = @"enableHelmOperator",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.EnableHelmOperator) })]
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.EnableHelmOperator? EnableHelmOperator { get; set; }
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorScope) })]
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorScope? OperatorScope { get; set; }
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ProvisioningState? ProvisioningState { get;  }
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

    }
    /// The SourceControl Configuration object.
    internal partial interface ISourceControlConfigurationInternal :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IProxyResourceInternal
    {
        /// <summary>Compliance Status of the Configuration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IComplianceStatus ComplianceStatus { get; set; }
        /// <summary>The compliance state of the configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceState? ComplianceStatusComplianceState { get; set; }
        /// <summary>Datetime the configuration was last applied.</summary>
        global::System.DateTime? ComplianceStatusLastConfigApplied { get; set; }
        /// <summary>Message from when the configuration was applied.</summary>
        string ComplianceStatusMessage { get; set; }
        /// <summary>Level of the message.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.MessageLevel? ComplianceStatusMessageLevel { get; set; }
        /// <summary>Option to enable Helm Operator for this git configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.EnableHelmOperator? EnableHelmOperator { get; set; }
        /// <summary>Properties for Helm operator.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IHelmOperatorProperties HelmOperatorProperty { get; set; }
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
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorScope? OperatorScope { get; set; }
        /// <summary>Type of the operator</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorType? OperatorType { get; set; }
        /// <summary>Properties to create a Source Control Configuration resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationProperties Property { get; set; }
        /// <summary>The provisioning state of the resource provider.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>
        /// Public Key associated with this SourceControl configuration (either generated within the cluster or provided by the user).
        /// </summary>
        string RepositoryPublicKey { get; set; }
        /// <summary>Url of the SourceControl Repository.</summary>
        string RepositoryUrl { get; set; }

    }
}
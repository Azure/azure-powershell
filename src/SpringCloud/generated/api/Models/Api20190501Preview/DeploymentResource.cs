namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Deployment resource payload</summary>
    public partial class DeploymentResource :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResource,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IProxyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IProxyResource __proxyResource = new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ProxyResource();

        /// <summary>Indicates whether the Deployment is active</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public bool? Active { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).Active; }

        /// <summary>App name of the deployment</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string AppName { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).AppName; }

        /// <summary>Date time when the resource is created</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public global::System.DateTime? CreatedTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).CreatedTime; }

        /// <summary>Required CPU, basic tier should be 1, standard tier should be in range (1, 4)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public int? DeploymentSettingCpu { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).DeploymentSettingCpu; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).DeploymentSettingCpu = value; }

        /// <summary>Collection of environment variables</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsEnvironmentVariables DeploymentSettingEnvironmentVariable { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).DeploymentSettingEnvironmentVariable; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).DeploymentSettingEnvironmentVariable = value; }

        /// <summary>
        /// Instance count, basic tier should be in range (1, 25), standard tier should be in range (1, 500)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public int? DeploymentSettingInstanceCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).DeploymentSettingInstanceCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).DeploymentSettingInstanceCount = value; }

        /// <summary>JVM parameter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string DeploymentSettingJvmOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).DeploymentSettingJvmOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).DeploymentSettingJvmOption = value; }

        /// <summary>
        /// Required Memory size in GB, basic tier should be in range (1, 2), standard tier should be in range (1, 8)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public int? DeploymentSettingMemoryInGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).DeploymentSettingMemoryInGb; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).DeploymentSettingMemoryInGb = value; }

        /// <summary>Runtime version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.RuntimeVersion? DeploymentSettingRuntimeVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).DeploymentSettingRuntimeVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).DeploymentSettingRuntimeVersion = value; }

        /// <summary>Fully qualified resource Id for the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal)__proxyResource).Id; }

        /// <summary>Collection of instances belong to the Deployment</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentInstance[] Instance { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).Instance; }

        /// <summary>Internal Acessors for Active</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourceInternal.Active { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).Active; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).Active = value; }

        /// <summary>Internal Acessors for AppName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourceInternal.AppName { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).AppName; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).AppName = value; }

        /// <summary>Internal Acessors for CreatedTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourceInternal.CreatedTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).CreatedTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).CreatedTime = value; }

        /// <summary>Internal Acessors for DeploymentSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettings Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourceInternal.DeploymentSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).DeploymentSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).DeploymentSetting = value; }

        /// <summary>Internal Acessors for Instance</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentInstance[] Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourceInternal.Instance { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).Instance; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).Instance = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourceProperties Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.DeploymentResourceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.DeploymentResourceProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourceInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Source</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IUserSourceInfo Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourceInternal.Source { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).Source; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).Source = value; }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.DeploymentResourceStatus? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourceInternal.Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).Status = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal)__proxyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal)__proxyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal)__proxyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal)__proxyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal)__proxyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal)__proxyResource).Type = value; }

        /// <summary>The name of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal)__proxyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourceProperties _property;

        /// <summary>Properties of the Deployment resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.DeploymentResourceProperties()); set => this._property = value; }

        /// <summary>Provisioning state of the Deployment</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.DeploymentResourceProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).ProvisioningState; }

        /// <summary>
        /// Selector for the artifact to be used for the deployment for multi-module projects. This should be
        /// the relative path to the target module/project.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string SourceArtifactSelector { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).SourceArtifactSelector; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).SourceArtifactSelector = value; }

        /// <summary>Relative path of the storage which stores the source</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string SourceRelativePath { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).SourceRelativePath; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).SourceRelativePath = value; }

        /// <summary>Type of the source uploaded</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.UserSourceType? SourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).SourceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).SourceType = value; }

        /// <summary>Version of the source</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string SourceVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).SourceVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).SourceVersion = value; }

        /// <summary>Status of the Deployment</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.DeploymentResourceStatus? Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourcePropertiesInternal)Property).Status; }

        /// <summary>The type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal)__proxyResource).Type; }

        /// <summary>Creates an new <see cref="DeploymentResource" /> instance.</summary>
        public DeploymentResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyResource), __proxyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyResource), __proxyResource);
        }
    }
    /// Deployment resource payload
    public partial interface IDeploymentResource :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IProxyResource
    {
        /// <summary>Indicates whether the Deployment is active</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Indicates whether the Deployment is active",
        SerializedName = @"active",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Active { get;  }
        /// <summary>App name of the deployment</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"App name of the deployment",
        SerializedName = @"appName",
        PossibleTypes = new [] { typeof(string) })]
        string AppName { get;  }
        /// <summary>Date time when the resource is created</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Date time when the resource is created",
        SerializedName = @"createdTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreatedTime { get;  }
        /// <summary>Required CPU, basic tier should be 1, standard tier should be in range (1, 4)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Required CPU, basic tier should be 1, standard tier should be in range (1, 4)",
        SerializedName = @"cpu",
        PossibleTypes = new [] { typeof(int) })]
        int? DeploymentSettingCpu { get; set; }
        /// <summary>Collection of environment variables</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of environment variables",
        SerializedName = @"environmentVariables",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsEnvironmentVariables) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsEnvironmentVariables DeploymentSettingEnvironmentVariable { get; set; }
        /// <summary>
        /// Instance count, basic tier should be in range (1, 25), standard tier should be in range (1, 500)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Instance count, basic tier should be in range (1, 25), standard tier should be in range (1, 500)",
        SerializedName = @"instanceCount",
        PossibleTypes = new [] { typeof(int) })]
        int? DeploymentSettingInstanceCount { get; set; }
        /// <summary>JVM parameter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"JVM parameter",
        SerializedName = @"jvmOptions",
        PossibleTypes = new [] { typeof(string) })]
        string DeploymentSettingJvmOption { get; set; }
        /// <summary>
        /// Required Memory size in GB, basic tier should be in range (1, 2), standard tier should be in range (1, 8)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Required Memory size in GB, basic tier should be in range (1, 2), standard tier should be in range (1, 8)",
        SerializedName = @"memoryInGB",
        PossibleTypes = new [] { typeof(int) })]
        int? DeploymentSettingMemoryInGb { get; set; }
        /// <summary>Runtime version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Runtime version",
        SerializedName = @"runtimeVersion",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.RuntimeVersion) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.RuntimeVersion? DeploymentSettingRuntimeVersion { get; set; }
        /// <summary>Collection of instances belong to the Deployment</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Collection of instances belong to the Deployment",
        SerializedName = @"instances",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentInstance) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentInstance[] Instance { get;  }
        /// <summary>Provisioning state of the Deployment</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the Deployment",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.DeploymentResourceProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.DeploymentResourceProvisioningState? ProvisioningState { get;  }
        /// <summary>
        /// Selector for the artifact to be used for the deployment for multi-module projects. This should be
        /// the relative path to the target module/project.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Selector for the artifact to be used for the deployment for multi-module projects. This should be
        the relative path to the target module/project.",
        SerializedName = @"artifactSelector",
        PossibleTypes = new [] { typeof(string) })]
        string SourceArtifactSelector { get; set; }
        /// <summary>Relative path of the storage which stores the source</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Relative path of the storage which stores the source",
        SerializedName = @"relativePath",
        PossibleTypes = new [] { typeof(string) })]
        string SourceRelativePath { get; set; }
        /// <summary>Type of the source uploaded</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of the source uploaded",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.UserSourceType) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.UserSourceType? SourceType { get; set; }
        /// <summary>Version of the source</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Version of the source",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string SourceVersion { get; set; }
        /// <summary>Status of the Deployment</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Status of the Deployment",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.DeploymentResourceStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.DeploymentResourceStatus? Status { get;  }

    }
    /// Deployment resource payload
    public partial interface IDeploymentResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IProxyResourceInternal
    {
        /// <summary>Indicates whether the Deployment is active</summary>
        bool? Active { get; set; }
        /// <summary>App name of the deployment</summary>
        string AppName { get; set; }
        /// <summary>Date time when the resource is created</summary>
        global::System.DateTime? CreatedTime { get; set; }
        /// <summary>Deployment settings of the Deployment</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettings DeploymentSetting { get; set; }
        /// <summary>Required CPU, basic tier should be 1, standard tier should be in range (1, 4)</summary>
        int? DeploymentSettingCpu { get; set; }
        /// <summary>Collection of environment variables</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsEnvironmentVariables DeploymentSettingEnvironmentVariable { get; set; }
        /// <summary>
        /// Instance count, basic tier should be in range (1, 25), standard tier should be in range (1, 500)
        /// </summary>
        int? DeploymentSettingInstanceCount { get; set; }
        /// <summary>JVM parameter</summary>
        string DeploymentSettingJvmOption { get; set; }
        /// <summary>
        /// Required Memory size in GB, basic tier should be in range (1, 2), standard tier should be in range (1, 8)
        /// </summary>
        int? DeploymentSettingMemoryInGb { get; set; }
        /// <summary>Runtime version</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.RuntimeVersion? DeploymentSettingRuntimeVersion { get; set; }
        /// <summary>Collection of instances belong to the Deployment</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentInstance[] Instance { get; set; }
        /// <summary>Properties of the Deployment resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResourceProperties Property { get; set; }
        /// <summary>Provisioning state of the Deployment</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.DeploymentResourceProvisioningState? ProvisioningState { get; set; }
        /// <summary>Uploaded source information of the deployment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IUserSourceInfo Source { get; set; }
        /// <summary>
        /// Selector for the artifact to be used for the deployment for multi-module projects. This should be
        /// the relative path to the target module/project.
        /// </summary>
        string SourceArtifactSelector { get; set; }
        /// <summary>Relative path of the storage which stores the source</summary>
        string SourceRelativePath { get; set; }
        /// <summary>Type of the source uploaded</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.UserSourceType? SourceType { get; set; }
        /// <summary>Version of the source</summary>
        string SourceVersion { get; set; }
        /// <summary>Status of the Deployment</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.DeploymentResourceStatus? Status { get; set; }

    }
}
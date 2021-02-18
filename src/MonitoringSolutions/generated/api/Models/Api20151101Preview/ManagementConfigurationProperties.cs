namespace Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Extensions;

    /// <summary>
    /// ManagementConfiguration properties supported by the OperationsManagement resource provider.
    /// </summary>
    public partial class ManagementConfigurationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementConfigurationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementConfigurationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ApplicationId" /> property.</summary>
        private string _applicationId;

        /// <summary>The applicationId of the appliance for this Management.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        public string ApplicationId { get => this._applicationId; set => this._applicationId = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementConfigurationPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="Parameter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IArmTemplateParameter[] _parameter;

        /// <summary>Parameters to run the ARM template</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IArmTemplateParameter[] Parameter { get => this._parameter; set => this._parameter = value; }

        /// <summary>Backing field for <see cref="ParentResourceType" /> property.</summary>
        private string _parentResourceType;

        /// <summary>The type of the parent resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        public string ParentResourceType { get => this._parentResourceType; set => this._parentResourceType = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The provisioning state for the ManagementConfiguration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="Template" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementConfigurationPropertiesTemplate _template;

        /// <summary>The Json object containing the ARM template to deploy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementConfigurationPropertiesTemplate Template { get => (this._template = this._template ?? new Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ManagementConfigurationPropertiesTemplate()); set => this._template = value; }

        /// <summary>Creates an new <see cref="ManagementConfigurationProperties" /> instance.</summary>
        public ManagementConfigurationProperties()
        {

        }
    }
    /// ManagementConfiguration properties supported by the OperationsManagement resource provider.
    public partial interface IManagementConfigurationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.IJsonSerializable
    {
        /// <summary>The applicationId of the appliance for this Management.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The applicationId of the appliance for this Management.",
        SerializedName = @"applicationId",
        PossibleTypes = new [] { typeof(string) })]
        string ApplicationId { get; set; }
        /// <summary>Parameters to run the ARM template</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Parameters to run the ARM template",
        SerializedName = @"parameters",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IArmTemplateParameter) })]
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IArmTemplateParameter[] Parameter { get; set; }
        /// <summary>The type of the parent resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The type of the parent resource.",
        SerializedName = @"parentResourceType",
        PossibleTypes = new [] { typeof(string) })]
        string ParentResourceType { get; set; }
        /// <summary>The provisioning state for the ManagementConfiguration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state for the ManagementConfiguration.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>The Json object containing the ARM template to deploy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The Json object containing the ARM template to deploy",
        SerializedName = @"template",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementConfigurationPropertiesTemplate) })]
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementConfigurationPropertiesTemplate Template { get; set; }

    }
    /// ManagementConfiguration properties supported by the OperationsManagement resource provider.
    internal partial interface IManagementConfigurationPropertiesInternal

    {
        /// <summary>The applicationId of the appliance for this Management.</summary>
        string ApplicationId { get; set; }
        /// <summary>Parameters to run the ARM template</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IArmTemplateParameter[] Parameter { get; set; }
        /// <summary>The type of the parent resource.</summary>
        string ParentResourceType { get; set; }
        /// <summary>The provisioning state for the ManagementConfiguration.</summary>
        string ProvisioningState { get; set; }
        /// <summary>The Json object containing the ARM template to deploy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementConfigurationPropertiesTemplate Template { get; set; }

    }
}
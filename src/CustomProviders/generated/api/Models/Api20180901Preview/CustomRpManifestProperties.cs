namespace Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Extensions;

    /// <summary>The manifest for the custom resource provider</summary>
    public partial class CustomRpManifestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifestProperties,
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifestPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Action" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpActionRouteDefinition[] _action;

        /// <summary>A list of actions that the custom resource provider implements.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpActionRouteDefinition[] Action { get => this._action; set => this._action = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifestPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Support.ProvisioningState? _provisioningState;

        /// <summary>The provisioning state of the resource provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="ResourceType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpResourceTypeRouteDefinition[] _resourceType;

        /// <summary>A list of resource types that the custom resource provider implements.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpResourceTypeRouteDefinition[] ResourceType { get => this._resourceType; set => this._resourceType = value; }

        /// <summary>Backing field for <see cref="Validation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpValidations[] _validation;

        /// <summary>A list of validations to run on the custom resource provider's requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpValidations[] Validation { get => this._validation; set => this._validation = value; }

        /// <summary>Creates an new <see cref="CustomRpManifestProperties" /> instance.</summary>
        public CustomRpManifestProperties()
        {

        }
    }
    /// The manifest for the custom resource provider
    public partial interface ICustomRpManifestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.IJsonSerializable
    {
        /// <summary>A list of actions that the custom resource provider implements.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of actions that the custom resource provider implements.",
        SerializedName = @"actions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpActionRouteDefinition) })]
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpActionRouteDefinition[] Action { get; set; }
        /// <summary>The provisioning state of the resource provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the resource provider.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>A list of resource types that the custom resource provider implements.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of resource types that the custom resource provider implements.",
        SerializedName = @"resourceTypes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpResourceTypeRouteDefinition) })]
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpResourceTypeRouteDefinition[] ResourceType { get; set; }
        /// <summary>A list of validations to run on the custom resource provider's requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of validations to run on the custom resource provider's requests.",
        SerializedName = @"validations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpValidations) })]
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpValidations[] Validation { get; set; }

    }
    /// The manifest for the custom resource provider
    internal partial interface ICustomRpManifestPropertiesInternal

    {
        /// <summary>A list of actions that the custom resource provider implements.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpActionRouteDefinition[] Action { get; set; }
        /// <summary>The provisioning state of the resource provider.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>A list of resource types that the custom resource provider implements.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpResourceTypeRouteDefinition[] ResourceType { get; set; }
        /// <summary>A list of validations to run on the custom resource provider's requests.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpValidations[] Validation { get; set; }

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Extensions;

    /// <summary>A manifest file that defines the custom resource provider resources.</summary>
    public partial class CustomRpManifest :
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifest,
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifestInternal,
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.Resource();

        /// <summary>A list of actions that the custom resource provider implements.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpActionRouteDefinition[] Action { get => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifestPropertiesInternal)Property).Action; set => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifestPropertiesInternal)Property).Action = value; }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceInternal)__resource).Id; }

        /// <summary>Resource location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceInternal)__resource).Location = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifestProperties Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifestInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.CustomRpManifestProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifestInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifestPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifestPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifestProperties _property;

        /// <summary>The manifest for the custom resource provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifestProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.CustomRpManifestProperties()); set => this._property = value; }

        /// <summary>The provisioning state of the resource provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifestPropertiesInternal)Property).ProvisioningState; }

        /// <summary>A list of resource types that the custom resource provider implements.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpResourceTypeRouteDefinition[] ResourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifestPropertiesInternal)Property).ResourceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifestPropertiesInternal)Property).ResourceType = value; }

        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceInternal)__resource).Tag = value; }

        /// <summary>Resource type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceInternal)__resource).Type; }

        /// <summary>A list of validations to run on the custom resource provider's requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpValidations[] Validation { get => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifestPropertiesInternal)Property).Validation; set => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifestPropertiesInternal)Property).Validation = value; }

        /// <summary>Creates an new <see cref="CustomRpManifest" /> instance.</summary>
        public CustomRpManifest()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// A manifest file that defines the custom resource provider resources.
    public partial interface ICustomRpManifest :
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResource
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
    /// A manifest file that defines the custom resource provider resources.
    internal partial interface ICustomRpManifestInternal :
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceInternal
    {
        /// <summary>A list of actions that the custom resource provider implements.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpActionRouteDefinition[] Action { get; set; }
        /// <summary>The manifest for the custom resource provider</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifestProperties Property { get; set; }
        /// <summary>The provisioning state of the resource provider.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>A list of resource types that the custom resource provider implements.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpResourceTypeRouteDefinition[] ResourceType { get; set; }
        /// <summary>A list of validations to run on the custom resource provider's requests.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpValidations[] Validation { get; set; }

    }
}
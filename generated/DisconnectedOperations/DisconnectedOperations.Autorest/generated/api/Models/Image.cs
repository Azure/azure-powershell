// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;

    /// <summary>Holds the release information of a disconnected operations image.</summary>
    public partial class Image :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImage,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IProxyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IProxyResource __proxyResource = new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ProxyResource();

        /// <summary>The versions that are compatible for this update package.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> CompatibleVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).CompatibleVersion; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).Id; }

        /// <summary>Internal Acessors for CompatibleVersion</summary>
        System.Collections.Generic.List<string> Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageInternal.CompatibleVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).CompatibleVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).CompatibleVersion = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageProperties Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ImageProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).ProvisioningState = value ?? null; }

        /// <summary>Internal Acessors for ReleaseDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageInternal.ReleaseDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).ReleaseDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).ReleaseDate = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for ReleaseDisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageInternal.ReleaseDisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).ReleaseDisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).ReleaseDisplayName = value ?? null; }

        /// <summary>Internal Acessors for ReleaseNote</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageInternal.ReleaseNote { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).ReleaseNote; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).ReleaseNote = value ?? null; }

        /// <summary>Internal Acessors for ReleaseType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageInternal.ReleaseType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).ReleaseType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).ReleaseType = value ?? null; }

        /// <summary>Internal Acessors for ReleaseVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageInternal.ReleaseVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).ReleaseVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).ReleaseVersion = value ?? null; }

        /// <summary>Internal Acessors for UpdateProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdateProperties Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageInternal.UpdateProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).UpdateProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).UpdateProperty = value ?? null /* model class */; }

        /// <summary>Internal Acessors for UpdatePropertyAgentVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageInternal.UpdatePropertyAgentVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).UpdatePropertyAgentVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).UpdatePropertyAgentVersion = value ?? null; }

        /// <summary>Internal Acessors for UpdatePropertyFeatureUpdate</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageInternal.UpdatePropertyFeatureUpdate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).UpdatePropertyFeatureUpdate; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).UpdatePropertyFeatureUpdate = value ?? null; }

        /// <summary>Internal Acessors for UpdatePropertyOSVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageInternal.UpdatePropertyOSVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).UpdatePropertyOSVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).UpdatePropertyOSVersion = value ?? null; }

        /// <summary>Internal Acessors for UpdatePropertySecurityUpdate</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageInternal.UpdatePropertySecurityUpdate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).UpdatePropertySecurityUpdate; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).UpdatePropertySecurityUpdate = value ?? null; }

        /// <summary>Internal Acessors for UpdatePropertySystemReboot</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageInternal.UpdatePropertySystemReboot { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).UpdatePropertySystemReboot; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).UpdatePropertySystemReboot = value ?? null; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).Id = value ?? null; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).Name = value ?? null; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ISystemData Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemData = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SystemDataCreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataCreatedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataCreatedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataLastModifiedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType = value ?? null; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).Type = value ?? null; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageProperties _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ImageProperties()); set => this._property = value; }

        /// <summary>The resource provisioning state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).ProvisioningState; }

        /// <summary>The release date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public global::System.DateTime? ReleaseDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).ReleaseDate; }

        /// <summary>The release name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string ReleaseDisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).ReleaseDisplayName; }

        /// <summary>The release notes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string ReleaseNote { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).ReleaseNote; }

        /// <summary>The release type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string ReleaseType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).ReleaseType; }

        /// <summary>The version of the package in the format 1.1.1</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string ReleaseVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).ReleaseVersion; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemData = value ?? null /* model class */; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__proxyResource).Type; }

        /// <summary>The version(s) of the agent software included in this image update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string UpdatePropertyAgentVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).UpdatePropertyAgentVersion; }

        /// <summary>Details of feature updates included in this image release.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string UpdatePropertyFeatureUpdate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).UpdatePropertyFeatureUpdate; }

        /// <summary>The operating system version provided by this image update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string UpdatePropertyOSVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).UpdatePropertyOSVersion; }

        /// <summary>Details of security updates included in this image release.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string UpdatePropertySecurityUpdate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).UpdatePropertySecurityUpdate; }

        /// <summary>Indicates if a system reboot is required after applying the update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string UpdatePropertySystemReboot { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImagePropertiesInternal)Property).UpdatePropertySystemReboot; }

        /// <summary>Creates an new <see cref="Image" /> instance.</summary>
        public Image()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyResource), __proxyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyResource), __proxyResource);
        }
    }
    /// Holds the release information of a disconnected operations image.
    public partial interface IImage :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IProxyResource
    {
        /// <summary>The versions that are compatible for this update package.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The versions that are compatible for this update package.",
        SerializedName = @"compatibleVersions",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> CompatibleVersion { get;  }
        /// <summary>The resource provisioning state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The resource provisioning state",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled")]
        string ProvisioningState { get;  }
        /// <summary>The release date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The release date",
        SerializedName = @"releaseDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ReleaseDate { get;  }
        /// <summary>The release name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The release name",
        SerializedName = @"releaseDisplayName",
        PossibleTypes = new [] { typeof(string) })]
        string ReleaseDisplayName { get;  }
        /// <summary>The release notes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The release notes",
        SerializedName = @"releaseNotes",
        PossibleTypes = new [] { typeof(string) })]
        string ReleaseNote { get;  }
        /// <summary>The release type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The release type",
        SerializedName = @"releaseType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Install", "Update")]
        string ReleaseType { get;  }
        /// <summary>The version of the package in the format 1.1.1</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The version of the package in the format 1.1.1",
        SerializedName = @"releaseVersion",
        PossibleTypes = new [] { typeof(string) })]
        string ReleaseVersion { get;  }
        /// <summary>The version(s) of the agent software included in this image update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The version(s) of the agent software included in this image update.",
        SerializedName = @"agentVersion",
        PossibleTypes = new [] { typeof(string) })]
        string UpdatePropertyAgentVersion { get;  }
        /// <summary>Details of feature updates included in this image release.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Details of feature updates included in this image release.",
        SerializedName = @"featureUpdates",
        PossibleTypes = new [] { typeof(string) })]
        string UpdatePropertyFeatureUpdate { get;  }
        /// <summary>The operating system version provided by this image update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The operating system version provided by this image update.",
        SerializedName = @"osVersion",
        PossibleTypes = new [] { typeof(string) })]
        string UpdatePropertyOSVersion { get;  }
        /// <summary>Details of security updates included in this image release.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Details of security updates included in this image release.",
        SerializedName = @"securityUpdates",
        PossibleTypes = new [] { typeof(string) })]
        string UpdatePropertySecurityUpdate { get;  }
        /// <summary>Indicates if a system reboot is required after applying the update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Indicates if a system reboot is required after applying the update.",
        SerializedName = @"systemReboot",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Required", "NotRequired")]
        string UpdatePropertySystemReboot { get;  }

    }
    /// Holds the release information of a disconnected operations image.
    internal partial interface IImageInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IProxyResourceInternal
    {
        /// <summary>The versions that are compatible for this update package.</summary>
        System.Collections.Generic.List<string> CompatibleVersion { get; set; }
        /// <summary>The resource-specific properties for this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageProperties Property { get; set; }
        /// <summary>The resource provisioning state</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled")]
        string ProvisioningState { get; set; }
        /// <summary>The release date</summary>
        global::System.DateTime? ReleaseDate { get; set; }
        /// <summary>The release name</summary>
        string ReleaseDisplayName { get; set; }
        /// <summary>The release notes</summary>
        string ReleaseNote { get; set; }
        /// <summary>The release type</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Install", "Update")]
        string ReleaseType { get; set; }
        /// <summary>The version of the package in the format 1.1.1</summary>
        string ReleaseVersion { get; set; }
        /// <summary>Image update properties for update release type image.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdateProperties UpdateProperty { get; set; }
        /// <summary>The version(s) of the agent software included in this image update.</summary>
        string UpdatePropertyAgentVersion { get; set; }
        /// <summary>Details of feature updates included in this image release.</summary>
        string UpdatePropertyFeatureUpdate { get; set; }
        /// <summary>The operating system version provided by this image update.</summary>
        string UpdatePropertyOSVersion { get; set; }
        /// <summary>Details of security updates included in this image release.</summary>
        string UpdatePropertySecurityUpdate { get; set; }
        /// <summary>Indicates if a system reboot is required after applying the update.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Required", "NotRequired")]
        string UpdatePropertySystemReboot { get; set; }

    }
}
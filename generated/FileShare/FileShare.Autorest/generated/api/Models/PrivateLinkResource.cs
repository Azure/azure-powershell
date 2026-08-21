// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>A private link resource.</summary>
    public partial class PrivateLinkResource :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateLinkResource,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateLinkResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IProxyResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IProxyResource __proxyResource = new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ProxyResource();

        /// <summary>The private link resource group id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public string GroupId { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateLinkResourcePropertiesInternal)Property).GroupId; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).Id; }

        /// <summary>Internal Acessors for GroupId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateLinkResourceInternal.GroupId { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateLinkResourcePropertiesInternal)Property).GroupId; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateLinkResourcePropertiesInternal)Property).GroupId = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateLinkResourceProperties Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateLinkResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.PrivateLinkResourceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for RequiredMember</summary>
        System.Collections.Generic.List<string> Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateLinkResourceInternal.RequiredMember { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateLinkResourcePropertiesInternal)Property).RequiredMember; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateLinkResourcePropertiesInternal)Property).RequiredMember = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for RequiredZoneName</summary>
        System.Collections.Generic.List<string> Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateLinkResourceInternal.RequiredZoneName { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateLinkResourcePropertiesInternal)Property).RequiredZoneName; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateLinkResourcePropertiesInternal)Property).RequiredZoneName = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).Id = value ?? null; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).Name = value ?? null; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ISystemData Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).SystemData = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SystemDataCreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal.SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataCreatedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal.SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataCreatedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal.SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal.SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataLastModifiedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal.SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal.SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType = value ?? null; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).Type = value ?? null; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateLinkResourceProperties _property;

        /// <summary>Resource properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateLinkResourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.PrivateLinkResourceProperties()); set => this._property = value; }

        /// <summary>The private link resource required member names.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> RequiredMember { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateLinkResourcePropertiesInternal)Property).RequiredMember; }

        /// <summary>The private link resource private link DNS zone name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> RequiredZoneName { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateLinkResourcePropertiesInternal)Property).RequiredZoneName; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).SystemData = value ?? null /* model class */; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inherited)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inherited)]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IResourceInternal)__proxyResource).Type; }

        /// <summary>Creates an new <see cref="PrivateLinkResource" /> instance.</summary>
        public PrivateLinkResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyResource), __proxyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyResource), __proxyResource);
        }
    }
    /// A private link resource.
    public partial interface IPrivateLinkResource :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IProxyResource
    {
        /// <summary>The private link resource group id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The private link resource group id.",
        SerializedName = @"groupId",
        PossibleTypes = new [] { typeof(string) })]
        string GroupId { get;  }
        /// <summary>The private link resource required member names.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The private link resource required member names.",
        SerializedName = @"requiredMembers",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> RequiredMember { get;  }
        /// <summary>The private link resource private link DNS zone name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The private link resource private link DNS zone name.",
        SerializedName = @"requiredZoneNames",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> RequiredZoneName { get;  }

    }
    /// A private link resource.
    internal partial interface IPrivateLinkResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IProxyResourceInternal
    {
        /// <summary>The private link resource group id.</summary>
        string GroupId { get; set; }
        /// <summary>Resource properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateLinkResourceProperties Property { get; set; }
        /// <summary>The private link resource required member names.</summary>
        System.Collections.Generic.List<string> RequiredMember { get; set; }
        /// <summary>The private link resource private link DNS zone name.</summary>
        System.Collections.Generic.List<string> RequiredZoneName { get; set; }

    }
}
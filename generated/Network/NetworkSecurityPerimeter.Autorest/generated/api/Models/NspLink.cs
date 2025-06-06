// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Runtime.Extensions;

    /// <summary>The network security perimeter link resource</summary>
    public partial class NspLink :
        Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLink,
        Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkInternal,
        Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IProxyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IProxyResource __proxyResource = new Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.ProxyResource();

        /// <summary>
        /// Perimeter ARM Id for the remote NSP with which the link gets created in Auto-approval mode. It should be used when the
        /// NSP admin have Microsoft.Network/networkSecurityPerimeters/linkPerimeter/action permission on the remote NSP resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PropertyOrigin.Inlined)]
        public string AutoApprovedRemotePerimeterResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).AutoApprovedRemotePerimeterResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).AutoApprovedRemotePerimeterResourceId = value ?? null; }

        /// <summary>
        /// A message passed to the owner of the remote NSP link resource with this connection request. In case of Auto-approved flow,
        /// it is default to 'Auto Approved'. Restricted to 140 chars.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).Description = value ?? null; }

        /// <summary>
        /// Fully qualified resource ID for the resource. E.g. "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).Id; }

        /// <summary>
        /// Local Inbound profile names to which Inbound is allowed. Use ['*'] to allow inbound to all profiles.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> LocalInboundProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).LocalInboundProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).LocalInboundProfile = value ?? null /* arrayOf */; }

        /// <summary>
        /// Local Outbound profile names from which Outbound is allowed. In current version, it is readonly property and it's value
        /// is set to ['*'] to allow outbound from all profiles. In later version, user will be able to modify it.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> LocalOutboundProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).LocalOutboundProfile; }

        /// <summary>Internal Acessors for LocalOutboundProfile</summary>
        System.Collections.Generic.List<string> Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkInternal.LocalOutboundProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).LocalOutboundProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).LocalOutboundProfile = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkProperties Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.NspLinkProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).ProvisioningState = value ?? null; }

        /// <summary>Internal Acessors for RemoteOutboundProfile</summary>
        System.Collections.Generic.List<string> Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkInternal.RemoteOutboundProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).RemoteOutboundProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).RemoteOutboundProfile = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for RemotePerimeterGuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkInternal.RemotePerimeterGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).RemotePerimeterGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).RemotePerimeterGuid = value ?? null; }

        /// <summary>Internal Acessors for RemotePerimeterLocation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkInternal.RemotePerimeterLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).RemotePerimeterLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).RemotePerimeterLocation = value ?? null; }

        /// <summary>Internal Acessors for Status</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkInternal.Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).Status = value ?? null; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).Id = value ?? null; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).Name = value ?? null; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.ISystemData Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).SystemData = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SystemDataCreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal.SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataCreatedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal.SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataCreatedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal.SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal.SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataLastModifiedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal.SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal.SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType = value ?? null; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).Type = value ?? null; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkProperties _property;

        /// <summary>Properties of the network security perimeter link resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.NspLinkProperties()); set => this._property = value; }

        /// <summary>The provisioning state of the NSP Link resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).ProvisioningState; }

        /// <summary>
        /// Remote Inbound profile names to which Inbound is allowed. Use ['*'] to allow inbound to all profiles. This property can
        /// only be updated in auto-approval mode.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> RemoteInboundProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).RemoteInboundProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).RemoteInboundProfile = value ?? null /* arrayOf */; }

        /// <summary>
        /// Remote Outbound profile names from which Outbound is allowed. In current version, it is readonly property and it's value
        /// is set to ['*'] to allow outbound from all profiles. In later version, user will be able to modify it.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> RemoteOutboundProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).RemoteOutboundProfile; }

        /// <summary>Remote NSP Guid with which the link gets created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PropertyOrigin.Inlined)]
        public string RemotePerimeterGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).RemotePerimeterGuid; }

        /// <summary>Remote NSP location with which the link gets created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PropertyOrigin.Inlined)]
        public string RemotePerimeterLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).RemotePerimeterLocation; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>The NSP link state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PropertyOrigin.Inlined)]
        public string Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkPropertiesInternal)Property).Status; }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).SystemData = value ?? null /* model class */; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PropertyOrigin.Inherited)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PropertyOrigin.Inherited)]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IResourceInternal)__proxyResource).Type; }

        /// <summary>Creates an new <see cref="NspLink" /> instance.</summary>
        public NspLink()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyResource), __proxyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyResource), __proxyResource);
        }
    }
    /// The network security perimeter link resource
    public partial interface INspLink :
        Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IProxyResource
    {
        /// <summary>
        /// Perimeter ARM Id for the remote NSP with which the link gets created in Auto-approval mode. It should be used when the
        /// NSP admin have Microsoft.Network/networkSecurityPerimeters/linkPerimeter/action permission on the remote NSP resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Perimeter ARM Id for the remote NSP with which the link gets created in Auto-approval mode. It should be used when the NSP admin have Microsoft.Network/networkSecurityPerimeters/linkPerimeter/action permission on the remote NSP resource.",
        SerializedName = @"autoApprovedRemotePerimeterResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string AutoApprovedRemotePerimeterResourceId { get; set; }
        /// <summary>
        /// A message passed to the owner of the remote NSP link resource with this connection request. In case of Auto-approved flow,
        /// it is default to 'Auto Approved'. Restricted to 140 chars.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A message passed to the owner of the remote NSP link resource with this connection request. In case of Auto-approved flow, it is default to 'Auto Approved'. Restricted to 140 chars.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>
        /// Local Inbound profile names to which Inbound is allowed. Use ['*'] to allow inbound to all profiles.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Local Inbound profile names to which Inbound is allowed. Use ['*'] to allow inbound to all profiles.",
        SerializedName = @"localInboundProfiles",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> LocalInboundProfile { get; set; }
        /// <summary>
        /// Local Outbound profile names from which Outbound is allowed. In current version, it is readonly property and it's value
        /// is set to ['*'] to allow outbound from all profiles. In later version, user will be able to modify it.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Local Outbound profile names from which Outbound is allowed. In current version, it is readonly property and it's value is set to ['*'] to allow outbound from all profiles. In later version, user will be able to modify it.",
        SerializedName = @"localOutboundProfiles",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> LocalOutboundProfile { get;  }
        /// <summary>The provisioning state of the NSP Link resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The provisioning state of the NSP Link resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PSArgumentCompleterAttribute("Succeeded", "Creating", "Updating", "Deleting", "Accepted", "Failed", "WaitForRemoteCompletion")]
        string ProvisioningState { get;  }
        /// <summary>
        /// Remote Inbound profile names to which Inbound is allowed. Use ['*'] to allow inbound to all profiles. This property can
        /// only be updated in auto-approval mode.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Remote Inbound profile names to which Inbound is allowed. Use ['*'] to allow inbound to all profiles. This property can only be updated in auto-approval mode.",
        SerializedName = @"remoteInboundProfiles",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> RemoteInboundProfile { get; set; }
        /// <summary>
        /// Remote Outbound profile names from which Outbound is allowed. In current version, it is readonly property and it's value
        /// is set to ['*'] to allow outbound from all profiles. In later version, user will be able to modify it.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Remote Outbound profile names from which Outbound is allowed. In current version, it is readonly property and it's value is set to ['*'] to allow outbound from all profiles. In later version, user will be able to modify it.",
        SerializedName = @"remoteOutboundProfiles",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> RemoteOutboundProfile { get;  }
        /// <summary>Remote NSP Guid with which the link gets created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Remote NSP Guid with which the link gets created.",
        SerializedName = @"remotePerimeterGuid",
        PossibleTypes = new [] { typeof(string) })]
        string RemotePerimeterGuid { get;  }
        /// <summary>Remote NSP location with which the link gets created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Remote NSP location with which the link gets created.",
        SerializedName = @"remotePerimeterLocation",
        PossibleTypes = new [] { typeof(string) })]
        string RemotePerimeterLocation { get;  }
        /// <summary>The NSP link state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The NSP link state.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PSArgumentCompleterAttribute("Approved", "Pending", "Rejected", "Disconnected")]
        string Status { get;  }

    }
    /// The network security perimeter link resource
    internal partial interface INspLinkInternal :
        Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IProxyResourceInternal
    {
        /// <summary>
        /// Perimeter ARM Id for the remote NSP with which the link gets created in Auto-approval mode. It should be used when the
        /// NSP admin have Microsoft.Network/networkSecurityPerimeters/linkPerimeter/action permission on the remote NSP resource.
        /// </summary>
        string AutoApprovedRemotePerimeterResourceId { get; set; }
        /// <summary>
        /// A message passed to the owner of the remote NSP link resource with this connection request. In case of Auto-approved flow,
        /// it is default to 'Auto Approved'. Restricted to 140 chars.
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Local Inbound profile names to which Inbound is allowed. Use ['*'] to allow inbound to all profiles.
        /// </summary>
        System.Collections.Generic.List<string> LocalInboundProfile { get; set; }
        /// <summary>
        /// Local Outbound profile names from which Outbound is allowed. In current version, it is readonly property and it's value
        /// is set to ['*'] to allow outbound from all profiles. In later version, user will be able to modify it.
        /// </summary>
        System.Collections.Generic.List<string> LocalOutboundProfile { get; set; }
        /// <summary>Properties of the network security perimeter link resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLinkProperties Property { get; set; }
        /// <summary>The provisioning state of the NSP Link resource.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PSArgumentCompleterAttribute("Succeeded", "Creating", "Updating", "Deleting", "Accepted", "Failed", "WaitForRemoteCompletion")]
        string ProvisioningState { get; set; }
        /// <summary>
        /// Remote Inbound profile names to which Inbound is allowed. Use ['*'] to allow inbound to all profiles. This property can
        /// only be updated in auto-approval mode.
        /// </summary>
        System.Collections.Generic.List<string> RemoteInboundProfile { get; set; }
        /// <summary>
        /// Remote Outbound profile names from which Outbound is allowed. In current version, it is readonly property and it's value
        /// is set to ['*'] to allow outbound from all profiles. In later version, user will be able to modify it.
        /// </summary>
        System.Collections.Generic.List<string> RemoteOutboundProfile { get; set; }
        /// <summary>Remote NSP Guid with which the link gets created.</summary>
        string RemotePerimeterGuid { get; set; }
        /// <summary>Remote NSP location with which the link gets created.</summary>
        string RemotePerimeterLocation { get; set; }
        /// <summary>The NSP link state.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.PSArgumentCompleterAttribute("Approved", "Pending", "Rejected", "Disconnected")]
        string Status { get; set; }

    }
}
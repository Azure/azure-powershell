namespace Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Extensions;

    /// <summary>Payload for iSCSI Target create or update requests.</summary>
    public partial class IscsiTargetCreate :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTargetCreate,
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTargetCreateInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.Resource();

        /// <summary>Mode for Target connectivity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Support.IscsiTargetAclMode AclMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTargetCreatePropertiesInternal)Property).AclMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTargetCreatePropertiesInternal)Property).AclMode = value ; }

        /// <summary>
        /// Fully qualified resource Id for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IResourceInternal)__resource).Id; }

        /// <summary>List of LUNs to be exposed through iSCSI Target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiLun[] Lun { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTargetCreatePropertiesInternal)Property).Lun; set => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTargetCreatePropertiesInternal)Property).Lun = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTargetCreateProperties Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTargetCreateInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IscsiTargetCreateProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IResourceInternal)__resource).Type = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTargetCreateProperties _property;

        /// <summary>Properties for iSCSI Target create request.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTargetCreateProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IscsiTargetCreateProperties()); set => this._property = value; }

        /// <summary>Access Control List (ACL) for an iSCSI Target; defines LUN masking policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IAcl[] StaticAcls { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTargetCreatePropertiesInternal)Property).StaticAcls; set => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTargetCreatePropertiesInternal)Property).StaticAcls = value ?? null /* arrayOf */; }

        /// <summary>
        /// iSCSI Target IQN (iSCSI Qualified Name); example: "iqn.2005-03.org.iscsi:server".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Inlined)]
        public string TargetIqn { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTargetCreatePropertiesInternal)Property).TargetIqn; set => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTargetCreatePropertiesInternal)Property).TargetIqn = value ?? null; }

        /// <summary>
        /// The type of the resource. Ex- Microsoft.Compute/virtualMachines or Microsoft.Storage/storageAccounts.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="IscsiTargetCreate" /> instance.</summary>
        public IscsiTargetCreate()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Payload for iSCSI Target create or update requests.
    public partial interface IIscsiTargetCreate :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IResource
    {
        /// <summary>Mode for Target connectivity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Mode for Target connectivity.",
        SerializedName = @"aclMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Support.IscsiTargetAclMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Support.IscsiTargetAclMode AclMode { get; set; }
        /// <summary>List of LUNs to be exposed through iSCSI Target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of LUNs to be exposed through iSCSI Target.",
        SerializedName = @"luns",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiLun) })]
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiLun[] Lun { get; set; }
        /// <summary>Access Control List (ACL) for an iSCSI Target; defines LUN masking policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Access Control List (ACL) for an iSCSI Target; defines LUN masking policy",
        SerializedName = @"staticAcls",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IAcl) })]
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IAcl[] StaticAcls { get; set; }
        /// <summary>
        /// iSCSI Target IQN (iSCSI Qualified Name); example: "iqn.2005-03.org.iscsi:server".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"iSCSI Target IQN (iSCSI Qualified Name); example: ""iqn.2005-03.org.iscsi:server"".",
        SerializedName = @"targetIqn",
        PossibleTypes = new [] { typeof(string) })]
        string TargetIqn { get; set; }

    }
    /// Payload for iSCSI Target create or update requests.
    internal partial interface IIscsiTargetCreateInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IResourceInternal
    {
        /// <summary>Mode for Target connectivity.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Support.IscsiTargetAclMode AclMode { get; set; }
        /// <summary>List of LUNs to be exposed through iSCSI Target.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiLun[] Lun { get; set; }
        /// <summary>Properties for iSCSI Target create request.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTargetCreateProperties Property { get; set; }
        /// <summary>Access Control List (ACL) for an iSCSI Target; defines LUN masking policy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IAcl[] StaticAcls { get; set; }
        /// <summary>
        /// iSCSI Target IQN (iSCSI Qualified Name); example: "iqn.2005-03.org.iscsi:server".
        /// </summary>
        string TargetIqn { get; set; }

    }
}
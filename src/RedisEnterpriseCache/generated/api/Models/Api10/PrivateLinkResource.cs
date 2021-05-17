namespace Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10
{
    using static Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Extensions;

    /// <summary>A private link resource</summary>
    public partial class PrivateLinkResource :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IPrivateLinkResource,
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IPrivateLinkResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.Resource();

        /// <summary>The private link resource group id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inlined)]
        public string GroupId { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IPrivateLinkResourcePropertiesInternal)Property).GroupId; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IResourceInternal)__resource).Id; }

        /// <summary>Internal Acessors for GroupId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IPrivateLinkResourceInternal.GroupId { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IPrivateLinkResourcePropertiesInternal)Property).GroupId; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IPrivateLinkResourcePropertiesInternal)Property).GroupId = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IPrivateLinkResourceProperties Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IPrivateLinkResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.PrivateLinkResourceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for RequiredMember</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IPrivateLinkResourceInternal.RequiredMember { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IPrivateLinkResourcePropertiesInternal)Property).RequiredMember; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IPrivateLinkResourcePropertiesInternal)Property).RequiredMember = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IResourceInternal)__resource).Type = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IPrivateLinkResourceProperties _property;

        /// <summary>Resource properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IPrivateLinkResourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.PrivateLinkResourceProperties()); set => this._property = value; }

        /// <summary>The private link resource required member names.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inlined)]
        public string[] RequiredMember { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IPrivateLinkResourcePropertiesInternal)Property).RequiredMember; }

        /// <summary>The private link resource Private link DNS zone name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inlined)]
        public string[] RequiredZoneName { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IPrivateLinkResourcePropertiesInternal)Property).RequiredZoneName; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IPrivateLinkResourcePropertiesInternal)Property).RequiredZoneName = value ?? null /* arrayOf */; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="PrivateLinkResource" /> instance.</summary>
        public PrivateLinkResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// A private link resource
    public partial interface IPrivateLinkResource :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IResource
    {
        /// <summary>The private link resource group id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The private link resource group id.",
        SerializedName = @"groupId",
        PossibleTypes = new [] { typeof(string) })]
        string GroupId { get;  }
        /// <summary>The private link resource required member names.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The private link resource required member names.",
        SerializedName = @"requiredMembers",
        PossibleTypes = new [] { typeof(string) })]
        string[] RequiredMember { get;  }
        /// <summary>The private link resource Private link DNS zone name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The private link resource Private link DNS zone name.",
        SerializedName = @"requiredZoneNames",
        PossibleTypes = new [] { typeof(string) })]
        string[] RequiredZoneName { get; set; }

    }
    /// A private link resource
    internal partial interface IPrivateLinkResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IResourceInternal
    {
        /// <summary>The private link resource group id.</summary>
        string GroupId { get; set; }
        /// <summary>Resource properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IPrivateLinkResourceProperties Property { get; set; }
        /// <summary>The private link resource required member names.</summary>
        string[] RequiredMember { get; set; }
        /// <summary>The private link resource Private link DNS zone name.</summary>
        string[] RequiredZoneName { get; set; }

    }
}
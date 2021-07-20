namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>A private link resource</summary>
    public partial class PrivateLinkResource :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateLinkResource,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateLinkResourceInternal
    {

        /// <summary>Backing field for <see cref="GroupId" /> property.</summary>
        private string _groupId;

        /// <summary>The group ID of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string GroupId { get => this._groupId; set => this._groupId = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The ID of the private link resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Internal Acessors for PrivateLinkServiceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateLinkResourceInternal.PrivateLinkServiceId { get => this._privateLinkServiceId; set { {_privateLinkServiceId = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the private link resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="PrivateLinkServiceId" /> property.</summary>
        private string _privateLinkServiceId;

        /// <summary>
        /// The private link service ID of the resource, this field is exposed only to NRP internally.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string PrivateLinkServiceId { get => this._privateLinkServiceId; }

        /// <summary>Backing field for <see cref="RequiredMember" /> property.</summary>
        private string[] _requiredMember;

        /// <summary>RequiredMembers of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string[] RequiredMember { get => this._requiredMember; set => this._requiredMember = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="PrivateLinkResource" /> instance.</summary>
        public PrivateLinkResource()
        {

        }
    }
    /// A private link resource
    public partial interface IPrivateLinkResource :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>The group ID of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The group ID of the resource.",
        SerializedName = @"groupId",
        PossibleTypes = new [] { typeof(string) })]
        string GroupId { get; set; }
        /// <summary>The ID of the private link resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of the private link resource.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>The name of the private link resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the private link resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// The private link service ID of the resource, this field is exposed only to NRP internally.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The private link service ID of the resource, this field is exposed only to NRP internally.",
        SerializedName = @"privateLinkServiceID",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateLinkServiceId { get;  }
        /// <summary>RequiredMembers of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"RequiredMembers of the resource",
        SerializedName = @"requiredMembers",
        PossibleTypes = new [] { typeof(string) })]
        string[] RequiredMember { get; set; }
        /// <summary>The resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// A private link resource
    internal partial interface IPrivateLinkResourceInternal

    {
        /// <summary>The group ID of the resource.</summary>
        string GroupId { get; set; }
        /// <summary>The ID of the private link resource.</summary>
        string Id { get; set; }
        /// <summary>The name of the private link resource.</summary>
        string Name { get; set; }
        /// <summary>
        /// The private link service ID of the resource, this field is exposed only to NRP internally.
        /// </summary>
        string PrivateLinkServiceId { get; set; }
        /// <summary>RequiredMembers of the resource</summary>
        string[] RequiredMember { get; set; }
        /// <summary>The resource type.</summary>
        string Type { get; set; }

    }
}
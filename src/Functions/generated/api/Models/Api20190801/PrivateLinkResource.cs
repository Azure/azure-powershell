namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>A private link resource</summary>
    public partial class PrivateLinkResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResource,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResourceInternal
    {

        /// <summary>GroupId of a private link resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string GroupId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResourcePropertiesInternal)Property).GroupId; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Internal Acessors for GroupId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResourceInternal.GroupId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResourcePropertiesInternal)Property).GroupId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResourcePropertiesInternal)Property).GroupId = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResourceProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.PrivateLinkResourceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for RequiredMember</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResourceInternal.RequiredMember { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResourcePropertiesInternal)Property).RequiredMember; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResourcePropertiesInternal)Property).RequiredMember = value; }

        /// <summary>Internal Acessors for RequiredZoneName</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResourceInternal.RequiredZoneName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResourcePropertiesInternal)Property).RequiredZoneName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResourcePropertiesInternal)Property).RequiredZoneName = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of a private link resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResourceProperties _property;

        /// <summary>Properties of a private link resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.PrivateLinkResourceProperties()); set => this._property = value; }

        /// <summary>RequiredMembers of a private link resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] RequiredMember { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResourcePropertiesInternal)Property).RequiredMember; }

        /// <summary>RequiredZoneNames of a private link resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] RequiredZoneName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResourcePropertiesInternal)Property).RequiredZoneName; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="PrivateLinkResource" /> instance.</summary>
        public PrivateLinkResource()
        {

        }
    }
    /// A private link resource
    public partial interface IPrivateLinkResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>GroupId of a private link resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"GroupId of a private link resource",
        SerializedName = @"groupId",
        PossibleTypes = new [] { typeof(string) })]
        string GroupId { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>Name of a private link resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Name of a private link resource",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>RequiredMembers of a private link resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"RequiredMembers of a private link resource",
        SerializedName = @"requiredMembers",
        PossibleTypes = new [] { typeof(string) })]
        string[] RequiredMember { get;  }
        /// <summary>RequiredZoneNames of a private link resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"RequiredZoneNames of a private link resource",
        SerializedName = @"requiredZoneNames",
        PossibleTypes = new [] { typeof(string) })]
        string[] RequiredZoneName { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// A private link resource
    internal partial interface IPrivateLinkResourceInternal

    {
        /// <summary>GroupId of a private link resource</summary>
        string GroupId { get; set; }

        string Id { get; set; }
        /// <summary>Name of a private link resource</summary>
        string Name { get; set; }
        /// <summary>Properties of a private link resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResourceProperties Property { get; set; }
        /// <summary>RequiredMembers of a private link resource</summary>
        string[] RequiredMember { get; set; }
        /// <summary>RequiredZoneNames of a private link resource</summary>
        string[] RequiredZoneName { get; set; }

        string Type { get; set; }

    }
}
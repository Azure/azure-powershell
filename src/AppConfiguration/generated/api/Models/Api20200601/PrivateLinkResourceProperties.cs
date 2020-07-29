namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Extensions;

    /// <summary>Properties of a private link resource.</summary>
    public partial class PrivateLinkResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateLinkResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateLinkResourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="GroupId" /> property.</summary>
        private string _groupId;

        /// <summary>The private link resource group id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string GroupId { get => this._groupId; }

        /// <summary>Internal Acessors for GroupId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateLinkResourcePropertiesInternal.GroupId { get => this._groupId; set { {_groupId = value;} } }

        /// <summary>Internal Acessors for RequiredMember</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateLinkResourcePropertiesInternal.RequiredMember { get => this._requiredMember; set { {_requiredMember = value;} } }

        /// <summary>Internal Acessors for RequiredZoneName</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateLinkResourcePropertiesInternal.RequiredZoneName { get => this._requiredZoneName; set { {_requiredZoneName = value;} } }

        /// <summary>Backing field for <see cref="RequiredMember" /> property.</summary>
        private string[] _requiredMember;

        /// <summary>The private link resource required member names.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string[] RequiredMember { get => this._requiredMember; }

        /// <summary>Backing field for <see cref="RequiredZoneName" /> property.</summary>
        private string[] _requiredZoneName;

        /// <summary>The list of required DNS zone names of the private link resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string[] RequiredZoneName { get => this._requiredZoneName; }

        /// <summary>Creates an new <see cref="PrivateLinkResourceProperties" /> instance.</summary>
        public PrivateLinkResourceProperties()
        {

        }
    }
    /// Properties of a private link resource.
    public partial interface IPrivateLinkResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>The private link resource group id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The private link resource group id.",
        SerializedName = @"groupId",
        PossibleTypes = new [] { typeof(string) })]
        string GroupId { get;  }
        /// <summary>The private link resource required member names.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The private link resource required member names.",
        SerializedName = @"requiredMembers",
        PossibleTypes = new [] { typeof(string) })]
        string[] RequiredMember { get;  }
        /// <summary>The list of required DNS zone names of the private link resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The list of required DNS zone names of the private link resource.",
        SerializedName = @"requiredZoneNames",
        PossibleTypes = new [] { typeof(string) })]
        string[] RequiredZoneName { get;  }

    }
    /// Properties of a private link resource.
    internal partial interface IPrivateLinkResourcePropertiesInternal

    {
        /// <summary>The private link resource group id.</summary>
        string GroupId { get; set; }
        /// <summary>The private link resource required member names.</summary>
        string[] RequiredMember { get; set; }
        /// <summary>The list of required DNS zone names of the private link resource.</summary>
        string[] RequiredZoneName { get; set; }

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>StaticSiteUserInvitationResponseResource resource specific properties</summary>
    public partial class StaticSiteUserInvitationResponseResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationResponseResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationResponseResourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="ExpiresOn" /> property.</summary>
        private global::System.DateTime? _expiresOn;

        /// <summary>The expiration time of the invitation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? ExpiresOn { get => this._expiresOn; }

        /// <summary>Backing field for <see cref="InvitationUrl" /> property.</summary>
        private string _invitationUrl;

        /// <summary>The url for the invitation link</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string InvitationUrl { get => this._invitationUrl; }

        /// <summary>Internal Acessors for ExpiresOn</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationResponseResourcePropertiesInternal.ExpiresOn { get => this._expiresOn; set { {_expiresOn = value;} } }

        /// <summary>Internal Acessors for InvitationUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationResponseResourcePropertiesInternal.InvitationUrl { get => this._invitationUrl; set { {_invitationUrl = value;} } }

        /// <summary>
        /// Creates an new <see cref="StaticSiteUserInvitationResponseResourceProperties" /> instance.
        /// </summary>
        public StaticSiteUserInvitationResponseResourceProperties()
        {

        }
    }
    /// StaticSiteUserInvitationResponseResource resource specific properties
    public partial interface IStaticSiteUserInvitationResponseResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The expiration time of the invitation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The expiration time of the invitation",
        SerializedName = @"expiresOn",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ExpiresOn { get;  }
        /// <summary>The url for the invitation link</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The url for the invitation link",
        SerializedName = @"invitationUrl",
        PossibleTypes = new [] { typeof(string) })]
        string InvitationUrl { get;  }

    }
    /// StaticSiteUserInvitationResponseResource resource specific properties
    internal partial interface IStaticSiteUserInvitationResponseResourcePropertiesInternal

    {
        /// <summary>The expiration time of the invitation</summary>
        global::System.DateTime? ExpiresOn { get; set; }
        /// <summary>The url for the invitation link</summary>
        string InvitationUrl { get; set; }

    }
}
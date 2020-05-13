namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>StaticSiteUserInvitationRequestResource resource specific properties</summary>
    public partial class StaticSiteUserInvitationRequestResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationRequestResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserInvitationRequestResourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="Domain" /> property.</summary>
        private string _domain;

        /// <summary>The domain name for the static site custom domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Domain { get => this._domain; set => this._domain = value; }

        /// <summary>Backing field for <see cref="NumHoursToExpiration" /> property.</summary>
        private int? _numHoursToExpiration;

        /// <summary>The number of hours the sas token stays valid</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? NumHoursToExpiration { get => this._numHoursToExpiration; set => this._numHoursToExpiration = value; }

        /// <summary>Backing field for <see cref="Provider" /> property.</summary>
        private string _provider;

        /// <summary>The identity provider for the static site user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Provider { get => this._provider; set => this._provider = value; }

        /// <summary>Backing field for <see cref="Role" /> property.</summary>
        private string _role;

        /// <summary>The roles for the static site user, in free-form string format</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Role { get => this._role; set => this._role = value; }

        /// <summary>Backing field for <see cref="UserDetail" /> property.</summary>
        private string _userDetail;

        /// <summary>The user id for the static site user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string UserDetail { get => this._userDetail; set => this._userDetail = value; }

        /// <summary>
        /// Creates an new <see cref="StaticSiteUserInvitationRequestResourceProperties" /> instance.
        /// </summary>
        public StaticSiteUserInvitationRequestResourceProperties()
        {

        }
    }
    /// StaticSiteUserInvitationRequestResource resource specific properties
    public partial interface IStaticSiteUserInvitationRequestResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The domain name for the static site custom domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The domain name for the static site custom domain.",
        SerializedName = @"domain",
        PossibleTypes = new [] { typeof(string) })]
        string Domain { get; set; }
        /// <summary>The number of hours the sas token stays valid</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The number of hours the sas token stays valid",
        SerializedName = @"numHoursToExpiration",
        PossibleTypes = new [] { typeof(int) })]
        int? NumHoursToExpiration { get; set; }
        /// <summary>The identity provider for the static site user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identity provider for the static site user.",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string Provider { get; set; }
        /// <summary>The roles for the static site user, in free-form string format</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The roles for the static site user, in free-form string format",
        SerializedName = @"roles",
        PossibleTypes = new [] { typeof(string) })]
        string Role { get; set; }
        /// <summary>The user id for the static site user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The user id for the static site user.",
        SerializedName = @"userDetails",
        PossibleTypes = new [] { typeof(string) })]
        string UserDetail { get; set; }

    }
    /// StaticSiteUserInvitationRequestResource resource specific properties
    internal partial interface IStaticSiteUserInvitationRequestResourcePropertiesInternal

    {
        /// <summary>The domain name for the static site custom domain.</summary>
        string Domain { get; set; }
        /// <summary>The number of hours the sas token stays valid</summary>
        int? NumHoursToExpiration { get; set; }
        /// <summary>The identity provider for the static site user.</summary>
        string Provider { get; set; }
        /// <summary>The roles for the static site user, in free-form string format</summary>
        string Role { get; set; }
        /// <summary>The user id for the static site user.</summary>
        string UserDetail { get; set; }

    }
}
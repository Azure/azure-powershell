namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>StaticSiteUserARMResource resource specific properties</summary>
    public partial class StaticSiteUserArmResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserArmResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserArmResourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>The display name for the static site user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserArmResourcePropertiesInternal.DisplayName { get => this._displayName; set { {_displayName = value;} } }

        /// <summary>Internal Acessors for Provider</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserArmResourcePropertiesInternal.Provider { get => this._provider; set { {_provider = value;} } }

        /// <summary>Internal Acessors for UserId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteUserArmResourcePropertiesInternal.UserId { get => this._userId; set { {_userId = value;} } }

        /// <summary>Backing field for <see cref="Provider" /> property.</summary>
        private string _provider;

        /// <summary>The identity provider for the static site user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Provider { get => this._provider; }

        /// <summary>Backing field for <see cref="Role" /> property.</summary>
        private string _role;

        /// <summary>The roles for the static site user, in free-form string format</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Role { get => this._role; set => this._role = value; }

        /// <summary>Backing field for <see cref="UserId" /> property.</summary>
        private string _userId;

        /// <summary>The user id for the static site user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string UserId { get => this._userId; }

        /// <summary>Creates an new <see cref="StaticSiteUserArmResourceProperties" /> instance.</summary>
        public StaticSiteUserArmResourceProperties()
        {

        }
    }
    /// StaticSiteUserARMResource resource specific properties
    public partial interface IStaticSiteUserArmResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The display name for the static site user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The display name for the static site user.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get;  }
        /// <summary>The identity provider for the static site user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The identity provider for the static site user.",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string Provider { get;  }
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
        ReadOnly = true,
        Description = @"The user id for the static site user.",
        SerializedName = @"userId",
        PossibleTypes = new [] { typeof(string) })]
        string UserId { get;  }

    }
    /// StaticSiteUserARMResource resource specific properties
    internal partial interface IStaticSiteUserArmResourcePropertiesInternal

    {
        /// <summary>The display name for the static site user.</summary>
        string DisplayName { get; set; }
        /// <summary>The identity provider for the static site user.</summary>
        string Provider { get; set; }
        /// <summary>The roles for the static site user, in free-form string format</summary>
        string Role { get; set; }
        /// <summary>The user id for the static site user.</summary>
        string UserId { get; set; }

    }
}
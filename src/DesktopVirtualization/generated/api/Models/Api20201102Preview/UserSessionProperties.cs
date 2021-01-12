namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Extensions;

    /// <summary>Schema for UserSession properties.</summary>
    public partial class UserSessionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IUserSessionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IUserSessionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ActiveDirectoryUserName" /> property.</summary>
        private string _activeDirectoryUserName;

        /// <summary>The active directory user name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string ActiveDirectoryUserName { get => this._activeDirectoryUserName; set => this._activeDirectoryUserName = value; }

        /// <summary>Backing field for <see cref="ApplicationType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.ApplicationType? _applicationType;

        /// <summary>Application type of application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.ApplicationType? ApplicationType { get => this._applicationType; set => this._applicationType = value; }

        /// <summary>Backing field for <see cref="CreateTime" /> property.</summary>
        private global::System.DateTime? _createTime;

        /// <summary>The timestamp of the user session create.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public global::System.DateTime? CreateTime { get => this._createTime; set => this._createTime = value; }

        /// <summary>Backing field for <see cref="SessionState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionState? _sessionState;

        /// <summary>State of user session.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionState? SessionState { get => this._sessionState; set => this._sessionState = value; }

        /// <summary>Backing field for <see cref="UserPrincipalName" /> property.</summary>
        private string _userPrincipalName;

        /// <summary>The user principal name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string UserPrincipalName { get => this._userPrincipalName; set => this._userPrincipalName = value; }

        /// <summary>Creates an new <see cref="UserSessionProperties" /> instance.</summary>
        public UserSessionProperties()
        {

        }
    }
    /// Schema for UserSession properties.
    public partial interface IUserSessionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IJsonSerializable
    {
        /// <summary>The active directory user name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The active directory user name.",
        SerializedName = @"activeDirectoryUserName",
        PossibleTypes = new [] { typeof(string) })]
        string ActiveDirectoryUserName { get; set; }
        /// <summary>Application type of application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Application type of application.",
        SerializedName = @"applicationType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.ApplicationType) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.ApplicationType? ApplicationType { get; set; }
        /// <summary>The timestamp of the user session create.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The timestamp of the user session create.",
        SerializedName = @"createTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreateTime { get; set; }
        /// <summary>State of user session.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"State of user session.",
        SerializedName = @"sessionState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionState) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionState? SessionState { get; set; }
        /// <summary>The user principal name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The user principal name.",
        SerializedName = @"userPrincipalName",
        PossibleTypes = new [] { typeof(string) })]
        string UserPrincipalName { get; set; }

    }
    /// Schema for UserSession properties.
    internal partial interface IUserSessionPropertiesInternal

    {
        /// <summary>The active directory user name.</summary>
        string ActiveDirectoryUserName { get; set; }
        /// <summary>Application type of application.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.ApplicationType? ApplicationType { get; set; }
        /// <summary>The timestamp of the user session create.</summary>
        global::System.DateTime? CreateTime { get; set; }
        /// <summary>State of user session.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionState? SessionState { get; set; }
        /// <summary>The user principal name.</summary>
        string UserPrincipalName { get; set; }

    }
}
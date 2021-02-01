namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Request parameters for creating a new group.</summary>
    public partial class GroupCreateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IGroupCreateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IGroupCreateParametersInternal
    {

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>Group display name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="MailEnabled" /> property.</summary>
        private bool _mailEnabled;

        /// <summary>
        /// Whether the group is mail-enabled. Must be false. This is because only pure security groups can be created using the Graph
        /// API.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool MailEnabled { get => this._mailEnabled; }

        /// <summary>Backing field for <see cref="MailNickname" /> property.</summary>
        private string _mailNickname;

        /// <summary>Mail nickname</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string MailNickname { get => this._mailNickname; set => this._mailNickname = value; }

        /// <summary>Internal Acessors for MailEnabled</summary>
        bool Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IGroupCreateParametersInternal.MailEnabled { get => this._mailEnabled; set { {_mailEnabled = value;} } }

        /// <summary>Internal Acessors for SecurityEnabled</summary>
        bool Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IGroupCreateParametersInternal.SecurityEnabled { get => this._securityEnabled; set { {_securityEnabled = value;} } }

        /// <summary>Backing field for <see cref="SecurityEnabled" /> property.</summary>
        private bool _securityEnabled= true;

        /// <summary>
        /// Whether the group is a security group. Must be true. This is because only pure security groups can be created using the
        /// Graph API.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool SecurityEnabled { get => this._securityEnabled; }

        /// <summary>Creates an new <see cref="GroupCreateParameters" /> instance.</summary>
        public GroupCreateParameters()
        {

        }
    }
    /// Request parameters for creating a new group.
    public partial interface IGroupCreateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>
    {
        /// <summary>Group display name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Group display name",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>
        /// Whether the group is mail-enabled. Must be false. This is because only pure security groups can be created using the Graph
        /// API.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Whether the group is mail-enabled. Must be false. This is because only pure security groups can be created using the Graph API.",
        SerializedName = @"mailEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool MailEnabled { get;  }
        /// <summary>Mail nickname</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Mail nickname",
        SerializedName = @"mailNickname",
        PossibleTypes = new [] { typeof(string) })]
        string MailNickname { get; set; }
        /// <summary>
        /// Whether the group is a security group. Must be true. This is because only pure security groups can be created using the
        /// Graph API.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Description = @"Whether the group is a security group. Must be true. This is because only pure security groups can be created using the Graph API.",
        SerializedName = @"securityEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool SecurityEnabled { get;  }

    }
    /// Request parameters for creating a new group.
    internal partial interface IGroupCreateParametersInternal

    {
        /// <summary>Group display name</summary>
        string DisplayName { get; set; }
        /// <summary>
        /// Whether the group is mail-enabled. Must be false. This is because only pure security groups can be created using the Graph
        /// API.
        /// </summary>
        bool MailEnabled { get; set; }
        /// <summary>Mail nickname</summary>
        string MailNickname { get; set; }
        /// <summary>
        /// Whether the group is a security group. Must be true. This is because only pure security groups can be created using the
        /// Graph API.
        /// </summary>
        bool SecurityEnabled { get; set; }

    }
}
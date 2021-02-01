namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Active Directory group information.</summary>
    public partial class AdGroup :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAdGroup,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAdGroupInternal,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObject" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObject __directoryObject = new Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.DirectoryObject();

        /// <summary>The time at which the directory object was deleted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public global::System.DateTime? DeletionTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).DeletionTimestamp; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>The display name of the group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="Mail" /> property.</summary>
        private string _mail;

        /// <summary>The primary email address of the group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Mail { get => this._mail; set => this._mail = value; }

        /// <summary>Backing field for <see cref="MailEnabled" /> property.</summary>
        private bool? _mailEnabled;

        /// <summary>
        /// Whether the group is mail-enabled. Must be false. This is because only pure security groups can be created using the Graph
        /// API.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? MailEnabled { get => this._mailEnabled; set => this._mailEnabled = value; }

        /// <summary>Backing field for <see cref="MailNickname" /> property.</summary>
        private string _mailNickname;

        /// <summary>The mail alias for the group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string MailNickname { get => this._mailNickname; set => this._mailNickname = value; }

        /// <summary>Internal Acessors for DeletionTimestamp</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal.DeletionTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).DeletionTimestamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).DeletionTimestamp = value; }

        /// <summary>Internal Acessors for ObjectId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal.ObjectId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).ObjectId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).ObjectId = value; }

        /// <summary>The object ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string ObjectId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).ObjectId; }

        /// <summary>The object type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).ObjectType = value; }

        /// <summary>Backing field for <see cref="SecurityEnabled" /> property.</summary>
        private bool? _securityEnabled;

        /// <summary>Whether the group is security-enable.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? SecurityEnabled { get => this._securityEnabled; set => this._securityEnabled = value; }

        /// <summary>Creates an new <see cref="AdGroup" /> instance.</summary>
        public AdGroup()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__directoryObject), __directoryObject);
            await eventListener.AssertObjectIsValid(nameof(__directoryObject), __directoryObject);
        }
    }
    /// Active Directory group information.
    public partial interface IAdGroup :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObject
    {
        /// <summary>The display name of the group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The display name of the group.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>The primary email address of the group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary email address of the group.",
        SerializedName = @"mail",
        PossibleTypes = new [] { typeof(string) })]
        string Mail { get; set; }
        /// <summary>
        /// Whether the group is mail-enabled. Must be false. This is because only pure security groups can be created using the Graph
        /// API.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether the group is mail-enabled. Must be false. This is because only pure security groups can be created using the Graph API.",
        SerializedName = @"mailEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? MailEnabled { get; set; }
        /// <summary>The mail alias for the group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The mail alias for the group. ",
        SerializedName = @"mailNickname",
        PossibleTypes = new [] { typeof(string) })]
        string MailNickname { get; set; }
        /// <summary>Whether the group is security-enable.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether the group is security-enable.",
        SerializedName = @"securityEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SecurityEnabled { get; set; }

    }
    /// Active Directory group information.
    internal partial interface IAdGroupInternal :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal
    {
        /// <summary>The display name of the group.</summary>
        string DisplayName { get; set; }
        /// <summary>The primary email address of the group.</summary>
        string Mail { get; set; }
        /// <summary>
        /// Whether the group is mail-enabled. Must be false. This is because only pure security groups can be created using the Graph
        /// API.
        /// </summary>
        bool? MailEnabled { get; set; }
        /// <summary>The mail alias for the group.</summary>
        string MailNickname { get; set; }
        /// <summary>Whether the group is security-enable.</summary>
        bool? SecurityEnabled { get; set; }

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>AppRoleAssignment information.</summary>
    public partial class AppRoleAssignment :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRoleAssignment,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRoleAssignmentInternal,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObject" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObject __directoryObject = new Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.DirectoryObject();

        /// <summary>The time at which the directory object was deleted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public global::System.DateTime? DeletionTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).DeletionTimestamp; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>
        /// The role id that was assigned to the principal. This role must be declared by the target resource application resourceId
        /// in its appRoles property.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

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

        /// <summary>Backing field for <see cref="PrincipalDisplayName" /> property.</summary>
        private string _principalDisplayName;

        /// <summary>The display name of the principal that was granted the access.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string PrincipalDisplayName { get => this._principalDisplayName; set => this._principalDisplayName = value; }

        /// <summary>Backing field for <see cref="PrincipalId" /> property.</summary>
        private string _principalId;

        /// <summary>The unique identifier (objectId) for the principal being granted the access.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string PrincipalId { get => this._principalId; set => this._principalId = value; }

        /// <summary>Backing field for <see cref="PrincipalType" /> property.</summary>
        private string _principalType;

        /// <summary>
        /// The type of principal. This can either be "User", "Group" or "ServicePrincipal".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string PrincipalType { get => this._principalType; set => this._principalType = value; }

        /// <summary>Backing field for <see cref="ResourceDisplayName" /> property.</summary>
        private string _resourceDisplayName;

        /// <summary>The display name of the resource to which the assignment was made.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string ResourceDisplayName { get => this._resourceDisplayName; set => this._resourceDisplayName = value; }

        /// <summary>Backing field for <see cref="ResourceId" /> property.</summary>
        private string _resourceId;

        /// <summary>
        /// The unique identifier (objectId) for the target resource (service principal) for which the assignment was made.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string ResourceId { get => this._resourceId; set => this._resourceId = value; }

        /// <summary>Creates an new <see cref="AppRoleAssignment" /> instance.</summary>
        public AppRoleAssignment()
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
    /// AppRoleAssignment information.
    public partial interface IAppRoleAssignment :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObject
    {
        /// <summary>
        /// The role id that was assigned to the principal. This role must be declared by the target resource application resourceId
        /// in its appRoles property.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The role id that was assigned to the principal. This role must be declared by the target resource application resourceId in its appRoles property.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>The display name of the principal that was granted the access.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The display name of the principal that was granted the access.",
        SerializedName = @"principalDisplayName",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalDisplayName { get; set; }
        /// <summary>The unique identifier (objectId) for the principal being granted the access.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The unique identifier (objectId) for the principal being granted the access.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalId { get; set; }
        /// <summary>
        /// The type of principal. This can either be "User", "Group" or "ServicePrincipal".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of principal. This can either be ""User"", ""Group"" or ""ServicePrincipal"".",
        SerializedName = @"principalType",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalType { get; set; }
        /// <summary>The display name of the resource to which the assignment was made.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The display name of the resource to which the assignment was made.",
        SerializedName = @"resourceDisplayName",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceDisplayName { get; set; }
        /// <summary>
        /// The unique identifier (objectId) for the target resource (service principal) for which the assignment was made.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The unique identifier (objectId) for the target resource (service principal) for which the assignment was made.",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceId { get; set; }

    }
    /// AppRoleAssignment information.
    internal partial interface IAppRoleAssignmentInternal :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal
    {
        /// <summary>
        /// The role id that was assigned to the principal. This role must be declared by the target resource application resourceId
        /// in its appRoles property.
        /// </summary>
        string Id { get; set; }
        /// <summary>The display name of the principal that was granted the access.</summary>
        string PrincipalDisplayName { get; set; }
        /// <summary>The unique identifier (objectId) for the principal being granted the access.</summary>
        string PrincipalId { get; set; }
        /// <summary>
        /// The type of principal. This can either be "User", "Group" or "ServicePrincipal".
        /// </summary>
        string PrincipalType { get; set; }
        /// <summary>The display name of the resource to which the assignment was made.</summary>
        string ResourceDisplayName { get; set; }
        /// <summary>
        /// The unique identifier (objectId) for the target resource (service principal) for which the assignment was made.
        /// </summary>
        string ResourceId { get; set; }

    }
}
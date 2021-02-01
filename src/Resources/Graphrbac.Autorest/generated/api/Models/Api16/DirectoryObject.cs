namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Represents an Azure Active Directory object.</summary>
    public partial class DirectoryObject :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObject,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal
    {

        /// <summary>Backing field for <see cref="DeletionTimestamp" /> property.</summary>
        private global::System.DateTime? _deletionTimestamp;

        /// <summary>The time at which the directory object was deleted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public global::System.DateTime? DeletionTimestamp { get => this._deletionTimestamp; }

        /// <summary>Internal Acessors for DeletionTimestamp</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal.DeletionTimestamp { get => this._deletionTimestamp; set { {_deletionTimestamp = value;} } }

        /// <summary>Internal Acessors for ObjectId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal.ObjectId { get => this._objectId; set { {_objectId = value;} } }

        /// <summary>Backing field for <see cref="ObjectId" /> property.</summary>
        private string _objectId;

        /// <summary>The object ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string ObjectId { get => this._objectId; }

        /// <summary>Backing field for <see cref="ObjectType" /> property.</summary>
        private string _objectType;

        /// <summary>The object type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string ObjectType { get => this._objectType; set => this._objectType = value; }

        /// <summary>Creates an new <see cref="DirectoryObject" /> instance.</summary>
        public DirectoryObject()
        {

        }
    }
    /// Represents an Azure Active Directory object.
    public partial interface IDirectoryObject :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>
    {
        /// <summary>The time at which the directory object was deleted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The time at which the directory object was deleted.",
        SerializedName = @"deletionTimestamp",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? DeletionTimestamp { get;  }
        /// <summary>The object ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The object ID.",
        SerializedName = @"objectId",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectId { get;  }
        /// <summary>The object type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The object type.",
        SerializedName = @"objectType",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectType { get; set; }

    }
    /// Represents an Azure Active Directory object.
    internal partial interface IDirectoryObjectInternal

    {
        /// <summary>The time at which the directory object was deleted.</summary>
        global::System.DateTime? DeletionTimestamp { get; set; }
        /// <summary>The object ID.</summary>
        string ObjectId { get; set; }
        /// <summary>The object type.</summary>
        string ObjectType { get; set; }

    }
}
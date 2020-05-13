namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>A tag of the LegalHold of a blob container.</summary>
    public partial class TagProperty :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ITagProperty,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ITagPropertyInternal
    {

        /// <summary>Internal Acessors for ObjectIdentifier</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ITagPropertyInternal.ObjectIdentifier { get => this._objectIdentifier; set { {_objectIdentifier = value;} } }

        /// <summary>Internal Acessors for Tag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ITagPropertyInternal.Tag { get => this._tag; set { {_tag = value;} } }

        /// <summary>Internal Acessors for TenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ITagPropertyInternal.TenantId { get => this._tenantId; set { {_tenantId = value;} } }

        /// <summary>Internal Acessors for Timestamp</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ITagPropertyInternal.Timestamp { get => this._timestamp; set { {_timestamp = value;} } }

        /// <summary>Internal Acessors for Upn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ITagPropertyInternal.Upn { get => this._upn; set { {_upn = value;} } }

        /// <summary>Backing field for <see cref="ObjectIdentifier" /> property.</summary>
        private string _objectIdentifier;

        /// <summary>Returns the Object ID of the user who added the tag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ObjectIdentifier { get => this._objectIdentifier; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private string _tag;

        /// <summary>The tag value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Tag { get => this._tag; }

        /// <summary>Backing field for <see cref="TenantId" /> property.</summary>
        private string _tenantId;

        /// <summary>Returns the Tenant ID that issued the token for the user who added the tag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TenantId { get => this._tenantId; }

        /// <summary>Backing field for <see cref="Timestamp" /> property.</summary>
        private global::System.DateTime? _timestamp;

        /// <summary>Returns the date and time the tag was added.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? Timestamp { get => this._timestamp; }

        /// <summary>Backing field for <see cref="Upn" /> property.</summary>
        private string _upn;

        /// <summary>Returns the User Principal Name of the user who added the tag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Upn { get => this._upn; }

        /// <summary>Creates an new <see cref="TagProperty" /> instance.</summary>
        public TagProperty()
        {

        }
    }
    /// A tag of the LegalHold of a blob container.
    public partial interface ITagProperty :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Returns the Object ID of the user who added the tag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Returns the Object ID of the user who added the tag.",
        SerializedName = @"objectIdentifier",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectIdentifier { get;  }
        /// <summary>The tag value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The tag value.",
        SerializedName = @"tag",
        PossibleTypes = new [] { typeof(string) })]
        string Tag { get;  }
        /// <summary>Returns the Tenant ID that issued the token for the user who added the tag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Returns the Tenant ID that issued the token for the user who added the tag.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get;  }
        /// <summary>Returns the date and time the tag was added.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Returns the date and time the tag was added.",
        SerializedName = @"timestamp",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? Timestamp { get;  }
        /// <summary>Returns the User Principal Name of the user who added the tag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Returns the User Principal Name of the user who added the tag.",
        SerializedName = @"upn",
        PossibleTypes = new [] { typeof(string) })]
        string Upn { get;  }

    }
    /// A tag of the LegalHold of a blob container.
    internal partial interface ITagPropertyInternal

    {
        /// <summary>Returns the Object ID of the user who added the tag.</summary>
        string ObjectIdentifier { get; set; }
        /// <summary>The tag value.</summary>
        string Tag { get; set; }
        /// <summary>Returns the Tenant ID that issued the token for the user who added the tag.</summary>
        string TenantId { get; set; }
        /// <summary>Returns the date and time the tag was added.</summary>
        global::System.DateTime? Timestamp { get; set; }
        /// <summary>Returns the User Principal Name of the user who added the tag.</summary>
        string Upn { get; set; }

    }
}
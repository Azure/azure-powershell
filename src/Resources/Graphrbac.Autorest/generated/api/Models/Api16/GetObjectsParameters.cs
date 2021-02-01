namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Request parameters for the GetObjectsByObjectIds API.</summary>
    public partial class GetObjectsParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IGetObjectsParameters,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IGetObjectsParametersInternal
    {

        /// <summary>Backing field for <see cref="IncludeDirectoryObjectReference" /> property.</summary>
        private bool? _includeDirectoryObjectReference;

        /// <summary>If true, also searches for object IDs in the partner tenant.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? IncludeDirectoryObjectReference { get => this._includeDirectoryObjectReference; set => this._includeDirectoryObjectReference = value; }

        /// <summary>Backing field for <see cref="ObjectId" /> property.</summary>
        private string[] _objectId;

        /// <summary>The requested object IDs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string[] ObjectId { get => this._objectId; set => this._objectId = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string[] _type;

        /// <summary>The requested object types.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string[] Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="GetObjectsParameters" /> instance.</summary>
        public GetObjectsParameters()
        {

        }
    }
    /// Request parameters for the GetObjectsByObjectIds API.
    public partial interface IGetObjectsParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>
    {
        /// <summary>If true, also searches for object IDs in the partner tenant.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If true, also searches for object IDs in the partner tenant.",
        SerializedName = @"includeDirectoryObjectReferences",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IncludeDirectoryObjectReference { get; set; }
        /// <summary>The requested object IDs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The requested object IDs.",
        SerializedName = @"objectIds",
        PossibleTypes = new [] { typeof(string) })]
        string[] ObjectId { get; set; }
        /// <summary>The requested object types.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The requested object types.",
        SerializedName = @"types",
        PossibleTypes = new [] { typeof(string) })]
        string[] Type { get; set; }

    }
    /// Request parameters for the GetObjectsByObjectIds API.
    internal partial interface IGetObjectsParametersInternal

    {
        /// <summary>If true, also searches for object IDs in the partner tenant.</summary>
        bool? IncludeDirectoryObjectReference { get; set; }
        /// <summary>The requested object IDs.</summary>
        string[] ObjectId { get; set; }
        /// <summary>The requested object types.</summary>
        string[] Type { get; set; }

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>DirectoryObject list operation result.</summary>
    public partial class DirectoryObjectListResult :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectListResult,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectListResultInternal
    {

        /// <summary>Backing field for <see cref="OdataNextLink" /> property.</summary>
        private string _odataNextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string OdataNextLink { get => this._odataNextLink; set => this._odataNextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObject[] _value;

        /// <summary>A collection of DirectoryObject.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObject[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="DirectoryObjectListResult" /> instance.</summary>
        public DirectoryObjectListResult()
        {

        }
    }
    /// DirectoryObject list operation result.
    public partial interface IDirectoryObjectListResult :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URL to get the next set of results.",
        SerializedName = @"odata.nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string OdataNextLink { get; set; }
        /// <summary>A collection of DirectoryObject.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of DirectoryObject.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObject),typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRoleAssignment) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObject[] Value { get; set; }

    }
    /// DirectoryObject list operation result.
    internal partial interface IDirectoryObjectListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string OdataNextLink { get; set; }
        /// <summary>A collection of DirectoryObject.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObject[] Value { get; set; }

    }
}
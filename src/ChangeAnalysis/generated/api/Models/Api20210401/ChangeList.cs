namespace Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Extensions;

    /// <summary>The list of detected changes.</summary>
    public partial class ChangeList :
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeList,
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeListInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URI that can be used to request the next page of changes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChange[] _value;

        /// <summary>The list of changes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChange[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ChangeList" /> instance.</summary>
        public ChangeList()
        {

        }
    }
    /// The list of detected changes.
    public partial interface IChangeList :
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.IJsonSerializable
    {
        /// <summary>The URI that can be used to request the next page of changes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URI that can be used to request the next page of changes.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The list of changes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of changes.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChange) })]
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChange[] Value { get; set; }

    }
    /// The list of detected changes.
    internal partial interface IChangeListInternal

    {
        /// <summary>The URI that can be used to request the next page of changes.</summary>
        string NextLink { get; set; }
        /// <summary>The list of changes.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChange[] Value { get; set; }

    }
}
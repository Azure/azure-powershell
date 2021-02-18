namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Target compute size collection.</summary>
    public partial class TargetComputeSizeCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizeCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizeCollectionInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSize[] _value;

        /// <summary>The list of target compute sizes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSize[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="TargetComputeSizeCollection" /> instance.</summary>
        public TargetComputeSizeCollection()
        {

        }
    }
    /// Target compute size collection.
    public partial interface ITargetComputeSizeCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value of next link.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The list of target compute sizes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of target compute sizes.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSize) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSize[] Value { get; set; }

    }
    /// Target compute size collection.
    internal partial interface ITargetComputeSizeCollectionInternal

    {
        /// <summary>The value of next link.</summary>
        string NextLink { get; set; }
        /// <summary>The list of target compute sizes.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSize[] Value { get; set; }

    }
}
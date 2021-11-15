namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Required for resources collection.</summary>
    public partial class RequiredForResourcesCollection :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IRequiredForResourcesCollection,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IRequiredForResourcesCollectionInternal
    {

        /// <summary>Backing field for <see cref="SourceId" /> property.</summary>
        private string[] _sourceId;

        /// <summary>Gets or sets the list of source Ids for which the input resource is required.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string[] SourceId { get => this._sourceId; set => this._sourceId = value; }

        /// <summary>Creates an new <see cref="RequiredForResourcesCollection" /> instance.</summary>
        public RequiredForResourcesCollection()
        {

        }
    }
    /// Required for resources collection.
    public partial interface IRequiredForResourcesCollection :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the list of source Ids for which the input resource is required.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the list of source Ids for which the input resource is required.",
        SerializedName = @"sourceIds",
        PossibleTypes = new [] { typeof(string) })]
        string[] SourceId { get; set; }

    }
    /// Required for resources collection.
    internal partial interface IRequiredForResourcesCollectionInternal

    {
        /// <summary>Gets or sets the list of source Ids for which the input resource is required.</summary>
        string[] SourceId { get; set; }

    }
}
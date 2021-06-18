namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    public partial class DppTrackedResourceList :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceList,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceListInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>
        /// The uri to fetch the next page of resources. Call ListNext() fetches next page of resources.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Creates an new <see cref="DppTrackedResourceList" /> instance.</summary>
        public DppTrackedResourceList()
        {

        }
    }
    public partial interface IDppTrackedResourceList :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The uri to fetch the next page of resources. Call ListNext() fetches next page of resources.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The uri to fetch the next page of resources. Call ListNext() fetches next page of resources.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }

    }
    internal partial interface IDppTrackedResourceListInternal

    {
        /// <summary>
        /// The uri to fetch the next page of resources. Call ListNext() fetches next page of resources.
        /// </summary>
        string NextLink { get; set; }

    }
}
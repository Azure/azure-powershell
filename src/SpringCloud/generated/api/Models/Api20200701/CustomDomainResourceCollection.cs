namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>
    /// Collection compose of a custom domain resources list and a possible link for next page.
    /// </summary>
    public partial class CustomDomainResourceCollection :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICustomDomainResourceCollection,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICustomDomainResourceCollectionInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The link to next page of custom domain list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICustomDomainResource[] _value;

        /// <summary>The custom domain resources list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICustomDomainResource[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="CustomDomainResourceCollection" /> instance.</summary>
        public CustomDomainResourceCollection()
        {

        }
    }
    /// Collection compose of a custom domain resources list and a possible link for next page.
    public partial interface ICustomDomainResourceCollection :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>The link to next page of custom domain list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The link to next page of custom domain list.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The custom domain resources list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The custom domain resources list.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICustomDomainResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICustomDomainResource[] Value { get; set; }

    }
    /// Collection compose of a custom domain resources list and a possible link for next page.
    public partial interface ICustomDomainResourceCollectionInternal

    {
        /// <summary>The link to next page of custom domain list.</summary>
        string NextLink { get; set; }
        /// <summary>The custom domain resources list.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICustomDomainResource[] Value { get; set; }

    }
}
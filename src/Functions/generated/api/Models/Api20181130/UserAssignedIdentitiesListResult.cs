namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Values returned by the List operation.</summary>
    public partial class UserAssignedIdentitiesListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IUserAssignedIdentitiesListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IUserAssignedIdentitiesListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The url to get the next page of results, if any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IIdentity[] _value;

        /// <summary>The collection of userAssignedIdentities returned by the listing operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IIdentity[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="UserAssignedIdentitiesListResult" /> instance.</summary>
        public UserAssignedIdentitiesListResult()
        {

        }
    }
    /// Values returned by the List operation.
    public partial interface IUserAssignedIdentitiesListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The url to get the next page of results, if any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The url to get the next page of results, if any.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The collection of userAssignedIdentities returned by the listing operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The collection of userAssignedIdentities returned by the listing operation.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IIdentity) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IIdentity[] Value { get; set; }

    }
    /// Values returned by the List operation.
    internal partial interface IUserAssignedIdentitiesListResultInternal

    {
        /// <summary>The url to get the next page of results, if any.</summary>
        string NextLink { get; set; }
        /// <summary>The collection of userAssignedIdentities returned by the listing operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IIdentity[] Value { get; set; }

    }
}
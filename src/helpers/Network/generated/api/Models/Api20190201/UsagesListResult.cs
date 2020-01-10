namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>The list usages operation response.</summary>
    public partial class UsagesListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IUsagesListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IUsagesListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IUsage[] _value;

        /// <summary>The list network resource usages.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IUsage[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="UsagesListResult" /> instance.</summary>
        public UsagesListResult()
        {

        }
    }
    /// The list usages operation response.
    public partial interface IUsagesListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URL to get the next set of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The list network resource usages.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list network resource usages.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IUsage) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IUsage[] Value { get; set; }

    }
    /// The list usages operation response.
    internal partial interface IUsagesListResultInternal

    {
        /// <summary>URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>The list network resource usages.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IUsage[] Value { get; set; }

    }
}
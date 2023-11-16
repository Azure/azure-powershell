namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>A list of streaming jobs. Populated by a List operation.</summary>
    public partial class ClusterJobListResult :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJobListResult,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJobListResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJobListResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJob[] Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJobListResultInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to fetch the next set of streaming jobs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJob[] _value;

        /// <summary>A list of streaming jobs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJob[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="ClusterJobListResult" /> instance.</summary>
        public ClusterJobListResult()
        {

        }
    }
    /// A list of streaming jobs. Populated by a List operation.
    public partial interface IClusterJobListResult :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>The URL to fetch the next set of streaming jobs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The URL to fetch the next set of streaming jobs.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>A list of streaming jobs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A list of streaming jobs.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJob) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJob[] Value { get;  }

    }
    /// A list of streaming jobs. Populated by a List operation.
    internal partial interface IClusterJobListResultInternal

    {
        /// <summary>The URL to fetch the next set of streaming jobs.</summary>
        string NextLink { get; set; }
        /// <summary>A list of streaming jobs.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJob[] Value { get; set; }

    }
}
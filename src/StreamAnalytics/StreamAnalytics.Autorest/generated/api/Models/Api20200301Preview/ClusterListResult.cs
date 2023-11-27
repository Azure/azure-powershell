namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>A list of clusters populated by a 'list' operation.</summary>
    public partial class ClusterListResult :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterListResult,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterListResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterListResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.ICluster[] Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterListResultInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to fetch the next set of clusters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.ICluster[] _value;

        /// <summary>A list of clusters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.ICluster[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="ClusterListResult" /> instance.</summary>
        public ClusterListResult()
        {

        }
    }
    /// A list of clusters populated by a 'list' operation.
    public partial interface IClusterListResult :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>The URL to fetch the next set of clusters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The URL to fetch the next set of clusters.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>A list of clusters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A list of clusters.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.ICluster) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.ICluster[] Value { get;  }

    }
    /// A list of clusters populated by a 'list' operation.
    internal partial interface IClusterListResultInternal

    {
        /// <summary>The URL to fetch the next set of clusters.</summary>
        string NextLink { get; set; }
        /// <summary>A list of clusters.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.ICluster[] Value { get; set; }

    }
}
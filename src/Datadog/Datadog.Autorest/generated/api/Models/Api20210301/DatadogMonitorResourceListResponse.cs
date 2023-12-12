namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    /// <summary>Response of a list operation.</summary>
    public partial class DatadogMonitorResourceListResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceListResponse,
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceListResponseInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Link to the next set of results, if any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResource[] _value;

        /// <summary>Results of a list operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResource[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="DatadogMonitorResourceListResponse" /> instance.</summary>
        public DatadogMonitorResourceListResponse()
        {

        }
    }
    /// Response of a list operation.
    public partial interface IDatadogMonitorResourceListResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.IJsonSerializable
    {
        /// <summary>Link to the next set of results, if any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Link to the next set of results, if any.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>Results of a list operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Results of a list operation.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResource[] Value { get; set; }

    }
    /// Response of a list operation.
    internal partial interface IDatadogMonitorResourceListResponseInternal

    {
        /// <summary>Link to the next set of results, if any.</summary>
        string NextLink { get; set; }
        /// <summary>Results of a list operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResource[] Value { get; set; }

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Extensions;

    /// <summary>List of dashboards.</summary>
    public partial class DashboardListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to use for getting the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Portal.Origin(Microsoft.Azure.PowerShell.Cmdlets.Portal.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboard[] _value;

        /// <summary>The array of custom resource provider manifests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Portal.Origin(Microsoft.Azure.PowerShell.Cmdlets.Portal.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboard[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="DashboardListResult" /> instance.</summary>
        public DashboardListResult()
        {

        }
    }
    /// List of dashboards.
    public partial interface IDashboardListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IJsonSerializable
    {
        /// <summary>The URL to use for getting the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URL to use for getting the next set of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The array of custom resource provider manifests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The array of custom resource provider manifests.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboard) })]
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboard[] Value { get; set; }

    }
    /// List of dashboards.
    internal partial interface IDashboardListResultInternal

    {
        /// <summary>The URL to use for getting the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>The array of custom resource provider manifests.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboard[] Value { get; set; }

    }
}
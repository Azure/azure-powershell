namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>Result of alerts.</summary>
    public partial class AlertsResult :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertsResult,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertsResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertsResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlert[] Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertsResultInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>URL to get the next set of alerts results if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlert[] _value;

        /// <summary>List of alerts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlert[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="AlertsResult" /> instance.</summary>
        public AlertsResult()
        {

        }
    }
    /// Result of alerts.
    public partial interface IAlertsResult :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>URL to get the next set of alerts results if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"URL to get the next set of alerts results if there are any.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>List of alerts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of alerts.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlert) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlert[] Value { get;  }

    }
    /// Result of alerts.
    public partial interface IAlertsResultInternal

    {
        /// <summary>URL to get the next set of alerts results if there are any.</summary>
        string NextLink { get; set; }
        /// <summary>List of alerts.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlert[] Value { get; set; }

    }
}
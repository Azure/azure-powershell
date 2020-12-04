namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>Result of listing views. It contains a list of available views.</summary>
    public partial class ViewListResult :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewListResult,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewListResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewListResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IView[] Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewListResultInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The link (url) to the next page of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IView[] _value;

        /// <summary>The list of views.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IView[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="ViewListResult" /> instance.</summary>
        public ViewListResult()
        {

        }
    }
    /// Result of listing views. It contains a list of available views.
    public partial interface IViewListResult :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>The link (url) to the next page of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The link (url) to the next page of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>The list of views.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The list of views.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IView) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IView[] Value { get;  }

    }
    /// Result of listing views. It contains a list of available views.
    public partial interface IViewListResultInternal

    {
        /// <summary>The link (url) to the next page of results.</summary>
        string NextLink { get; set; }
        /// <summary>The list of views.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IView[] Value { get; set; }

    }
}
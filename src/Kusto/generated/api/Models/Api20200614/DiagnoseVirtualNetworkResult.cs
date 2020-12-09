namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    public partial class DiagnoseVirtualNetworkResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDiagnoseVirtualNetworkResult,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDiagnoseVirtualNetworkResultInternal
    {

        /// <summary>Backing field for <see cref="Finding" /> property.</summary>
        private string[] _finding;

        /// <summary>The list of network connectivity diagnostic finding</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string[] Finding { get => this._finding; set => this._finding = value; }

        /// <summary>Creates an new <see cref="DiagnoseVirtualNetworkResult" /> instance.</summary>
        public DiagnoseVirtualNetworkResult()
        {

        }
    }
    public partial interface IDiagnoseVirtualNetworkResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The list of network connectivity diagnostic finding</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of network connectivity diagnostic finding",
        SerializedName = @"findings",
        PossibleTypes = new [] { typeof(string) })]
        string[] Finding { get; set; }

    }
    internal partial interface IDiagnoseVirtualNetworkResultInternal

    {
        /// <summary>The list of network connectivity diagnostic finding</summary>
        string[] Finding { get; set; }

    }
}
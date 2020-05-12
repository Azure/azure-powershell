namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>List of available SKUs for a Kusto Cluster.</summary>
    public partial class ListResourceSkusResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IListResourceSkusResult,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IListResourceSkusResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureResourceSku[] _value;

        /// <summary>The collection of available SKUs for an existing resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureResourceSku[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ListResourceSkusResult" /> instance.</summary>
        public ListResourceSkusResult()
        {

        }
    }
    /// List of available SKUs for a Kusto Cluster.
    public partial interface IListResourceSkusResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The collection of available SKUs for an existing resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The collection of available SKUs for an existing resource.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureResourceSku) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureResourceSku[] Value { get; set; }

    }
    /// List of available SKUs for a Kusto Cluster.
    internal partial interface IListResourceSkusResultInternal

    {
        /// <summary>The collection of available SKUs for an existing resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IAzureResourceSku[] Value { get; set; }

    }
}
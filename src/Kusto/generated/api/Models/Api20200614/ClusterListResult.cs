namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>The list Kusto clusters operation response.</summary>
    public partial class ClusterListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ICluster[] _value;

        /// <summary>The list of Kusto clusters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ICluster[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ClusterListResult" /> instance.</summary>
        public ClusterListResult()
        {

        }
    }
    /// The list Kusto clusters operation response.
    public partial interface IClusterListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The list of Kusto clusters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of Kusto clusters.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ICluster) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ICluster[] Value { get; set; }

    }
    /// The list Kusto clusters operation response.
    internal partial interface IClusterListResultInternal

    {
        /// <summary>The list of Kusto clusters.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ICluster[] Value { get; set; }

    }
}
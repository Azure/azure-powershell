namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>The list Kusto data connections operation response.</summary>
    public partial class DataConnectionListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnectionListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnectionListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnection[] _value;

        /// <summary>The list of Kusto data connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnection[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="DataConnectionListResult" /> instance.</summary>
        public DataConnectionListResult()
        {

        }
    }
    /// The list Kusto data connections operation response.
    public partial interface IDataConnectionListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The list of Kusto data connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of Kusto data connections.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnection),typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventHubDataConnection),typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIotHubDataConnection),typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridDataConnection) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnection[] Value { get; set; }

    }
    /// The list Kusto data connections operation response.
    internal partial interface IDataConnectionListResultInternal

    {
        /// <summary>The list of Kusto data connections.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnection[] Value { get; set; }

    }
}
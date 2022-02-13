namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>The list Kusto database script operation response.</summary>
    public partial class ScriptListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IScriptListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IScriptListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IScript[] _value;

        /// <summary>The list of Kusto scripts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IScript[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ScriptListResult" /> instance.</summary>
        public ScriptListResult()
        {

        }
    }
    /// The list Kusto database script operation response.
    public partial interface IScriptListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The list of Kusto scripts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of Kusto scripts.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IScript) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IScript[] Value { get; set; }

    }
    /// The list Kusto database script operation response.
    internal partial interface IScriptListResultInternal

    {
        /// <summary>The list of Kusto scripts.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IScript[] Value { get; set; }

    }
}
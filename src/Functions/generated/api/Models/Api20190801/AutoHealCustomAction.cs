namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Custom action to be executed
    /// when an auto heal rule is triggered.
    /// </summary>
    public partial class AutoHealCustomAction :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealCustomAction,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealCustomActionInternal
    {

        /// <summary>Backing field for <see cref="Exe" /> property.</summary>
        private string _exe;

        /// <summary>Executable to be run.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Exe { get => this._exe; set => this._exe = value; }

        /// <summary>Backing field for <see cref="Parameter" /> property.</summary>
        private string _parameter;

        /// <summary>Parameters for the executable.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Parameter { get => this._parameter; set => this._parameter = value; }

        /// <summary>Creates an new <see cref="AutoHealCustomAction" /> instance.</summary>
        public AutoHealCustomAction()
        {

        }
    }
    /// Custom action to be executed
    /// when an auto heal rule is triggered.
    public partial interface IAutoHealCustomAction :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Executable to be run.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Executable to be run.",
        SerializedName = @"exe",
        PossibleTypes = new [] { typeof(string) })]
        string Exe { get; set; }
        /// <summary>Parameters for the executable.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Parameters for the executable.",
        SerializedName = @"parameters",
        PossibleTypes = new [] { typeof(string) })]
        string Parameter { get; set; }

    }
    /// Custom action to be executed
    /// when an auto heal rule is triggered.
    internal partial interface IAutoHealCustomActionInternal

    {
        /// <summary>Executable to be run.</summary>
        string Exe { get; set; }
        /// <summary>Parameters for the executable.</summary>
        string Parameter { get; set; }

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Diagnostics for an App Service Environment.</summary>
    public partial class HostingEnvironmentDiagnostics :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentDiagnostics,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentDiagnosticsInternal
    {

        /// <summary>Backing field for <see cref="DiagnosticsOutput" /> property.</summary>
        private string _diagnosticsOutput;

        /// <summary>Diagnostics output.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DiagnosticsOutput { get => this._diagnosticsOutput; set => this._diagnosticsOutput = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name/identifier of the diagnostics.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="HostingEnvironmentDiagnostics" /> instance.</summary>
        public HostingEnvironmentDiagnostics()
        {

        }
    }
    /// Diagnostics for an App Service Environment.
    public partial interface IHostingEnvironmentDiagnostics :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Diagnostics output.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Diagnostics output.",
        SerializedName = @"diagnosticsOutput",
        PossibleTypes = new [] { typeof(string) })]
        string DiagnosticsOutput { get; set; }
        /// <summary>Name/identifier of the diagnostics.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name/identifier of the diagnostics.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Diagnostics for an App Service Environment.
    internal partial interface IHostingEnvironmentDiagnosticsInternal

    {
        /// <summary>Diagnostics output.</summary>
        string DiagnosticsOutput { get; set; }
        /// <summary>Name/identifier of the diagnostics.</summary>
        string Name { get; set; }

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Network trace</summary>
    public partial class NetworkTrace :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkTrace,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkTraceInternal
    {

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>
        /// Detailed message of a network trace operation, e.g. error message in case of failure.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Backing field for <see cref="Path" /> property.</summary>
        private string _path;

        /// <summary>Local file path for the captured network trace file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Path { get => this._path; set => this._path = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>
        /// Current status of the network trace operation, same as Operation.Status (InProgress/Succeeded/Failed).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Status { get => this._status; set => this._status = value; }

        /// <summary>Creates an new <see cref="NetworkTrace" /> instance.</summary>
        public NetworkTrace()
        {

        }
    }
    /// Network trace
    public partial interface INetworkTrace :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Detailed message of a network trace operation, e.g. error message in case of failure.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Detailed message of a network trace operation, e.g. error message in case of failure.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>Local file path for the captured network trace file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Local file path for the captured network trace file.",
        SerializedName = @"path",
        PossibleTypes = new [] { typeof(string) })]
        string Path { get; set; }
        /// <summary>
        /// Current status of the network trace operation, same as Operation.Status (InProgress/Succeeded/Failed).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Current status of the network trace operation, same as Operation.Status (InProgress/Succeeded/Failed).",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string Status { get; set; }

    }
    /// Network trace
    internal partial interface INetworkTraceInternal

    {
        /// <summary>
        /// Detailed message of a network trace operation, e.g. error message in case of failure.
        /// </summary>
        string Message { get; set; }
        /// <summary>Local file path for the captured network trace file.</summary>
        string Path { get; set; }
        /// <summary>
        /// Current status of the network trace operation, same as Operation.Status (InProgress/Succeeded/Failed).
        /// </summary>
        string Status { get; set; }

    }
}
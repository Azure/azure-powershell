namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// The IIS handler mappings used to define which handler processes HTTP requests with certain extension.
    /// For example, it is used to configure php-cgi.exe process to handle all HTTP requests with *.php extension.
    /// </summary>
    public partial class HandlerMapping :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHandlerMapping,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHandlerMappingInternal
    {

        /// <summary>Backing field for <see cref="Argument" /> property.</summary>
        private string _argument;

        /// <summary>Command-line arguments to be passed to the script processor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Argument { get => this._argument; set => this._argument = value; }

        /// <summary>Backing field for <see cref="Extension" /> property.</summary>
        private string _extension;

        /// <summary>
        /// Requests with this extension will be handled using the specified FastCGI application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Extension { get => this._extension; set => this._extension = value; }

        /// <summary>Backing field for <see cref="ScriptProcessor" /> property.</summary>
        private string _scriptProcessor;

        /// <summary>The absolute path to the FastCGI application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ScriptProcessor { get => this._scriptProcessor; set => this._scriptProcessor = value; }

        /// <summary>Creates an new <see cref="HandlerMapping" /> instance.</summary>
        public HandlerMapping()
        {

        }
    }
    /// The IIS handler mappings used to define which handler processes HTTP requests with certain extension.
    /// For example, it is used to configure php-cgi.exe process to handle all HTTP requests with *.php extension.
    public partial interface IHandlerMapping :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Command-line arguments to be passed to the script processor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Command-line arguments to be passed to the script processor.",
        SerializedName = @"arguments",
        PossibleTypes = new [] { typeof(string) })]
        string Argument { get; set; }
        /// <summary>
        /// Requests with this extension will be handled using the specified FastCGI application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Requests with this extension will be handled using the specified FastCGI application.",
        SerializedName = @"extension",
        PossibleTypes = new [] { typeof(string) })]
        string Extension { get; set; }
        /// <summary>The absolute path to the FastCGI application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The absolute path to the FastCGI application.",
        SerializedName = @"scriptProcessor",
        PossibleTypes = new [] { typeof(string) })]
        string ScriptProcessor { get; set; }

    }
    /// The IIS handler mappings used to define which handler processes HTTP requests with certain extension.
    /// For example, it is used to configure php-cgi.exe process to handle all HTTP requests with *.php extension.
    internal partial interface IHandlerMappingInternal

    {
        /// <summary>Command-line arguments to be passed to the script processor.</summary>
        string Argument { get; set; }
        /// <summary>
        /// Requests with this extension will be handled using the specified FastCGI application.
        /// </summary>
        string Extension { get; set; }
        /// <summary>The absolute path to the FastCGI application.</summary>
        string ScriptProcessor { get; set; }

    }
}
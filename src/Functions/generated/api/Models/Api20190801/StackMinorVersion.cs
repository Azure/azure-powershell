namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Application stack minor version.</summary>
    public partial class StackMinorVersion :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMinorVersion,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMinorVersionInternal
    {

        /// <summary>Backing field for <see cref="DisplayVersion" /> property.</summary>
        private string _displayVersion;

        /// <summary>Application stack minor version (display only).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DisplayVersion { get => this._displayVersion; set => this._displayVersion = value; }

        /// <summary>Backing field for <see cref="IsDefault" /> property.</summary>
        private bool? _isDefault;

        /// <summary>
        /// <code>true</code> if this is the default minor version; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsDefault { get => this._isDefault; set => this._isDefault = value; }

        /// <summary>Backing field for <see cref="IsRemoteDebuggingEnabled" /> property.</summary>
        private bool? _isRemoteDebuggingEnabled;

        /// <summary>
        /// <code>true</code> if this supports Remote Debugging, otherwise <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsRemoteDebuggingEnabled { get => this._isRemoteDebuggingEnabled; set => this._isRemoteDebuggingEnabled = value; }

        /// <summary>Backing field for <see cref="RuntimeVersion" /> property.</summary>
        private string _runtimeVersion;

        /// <summary>Application stack minor version (runtime only).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string RuntimeVersion { get => this._runtimeVersion; set => this._runtimeVersion = value; }

        /// <summary>Creates an new <see cref="StackMinorVersion" /> instance.</summary>
        public StackMinorVersion()
        {

        }
    }
    /// Application stack minor version.
    public partial interface IStackMinorVersion :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Application stack minor version (display only).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Application stack minor version (display only).",
        SerializedName = @"displayVersion",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayVersion { get; set; }
        /// <summary>
        /// <code>true</code> if this is the default minor version; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if this is the default minor version; otherwise, <code>false</code>.",
        SerializedName = @"isDefault",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDefault { get; set; }
        /// <summary>
        /// <code>true</code> if this supports Remote Debugging, otherwise <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if this supports Remote Debugging, otherwise <code>false</code>.",
        SerializedName = @"isRemoteDebuggingEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsRemoteDebuggingEnabled { get; set; }
        /// <summary>Application stack minor version (runtime only).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Application stack minor version (runtime only).",
        SerializedName = @"runtimeVersion",
        PossibleTypes = new [] { typeof(string) })]
        string RuntimeVersion { get; set; }

    }
    /// Application stack minor version.
    internal partial interface IStackMinorVersionInternal

    {
        /// <summary>Application stack minor version (display only).</summary>
        string DisplayVersion { get; set; }
        /// <summary>
        /// <code>true</code> if this is the default minor version; otherwise, <code>false</code>.
        /// </summary>
        bool? IsDefault { get; set; }
        /// <summary>
        /// <code>true</code> if this supports Remote Debugging, otherwise <code>false</code>.
        /// </summary>
        bool? IsRemoteDebuggingEnabled { get; set; }
        /// <summary>Application stack minor version (runtime only).</summary>
        string RuntimeVersion { get; set; }

    }
}
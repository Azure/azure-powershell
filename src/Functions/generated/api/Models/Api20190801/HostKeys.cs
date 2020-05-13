namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Functions host level keys.</summary>
    public partial class HostKeys :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeys,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysInternal
    {

        /// <summary>Backing field for <see cref="FunctionKey" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysFunctionKeys _functionKey;

        /// <summary>Host level function keys.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysFunctionKeys FunctionKey { get => (this._functionKey = this._functionKey ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostKeysFunctionKeys()); set => this._functionKey = value; }

        /// <summary>Backing field for <see cref="MasterKey" /> property.</summary>
        private string _masterKey;

        /// <summary>Secret key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string MasterKey { get => this._masterKey; set => this._masterKey = value; }

        /// <summary>Backing field for <see cref="SystemKey" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysSystemKeys _systemKey;

        /// <summary>System keys.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysSystemKeys SystemKey { get => (this._systemKey = this._systemKey ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostKeysSystemKeys()); set => this._systemKey = value; }

        /// <summary>Creates an new <see cref="HostKeys" /> instance.</summary>
        public HostKeys()
        {

        }
    }
    /// Functions host level keys.
    public partial interface IHostKeys :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Host level function keys.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Host level function keys.",
        SerializedName = @"functionKeys",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysFunctionKeys) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysFunctionKeys FunctionKey { get; set; }
        /// <summary>Secret key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Secret key.",
        SerializedName = @"masterKey",
        PossibleTypes = new [] { typeof(string) })]
        string MasterKey { get; set; }
        /// <summary>System keys.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"System keys.",
        SerializedName = @"systemKeys",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysSystemKeys) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysSystemKeys SystemKey { get; set; }

    }
    /// Functions host level keys.
    internal partial interface IHostKeysInternal

    {
        /// <summary>Host level function keys.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysFunctionKeys FunctionKey { get; set; }
        /// <summary>Secret key.</summary>
        string MasterKey { get; set; }
        /// <summary>System keys.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysSystemKeys SystemKey { get; set; }

    }
}
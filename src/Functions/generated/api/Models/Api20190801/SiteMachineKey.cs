namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>MachineKey of an app.</summary>
    public partial class SiteMachineKey :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteMachineKey,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteMachineKeyInternal
    {

        /// <summary>Backing field for <see cref="Decryption" /> property.</summary>
        private string _decryption;

        /// <summary>Algorithm used for decryption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Decryption { get => this._decryption; set => this._decryption = value; }

        /// <summary>Backing field for <see cref="DecryptionKey" /> property.</summary>
        private string _decryptionKey;

        /// <summary>Decryption key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DecryptionKey { get => this._decryptionKey; set => this._decryptionKey = value; }

        /// <summary>Backing field for <see cref="Validation" /> property.</summary>
        private string _validation;

        /// <summary>MachineKey validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Validation { get => this._validation; set => this._validation = value; }

        /// <summary>Backing field for <see cref="ValidationKey" /> property.</summary>
        private string _validationKey;

        /// <summary>Validation key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ValidationKey { get => this._validationKey; set => this._validationKey = value; }

        /// <summary>Creates an new <see cref="SiteMachineKey" /> instance.</summary>
        public SiteMachineKey()
        {

        }
    }
    /// MachineKey of an app.
    public partial interface ISiteMachineKey :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Algorithm used for decryption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Algorithm used for decryption.",
        SerializedName = @"decryption",
        PossibleTypes = new [] { typeof(string) })]
        string Decryption { get; set; }
        /// <summary>Decryption key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Decryption key.",
        SerializedName = @"decryptionKey",
        PossibleTypes = new [] { typeof(string) })]
        string DecryptionKey { get; set; }
        /// <summary>MachineKey validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"MachineKey validation.",
        SerializedName = @"validation",
        PossibleTypes = new [] { typeof(string) })]
        string Validation { get; set; }
        /// <summary>Validation key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Validation key.",
        SerializedName = @"validationKey",
        PossibleTypes = new [] { typeof(string) })]
        string ValidationKey { get; set; }

    }
    /// MachineKey of an app.
    internal partial interface ISiteMachineKeyInternal

    {
        /// <summary>Algorithm used for decryption.</summary>
        string Decryption { get; set; }
        /// <summary>Decryption key.</summary>
        string DecryptionKey { get; set; }
        /// <summary>MachineKey validation.</summary>
        string Validation { get; set; }
        /// <summary>Validation key.</summary>
        string ValidationKey { get; set; }

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>FunctionSecrets resource specific properties</summary>
    public partial class FunctionSecretsProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionSecretsProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionSecretsPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Key" /> property.</summary>
        private string _key;

        /// <summary>Secret key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Key { get => this._key; set => this._key = value; }

        /// <summary>Backing field for <see cref="TriggerUrl" /> property.</summary>
        private string _triggerUrl;

        /// <summary>Trigger URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TriggerUrl { get => this._triggerUrl; set => this._triggerUrl = value; }

        /// <summary>Creates an new <see cref="FunctionSecretsProperties" /> instance.</summary>
        public FunctionSecretsProperties()
        {

        }
    }
    /// FunctionSecrets resource specific properties
    public partial interface IFunctionSecretsProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Secret key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Secret key.",
        SerializedName = @"key",
        PossibleTypes = new [] { typeof(string) })]
        string Key { get; set; }
        /// <summary>Trigger URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Trigger URL.",
        SerializedName = @"trigger_url",
        PossibleTypes = new [] { typeof(string) })]
        string TriggerUrl { get; set; }

    }
    /// FunctionSecrets resource specific properties
    internal partial interface IFunctionSecretsPropertiesInternal

    {
        /// <summary>Secret key.</summary>
        string Key { get; set; }
        /// <summary>Trigger URL.</summary>
        string TriggerUrl { get; set; }

    }
}
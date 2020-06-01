namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>HybridConnectionKey resource specific properties</summary>
    public partial class HybridConnectionKeyProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHybridConnectionKeyProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHybridConnectionKeyPropertiesInternal
    {

        /// <summary>Internal Acessors for SendKeyName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHybridConnectionKeyPropertiesInternal.SendKeyName { get => this._sendKeyName; set { {_sendKeyName = value;} } }

        /// <summary>Internal Acessors for SendKeyValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHybridConnectionKeyPropertiesInternal.SendKeyValue { get => this._sendKeyValue; set { {_sendKeyValue = value;} } }

        /// <summary>Backing field for <see cref="SendKeyName" /> property.</summary>
        private string _sendKeyName;

        /// <summary>The name of the send key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SendKeyName { get => this._sendKeyName; }

        /// <summary>Backing field for <see cref="SendKeyValue" /> property.</summary>
        private string _sendKeyValue;

        /// <summary>The value of the send key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SendKeyValue { get => this._sendKeyValue; }

        /// <summary>Creates an new <see cref="HybridConnectionKeyProperties" /> instance.</summary>
        public HybridConnectionKeyProperties()
        {

        }
    }
    /// HybridConnectionKey resource specific properties
    public partial interface IHybridConnectionKeyProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The name of the send key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the send key.",
        SerializedName = @"sendKeyName",
        PossibleTypes = new [] { typeof(string) })]
        string SendKeyName { get;  }
        /// <summary>The value of the send key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The value of the send key.",
        SerializedName = @"sendKeyValue",
        PossibleTypes = new [] { typeof(string) })]
        string SendKeyValue { get;  }

    }
    /// HybridConnectionKey resource specific properties
    internal partial interface IHybridConnectionKeyPropertiesInternal

    {
        /// <summary>The name of the send key.</summary>
        string SendKeyName { get; set; }
        /// <summary>The value of the send key.</summary>
        string SendKeyValue { get; set; }

    }
}
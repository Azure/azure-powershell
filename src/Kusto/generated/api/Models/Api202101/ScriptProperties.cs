namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>A class representing database script property.</summary>
    public partial class ScriptProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IScriptProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IScriptPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ContinueOnError" /> property.</summary>
        private bool? _continueOnError;

        /// <summary>Flag that indicates whether to continue if one of the command fails.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public bool? ContinueOnError { get => this._continueOnError; set => this._continueOnError = value; }

        /// <summary>Backing field for <see cref="ForceUpdateTag" /> property.</summary>
        private string _forceUpdateTag;

        /// <summary>A unique string. If changed the script will be applied again.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string ForceUpdateTag { get => this._forceUpdateTag; set => this._forceUpdateTag = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IScriptPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? _provisioningState;

        /// <summary>The provisioned state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="ScriptUrl" /> property.</summary>
        private string _scriptUrl;

        /// <summary>The url to the KQL script blob file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string ScriptUrl { get => this._scriptUrl; set => this._scriptUrl = value; }

        /// <summary>Backing field for <see cref="ScriptUrlSasToken" /> property.</summary>
        private string _scriptUrlSasToken;

        /// <summary>The SaS token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string ScriptUrlSasToken { get => this._scriptUrlSasToken; set => this._scriptUrlSasToken = value; }

        /// <summary>Creates an new <see cref="ScriptProperties" /> instance.</summary>
        public ScriptProperties()
        {

        }
    }
    /// A class representing database script property.
    public partial interface IScriptProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>Flag that indicates whether to continue if one of the command fails.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag that indicates whether to continue if one of the command fails.",
        SerializedName = @"continueOnErrors",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ContinueOnError { get; set; }
        /// <summary>A unique string. If changed the script will be applied again.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique string. If changed the script will be applied again.",
        SerializedName = @"forceUpdateTag",
        PossibleTypes = new [] { typeof(string) })]
        string ForceUpdateTag { get; set; }
        /// <summary>The provisioned state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioned state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>The url to the KQL script blob file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The url to the KQL script blob file.",
        SerializedName = @"scriptUrl",
        PossibleTypes = new [] { typeof(string) })]
        string ScriptUrl { get; set; }
        /// <summary>The SaS token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The SaS token.",
        SerializedName = @"scriptUrlSasToken",
        PossibleTypes = new [] { typeof(string) })]
        string ScriptUrlSasToken { get; set; }

    }
    /// A class representing database script property.
    internal partial interface IScriptPropertiesInternal

    {
        /// <summary>Flag that indicates whether to continue if one of the command fails.</summary>
        bool? ContinueOnError { get; set; }
        /// <summary>A unique string. If changed the script will be applied again.</summary>
        string ForceUpdateTag { get; set; }
        /// <summary>The provisioned state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The url to the KQL script blob file.</summary>
        string ScriptUrl { get; set; }
        /// <summary>The SaS token.</summary>
        string ScriptUrlSasToken { get; set; }

    }
}
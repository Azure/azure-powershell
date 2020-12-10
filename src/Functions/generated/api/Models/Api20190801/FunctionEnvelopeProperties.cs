namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>FunctionEnvelope resource specific properties</summary>
    public partial class FunctionEnvelopeProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopePropertiesInternal
    {

        /// <summary>Backing field for <see cref="Config" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IAny _config;

        /// <summary>Config information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IAny Config { get => (this._config = this._config ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Any()); set => this._config = value; }

        /// <summary>Backing field for <see cref="ConfigHref" /> property.</summary>
        private string _configHref;

        /// <summary>Config URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ConfigHref { get => this._configHref; set => this._configHref = value; }

        /// <summary>Backing field for <see cref="File" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopePropertiesFiles _file;

        /// <summary>File list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopePropertiesFiles File { get => (this._file = this._file ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.FunctionEnvelopePropertiesFiles()); set => this._file = value; }

        /// <summary>Backing field for <see cref="FunctionAppId" /> property.</summary>
        private string _functionAppId;

        /// <summary>Function App ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string FunctionAppId { get => this._functionAppId; set => this._functionAppId = value; }

        /// <summary>Backing field for <see cref="Href" /> property.</summary>
        private string _href;

        /// <summary>Function URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Href { get => this._href; set => this._href = value; }

        /// <summary>Backing field for <see cref="InvokeUrlTemplate" /> property.</summary>
        private string _invokeUrlTemplate;

        /// <summary>The invocation URL</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string InvokeUrlTemplate { get => this._invokeUrlTemplate; set => this._invokeUrlTemplate = value; }

        /// <summary>Backing field for <see cref="IsDisabled" /> property.</summary>
        private bool? _isDisabled;

        /// <summary>Gets or sets a value indicating whether the function is disabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsDisabled { get => this._isDisabled; set => this._isDisabled = value; }

        /// <summary>Backing field for <see cref="Language" /> property.</summary>
        private string _language;

        /// <summary>The function language</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Language { get => this._language; set => this._language = value; }

        /// <summary>Backing field for <see cref="ScriptHref" /> property.</summary>
        private string _scriptHref;

        /// <summary>Script URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ScriptHref { get => this._scriptHref; set => this._scriptHref = value; }

        /// <summary>Backing field for <see cref="ScriptRootPathHref" /> property.</summary>
        private string _scriptRootPathHref;

        /// <summary>Script root path URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ScriptRootPathHref { get => this._scriptRootPathHref; set => this._scriptRootPathHref = value; }

        /// <summary>Backing field for <see cref="SecretsFileHref" /> property.</summary>
        private string _secretsFileHref;

        /// <summary>Secrets file URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SecretsFileHref { get => this._secretsFileHref; set => this._secretsFileHref = value; }

        /// <summary>Backing field for <see cref="TestData" /> property.</summary>
        private string _testData;

        /// <summary>Test data used when testing via the Azure Portal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TestData { get => this._testData; set => this._testData = value; }

        /// <summary>Backing field for <see cref="TestDataHref" /> property.</summary>
        private string _testDataHref;

        /// <summary>Test data URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TestDataHref { get => this._testDataHref; set => this._testDataHref = value; }

        /// <summary>Creates an new <see cref="FunctionEnvelopeProperties" /> instance.</summary>
        public FunctionEnvelopeProperties()
        {

        }
    }
    /// FunctionEnvelope resource specific properties
    public partial interface IFunctionEnvelopeProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Config information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Config information.",
        SerializedName = @"config",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IAny Config { get; set; }
        /// <summary>Config URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Config URI.",
        SerializedName = @"config_href",
        PossibleTypes = new [] { typeof(string) })]
        string ConfigHref { get; set; }
        /// <summary>File list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"File list.",
        SerializedName = @"files",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopePropertiesFiles) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopePropertiesFiles File { get; set; }
        /// <summary>Function App ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Function App ID.",
        SerializedName = @"function_app_id",
        PossibleTypes = new [] { typeof(string) })]
        string FunctionAppId { get; set; }
        /// <summary>Function URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Function URI.",
        SerializedName = @"href",
        PossibleTypes = new [] { typeof(string) })]
        string Href { get; set; }
        /// <summary>The invocation URL</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The invocation URL",
        SerializedName = @"invoke_url_template",
        PossibleTypes = new [] { typeof(string) })]
        string InvokeUrlTemplate { get; set; }
        /// <summary>Gets or sets a value indicating whether the function is disabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets a value indicating whether the function is disabled",
        SerializedName = @"isDisabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDisabled { get; set; }
        /// <summary>The function language</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The function language",
        SerializedName = @"language",
        PossibleTypes = new [] { typeof(string) })]
        string Language { get; set; }
        /// <summary>Script URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Script URI.",
        SerializedName = @"script_href",
        PossibleTypes = new [] { typeof(string) })]
        string ScriptHref { get; set; }
        /// <summary>Script root path URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Script root path URI.",
        SerializedName = @"script_root_path_href",
        PossibleTypes = new [] { typeof(string) })]
        string ScriptRootPathHref { get; set; }
        /// <summary>Secrets file URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Secrets file URI.",
        SerializedName = @"secrets_file_href",
        PossibleTypes = new [] { typeof(string) })]
        string SecretsFileHref { get; set; }
        /// <summary>Test data used when testing via the Azure Portal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Test data used when testing via the Azure Portal.",
        SerializedName = @"test_data",
        PossibleTypes = new [] { typeof(string) })]
        string TestData { get; set; }
        /// <summary>Test data URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Test data URI.",
        SerializedName = @"test_data_href",
        PossibleTypes = new [] { typeof(string) })]
        string TestDataHref { get; set; }

    }
    /// FunctionEnvelope resource specific properties
    internal partial interface IFunctionEnvelopePropertiesInternal

    {
        /// <summary>Config information.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IAny Config { get; set; }
        /// <summary>Config URI.</summary>
        string ConfigHref { get; set; }
        /// <summary>File list.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopePropertiesFiles File { get; set; }
        /// <summary>Function App ID.</summary>
        string FunctionAppId { get; set; }
        /// <summary>Function URI.</summary>
        string Href { get; set; }
        /// <summary>The invocation URL</summary>
        string InvokeUrlTemplate { get; set; }
        /// <summary>Gets or sets a value indicating whether the function is disabled</summary>
        bool? IsDisabled { get; set; }
        /// <summary>The function language</summary>
        string Language { get; set; }
        /// <summary>Script URI.</summary>
        string ScriptHref { get; set; }
        /// <summary>Script root path URI.</summary>
        string ScriptRootPathHref { get; set; }
        /// <summary>Secrets file URI.</summary>
        string SecretsFileHref { get; set; }
        /// <summary>Test data used when testing via the Azure Portal.</summary>
        string TestData { get; set; }
        /// <summary>Test data URI.</summary>
        string TestDataHref { get; set; }

    }
}
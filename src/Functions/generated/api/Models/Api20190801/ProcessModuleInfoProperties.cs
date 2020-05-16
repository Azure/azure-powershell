namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>ProcessModuleInfo resource specific properties</summary>
    public partial class ProcessModuleInfoProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal
    {

        /// <summary>Backing field for <see cref="BaseAddress" /> property.</summary>
        private string _baseAddress;

        /// <summary>Base address. Used as module identifier in ARM resource URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string BaseAddress { get => this._baseAddress; set => this._baseAddress = value; }

        /// <summary>Backing field for <see cref="FileDescription" /> property.</summary>
        private string _fileDescription;

        /// <summary>File description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string FileDescription { get => this._fileDescription; set => this._fileDescription = value; }

        /// <summary>Backing field for <see cref="FileName" /> property.</summary>
        private string _fileName;

        /// <summary>File name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string FileName { get => this._fileName; set => this._fileName = value; }

        /// <summary>Backing field for <see cref="FilePath" /> property.</summary>
        private string _filePath;

        /// <summary>File path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string FilePath { get => this._filePath; set => this._filePath = value; }

        /// <summary>Backing field for <see cref="FileVersion" /> property.</summary>
        private string _fileVersion;

        /// <summary>File version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string FileVersion { get => this._fileVersion; set => this._fileVersion = value; }

        /// <summary>Backing field for <see cref="Href" /> property.</summary>
        private string _href;

        /// <summary>HRef URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Href { get => this._href; set => this._href = value; }

        /// <summary>Backing field for <see cref="IsDebug" /> property.</summary>
        private bool? _isDebug;

        /// <summary>Is debug?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsDebug { get => this._isDebug; set => this._isDebug = value; }

        /// <summary>Backing field for <see cref="Language" /> property.</summary>
        private string _language;

        /// <summary>Module language (locale).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Language { get => this._language; set => this._language = value; }

        /// <summary>Backing field for <see cref="ModuleMemorySize" /> property.</summary>
        private int? _moduleMemorySize;

        /// <summary>Module memory size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? ModuleMemorySize { get => this._moduleMemorySize; set => this._moduleMemorySize = value; }

        /// <summary>Backing field for <see cref="Product" /> property.</summary>
        private string _product;

        /// <summary>Product name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Product { get => this._product; set => this._product = value; }

        /// <summary>Backing field for <see cref="ProductVersion" /> property.</summary>
        private string _productVersion;

        /// <summary>Product version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ProductVersion { get => this._productVersion; set => this._productVersion = value; }

        /// <summary>Creates an new <see cref="ProcessModuleInfoProperties" /> instance.</summary>
        public ProcessModuleInfoProperties()
        {

        }
    }
    /// ProcessModuleInfo resource specific properties
    public partial interface IProcessModuleInfoProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Base address. Used as module identifier in ARM resource URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Base address. Used as module identifier in ARM resource URI.",
        SerializedName = @"base_address",
        PossibleTypes = new [] { typeof(string) })]
        string BaseAddress { get; set; }
        /// <summary>File description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"File description.",
        SerializedName = @"file_description",
        PossibleTypes = new [] { typeof(string) })]
        string FileDescription { get; set; }
        /// <summary>File name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"File name.",
        SerializedName = @"file_name",
        PossibleTypes = new [] { typeof(string) })]
        string FileName { get; set; }
        /// <summary>File path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"File path.",
        SerializedName = @"file_path",
        PossibleTypes = new [] { typeof(string) })]
        string FilePath { get; set; }
        /// <summary>File version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"File version.",
        SerializedName = @"file_version",
        PossibleTypes = new [] { typeof(string) })]
        string FileVersion { get; set; }
        /// <summary>HRef URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"HRef URI.",
        SerializedName = @"href",
        PossibleTypes = new [] { typeof(string) })]
        string Href { get; set; }
        /// <summary>Is debug?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Is debug?",
        SerializedName = @"is_debug",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDebug { get; set; }
        /// <summary>Module language (locale).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Module language (locale).",
        SerializedName = @"language",
        PossibleTypes = new [] { typeof(string) })]
        string Language { get; set; }
        /// <summary>Module memory size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Module memory size.",
        SerializedName = @"module_memory_size",
        PossibleTypes = new [] { typeof(int) })]
        int? ModuleMemorySize { get; set; }
        /// <summary>Product name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Product name.",
        SerializedName = @"product",
        PossibleTypes = new [] { typeof(string) })]
        string Product { get; set; }
        /// <summary>Product version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Product version.",
        SerializedName = @"product_version",
        PossibleTypes = new [] { typeof(string) })]
        string ProductVersion { get; set; }

    }
    /// ProcessModuleInfo resource specific properties
    internal partial interface IProcessModuleInfoPropertiesInternal

    {
        /// <summary>Base address. Used as module identifier in ARM resource URI.</summary>
        string BaseAddress { get; set; }
        /// <summary>File description.</summary>
        string FileDescription { get; set; }
        /// <summary>File name.</summary>
        string FileName { get; set; }
        /// <summary>File path.</summary>
        string FilePath { get; set; }
        /// <summary>File version.</summary>
        string FileVersion { get; set; }
        /// <summary>HRef URI.</summary>
        string Href { get; set; }
        /// <summary>Is debug?</summary>
        bool? IsDebug { get; set; }
        /// <summary>Module language (locale).</summary>
        string Language { get; set; }
        /// <summary>Module memory size.</summary>
        int? ModuleMemorySize { get; set; }
        /// <summary>Product name.</summary>
        string Product { get; set; }
        /// <summary>Product version.</summary>
        string ProductVersion { get; set; }

    }
}
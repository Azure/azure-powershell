namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Process Module Information.</summary>
    public partial class ProcessModuleInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfo,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Base address. Used as module identifier in ARM resource URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string BaseAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)Property).BaseAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)Property).BaseAddress = value; }

        /// <summary>File description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string FileDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)Property).FileDescription; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)Property).FileDescription = value; }

        /// <summary>File name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string FileName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)Property).FileName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)Property).FileName = value; }

        /// <summary>File path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string FilePath { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)Property).FilePath; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)Property).FilePath = value; }

        /// <summary>File version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string FileVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)Property).FileVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)Property).FileVersion = value; }

        /// <summary>HRef URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Href { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)Property).Href; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)Property).Href = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Is debug?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IsDebug { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)Property).IsDebug; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)Property).IsDebug = value; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Module language (locale).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Language { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)Property).Language; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)Property).Language = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessModuleInfoProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Module memory size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? ModuleMemorySize { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)Property).ModuleMemorySize; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)Property).ModuleMemorySize = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Product name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Product { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)Property).Product; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)Property).Product = value; }

        /// <summary>Product version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ProductVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)Property).ProductVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)Property).ProductVersion = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoProperties _property;

        /// <summary>ProcessModuleInfo resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessModuleInfoProperties()); set => this._property = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Creates an new <see cref="ProcessModuleInfo" /> instance.</summary>
        public ProcessModuleInfo()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// Process Module Information.
    public partial interface IProcessModuleInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
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
    /// Process Module Information.
    internal partial interface IProcessModuleInfoInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
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
        /// <summary>ProcessModuleInfo resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoProperties Property { get; set; }

    }
}
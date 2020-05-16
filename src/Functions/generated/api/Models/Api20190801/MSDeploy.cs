namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>MSDeploy ARM PUT information</summary>
    public partial class MSDeploy :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeploy,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>
        /// Sets the AppOffline rule while the MSDeploy operation executes.
        /// Setting is <code>false</code> by default.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? AppOffline { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreInternal)Property).AppOffline; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreInternal)Property).AppOffline = value; }

        /// <summary>SQL Connection String</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ConnectionString { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreInternal)Property).ConnectionString; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreInternal)Property).ConnectionString = value; }

        /// <summary>Database Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DbType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreInternal)Property).DbType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreInternal)Property).DbType = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCore Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.MSDeployCore()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Package URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PackageUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreInternal)Property).PackageUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreInternal)Property).PackageUri = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCore _property;

        /// <summary>Core resource properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCore Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.MSDeployCore()); set => this._property = value; }

        /// <summary>MSDeploy Parameters. Must not be set if SetParametersXmlFileUri is used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreSetParameters SetParameter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreInternal)Property).SetParameter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreInternal)Property).SetParameter = value; }

        /// <summary>URI of MSDeploy Parameters file. Must not be set if SetParameters is used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SetParametersXmlFileUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreInternal)Property).SetParametersXmlFileUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreInternal)Property).SetParametersXmlFileUri = value; }

        /// <summary>
        /// Controls whether the MSDeploy operation skips the App_Data directory.
        /// If set to <code>true</code>, the existing App_Data directory on the destination
        /// will not be deleted, and any App_Data directory in the source will be ignored.
        /// Setting is <code>false</code> by default.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? SkipAppData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreInternal)Property).SkipAppData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreInternal)Property).SkipAppData = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Creates an new <see cref="MSDeploy" /> instance.</summary>
        public MSDeploy()
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
    /// MSDeploy ARM PUT information
    public partial interface IMSDeploy :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>
        /// Sets the AppOffline rule while the MSDeploy operation executes.
        /// Setting is <code>false</code> by default.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sets the AppOffline rule while the MSDeploy operation executes.
        Setting is <code>false</code> by default.",
        SerializedName = @"appOffline",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AppOffline { get; set; }
        /// <summary>SQL Connection String</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SQL Connection String",
        SerializedName = @"connectionString",
        PossibleTypes = new [] { typeof(string) })]
        string ConnectionString { get; set; }
        /// <summary>Database Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Database Type",
        SerializedName = @"dbType",
        PossibleTypes = new [] { typeof(string) })]
        string DbType { get; set; }
        /// <summary>Package URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Package URI",
        SerializedName = @"packageUri",
        PossibleTypes = new [] { typeof(string) })]
        string PackageUri { get; set; }
        /// <summary>MSDeploy Parameters. Must not be set if SetParametersXmlFileUri is used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"MSDeploy Parameters. Must not be set if SetParametersXmlFileUri is used.",
        SerializedName = @"setParameters",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreSetParameters) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreSetParameters SetParameter { get; set; }
        /// <summary>URI of MSDeploy Parameters file. Must not be set if SetParameters is used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URI of MSDeploy Parameters file. Must not be set if SetParameters is used.",
        SerializedName = @"setParametersXmlFileUri",
        PossibleTypes = new [] { typeof(string) })]
        string SetParametersXmlFileUri { get; set; }
        /// <summary>
        /// Controls whether the MSDeploy operation skips the App_Data directory.
        /// If set to <code>true</code>, the existing App_Data directory on the destination
        /// will not be deleted, and any App_Data directory in the source will be ignored.
        /// Setting is <code>false</code> by default.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Controls whether the MSDeploy operation skips the App_Data directory.
        If set to <code>true</code>, the existing App_Data directory on the destination
        will not be deleted, and any App_Data directory in the source will be ignored.
        Setting is <code>false</code> by default.",
        SerializedName = @"skipAppData",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SkipAppData { get; set; }

    }
    /// MSDeploy ARM PUT information
    internal partial interface IMSDeployInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>
        /// Sets the AppOffline rule while the MSDeploy operation executes.
        /// Setting is <code>false</code> by default.
        /// </summary>
        bool? AppOffline { get; set; }
        /// <summary>SQL Connection String</summary>
        string ConnectionString { get; set; }
        /// <summary>Database Type</summary>
        string DbType { get; set; }
        /// <summary>Package URI</summary>
        string PackageUri { get; set; }
        /// <summary>Core resource properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCore Property { get; set; }
        /// <summary>MSDeploy Parameters. Must not be set if SetParametersXmlFileUri is used.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreSetParameters SetParameter { get; set; }
        /// <summary>URI of MSDeploy Parameters file. Must not be set if SetParameters is used.</summary>
        string SetParametersXmlFileUri { get; set; }
        /// <summary>
        /// Controls whether the MSDeploy operation skips the App_Data directory.
        /// If set to <code>true</code>, the existing App_Data directory on the destination
        /// will not be deleted, and any App_Data directory in the source will be ignored.
        /// Setting is <code>false</code> by default.
        /// </summary>
        bool? SkipAppData { get; set; }

    }
}
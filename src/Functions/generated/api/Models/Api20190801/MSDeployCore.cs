namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>MSDeploy ARM PUT core information</summary>
    public partial class MSDeployCore :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCore,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreInternal
    {

        /// <summary>Backing field for <see cref="AppOffline" /> property.</summary>
        private bool? _appOffline;

        /// <summary>
        /// Sets the AppOffline rule while the MSDeploy operation executes.
        /// Setting is <code>false</code> by default.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? AppOffline { get => this._appOffline; set => this._appOffline = value; }

        /// <summary>Backing field for <see cref="ConnectionString" /> property.</summary>
        private string _connectionString;

        /// <summary>SQL Connection String</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ConnectionString { get => this._connectionString; set => this._connectionString = value; }

        /// <summary>Backing field for <see cref="DbType" /> property.</summary>
        private string _dbType;

        /// <summary>Database Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DbType { get => this._dbType; set => this._dbType = value; }

        /// <summary>Backing field for <see cref="PackageUri" /> property.</summary>
        private string _packageUri;

        /// <summary>Package URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PackageUri { get => this._packageUri; set => this._packageUri = value; }

        /// <summary>Backing field for <see cref="SetParameter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreSetParameters _setParameter;

        /// <summary>MSDeploy Parameters. Must not be set if SetParametersXmlFileUri is used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreSetParameters SetParameter { get => (this._setParameter = this._setParameter ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.MSDeployCoreSetParameters()); set => this._setParameter = value; }

        /// <summary>Backing field for <see cref="SetParametersXmlFileUri" /> property.</summary>
        private string _setParametersXmlFileUri;

        /// <summary>URI of MSDeploy Parameters file. Must not be set if SetParameters is used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SetParametersXmlFileUri { get => this._setParametersXmlFileUri; set => this._setParametersXmlFileUri = value; }

        /// <summary>Backing field for <see cref="SkipAppData" /> property.</summary>
        private bool? _skipAppData;

        /// <summary>
        /// Controls whether the MSDeploy operation skips the App_Data directory.
        /// If set to <code>true</code>, the existing App_Data directory on the destination
        /// will not be deleted, and any App_Data directory in the source will be ignored.
        /// Setting is <code>false</code> by default.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? SkipAppData { get => this._skipAppData; set => this._skipAppData = value; }

        /// <summary>Creates an new <see cref="MSDeployCore" /> instance.</summary>
        public MSDeployCore()
        {

        }
    }
    /// MSDeploy ARM PUT core information
    public partial interface IMSDeployCore :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
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
    /// MSDeploy ARM PUT core information
    internal partial interface IMSDeployCoreInternal

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
namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Options for app content migration.</summary>
    public partial class StorageMigrationOptions :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStorageMigrationOptions,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStorageMigrationOptionsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>AzureFiles connection string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string AzurefilesConnectionString { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStorageMigrationOptionsPropertiesInternal)Property).AzurefilesConnectionString; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStorageMigrationOptionsPropertiesInternal)Property).AzurefilesConnectionString = value; }

        /// <summary>AzureFiles share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string AzurefilesShare { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStorageMigrationOptionsPropertiesInternal)Property).AzurefilesShare; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStorageMigrationOptionsPropertiesInternal)Property).AzurefilesShare = value; }

        /// <summary>
        /// <code>true</code> if the app should be read only during copy operation; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? BlockWriteAccessToSite { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStorageMigrationOptionsPropertiesInternal)Property).BlockWriteAccessToSite; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStorageMigrationOptionsPropertiesInternal)Property).BlockWriteAccessToSite = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStorageMigrationOptionsProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStorageMigrationOptionsInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StorageMigrationOptionsProperties()); set { {_property = value;} } }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStorageMigrationOptionsProperties _property;

        /// <summary>StorageMigrationOptions resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStorageMigrationOptionsProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StorageMigrationOptionsProperties()); set => this._property = value; }

        /// <summary>
        /// <code>true</code>if the app should be switched over; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? SwitchSiteAfterMigration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStorageMigrationOptionsPropertiesInternal)Property).SwitchSiteAfterMigration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStorageMigrationOptionsPropertiesInternal)Property).SwitchSiteAfterMigration = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Creates an new <see cref="StorageMigrationOptions" /> instance.</summary>
        public StorageMigrationOptions()
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
    /// Options for app content migration.
    public partial interface IStorageMigrationOptions :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>AzureFiles connection string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"AzureFiles connection string.",
        SerializedName = @"azurefilesConnectionString",
        PossibleTypes = new [] { typeof(string) })]
        string AzurefilesConnectionString { get; set; }
        /// <summary>AzureFiles share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"AzureFiles share.",
        SerializedName = @"azurefilesShare",
        PossibleTypes = new [] { typeof(string) })]
        string AzurefilesShare { get; set; }
        /// <summary>
        /// <code>true</code> if the app should be read only during copy operation; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if the app should be read only during copy operation; otherwise, <code>false</code>.",
        SerializedName = @"blockWriteAccessToSite",
        PossibleTypes = new [] { typeof(bool) })]
        bool? BlockWriteAccessToSite { get; set; }
        /// <summary>
        /// <code>true</code>if the app should be switched over; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code>if the app should be switched over; otherwise, <code>false</code>.",
        SerializedName = @"switchSiteAfterMigration",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SwitchSiteAfterMigration { get; set; }

    }
    /// Options for app content migration.
    internal partial interface IStorageMigrationOptionsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>AzureFiles connection string.</summary>
        string AzurefilesConnectionString { get; set; }
        /// <summary>AzureFiles share.</summary>
        string AzurefilesShare { get; set; }
        /// <summary>
        /// <code>true</code> if the app should be read only during copy operation; otherwise, <code>false</code>.
        /// </summary>
        bool? BlockWriteAccessToSite { get; set; }
        /// <summary>StorageMigrationOptions resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStorageMigrationOptionsProperties Property { get; set; }
        /// <summary>
        /// <code>true</code>if the app should be switched over; otherwise, <code>false</code>.
        /// </summary>
        bool? SwitchSiteAfterMigration { get; set; }

    }
}
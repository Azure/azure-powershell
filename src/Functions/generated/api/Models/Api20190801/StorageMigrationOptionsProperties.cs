namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>StorageMigrationOptions resource specific properties</summary>
    public partial class StorageMigrationOptionsProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStorageMigrationOptionsProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStorageMigrationOptionsPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AzurefilesConnectionString" /> property.</summary>
        private string _azurefilesConnectionString;

        /// <summary>AzureFiles connection string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string AzurefilesConnectionString { get => this._azurefilesConnectionString; set => this._azurefilesConnectionString = value; }

        /// <summary>Backing field for <see cref="AzurefilesShare" /> property.</summary>
        private string _azurefilesShare;

        /// <summary>AzureFiles share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string AzurefilesShare { get => this._azurefilesShare; set => this._azurefilesShare = value; }

        /// <summary>Backing field for <see cref="BlockWriteAccessToSite" /> property.</summary>
        private bool? _blockWriteAccessToSite;

        /// <summary>
        /// <code>true</code> if the app should be read only during copy operation; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? BlockWriteAccessToSite { get => this._blockWriteAccessToSite; set => this._blockWriteAccessToSite = value; }

        /// <summary>Backing field for <see cref="SwitchSiteAfterMigration" /> property.</summary>
        private bool? _switchSiteAfterMigration;

        /// <summary>
        /// <code>true</code>if the app should be switched over; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? SwitchSiteAfterMigration { get => this._switchSiteAfterMigration; set => this._switchSiteAfterMigration = value; }

        /// <summary>Creates an new <see cref="StorageMigrationOptionsProperties" /> instance.</summary>
        public StorageMigrationOptionsProperties()
        {

        }
    }
    /// StorageMigrationOptions resource specific properties
    public partial interface IStorageMigrationOptionsProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
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
    /// StorageMigrationOptions resource specific properties
    internal partial interface IStorageMigrationOptionsPropertiesInternal

    {
        /// <summary>AzureFiles connection string.</summary>
        string AzurefilesConnectionString { get; set; }
        /// <summary>AzureFiles share.</summary>
        string AzurefilesShare { get; set; }
        /// <summary>
        /// <code>true</code> if the app should be read only during copy operation; otherwise, <code>false</code>.
        /// </summary>
        bool? BlockWriteAccessToSite { get; set; }
        /// <summary>
        /// <code>true</code>if the app should be switched over; otherwise, <code>false</code>.
        /// </summary>
        bool? SwitchSiteAfterMigration { get; set; }

    }
}
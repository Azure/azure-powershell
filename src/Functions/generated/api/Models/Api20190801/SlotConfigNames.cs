namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Names for connection strings, application settings, and external Azure storage account configuration
    /// identifiers to be marked as sticky to the deployment slot and not moved during a swap operation.
    /// This is valid for all deployment slots in an app.
    /// </summary>
    public partial class SlotConfigNames :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotConfigNames,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotConfigNamesInternal
    {

        /// <summary>Backing field for <see cref="AppSettingName" /> property.</summary>
        private string[] _appSettingName;

        /// <summary>List of application settings names.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] AppSettingName { get => this._appSettingName; set => this._appSettingName = value; }

        /// <summary>Backing field for <see cref="AzureStorageConfigName" /> property.</summary>
        private string[] _azureStorageConfigName;

        /// <summary>List of external Azure storage account identifiers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] AzureStorageConfigName { get => this._azureStorageConfigName; set => this._azureStorageConfigName = value; }

        /// <summary>Backing field for <see cref="ConnectionStringName" /> property.</summary>
        private string[] _connectionStringName;

        /// <summary>List of connection string names.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] ConnectionStringName { get => this._connectionStringName; set => this._connectionStringName = value; }

        /// <summary>Creates an new <see cref="SlotConfigNames" /> instance.</summary>
        public SlotConfigNames()
        {

        }
    }
    /// Names for connection strings, application settings, and external Azure storage account configuration
    /// identifiers to be marked as sticky to the deployment slot and not moved during a swap operation.
    /// This is valid for all deployment slots in an app.
    public partial interface ISlotConfigNames :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>List of application settings names.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of application settings names.",
        SerializedName = @"appSettingNames",
        PossibleTypes = new [] { typeof(string) })]
        string[] AppSettingName { get; set; }
        /// <summary>List of external Azure storage account identifiers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of external Azure storage account identifiers.",
        SerializedName = @"azureStorageConfigNames",
        PossibleTypes = new [] { typeof(string) })]
        string[] AzureStorageConfigName { get; set; }
        /// <summary>List of connection string names.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of connection string names.",
        SerializedName = @"connectionStringNames",
        PossibleTypes = new [] { typeof(string) })]
        string[] ConnectionStringName { get; set; }

    }
    /// Names for connection strings, application settings, and external Azure storage account configuration
    /// identifiers to be marked as sticky to the deployment slot and not moved during a swap operation.
    /// This is valid for all deployment slots in an app.
    internal partial interface ISlotConfigNamesInternal

    {
        /// <summary>List of application settings names.</summary>
        string[] AppSettingName { get; set; }
        /// <summary>List of external Azure storage account identifiers.</summary>
        string[] AzureStorageConfigName { get; set; }
        /// <summary>List of connection string names.</summary>
        string[] ConnectionStringName { get; set; }

    }
}
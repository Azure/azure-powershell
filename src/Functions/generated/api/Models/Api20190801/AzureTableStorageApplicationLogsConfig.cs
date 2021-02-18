namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Application logs to Azure table storage configuration.</summary>
    public partial class AzureTableStorageApplicationLogsConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureTableStorageApplicationLogsConfig,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureTableStorageApplicationLogsConfigInternal
    {

        /// <summary>Backing field for <see cref="Level" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? _level;

        /// <summary>Log level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? Level { get => this._level; set => this._level = value; }

        /// <summary>Backing field for <see cref="SasUrl" /> property.</summary>
        private string _sasUrl;

        /// <summary>SAS URL to an Azure table with add/query/delete permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SasUrl { get => this._sasUrl; set => this._sasUrl = value; }

        /// <summary>Creates an new <see cref="AzureTableStorageApplicationLogsConfig" /> instance.</summary>
        public AzureTableStorageApplicationLogsConfig()
        {

        }
    }
    /// Application logs to Azure table storage configuration.
    public partial interface IAzureTableStorageApplicationLogsConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Log level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Log level.",
        SerializedName = @"level",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? Level { get; set; }
        /// <summary>SAS URL to an Azure table with add/query/delete permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"SAS URL to an Azure table with add/query/delete permissions.",
        SerializedName = @"sasUrl",
        PossibleTypes = new [] { typeof(string) })]
        string SasUrl { get; set; }

    }
    /// Application logs to Azure table storage configuration.
    internal partial interface IAzureTableStorageApplicationLogsConfigInternal

    {
        /// <summary>Log level.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? Level { get; set; }
        /// <summary>SAS URL to an Azure table with add/query/delete permissions.</summary>
        string SasUrl { get; set; }

    }
}
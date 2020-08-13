namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>
    /// The storage configuration provides the non-secret connection details about the customer storage account that is used to
    /// store the environment's data.
    /// </summary>
    public partial class Gen2StorageConfigurationOutput :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2StorageConfigurationOutput,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2StorageConfigurationOutputInternal
    {

        /// <summary>Backing field for <see cref="AccountName" /> property.</summary>
        private string _accountName;

        /// <summary>The name of the storage account that will hold the environment's Gen2 data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public string AccountName { get => this._accountName; set => this._accountName = value; }

        /// <summary>Creates an new <see cref="Gen2StorageConfigurationOutput" /> instance.</summary>
        public Gen2StorageConfigurationOutput()
        {

        }
    }
    /// The storage configuration provides the non-secret connection details about the customer storage account that is used to
    /// store the environment's data.
    public partial interface IGen2StorageConfigurationOutput :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable
    {
        /// <summary>The name of the storage account that will hold the environment's Gen2 data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the storage account that will hold the environment's Gen2 data.",
        SerializedName = @"accountName",
        PossibleTypes = new [] { typeof(string) })]
        string AccountName { get; set; }

    }
    /// The storage configuration provides the non-secret connection details about the customer storage account that is used to
    /// store the environment's data.
    internal partial interface IGen2StorageConfigurationOutputInternal

    {
        /// <summary>The name of the storage account that will hold the environment's Gen2 data.</summary>
        string AccountName { get; set; }

    }
}
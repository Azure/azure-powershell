namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>
    /// The storage configuration provides the non-secret connection details about the customer storage account that is used to
    /// store the environment's data.
    /// </summary>
    public partial class LongTermStorageConfigurationOutput :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermStorageConfigurationOutput,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermStorageConfigurationOutputInternal
    {

        /// <summary>Backing field for <see cref="AccountName" /> property.</summary>
        private string _accountName;

        /// <summary>
        /// The name of the storage account that will hold the environment's long term data.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public string AccountName { get => this._accountName; set => this._accountName = value; }

        /// <summary>Creates an new <see cref="LongTermStorageConfigurationOutput" /> instance.</summary>
        public LongTermStorageConfigurationOutput()
        {

        }
    }
    /// The storage configuration provides the non-secret connection details about the customer storage account that is used to
    /// store the environment's data.
    public partial interface ILongTermStorageConfigurationOutput :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The name of the storage account that will hold the environment's long term data.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the storage account that will hold the environment's long term data.",
        SerializedName = @"accountName",
        PossibleTypes = new [] { typeof(string) })]
        string AccountName { get; set; }

    }
    /// The storage configuration provides the non-secret connection details about the customer storage account that is used to
    /// store the environment's data.
    internal partial interface ILongTermStorageConfigurationOutputInternal

    {
        /// <summary>
        /// The name of the storage account that will hold the environment's long term data.
        /// </summary>
        string AccountName { get; set; }

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>
    /// The destination information for the delivery of the export. To allow access to a storage account, you must register the
    /// account's subscription with the Microsoft.CostManagementExports resource provider. This is required once per subscription.
    /// When creating an export in the Azure portal, it is done automatically, however API users need to register the subscription.
    /// For more information see https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-manager-supported-services
    /// .
    /// </summary>
    public partial class ExportDeliveryDestination :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestination,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestinationInternal
    {

        /// <summary>Backing field for <see cref="Container" /> property.</summary>
        private string _container;

        /// <summary>The name of the container where exports will be uploaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string Container { get => this._container; set => this._container = value; }

        /// <summary>Backing field for <see cref="ResourceId" /> property.</summary>
        private string _resourceId;

        /// <summary>The resource id of the storage account where exports will be delivered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string ResourceId { get => this._resourceId; set => this._resourceId = value; }

        /// <summary>Backing field for <see cref="RootFolderPath" /> property.</summary>
        private string _rootFolderPath;

        /// <summary>The name of the directory where exports will be uploaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string RootFolderPath { get => this._rootFolderPath; set => this._rootFolderPath = value; }

        /// <summary>Creates an new <see cref="ExportDeliveryDestination" /> instance.</summary>
        public ExportDeliveryDestination()
        {

        }
    }
    /// The destination information for the delivery of the export. To allow access to a storage account, you must register the
    /// account's subscription with the Microsoft.CostManagementExports resource provider. This is required once per subscription.
    /// When creating an export in the Azure portal, it is done automatically, however API users need to register the subscription.
    /// For more information see https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-manager-supported-services
    /// .
    public partial interface IExportDeliveryDestination :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>The name of the container where exports will be uploaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the container where exports will be uploaded.",
        SerializedName = @"container",
        PossibleTypes = new [] { typeof(string) })]
        string Container { get; set; }
        /// <summary>The resource id of the storage account where exports will be delivered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The resource id of the storage account where exports will be delivered.",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceId { get; set; }
        /// <summary>The name of the directory where exports will be uploaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the directory where exports will be uploaded.",
        SerializedName = @"rootFolderPath",
        PossibleTypes = new [] { typeof(string) })]
        string RootFolderPath { get; set; }

    }
    /// The destination information for the delivery of the export. To allow access to a storage account, you must register the
    /// account's subscription with the Microsoft.CostManagementExports resource provider. This is required once per subscription.
    /// When creating an export in the Azure portal, it is done automatically, however API users need to register the subscription.
    /// For more information see https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-manager-supported-services
    /// .
    public partial interface IExportDeliveryDestinationInternal

    {
        /// <summary>The name of the container where exports will be uploaded.</summary>
        string Container { get; set; }
        /// <summary>The resource id of the storage account where exports will be delivered.</summary>
        string ResourceId { get; set; }
        /// <summary>The name of the directory where exports will be uploaded.</summary>
        string RootFolderPath { get; set; }

    }
}
namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The delivery information associated with a export.</summary>
    public partial class ExportDeliveryInfo :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfo,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfoInternal
    {

        /// <summary>Backing field for <see cref="Destination" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestination _destination;

        /// <summary>Has destination for the export being delivered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestination Destination { get => (this._destination = this._destination ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDeliveryDestination()); set => this._destination = value; }

        /// <summary>The name of the container where exports will be uploaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string DestinationContainer { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestinationInternal)Destination).Container; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestinationInternal)Destination).Container = value ; }

        /// <summary>The resource id of the storage account where exports will be delivered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string DestinationResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestinationInternal)Destination).ResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestinationInternal)Destination).ResourceId = value ; }

        /// <summary>The name of the directory where exports will be uploaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string DestinationRootFolderPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestinationInternal)Destination).RootFolderPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestinationInternal)Destination).RootFolderPath = value ?? null; }

        /// <summary>Internal Acessors for Destination</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestination Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfoInternal.Destination { get => (this._destination = this._destination ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDeliveryDestination()); set { {_destination = value;} } }

        /// <summary>Creates an new <see cref="ExportDeliveryInfo" /> instance.</summary>
        public ExportDeliveryInfo()
        {

        }
    }
    /// The delivery information associated with a export.
    public partial interface IExportDeliveryInfo :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>The name of the container where exports will be uploaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the container where exports will be uploaded.",
        SerializedName = @"container",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationContainer { get; set; }
        /// <summary>The resource id of the storage account where exports will be delivered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The resource id of the storage account where exports will be delivered.",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationResourceId { get; set; }
        /// <summary>The name of the directory where exports will be uploaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the directory where exports will be uploaded.",
        SerializedName = @"rootFolderPath",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationRootFolderPath { get; set; }

    }
    /// The delivery information associated with a export.
    public partial interface IExportDeliveryInfoInternal

    {
        /// <summary>Has destination for the export being delivered.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestination Destination { get; set; }
        /// <summary>The name of the container where exports will be uploaded.</summary>
        string DestinationContainer { get; set; }
        /// <summary>The resource id of the storage account where exports will be delivered.</summary>
        string DestinationResourceId { get; set; }
        /// <summary>The name of the directory where exports will be uploaded.</summary>
        string DestinationRootFolderPath { get; set; }

    }
}
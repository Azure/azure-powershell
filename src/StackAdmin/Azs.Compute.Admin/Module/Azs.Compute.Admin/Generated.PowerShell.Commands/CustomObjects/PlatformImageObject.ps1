
class PlatformImageObject {
    # Resource properties
    [string]$Id;
    [string]$Location
    [string]$Name
    [string]$Type

    # Extended Properties
    [string]$Publisher
    [string]$Offer;
    [string]$Sku;
    [string]$Version

    # VM Extension Properties
    [Microsoft.AzureStack.Management.Compute.Admin.Models.OsDisk]$OsDisk;
    [Microsoft.AzureStack.Management.Compute.Admin.Models.DataDisk[]]$DataDisks
    [Microsoft.AzureStack.Management.Compute.Admin.Models.ImageDetails]$Details
    [Microsoft.AzureStack.Management.Compute.Admin.Models.ProvisioningState]$ProvisioningState
}

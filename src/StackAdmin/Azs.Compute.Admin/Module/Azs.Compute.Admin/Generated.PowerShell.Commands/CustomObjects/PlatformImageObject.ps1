
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
    [Object]$OsDisk;
    [Object]$DataDisks
    [Object]$Details
    [Object]$ProvisioningState
}


<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

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

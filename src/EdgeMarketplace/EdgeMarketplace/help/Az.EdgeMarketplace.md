---
Module Name: Az.EdgeMarketplace
Module Guid: accceef6-8113-453a-a31c-4f2ce57893d6
Download Help Link: https://learn.microsoft.com/powershell/module/az.edgemarketplace
Help Version: 1.0.0.0
Locale: en-US
---

# Az.EdgeMarketplace Module
## Description
Microsoft Azure PowerShell: EdgeMarketplace cmdlets

## Az.EdgeMarketplace Cmdlets
### [Get-AzEdgeMarketplaceOffer](Get-AzEdgeMarketplaceOffer.md)
Retrieves a list of all available marketplace offers for a given device.

### [Get-AzEdgeMarketplaceOfferAccessToken](Get-AzEdgeMarketplaceOfferAccessToken.md)
Retrieves the access token (SAS URL) for a disk that was previously requested via New-AzEdgeMarketplaceOfferAccessToken.

### [New-AzEdgeMarketplaceOfferAccessToken](New-AzEdgeMarketplaceOfferAccessToken.md)
Initiates an asynchronous disk creation process for a specified marketplace image and returns immediately with a 202 Accepted status.
it can poll for completion using the returned operation status URL and its result can be used to get access token using Get-AzEdgeMarketplaceOfferAccessToken.

### [Request-AzEdgeMarketplaceOfferAccessToken](Request-AzEdgeMarketplaceOfferAccessToken.md)
This cmdlet combines New-AzEdgeMarketplaceOfferAccessToken and Get-AzEdgeMarketplaceOfferAccessToken to generate access token and retrieve the final SAS token when the disk is ready-enabling clients to download marketplace images to their edge devices.


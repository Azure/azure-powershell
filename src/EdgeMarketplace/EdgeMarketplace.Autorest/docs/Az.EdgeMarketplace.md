---
Module Name: Az.EdgeMarketplace
Module Guid: 6633674a-30d3-4a3b-b8c1-2109004138d2
Download Help Link: https://learn.microsoft.com/powershell/module/az.edgemarketplace
Help Version: 1.0.0.0
Locale: en-US
---

# Az.EdgeMarketplace Module
## Description
Microsoft Azure PowerShell: EdgeMarketplace cmdlets

## Az.EdgeMarketplace Cmdlets
### [Get-AzEdgeMarketplaceOffer](Get-AzEdgeMarketplaceOffer.md)
Get a Offer

### [Get-AzEdgeMarketplaceOfferAccessToken](Get-AzEdgeMarketplaceOfferAccessToken.md)
Retrieves the access token (SAS URL) for a disk that was previously requested via New-AzEdgeMarketplaceOfferAccessToken.

### [New-AzEdgeMarketplaceOfferAccessToken](New-AzEdgeMarketplaceOfferAccessToken.md)
Initiates an asynchronous disk creation process for a specified marketplace image and returns immediately with a 202 Accepted status.
it can poll for completion using the returned operation status URL and its result can be used to get access token using Get-AzEdgeMarketplaceOfferAccessToken.

### [Request-AzEdgeMarketplaceOfferAccessToken](Request-AzEdgeMarketplaceOfferAccessToken.md)
This cmdlet combines New-AzEdgeMarketplaceOfferAccessToken and Get-AzEdgeMarketplaceOfferAccessToken to generate access token and retrieve the final SAS token when the disk is ready—enabling clients to download marketplace images to their edge devices.


## Download Instructions
After getting the Access token using [Get-AzEdgeMarketplaceOfferAccessToken](Get-AzEdgeMarketplaceOfferAccessToken.md) you can follow the below steps

### 1. Start the download 
Use `Start-BitsTransfer` to initiate the download from the access token link
```powershell 
Start-BitsTransfer -Source $downloadLink -Destination $filePath -Asynchronous -DisplayName "ALDO Download"
```

### 2. Check download status
Use `Get-BitsTransfer` to see the status of download
```powershell
Get-BitsTransfer -Name '*ALDO Download*'
```

### 3. Complete the download
Monitor the Bitstransfer job. When all jobs are in the JobState `Transferred` - please run the below command to finalize the download. Once completed, you will see the files in your destination path.
```powershell
Get-BitsTransfer | Where-Object JobState -eq 'Transferred' | Complete-BitsTransfer
```
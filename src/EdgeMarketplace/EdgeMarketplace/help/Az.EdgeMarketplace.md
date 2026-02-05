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
Get a Offer

### [Get-AzEdgeMarketplaceOfferAccessToken](Get-AzEdgeMarketplaceOfferAccessToken.md)
Get access token.

### [New-AzEdgeMarketplaceOfferAccessToken](New-AzEdgeMarketplaceOfferAccessToken.md)
A long-running resource action.

### [Request-AzEdgeMarketplaceOfferAccessToken](Request-AzEdgeMarketplaceOfferAccessToken.md)
Request Edge Marketplace Offer Access Token.

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


### Example 1: Delete an AzureCDN origin group under the AzureCDN endpoint
```powershell
Remove-AzCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -Name org001
```

Delete an AzureCDN origin group under the AzureCDN endpoint


### Example 2: Delete an AzureCDN origin group under the AzureCDN endpoint via identity
```powershell
Get-AzCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -Name org001| Remove-AzCdnOriginGroup
```

Delete an AzureCDN origin group under the AzureCDN endpoint via identity

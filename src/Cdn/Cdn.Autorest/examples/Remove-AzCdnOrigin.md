### Example 1: Delete an AzureCDN origin group under the AzureCDN endpoint
```powershell
Remove-AzCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -Name origin1
```


Delete an AzureCDN origin group under the AzureCDN endpoint


### Example 2: Delete an AzureCDN origin under the AzureCDN endpoint via identity
```powershell
Get-AzCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -Name origin1 | Remove-AzCdnOrigin
```

Delete an AzureCDN origin under the AzureCDN endpoint via identity



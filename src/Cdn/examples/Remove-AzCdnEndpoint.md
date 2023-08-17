### Example 1: Delete an AzureCDN Endpoint under the AzureCDN profile
```powershell
Remove-AzCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -Name endptest001
```

Delete an AzureCDN Endpoint under the AzureCDN profile


### Example 2: Delete an AzureCDN Endpoint under the AzureCDN profile via identity
```powershell
Get-AzCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -Name endptest001 | Remove-AzCdnEndpoint
```

Delete an AzureCDN Endpoint under the AzureCDN profile via identity

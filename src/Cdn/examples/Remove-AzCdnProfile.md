### Example 1: Delete an AzureCDN profile under the resource group
```powershell
Remove-AzCdnProfile -ResourceGroupName testps-rg-da16jm -Name cdn-001
```

Delete an AzureCDN profile under the resource group


### Example 2: Delete an AzureCDN profile under the resource group via identity
```powershell
Get-AzCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-cdn001 | Remove-AzCdnProfile
```

Delete an AzureCDN profile under the resource group
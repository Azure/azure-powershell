### Example 1: Delete an AzureFrontDoor profile under the resource group
```powershell
Remove-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6
```

Delete an AzureFrontDoor profile under the resource group

### Example 2: Delete an AzureFrontDoor profile under the resource group via identity
```powershell
Get-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 | Remove-AzFrontDoorCdnProfile
```

Delete an AzureFrontDoor profile under the resource group via identity
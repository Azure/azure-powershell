### Example 1: Delete an AzureFrontDoor route under the AzureFrontDoor profile
```powershell
Remove-AzFrontDoorCdnRoute -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001 -Name route001
```

Delete an AzureFrontDoor route under the AzureFrontDoor profile


### Example 2: Delete an AzureFrontDoor route under the AzureFrontDoor profile via identity
```powershell
Get-AzFrontDoorCdnRoute -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001 -Name route001  | Remove-AzFrontDoorCdnRoute
```

Delete an AzureFrontDoor route under the AzureFrontDoor profile via identity